using System;
using UnityEngine;

namespace Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(float projectileSpeed)
        {
            _rigidbody.velocity = transform.forward * projectileSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}