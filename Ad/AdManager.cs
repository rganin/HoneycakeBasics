using System;
using UnityEngine.Advertisements;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;
using HoneycakeBasics.Util;

namespace HoneycakeBasics.Ad
{
    public class AdManager: SingletonBase<AdManager>, IUnityAdsInitializationListener
    {
        private bool isAdInitialized = false;
        private AdConfig config = new AdConfig();
        private List<Action> onInitActions = new();
        private AdHandler adHandler = new();
        
        
        public static AdManager getInstance()
        {
            return Instance;
        }

        public AdManager()
        {
            initAds();
        }

        public void initAds()
        {
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(config.gameId, config.testMode, this);
            } else if (!Advertisement.isSupported)
            {
                Debug.Log("Ads not supported!");
            }
        }

        public void addInitListener(Action onInitAction)
        {
            onInitActions.Add(onInitAction);
        }

        public void callOnInitActions()
        {
            foreach (var action in onInitActions)
            {
                action();
            }
        }

        public bool getIsAdInitialized()
        {
            return isAdInitialized;
        }

        public void preloadAd()
        {
            adHandler.loadAd(config.rewardedADUnitId, () => { });
        }

        public bool isAdPreloaded()
        {
            return adHandler.isAdLoaded(config.rewardedADUnitId);
        }

        public void showAd(Action onCompleteCallback)
        {
            if (!adHandler.isAdLoaded(config.rewardedADUnitId))
            {
                adHandler.loadAd(config.rewardedADUnitId, () =>
                {
                    adHandler.showAd(config.rewardedADUnitId, onCompleteCallback);
                });
            }
            else
            {
                adHandler.showAd(config.rewardedADUnitId, onCompleteCallback);
            }
        }

        public void OnInitializationComplete()
        {
            this.isAdInitialized = true;
            Debug.Log("Ads initialization successful");
            this.callOnInitActions();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            this.isAdInitialized = false;
            Debug.Log("Ads init failed: " + message + error.GetType());
        }
    }
}