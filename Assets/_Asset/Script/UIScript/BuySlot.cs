using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;

public class BuySlot : MonoBehaviour
{
    [SerializeField] private Canvas BuyUI;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    [SerializeField] private SaveData savedata;
    [SerializeField] private CheckSlotPower slotadd;
    [SerializeField] private GetIntData getcoin;
    [SerializeField] private SaveData data;
    [SerializeField] private SetPrice price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void ExitUI()
    {
        BuyUI.gameObject.SetActive(false);
    }    
    public void UnLockSlot2()
    {
        var currentcoin = getcoin.GetData("currentcoin", 0);
        if(currentcoin > price.GetPrice())
        {
            if (!Slot1.GetComponent<UnlockSlot>().GetUnlock())
            {
                Slot1.GetComponent<UnlockSlot>().CheckUnlock(true);
                slotadd.SLotAdd(Slot1);
                savedata.SaveString("Slot2", "unlock");
                ExitUI();
                savedata.SaveCoinData("currentcoin", -price.GetPrice());
            }
        }
    }

    public void UnlockSlot3()
    {
        var currentcoin = getcoin.GetData("currentcoin", 0);
        if (currentcoin > price.GetPrice())
        {
            if (!Slot2.GetComponent<UnlockSlot>().GetUnlock())
            {
                Slot2.GetComponent<UnlockSlot>().CheckUnlock(true);
                slotadd.SLotAdd(Slot2);
                savedata.SaveString("Slot3", "unlock");
                ExitUI();
                savedata.SaveCoinData("currentcoin", -price.GetPrice());
            }
        }
    }

    public void UnlockSlot()
    {
        if (Slot1.GetComponent<UnlockSlot>().GetUnlock())
        {
            UnlockSlot3();
        }
        else if (!Slot1.GetComponent<UnlockSlot>().GetUnlock())
        {
            UnLockSlot2();
        }
    }

}
