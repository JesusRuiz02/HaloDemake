using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [Header ("Teclas") ]
    [SerializeField] private KeyCode Arriba;
    [SerializeField] private KeyCode Abajo;
    [SerializeField] private KeyCode Derecha;
    [SerializeField] private KeyCode Izquierda;

    [Header ("Otros")]
    private bool _facingRight = true;
    [SerializeField] private float _speed = 3;
    private Rigidbody2D _rigidbody2D = null;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DirectionCharacter();
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(Arriba))
        {
            Movement(0, 1);
        }
        if (Input.GetKey(Abajo))
        {
            Movement(0, -1);
        }
        if (Input.GetKey(Derecha))
        {
            Movement(1, 0);
        }
        if (Input.GetKey(Izquierda))
        {
            Movement(-1, 0);
        }
    }

    private void DirectionCharacter()
    {
        if (_rigidbody2D.velocity.x > 0 && !_facingRight)
        {
            Flip();
        }

        if (_rigidbody2D.velocity.x < 0 && _facingRight)
        {
            Flip();
        }
    }




    private void Movement( int DirectionX, int DirectionY)
    {
        transform.Translate(DirectionX * _speed, DirectionY * _speed, 0);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
