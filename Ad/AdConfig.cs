namespace HoneycakeBasics.Ad
{
    public class AdConfig
    {
        public string androidGameId = "5334508";
        public string iOSGameId = "5334509";
        public bool testMode = false;
        public string rewardedAndroidAdUnitId = "Rewarded_Android";
        public string rewardedIOSAdUnitId = "Rewarded_iOS";
        
        public string rewardedADUnitId = null;
        public string gameId;

        public AdConfig()
        {
#if UNITY_IOS
            gameId = iOSGameId;
            rewardedADUnitId = rewardedIOSAdUnitId;
#elif UNITY_ANDROID
            gameId = androidGameId;
            rewardedADUnitId = rewardedAndroidAdUnitId;
#elif UNITY_EDITOR
            rewardedADUnitId = rewardedAndroidAdUnitId;
            gameId = androidGameId; //Only for testing the functionality in the Editor
#endif
        }
    }
}