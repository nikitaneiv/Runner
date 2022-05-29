using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AdController _adController;

    private void FixedUpdate()
    {
        _button.interactable = _adController.IsRewardedReady;
    }
}
