using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string slotpower = "com.longnguyen.ninjatobuclone.slotpower1";
    [SerializeField] private BuySlot unlock;
    public void OnPurchaseCompleted(Product product)
    {
        if (product.definition.id == slotpower)
        {
            Debug.Log("Success");
            unlock.UnlockSlot();
        }
    }

    public void OnPurchaseFail(Product product, PurchaseFailureReason failreason)
    {

    }
}
