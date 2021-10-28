using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MoveUnit
{
    
    [SerializeField]
    private GameObject _frontSinwDrift;

    public GameObject snowDrift;
    public GameObject righrPoint;
    public GameObject leftPoint;

    [SerializeField]
    private GameObject _lose;
    [SerializeField]
    private GameObject _win;
    [SerializeField]
    private GameObject _start;

    private bool _doSnowDrifts = false;
    private bool _gameOver = false;
    private bool _startGame = false;
    private float _startTime;

    public CarFollow _carFollow;
    public CarFollow2 _carFollow2;
   

    private void Start()
    {
        _frontSinwDrift.SetActive(false);
        _win.SetActive(false);
        _lose.SetActive(false);
        _start.SetActive(true);
    }

    private void Update()
    {
        if (!_gameOver && _startGame)
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
            transform.Rotate(0, (CrossPlatformInputManager.GetAxis("Horizontal") * _rotatinSpeed * Time.deltaTime), 0);
        }
        
        if (_doSnowDrifts && !_gameOver)
            DoSnowDrifts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snow" && !_gameOver)
        {
            _doSnowDrifts = true;
            _frontSinwDrift.SetActive(true);
        }

        if(collision.gameObject.tag == "Finish")
        {
            _doSnowDrifts = false;
            _frontSinwDrift.SetActive(false);
            _gameOver = true;
            _carFollow.GameOver();
            _carFollow2.GameOver();
            _win.SetActive(true);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            _gameOver = true;
            _carFollow.GameOver();
            _carFollow2.GameOver();
            _lose.SetActive(true);
        }          
    }

    private void DoSnowDrifts()
    {
        _startTime -= Time.deltaTime;

        if (_startTime <= 0)
            {               
                Instantiate(snowDrift, righrPoint.transform.position, Quaternion.identity);
                Instantiate(snowDrift, leftPoint.transform.position, Quaternion.identity);
                _startTime = 0.4f;
            }              
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        _startGame = true;
        _start.SetActive(false);
        _carFollow.StartGame();
        _carFollow2.StartGame();
    }
}
