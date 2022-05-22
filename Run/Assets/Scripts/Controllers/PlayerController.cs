using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private ParticleSystem _particleSystem;
    private IInputHandler _inputHandler;
    private IMoveController _moveController;

    public event Action OnDied;
    public event Action OnFinish;
    public event Action OnCrystall;
    
    private bool _isActive = false;
    
   

    public bool IsActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            if (value == true) _animatorController.SetRunTrigger();
            _isActive = value;
        }
    }

    public void Update()
    {
        if(IsActive != true) return;
        _moveController.Move(_inputHandler.GetInputHandler());
    }

    public void Initialize()
    {
        _inputHandler = GetComponent<IInputHandler>();
        _moveController = GetComponent<IMoveController>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Crystall")
        {
            OnCrystall?.Invoke();
        }
        

        if (other.gameObject.tag == "Wall")
        {
            _particleSystem.Stop();
            _particleSystem.Play();
            Died();
        }

        if (other.gameObject.tag == "Finish")
        {
            Win();
        }
    }

    private void Died()
    {
        _animatorController.SetFallTrigger();
        IsActive = false;
        OnDied?.Invoke();
        Debug.Log("Game Over");
    }

    private void Win()
    {
        _animatorController.SetWinTrigger();
        OnFinish?.Invoke();
        IsActive = false;
        Debug.Log("You Win");
    }

}
