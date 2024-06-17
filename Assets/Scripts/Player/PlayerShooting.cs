using TDS.Scripts.Enemy;
using UnityEngine;

namespace TDS.Scripts.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        private GameObject bulletPrefab;
        private Transform firePoint;
        private float fireSpeed;
        private int damage;
        private float lastShotTime;

        public GameObject BulletPrefab => bulletPrefab;
        public Transform FirePoint => firePoint;
        public float FireSpeed => fireSpeed;
        public int Damage => damage;

        public void Initialize(GameObject bulletPrefab, Transform firePoint, float fireSpeed, int damage)
        {
            this.bulletPrefab = bulletPrefab;
            this.firePoint = firePoint;
            this.fireSpeed = fireSpeed;
            this.damage = damage;
        }

        public void HandleShooting(Transform target)
        {
            if (target == null || bulletPrefab == null || firePoint == null) return;

            if (Time.time - lastShotTime > 1f / fireSpeed)
            {
                Shoot(target);
                lastShotTime = Time.time;
            }
        }

        private void Shoot(Transform target)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetDamage(damage);
                bullet.Seek(target);
            }
        }

        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }
    }
}
