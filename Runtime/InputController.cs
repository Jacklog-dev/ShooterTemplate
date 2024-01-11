using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> OnAimChanged;
    [SerializeField] private UnityEvent OnShootTriggerd;
    [SerializeField] private UnityEvent<bool> OnOpsVisionChanged;
    [SerializeField] private UnityEvent<bool> OnShowMapChanged;
    [SerializeField] private UnityEvent<bool> OnInteractChanged;
    private bool _aim;
    private bool _opsVision;
    private bool _showMap;
    private bool _interact;

    public void OnAim(InputValue value)
    {
        if (_aim != value.isPressed)
        {
            _aim = value.isPressed;
            Debug.Log("Dispatch Aim");
            OnAimChanged?.Invoke(_aim);
            if (_aim) OnOpsVisionChanged?.Invoke(false);
        }
    }
    
    public void OnOpsVision(InputValue value)
    {
        if (value.isPressed)
        {
            _opsVision = !_opsVision;
            OnOpsVisionChanged?.Invoke(_opsVision);
        }
    }
    
    
    public void OnShowMap(InputValue value)
    {
        if (value.isPressed)
        {
            _showMap = !_showMap;
            OnShowMapChanged?.Invoke(_showMap);
        }
    }

    public void OnShoot(InputValue value)
    {
        OnShootTriggerd?.Invoke();
    }

    public void OnInteract(InputValue value)
    {
        if (_interact != value.isPressed)
        {
            _interact = value.isPressed;
            OnInteractChanged?.Invoke(_interact);
        }
    }
}
