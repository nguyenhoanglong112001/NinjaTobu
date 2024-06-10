using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsReward : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private SaveData savecoin;
    [SerializeField] private GameObject ShowAdButton;
    [SerializeField] private GameObject ShowCostButton;
    public bool isreward;
    public bool isadavaliable;
    // Start is called before the first frame update
    void Start()
    {
        isadavaliable = true;
    }

    // Update is called once per frame
    void Update()
    {
        RewardCoinAd();
    }

    public void ShowAds()
    {
        if(isadavaliable)
        {
            AddManager.Instance.rewarded.ShowAd();
        }
    }
    public void RewardCoinAd()
    {
        if (isreward)
        {
            savecoin.SaveCoinData("currentcoin", amount);
            isreward = false;
            isadavaliable = false;
        }
    }
    public bool CheckAds()
    {
        return isadavaliable;
    }
    public void SetADs(bool check)
    {
        isadavaliable = check;
    }
}
