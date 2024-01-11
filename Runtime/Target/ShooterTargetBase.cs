using UnityEngine;
using UnityEngine.Events;

namespace Target
{
    public class ShooterTargetBase : MonoBehaviour
    {
        [SerializeField] public UnityEvent<float, Vector3> OnDamageReceived;


        public void InflictDamage(float damage, Vector3 point)
        {
            OnDamageReceived?.Invoke(damage, point);
        }
    }
}