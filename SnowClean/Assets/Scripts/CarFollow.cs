using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MoveUnit
{ 
    private List<GameObject> _pointsToFollow = new List<GameObject>();

    private GameObject point;
    private float dist;
    
    void Update()
    {

        if(GameObject.FindGameObjectWithTag("PointFollow") != null)
        {
            point = GameObject.FindGameObjectWithTag("PointFollow");
            _pointsToFollow.Add(point);
            transform.LookAt(point.transform.position);
            dist = Vector3.Distance(transform.position, point.transform.position);

            if (dist < 8f)
            {
                _pointsToFollow.Remove(point);              
                Destroy(point);
            }                
        }
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);       
    }

    public void GameOver()
    {
        _moveSpeed = 0;
    }

    public void StartGame()
    {
        _moveSpeed = 5;
    }
}
