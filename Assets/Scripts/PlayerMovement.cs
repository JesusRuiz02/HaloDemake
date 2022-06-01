using UnityEngine.InputSystem;
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
    [SerializeField] private Animator _animator = default;
    [SerializeField] private int Xvelocity;
    [SerializeField] private int Yvelocity;
    [SerializeField] private Vector2 _move = Vector2.zero;
    [SerializeField] private Vector2 _moveInput = Vector2.zero;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        DirectionCharacter();
      _move.x = _moveInput.x;
      _move.y =  _moveInput.y;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * _speed * Time.fixedDeltaTime);
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

   /* private void Movement(int DirectionX, int DirectionY)
    {
       // transform.Translate(DirectionX * _speed, DirectionY * _speed, 0);
        transform.position += new Vector3(DirectionX * _speed * Time.deltaTime, DirectionY * _speed * Time.deltaTime, 0);
    }*/
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
