using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPads :MonoBehaviour
{
    [SerializeField] private GameObject AdsButton;
    [SerializeField] private GameObject IAPbutton;
    [SerializeField] private CoinsReward checkads;

    private void CheckAds()
    {
        if(checkads.CheckAds())
        {
            AdsButton.SetActive(true);
            IAPbutton.SetActive(false);
        }
        else
        {
            AdsButton.SetActive(false);
            IAPbutton.SetActive(true);
        }
    }

    private void Update()
    {
        CheckAds();
        StartCoroutine(SetADs());
    }

    IEnumerator SetADs()
    {
        if (!checkads.CheckAds())
        {
            yield return new WaitForSeconds(10);
            checkads.SetADs(true);
            StopAllCoroutines();
        }
    }
}
