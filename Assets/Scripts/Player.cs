using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public GameObject _gameover;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _Grab;
    [SerializeField] private Animator _playerAnimator = default;
    [SerializeField] private float _speed;
    private bool _grabed = false;


    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private Vector3 _jump;
    private bool _grounded;
        //______________________
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
        _jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    /*void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
            _playerAnimator.SetBool("RunFront", true);
        }
        else
        {
            _playerAnimator.SetBool("RunFront", false);
        }
        //---------------------------------------------

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.back);
            _playerAnimator.SetBool("RunBack", true);
        }
        else
        {
            _playerAnimator.SetBool("RunBack", false);
        }
        //---------------------------------------------------

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.left);
            _playerAnimator.SetBool("RunLeft", true);
        }
        else
        {
            _playerAnimator.SetBool("RunLeft", false);
        }
        //--------------------------------------------------------
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.right);
            _playerAnimator.SetBool("RunRight", true);
        }
        else
        {
            _playerAnimator.SetBool("RunRight", false);
        }
        //----------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.Space)&&_grounded==true)
        {
            rb.AddForce(_jump * _jumpForce, ForceMode.Impulse);
            _grounded = false;
        }
             

        if (Input.GetKeyDown(KeyCode.G))
        {
            _grabed = true;
        }
        else if(Input.GetKeyUp(KeyCode.G))
        {
            _grabed = false;
        }
        
    }*/

    void Update()
    {
        Move();
       
    }
    public void Jump()
    {
        if (_grounded == true)
        {
            rb.AddForce(_jump * _jumpForce, ForceMode.Impulse);
            _grounded = false;
        }
    }
    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            _playerAnimator.SetBool("RunFront", true);
        }

        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            _playerAnimator.SetBool("RunFront", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            _gameover.SetActive(true);
            Time.timeScale = 0;
        }
        /*if (other.CompareTag("Grab")&& _grabed == true)
        {
            _Grab.transform.DOMove(_player.position, 2f);
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Grab")&& _grabed == true)
        {
            _Grab.transform.DOMove(_player.position, 2f);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }
    }
}
