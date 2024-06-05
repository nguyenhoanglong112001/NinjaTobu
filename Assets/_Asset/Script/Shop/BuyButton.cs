using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private ShopManager manager;
    [SerializeField] private SaveData savedata;
    [SerializeField] private CheckCoin check;
    [SerializeField] private DisPlay cost;
    [SerializeField] private ChoiceCharacter checkbuy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCharacter()
    {
        var choice = manager.GetChoice();
        checkbuy = choice.GetComponent<ChoiceCharacter>();
        if (check.CoinCheck(cost.GetCost()))
        {
            savedata.SaveCoinData("currentcoin", -cost.GetCost());
            savedata.SaveString(choice.name, choice.name);
            checkbuy.SetBuy(true);
        }
    }
}
