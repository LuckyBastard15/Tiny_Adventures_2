using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camara : MonoBehaviour
{
    public Transform _target;
    public Vector3 _offset = new Vector3(0, 3, -6);
    public Vector3 _rotateOffset = new Vector3();
    public float _sensitivity;

    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
            // transform.LookAt(_target);
        }
        Move();
    }

    void FixedUpdate()
    {
        /*if (Input.GetMouseButton(0))
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");

            var newRotation = transform.rotation.eulerAngles;

            newRotation.y += rotateHorizontal * _sensitivity;
            newRotation.x += rotateVertical * _sensitivity;

            if (newRotation.y < 180 && newRotation.y > 0)
            {
                newRotation.y = Mathf.Clamp(newRotation.y, 0, 13);
            }
            else if (newRotation.y < 360 && newRotation.y > 180)
            {
                newRotation.y = Mathf.Clamp(newRotation.y, 350, 360);
            }

            if (newRotation.x < 180 && newRotation.x > 0)
            {
                newRotation.x = Mathf.Clamp(newRotation.x, 0, 10);
            }
            else if (newRotation.x < 360 && newRotation.x > 180)
            {
                newRotation.x = Mathf.Clamp(newRotation.x, 350, 360);
            }
            transform.rotation = Quaternion.Euler(newRotation.x, newRotation.y, 0);


        }
        else if (Input.GetMouseButtonUp(0))
        {
            //transform.rotation = Quaternion.Euler(0, 3, 0);
            transform.DORotate(new Vector3(0, 3, 0), 1f);
        }*/


    }
    private void Move()
    {
        
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _moveVector = Vector3.zero;
            _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
            _moveVector.y = _joystick.Vertical * _moveSpeed * Time.deltaTime;

            var newRotation = transform.rotation.eulerAngles;

            newRotation.y += _moveVector.x * _sensitivity;
            newRotation.x += _moveVector.y * _sensitivity;

            if (newRotation.y < 180 && newRotation.y > 0)
            {
                newRotation.y = Mathf.Clamp(newRotation.y, 0, 13);
            }
            else if (newRotation.y < 360 && newRotation.y > 180)
            {
                newRotation.y = Mathf.Clamp(newRotation.y, 350, 360);
            }

            if (newRotation.x < 180 && newRotation.x > 0)
            {
                newRotation.x = Mathf.Clamp(newRotation.x, 0, 10);
            }
            else if (newRotation.x < 360 && newRotation.x > 180)
            {
                newRotation.x = Mathf.Clamp(newRotation.x, 350, 360);
            }
            transform.rotation = Quaternion.Euler(newRotation.x, newRotation.y, 0);

        }


        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            transform.DORotate(new Vector3(0, 3, 0), 1f);
        }

    }
}

