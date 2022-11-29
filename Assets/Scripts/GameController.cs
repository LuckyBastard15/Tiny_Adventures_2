using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    
    GameController() { }
    [SerializeField] private Transform[] _movePath;
    public float pathDuration;
    Vector3[] _movePoints;

    private void Awake()
    {
        int movePathLeng = _movePath.Length;
        _movePoints = new Vector3[movePathLeng];
        for (int i = 0; i < movePathLeng; i++)
        {
            _movePoints[i] = _movePath[i].position;
        }

    }
    public Vector3[] GetMovePathPoints()
    {
        return _movePoints;
    }


}
