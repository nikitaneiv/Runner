using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelSetting _setting;

    [Header("Prefabs")]
    [SerializeField] private GameObject _finishPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _roadPartPrefab;
    [SerializeField] private GameObject _crystallPrefab;
    [SerializeField] private GameObject _startPrefab;
    [SerializeField] private GameObject _playerPrefab;

    private List<Vector3> _wallsPosition = new List<Vector3>();

    private PlayerController _player;
   
    public PlayerController Player => _player;

    [ContextMenu("GenerateRoad")]
    public void Generate()
    {
        Clear();
        GenerateRoad();
        GenerateWall();
        GenerateCrystall();
        GeneratePlayer();
    }

    public void StartGame()
    {
        _player.IsActive = true;
    }

    private void GenerateRoad()
    {
        Vector3 localPosition = Vector3.zero;
        int partsCount = Mathf.CeilToInt(_setting.RoadLenght / _setting.RoadPartLenght);
        for (int i = 0; i < partsCount; i++)
        {
            GameObject roadPart = Instantiate(_roadPartPrefab, transform);
            roadPart.transform.localPosition = localPosition;
            localPosition.z += _setting.RoadPartLenght;
        }

        GameObject startPart = Instantiate(_startPrefab, transform);

        GameObject finishPart = Instantiate(_finishPrefab, transform);
        finishPart.transform.localPosition = localPosition;
    }

    private void GenerateWall()
    {
        float roadLenght = _setting.RoadLenght;
        float currentLenght = _setting.StartWallOffset;
        float startX = - _setting.RoadPartWidht / 2f;
        float xOffset = _setting.RoadPartWidht / 4f;
        
        while (currentLenght < roadLenght)
        {
            int intWallCount = 4;
            int intWallPositionX = UnityEngine.Random.Range(0, 4);
            if (intWallPositionX == 1)
            {
                intWallCount = 3;
            }
            if (intWallPositionX == 0)
            {
                intWallCount = 1;
            }
            for (int intWallPosition = intWallPositionX; intWallPosition < intWallCount; intWallPosition++)
            {

                    float positionX = startX + intWallPosition * xOffset;

                    Vector3 localPosition = new Vector3(positionX, 0f, currentLenght);


                    GameObject wall = Instantiate(_wallPrefab, transform);

                    wall.transform.localPosition = localPosition;

                    _wallsPosition.Add(localPosition);
            }
            

            currentLenght += UnityEngine.Random.Range(_setting.MinWallOffsetZ, _setting.MaxWallOffsetZ);

        }
    }

    private void GenerateCrystall()
    {
        int wallsPositionIndex = 0;
        Vector3 currentWall = _wallsPosition[wallsPositionIndex];
        //Vector3 currentPosition = new Vector3(0, _crystallPrefab.transform.position.y, 0);

     
        float roadLenght = _setting.RoadLenght;
        float currentLenghtCrystall = _setting.StartWallOffset / 2.55f;
        float startX = - _setting.RoadPartWidht / 2f;
        float xOffsetCrystall = _setting.RoadPartWidht / 9f;
    
        while (currentLenghtCrystall < roadLenght )
        {
            int intCrystallPositionX = UnityEngine.Random.Range(0, 8);

                float positionX = startX + intCrystallPositionX * xOffsetCrystall;

                Vector3 localPosition = new Vector3(positionX, 0.5f, currentLenghtCrystall);
                GameObject crystall = Instantiate(_crystallPrefab, transform);
                crystall.transform.localPosition = localPosition;

                currentLenghtCrystall += _setting.RoadPartWidht;
        }
        
    }
    public void GeneratePlayer()
    {
        GameObject player = Instantiate(_playerPrefab, transform);
        player.transform.localPosition = new Vector3(0f, 0f, 0f);
        _player = player.GetComponent<PlayerController>();

        _player.Initialize();
    }

    public void DestroyPlayer()
    {
        Destroy(_player.gameObject);
    }

    public void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

}
