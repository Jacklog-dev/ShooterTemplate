using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private bool _aim;
    [SerializeField] private UnityEvent<bool> OnAimChanged;
    [SerializeField] private UnityEvent OnShootTriggerd;

    public void OnAim(InputValue value)
    {
        if (_aim != value.isPressed)
        {
            _aim = value.isPressed;
            Debug.Log("Dispatch Aim");
            OnAimChanged?.Invoke(_aim);
        }
    }

    public void OnShoot(InputValue value)
    {
        OnShootTriggerd?.Invoke();
    }
}
