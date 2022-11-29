using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] List<GameObject> _checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;
    private bool _checkpoint = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            vectorPoint = _player.transform.position;
        }
        if (other.CompareTag("Finish"))
        {
            _checkpoint = true;
        }
    }
    private void Update()
    {
        if(_checkpoint== true)
        {
            _player.transform.position = vectorPoint;
            StartCoroutine(WaithOnRespawn());
            _checkpoint = false;
        }
    }

    private IEnumerator WaithOnRespawn()
    {
        new WaitForSecondsRealtime(3);
        yield return(0);
    }

}
