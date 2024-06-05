using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;

public class BannerAd : MonoBehaviour
{
    [SerializeField] private string androindAdunitId;
    [SerializeField] private string IOSAdunitId;

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
            adUnitId = IOSAdunitId;
#elif UNITY_ANDROID
        adUnitId = androindAdunitId;
#elif UNITY_EDITOR
            adUnitId = _androidGameId; //Only for testing the functionality in the Editor
#endif

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };

        Advertisement.Banner.Show(adUnitId, options);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void BannerHidden()
    {

    }

    private void BannerClicked()
    {

    }

    private void BannerShown()
    {
    }

    private void BannerLoadedError(string message)
    {
    }

    private void BannerLoaded()
    {
    }
}
