using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreupdate : MonoBehaviour
{
    public static Scoreupdate instance;
    [SerializeField] private TextMeshProUGUI _currentscoreText;
    [SerializeField] private TextMeshProUGUI _currentscoreText2;
    [SerializeField] private TextMeshProUGUI _highscoreText;

    private int _score;
    public static int bossScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bossScore = 0;
        _currentscoreText.text = _score.ToString();
        _currentscoreText2.text = _score.ToString();
        _highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (bossScore > 11) 
        {
            bossScore = 0;
            BossSpawn.bossSpawned = false;
        }
    }
    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highscoreText.text = _score.ToString();
        }
    }
    public void UpdateScore()
    {
        bossScore++;
        _score++;
        _currentscoreText.text = _score.ToString();
        _currentscoreText2.text = _score.ToString();
        UpdateHighScore();
    }
}
