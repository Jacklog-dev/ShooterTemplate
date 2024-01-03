using System;
using Character;
using UnityEngine;

namespace Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private LayerMask _aimColliderMask;
        [SerializeField] protected Transform _muzzle;
        [SerializeField] protected Transform _aimPoint;
        [SerializeField] private ModelController _modelController;
        [SerializeField] protected float _fireRate;
        
        protected float _cooldown;
        private bool _aim;

        private void Update()
        {
            SetAimPoint();
            if (_cooldown > 0f)
            {
                _cooldown -= Time.deltaTime;
            }
        }

        public void SetAimPoint()
        {
            if (Camera.main == null) return;
            var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f, Screen.height/2f));
            if (Physics.Raycast(ray, out var hit, 999f, _aimColliderMask))
            {
                _aimPoint.position = hit.point;
                var aimTarget = hit.point;
                if (_aim)
                {
                    _modelController.RotateToPoint(aimTarget);
                }
            }
        }

        public void ToggleAimState(bool value)
        {
            _aim = value;
        }

        public abstract void Shoot();

    }
}