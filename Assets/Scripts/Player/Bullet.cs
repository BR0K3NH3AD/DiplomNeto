using System.Collections;
using System.Collections.Generic;
using TDS.Scripts.Enemy;
using Unity.VisualScripting;
using UnityEngine;
using TDS.Scripts.LastMegaBoss;

namespace TDS.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
        private int damage = 10;

        private Transform target;
        private Rigidbody2D rb;

        public void Seek(Transform _target)
        {
            target = _target;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            MoveTowardsTarget();
        }

        private void MoveTowardsTarget()
        {
            if (target != null)
            {
                Collider2D targetCollider = target.GetComponent<Collider2D>();
                if (targetCollider != null)
                {
                    Vector2 targetCenter = targetCollider.bounds.center;
                    Vector2 direction = (targetCenter - (Vector2)transform.position).normalized;
                    rb.velocity = direction * speed;
                }
            }
        }
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (!collision.collider.CompareTag("Bullet")) // ѕровер€ем, что столкнулись не с другим снар€дом
        //    {
        //        if (collision.collider.CompareTag("Enemy"))
        //        {
        //            BaseEnemy enemyHealth = collision.collider.GetComponent<BaseEnemy>();
        //            if (enemyHealth != null)
        //            {
        //                enemyHealth.TakeDamage(damage);
        //            }
        //            Destroy(gameObject);
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }

        //        if (collision.collider.CompareTag("MegaBoss"))
        //        {
        //            MegaBoss megaBoss = collision.collider.GetComponent<MegaBoss>();
        //            if(megaBoss != null)
        //            {
        //                megaBoss.TakeDamage(damage);
        //            }
        //            Destroy(gameObject);
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.CompareTag("Bullet"))
            {
                if (collision.collider.CompareTag("Enemy"))
                {
                    BaseEnemy enemyHealth = collision.collider.GetComponent<BaseEnemy>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damage);
                    }
                }
                else if (collision.collider.CompareTag("MegaBoss"))
                {
                    MegaBoss megaBoss = collision.collider.GetComponent<MegaBoss>();
                    if (megaBoss != null)
                    {
                        megaBoss.TakeDamage(damage);
                    }
                }
                Destroy(gameObject);
            }
        }

        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }
    }
}


