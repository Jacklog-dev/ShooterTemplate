using System;
using UnityEngine;

namespace Character
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] private float _aimSpeed;
        private int _targetWeight;


        public void ToogleAim(bool aim)
        {
            _targetWeight = aim ? 1 : 0;
        }

        private void Update()
        {
         //uff TODO find a better way
         if (Math.Abs(_animator.GetLayerWeight(1) - _targetWeight) > 0.01f)
         {
             _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), _targetWeight, Time.deltaTime * _aimSpeed));
         }
        }
    }
}