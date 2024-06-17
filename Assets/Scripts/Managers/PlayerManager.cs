using UnityEngine;
using UnityEngine.UI;
using TDS.Scripts.UI;
using TDS.Scripts.Player;

namespace TDS.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {

        /// <summary>
        /// Getting links to player components
        /// </summary>
        private PlayerShooting playerShooting;
        private EnemyDetection enemyDetection;
        private PlayerInputSystem playerInputSystem;
        private PlayerHealth playerHealth;
        private ScoreManager scoreManager;

        /// <summary>
        /// Parametrs to settring in incpector
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private int playerMaxHealth = 100;
        [SerializeField] private float _playerMoveSpeed = 40f;

        [Header("Player Attack Settings")]
        [SerializeField] private float _initialFireSpeed = 10f;
        [SerializeField] private float _playerAttackRadius = 10f;
        [SerializeField] private int _initialDamage = 10;

        /// <summary>
        /// Prefabs
        /// </summary>
        [Header("Game Prefabs")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;

        [Header("Enemy Layer")]
        [SerializeField] private LayerMask _enemyLayerMask;

        [Header("Player UI Component")]
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private PlayerUI playerUI;

        private void Awake()
        {
            playerShooting = GetComponent<PlayerShooting>();
            enemyDetection = GetComponent<EnemyDetection>();
            playerInputSystem = GetComponent<PlayerInputSystem>();
            playerHealth = GetComponent<PlayerHealth>();
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Start()
        {
            playerShooting.Initialize(bulletPrefab, firePoint, _initialFireSpeed, _initialDamage);
            enemyDetection.Initialize(_playerAttackRadius, _enemyLayerMask);
            playerInputSystem.Initialize(_playerMoveSpeed);
            playerHealth.Initialize(playerHealthSlider, playerUI, playerMaxHealth);

            if (scoreManager != null)
            {
                scoreManager.OnScoreChange += UpdateDamage;
            }
        }

        private void Update()
        {
            Transform nearestEnemy = enemyDetection.GetNearestEnemy();
            playerShooting.HandleShooting(nearestEnemy);
        }
        private void UpdateDamage(int score)
        {
            int newDamage = _initialDamage + (score / 50);
            //Debug.Log($"New damage set is: " +  newDamage);
            playerShooting.SetDamage(newDamage);
        }

        public void AddScore(int amount)
        {
            scoreManager.AddScore(amount);
        }

        private void OnDestroy()
        {
            if (scoreManager != null)
            {
                scoreManager.OnScoreChange -= UpdateDamage;
            }
        }
    }

}

