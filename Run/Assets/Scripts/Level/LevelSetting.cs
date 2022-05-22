using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Setting", menuName ="Config/Level Setting")]
public class LevelSetting : ScriptableObject
{
    [Header("Setting")]
    [SerializeField] private float _roadLenght;
    [SerializeField] private float _minWallOffsetZ;
    [SerializeField] private float _maxWallOffsetZ;
    [SerializeField] private float _startWallOffset;

    [Header("Element Setting")]
    [SerializeField] private float _roadPartLenght;
    [SerializeField] private float _roadPartWidth;

    public float RoadLenght => _roadLenght;
    public float MinWallOffsetZ => _minWallOffsetZ;
    public float MaxWallOffsetZ => _maxWallOffsetZ;
    public float StartWallOffset =>_startWallOffset;
    public float RoadPartLenght =>_roadPartLenght;
    public float RoadPartWidht => _roadPartWidth;
}
