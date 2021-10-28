using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCreatorToFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _point;
    
    [SerializeField]
    private float _startTime;

    void Start()
    {
        _startTime = 2f;
    }

    
    void Update()
    {
        _startTime -= Time.deltaTime;
        if(_startTime <= 0)
        {
            Vector3 currentPosition = gameObject.transform.position;
            Instantiate(_point, currentPosition, Quaternion.identity);
            _startTime = 2f;
        }
    }
}
