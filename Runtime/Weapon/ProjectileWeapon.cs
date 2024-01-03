using System.Numerics;
using Projectiles;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Weapon
{
    public class ProjectileWeapon : WeaponBase
    {
        [SerializeField] private ProjectileBase _projectilePrefab;
        [SerializeField] private float _projectileSpeed;


        public override void Shoot()
        {
            if (_cooldown > 0) return;
            _cooldown = _fireRate;
            
            var dir = (_aimPoint.position - _muzzle.position).normalized;
            var projectile = Instantiate(_projectilePrefab, _muzzle.position, Quaternion.LookRotation(dir, Vector3.up));
            projectile.Init(_projectileSpeed);
        }
    }
}