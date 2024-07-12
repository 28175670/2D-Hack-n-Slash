using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static Cinemachine.DocumentationSortingAttribute;

public class Levelupdate : MonoBehaviour
{
    public static Levelupdate instance;
    [SerializeField] private TextMeshProUGUI _currentscoreText;
    private bool[] levelUpPlayed = new bool[5];

    private float _level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayerDeterminationAttack.damages = 1;
        _level = 0;
        LevelUpdateText();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        if (_level >= 10)
        {
            return;
        }

        if (_level >= 2 && _level < 4 && !levelUpPlayed[0])
        {
            AudioSFX.levelup();
            PlayerDeterminationAttack.damages += 1;
            levelUpPlayed[0] = true;
        }
        else if (_level >= 4 && _level < 6 && !levelUpPlayed[1])
        {
            AudioSFX.levelup();
            PlayerDeterminationAttack.damages += 1;
            levelUpPlayed[1] = true;
        }
        else if (_level >= 6 && _level < 8 && !levelUpPlayed[2])
        {
            AudioSFX.levelup();
            PlayerDeterminationAttack.damages += 1;
            levelUpPlayed[2] = true;
        }
        else if (_level >= 8 && _level < 10 && !levelUpPlayed[3])
        {
            AudioSFX.levelup();
            PlayerDeterminationAttack.damages += 1;
            levelUpPlayed[3] = true;
        }
    }

    public void LevelUpdate()
    {
        _level+= 0.5f;
        LevelUpdateText();
    }

    private void LevelUpdateText()
    {
        _currentscoreText.text = Mathf.Floor(_level).ToString();
    }
}
