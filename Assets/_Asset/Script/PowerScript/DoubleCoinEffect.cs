using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinEffect : MonoBehaviour
{
    [SerializeField] private CoinUpdate updatecoin;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindObject();
    }

    public void EnableEffect()
    {
        CoinUpdate[] coinarr = Resources.FindObjectsOfTypeAll<CoinUpdate>();
        updatecoin = coinarr[0];
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        if (powercheck.DoubleCoinCheck())
        {
            //powerui.ShowPower(powerimage);
            updatecoin.SetCoinPoint(updatecoin.GetCoinPoint()*2);
        }
    }

    public void FindObject()
    {
    }    

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimage);
        updatecoin.SetCoinPoint(updatecoin.GetCoinPoint()/2);
        powercheck.DoubleCoinPower(false);
    }
}
