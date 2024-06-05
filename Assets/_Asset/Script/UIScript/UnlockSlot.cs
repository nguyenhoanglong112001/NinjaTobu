using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSlot : MonoBehaviour
{
    [SerializeField] private Image lockslot;
    [SerializeField] private Image unlockslot;
    [SerializeField] private CheckSlotPower slotpower;
    [SerializeField] private BuySlot buyslot;
    [SerializeField] private Canvas BuyUI;
    private bool isunlock;
    private bool isaddlist;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SlotUnlock();
    }

    public void CheckUnlock(bool check)
    {
        isunlock = check;
    }

    public bool GetUnlock()
    {
        return isunlock;
    }

    private void SlotUnlock()
    {
        if (isunlock == true)
        {
            lockslot.gameObject.SetActive(false);
            unlockslot.gameObject.SetActive(true);
        }
        else if (!isunlock)
        {
            lockslot.gameObject.SetActive(true);
            unlockslot.gameObject.SetActive(false);
        }
    }

    public void SlotCheck()
    {
        if (isunlock == false)
        {
            BuyUI.gameObject.SetActive(true);
        }
    }
}
