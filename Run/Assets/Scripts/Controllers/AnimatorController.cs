using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
 
    public void SetRunTrigger()
    {
        SetTrigger("Run");
    }

    public void SetFallTrigger()
    {
        SetTrigger("Fall");
    }

    public void SetWinTrigger()
    {
        SetTrigger("Dance");
    }

    public void SetIdleTrigger()
    {
        SetTrigger("Idle");
    }

    public void SetTrigger(int triggerId) => _animator.SetTrigger(triggerId);
    public void SetTrigger(string triggerName) => _animator.SetTrigger(triggerName);
    public void SetFloat(float value, string name) => _animator.SetFloat(name, value);
}
