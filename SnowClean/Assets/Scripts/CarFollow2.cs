using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow2 : MoveUnit
{
    public GameObject car1;
    private float _dist;

    private bool _startGame;

    private void Start()
    {
        _startGame = false;
    }
   
    void Update()
    {
        if (_startGame)
        {
            if (car1 != null)
            {
                transform.LookAt(car1.transform.position);
                _dist = Vector3.Distance(transform.position, car1.transform.position);
            }

            if (_dist > 5f)
                transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.forward * (_moveSpeed / 2) * Time.deltaTime);
        }     
    }
    public void GameOver()
    {
        _moveSpeed = 0;
        _startGame = false;
    }

    public void StartGame()
    {
        _moveSpeed = 6;
        _startGame = true;
    }
}
