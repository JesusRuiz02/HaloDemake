using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private GameObject _playerbullet = default;
    [SerializeField] private Vector3 _mousePos  = default;
    [SerializeField] private Camera _mainCamera = default;
    [SerializeField] private bool _shooted;

    private void Start()
        {
           _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

    private void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 rotation = _mousePos - transform.position;
        float RotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,RotationZ);
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("Cambio la variable");
        Instantiate(_playerbullet, _firepoint.position, _firepoint.rotation);
    }
}
