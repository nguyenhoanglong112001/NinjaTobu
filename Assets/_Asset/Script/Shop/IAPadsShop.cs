using UnityEngine;
using UnityEngine.Purchasing;

public class IAPadsShop : MonoBehaviour
{
    [SerializeField] private SaveData data;
    private string coins100 = "com.longnguyen.ninjatobuclone.100coins";
    public void OnPurchaseCompleted(Product product)
    {
        if (product.definition.id == coins100)
            data.SaveCoinData("currentcoin", 100);
    }
}
