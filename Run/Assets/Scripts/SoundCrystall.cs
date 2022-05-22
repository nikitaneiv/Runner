using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCrystall : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
