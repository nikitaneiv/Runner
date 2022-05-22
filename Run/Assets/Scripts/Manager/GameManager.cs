using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Level _level;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Text _crystallText;

    private Crystall _crystallClass;
    private PlayerData _playerData;
    public Crystall crystall => _crystallClass;

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerData") == false)
        {
            _playerData = new PlayerData();
            return;
        }

        string playerDataString = PlayerPrefs.GetString("PlayerData");
        _playerData = JsonUtility.FromJson<PlayerData>(playerDataString);
    }

    private void SaveData()
    {
        string stringData = JsonUtility.ToJson(_playerData);
        PlayerPrefs.SetString("PlayerData", stringData);
    }

    private void Awake()
    {
        _level.Generate();
        _uiManager.ShowStartScreen();
        LoadData();
    }

    public void StartGame()
    {
        _level.Player.OnFinish += Win;
        _level.Player.OnDied += Dead;
        _level.Player.OnCrystall += AddCrystall;
        _level.StartGame();
        _crystallText.text = _playerData.CrystallCount.ToString();
        _uiManager.ShowGameScreen();
    }

    public void NextLevel()
    {
        _level.Generate();
        StartGame();
    }

    public void Retry()
    {
        _level.DestroyPlayer();
        _level.GeneratePlayer();
        _crystallText.text = _playerData.CrystallCount.ToString();
        StartGame();
    }


    public void Win()
    {
        _uiManager.ShowWinScreen();
        SaveData();
    }

    public void Dead()
    {
        _playerData.CrystallCount += -10;
        if (_playerData.CrystallCount < 0)
        {
            _playerData.CrystallCount = 0;
        }
        _uiManager.ShowFailScreen();
        SaveData();
    }

    public void AddCrystall()
    {
        _playerData.CrystallCount++;
        _crystallText.text = _playerData.CrystallCount.ToString();
    }
}
