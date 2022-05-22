using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour, IMoveController
{
    [SerializeField] private float _speed;
    [SerializeField] private float _roadWidth;
    private float _maxspeed = 12;

    public void Move(float horizontalAxis)
    {
        if (_speed < _maxspeed)
        {
            _speed += 0.02f;
        }

        float xoffset = - horizontalAxis * _roadWidth;
        float zoffset = _speed * Time.deltaTime;

        Vector3 position = transform.position;

        if (Mathf.Abs(position.x + xoffset) > _roadWidth / 2f)
        {
            xoffset = (_roadWidth / 2f - Mathf.Abs(position.x)) * Mathf.Sign(position.x);
        }

        position.x += xoffset;
        position.z += zoffset;

        transform.position = position;
    }
}
