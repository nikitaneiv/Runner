using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : MonoBehaviour
{
    [SerializeField] private string _appKey = "85460dcd";
    private bool _isInterstitialReady;
    private bool _isRewardReady;

    public bool IsRewardedReady => _isRewardReady;

    private void Awake()
    {
        SubscribeEvents();
        IronSource.Agent.validateIntegration();
        IronSource.Agent.init(_appKey, IronSourceAdUnits.BANNER, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.REWARDED_VIDEO);
    }

    private void SubscribeEvents()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += InitializeCallback;

        IronSourceEvents.onBannerAdLoadFailedEvent += BannerLoadFailed;

        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialReady;
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialClosed;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialOpened;
        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialLoadFailed;

        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedReady;
        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedOpen;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedClosed;
        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedEvent;
        IronSourceEvents.onRewardedVideoAdLoadFailedEvent += RewardedLoadFailed;
    }

   
    private void InitializeCallback()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.BOTTOM);
        IronSource.Agent.loadInterstitial();
        IronSource.Agent.loadRewardedVideo();
    }

    private void BannerLoadFailed(IronSourceError error) => Debug.LogError(error);
    private void InterstitialLoadFailed(IronSourceError error) => Debug.LogError(error);

    private void RewardedLoadFailed(IronSourceError error) => Debug.LogError(error);

    #region Interstitial
    private void InterstitialReady()
    {
        _isInterstitialReady = true;
    }
    private void InterstitialOpened()
    {
        IronSource.Agent.hideBanner();
    }
    private void InterstitialClosed()
    {
        _isInterstitialReady = false;
        IronSource.Agent.displayBanner();
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitial()
    {
        if (_isInterstitialReady == false) return;

        IronSource.Agent.showInterstitial();
    }
    #endregion

    #region Rewarded
    private void RewardedReady(bool status) => _isRewardReady = status;

    private void RewardedOpen()
    {
        IronSource.Agent.hideBanner();
    }

    private void RewardedClosed()
    {
        _isRewardReady = false;
        IronSource.Agent.displayBanner();
        IronSource.Agent.loadRewardedVideo();
    }

    private void RewardedEvent(IronSourcePlacement ironSourcePlacement)
    {
        Debug.Log($"Get bonus: {ironSourcePlacement.getPlacementName()}");
    }

    public void ShowRewarded()
    {
        if (_isRewardReady == false) return;
        IronSource.Agent.showRewardedVideo();
    }


    #endregion

}
