using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPcoinsShop : MonoBehaviour
{
    [SerializeField] private SaveData data;
    private string coins300 = "com.longnguyen.ninjatobuclone.300coins";
    private string coins750 = "com.longnguyen.ninjatobuclone.750coins";
    private string coins2000 = "com.longnguyen.ninjatobuclone.2000coins";
    public void OnPurchaseCompleted(Product product)
    {
        if (product.definition.id == coins300)
        {
            data.SaveCoinData("currentcoin", 300);
        }
        if (product.definition.id == coins750)
        {
            data.SaveCoinData("currentcoin", 750);
        }
        if (product.definition.id == coins2000)
        {
            data.SaveCoinData("currentcoin", 2000);
        }
    }
}
