using UnityEngine;
using UnityEngine.UI;

namespace TDS.Scripts.Player
{
    public class PlayerUI : MonoBehaviour
    {
        private Slider playerHealthSlider;

        private void Awake()
        {
            // ѕопытка автоматически найти компонент Slider, если не был установлен вручную
            if (playerHealthSlider == null)
            {
                playerHealthSlider = GetComponent<Slider>();
                if (playerHealthSlider == null)
                {
                    Debug.LogError("PlayerUI: Slider component is not assigned and not found on the GameObject.");
                }
            }
        }

        public void SetSlider(Slider slider)
        {
            playerHealthSlider = slider;
        }

        public void SetMaxHealth(int health)
        {
            if (playerHealthSlider != null)
            {
                playerHealthSlider.maxValue = health;
                playerHealthSlider.value = health;
            }
            else
            {
                Debug.LogError("PlayerUI: Slider component is not assigned.");
            }
        }

        public void SetHealth(int health)
        {
            if (playerHealthSlider != null)
            {
                playerHealthSlider.value = health;
            }
            else
            {
                Debug.LogError("PlayerUI: Slider component is not assigned.");
            }
        }
    }
}
