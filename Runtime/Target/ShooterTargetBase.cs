using UnityEngine;
using UnityEngine.Events;

namespace Target
{
    public class ShooterTargetBase : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnDamageReceived;


        public void InflictDamage(float damage)
        {
            Debug.Log("inflict damage");
            OnDamageReceived?.Invoke();
        }
    }
}