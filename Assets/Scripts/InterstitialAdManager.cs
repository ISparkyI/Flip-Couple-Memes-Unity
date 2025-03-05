using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class InterstitialAdManager : MonoBehaviour
{
    private int clickCounter = 0;
    private const int interstitialInterval = 5;

    private InterstitialAd _interstitialAd;

#if UNITY_ANDROID
    private string interstitialAd_ID = "ca-app-pub-8274586101370231/9698029998";
#elif UNITY_IPHONE
    private string interstitialAd_ID = "";
#else
    private string interstitialAd_ID = "unused";
#endif

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        LoadAd();
    }

    private void LoadAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
        }

        InterstitialAd.Load(interstitialAd_ID, new AdRequest(),
            (InterstitialAd ad, LoadAdError loadAdError) =>
            {
                if (loadAdError != null)
                {
                    Debug.Log("Interstitial ad failed to load with error: " +
                               loadAdError.GetMessage());
                    return;
                }
                else if (ad == null)
                {
                    Debug.Log("Interstitial ad failed to load.");
                    return;
                }

                Debug.Log("Interstitial ad loaded.");
                _interstitialAd = ad;
                RegisterAdEvents(ad);
            });
    }

    private void RegisterAdEvents(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += HandleOnAdClosed;
    }

    private void HandleOnAdClosed()
    {
        Debug.Log("Interstitial ad closed.");
        LoadAd();
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    public void OnNextButtonClick()
    {
        clickCounter++;
        if (clickCounter % interstitialInterval == 0)
        {
            ShowInterstitialAd();
        }
    }
}
