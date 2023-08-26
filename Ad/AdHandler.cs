using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace HoneycakeBasics.Ad
{
    public class AdHandler : IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private Dictionary<string, Action> onShowComplete = new ();
        private Dictionary<string, Action> onLoadComplete = new ();

        private Dictionary<string, bool> adsLoaded = new ();

        public bool isAdLoaded(string placementId)
        {
            adsLoaded.TryGetValue(placementId, out var isLoaded);
            if (!isLoaded)
            {
                return false;
            }
            return true;
        }

        public void loadAd(string placementId, Action onLoadCompleteAction)
        {
            Debug.Log("AD load started: placementId = " + placementId);
            onLoadComplete.TryAdd(placementId, onLoadCompleteAction);
            Advertisement.Load(placementId, this);
        }

        public void showAd(string placementId, Action onShowCompleteAction)
        {
            onShowComplete.TryAdd(placementId, onShowCompleteAction);
            Advertisement.Show(placementId, this);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Debug.Log("AD loaded: placementId = " + placementId);
            this.adsLoaded.TryAdd(placementId, true);
            if (this.onLoadComplete.TryGetValue(placementId, out var action))
            {
                
                action.Invoke();
                onLoadComplete.Remove(placementId);
            }
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Debug.Log("AD show started: placementId = " + placementId);
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log("AD show clicked: placementId = " + placementId);
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Debug.Log("AD show completed: placementId = " + placementId);
            if (this.onShowComplete.TryGetValue(placementId, out var action))
            {
                adsLoaded.Remove(placementId);
                action.Invoke();
                onShowComplete.Remove(placementId);
            }
        }
    }
}
