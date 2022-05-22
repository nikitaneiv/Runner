using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _failScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Text _crystallTxt;

    private GameObject _currentScreen;


    private void Awake()
    {
        _currentScreen = _startScreen;
    }

    public void ShowStartScreen()
    {
        _currentScreen.SetActive(false);
        _startScreen.SetActive(true);
        _currentScreen = _startScreen;
    }
    public void ShowGameScreen()
    {
        _currentScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _currentScreen = _gameScreen;

    }
    public void ShowFailScreen()
    {
        _currentScreen.SetActive(false);
        _failScreen.SetActive(true);
        _currentScreen = _failScreen;
    }
    public void ShowWinScreen()
    {
        _currentScreen.SetActive(false);
        _winScreen.SetActive(true);
        _currentScreen = _winScreen;
    }

}
