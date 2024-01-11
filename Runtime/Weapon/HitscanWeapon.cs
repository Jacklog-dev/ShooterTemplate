using Target;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class HitscanWeapon : WeaponBase
    {
        [SerializeField] private UnityEvent<Vector3> HitscanHitEvent;

        public override void Shoot()
        {
            if (_cooldown > 0f) return;
            _cooldown = _fireRate;

            HitscanHitEvent?.Invoke(_currentHitPoint);
            var target = _currentTarget.GetComponent<ShooterTargetBase>();
            if (target != null)
            {
                target.InflictDamage(_damage, _currentHitPoint);
            }    
        }
    }
}