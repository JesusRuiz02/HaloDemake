using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [SerializeField] private GameObject _target = default;

    [SerializeField] private Vector2 _direction = default;

    [SerializeField] private bool detected = false;

    [SerializeField] private float _fireRate = default;

    private float NextTimeToshoot = 0;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private Transform _firePoint = default;

    [SerializeField] private float _force = default;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy");
    }
    void Update()
    {
        Vector2 targetPos = _target.transform.position;

        _direction = targetPos - (Vector2)transform.position;


        if (detected)
        {
            if (Time.time > NextTimeToshoot)
            {
                NextTimeToshoot = Time.time + 1 / _fireRate;
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            detected = false;
        }
    }

    private void Shoot()
    {
         GameObject Bullet  = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody2D>().AddForce(_direction * _force);
    }
}
