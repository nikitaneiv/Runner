using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Crystall : MonoBehaviour

{
    [SerializeField] GameObject _crystall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            _crystall.SetActive(false);
        }
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }


}
