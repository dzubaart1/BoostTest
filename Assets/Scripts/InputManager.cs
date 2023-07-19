using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PlayerFire _playerFire;
    
    private PlayerInput _playerInput;
    private PlayerInput.PlayerActions _playerActions;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerActions = _playerInput.Player;
    }

    private void Update()
    {
        if (_playerActions.Fire.triggered)
        {
            _playerFire.Fire();
        }
    }

    private void LateUpdate()
    {
        _playerRotation.Look(_playerActions.Rotation.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
