using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddManager : MonoBehaviour
{
    [SerializeField] public AdsInitializer initializeAd;
    [SerializeField] public InterstitialAd interstitialAd;
    [SerializeField] public BannerAd bannerad;
    [SerializeField] public RewardedAds rewarded;
    public static AddManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}