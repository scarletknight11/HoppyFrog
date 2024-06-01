using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private TMP_Text _scoreText;
    private TMP_Text _lifeText;
    private int _currentScore;
    private int _currentLife = 3;
    public GameObject canvas;
    public static GameManager manager;

    // Start is called before the first frame update
    void Awake()
    {
        if (manager == null) {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }  else if (manager != this) {
            Destroy(gameObject);
        }   
    }

    void Start() {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        _lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_scoreText == null) {
              _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
             UpdateScore();
        }   

        if (_lifeText == null) {
             _lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
             UpdateLife();
        } 
    }

    void UpdateScore() {
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

    public void AddScore(int points) {
       _currentScore += points;
       UpdateScore(); 
    }

    void UpdateLife() {
        _lifeText.text = "Life: " + _currentLife.ToString();
        if (_currentLife <= 0) {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }

    public void TakeLife(int lifebar) {
        _currentLife -= lifebar;
        UpdateLife();
    }
}
