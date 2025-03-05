using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    private BannerView _bannerView;

#if UNITY_ANDROID
    private string bANNER_ID = "";
#elif UNITY_IPHONE
    private string bANNER_ID = "";
#else
    private string bANNER_ID = "unused";
#endif

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        CreateBannerView();
    }

    public void CreateBannerView()
    {
        _bannerView = new BannerView(bANNER_ID, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom);
        LoadAd();
    }

    public void LoadAd()
    {
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest();
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }
}
