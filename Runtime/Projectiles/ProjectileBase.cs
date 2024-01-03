using System;
using Target;
using UnityEngine;

namespace Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _damage;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(float projectileSpeed, float damage)
        {
            _damage = damage;
            _rigidbody.velocity = transform.forward * projectileSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<ShooterTargetBase>();
            if (target != null)
            {
                target.InflictDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}