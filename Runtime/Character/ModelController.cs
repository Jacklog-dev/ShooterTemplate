using UnityEngine;

namespace Character
{
    public class ModelController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _turnSpeed;
        

        public void RotateToPoint(Vector3 point)
        {
            var position = _target.position;
            point.y = position.y;
            var direction = (point - position).normalized;
            _target.forward = Vector3.Lerp(_target.forward, direction, Time.deltaTime * _turnSpeed);
        }
    }
}