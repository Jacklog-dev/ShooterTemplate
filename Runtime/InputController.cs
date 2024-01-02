using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private bool _aim;
    [SerializeField] private UnityEvent<bool> OnAimChanged;

    public void OnAim(InputValue value)
    {
        Debug.Log("Aim");
        if (_aim != value.isPressed)
        {
            _aim = value.isPressed;
            Debug.Log("Dispatch Aim");
            OnAimChanged?.Invoke(_aim);
        }
    }
}
