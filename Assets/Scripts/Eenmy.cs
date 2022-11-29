using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Eenmy : MonoBehaviour
{
    [SerializeField] 
    private GameObject _gameover;
    [SerializeField]
    private Transform _player;
    private Transform _Grab;

    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _playerAnimator = default;

    private int _waypointIndex = 0;
    

    private void Start()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
        transform.position = _wayPoints[_waypointIndex].transform.position;
    }
    private void Update()
    {
        StartCoroutine(DoMovePath());
    }
    private IEnumerator DoMovePath()
    { 
        if(_waypointIndex <= _wayPoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_waypointIndex].transform.position, _speed * Time.deltaTime);
            this.transform.LookAt(_wayPoints[_waypointIndex]);

            if (transform.position == _wayPoints[_waypointIndex].transform.position)
            {
                _waypointIndex += 1;
            }
        }
        if (_waypointIndex >= _wayPoints.Length)
        {
            _waypointIndex = 0;
        }
        yield return new WaitForSecondsRealtime(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_gameover.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.DOLookAt(_player.position, 1f);
            StopCoroutine(DoMovePath());
            this.transform.DOMove(_player.position,6f);
            _playerAnimator.SetBool("Bite", true);
        }
        else
        {
            //_playerAnimator.SetBool("Bite", false);

        }

        if (other.CompareTag("Player2"))
        {
            this.transform.DOLookAt(_player.position, 1f);
            StopCoroutine(DoMovePath());
            this.transform.DOMove(_player.position, 6f);
        }
        
        if (other.CompareTag("Player3"))
        {
            this.transform.DOLookAt(_player.position, 1f);
            StopCoroutine(DoMovePath());
            this.transform.DOMove(_player.position, 6f);
        }
        
    }
}
