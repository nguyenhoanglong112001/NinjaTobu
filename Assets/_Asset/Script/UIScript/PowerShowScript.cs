using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerShowScript : MonoBehaviour
{
    [SerializeField] private UnlockSlot checkunlock;
    [SerializeField] private GameObject unlockUI;
    [SerializeField] private GameObject lockUI;
    [SerializeField] private CheckSlotPower slotpower;
    [SerializeField] private int index;
    [SerializeField] private Image imageslot;
    [SerializeField] private string slot;
    // Start is called before the first frame update
    void Start()
    {
        //CheckStartUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        CheckUnlock();
        SetImage();
    }

    private void CheckUnlock()
    {
        if (checkunlock.GetUnlock() || PlayerPrefs.HasKey(slot))
        {
            unlockUI.SetActive(true);
            lockUI.SetActive(false);
            return;
        }
        else if (!checkunlock.GetUnlock())
        {
            unlockUI.SetActive(false);
            lockUI.SetActive(true);
            return;
        }
    }

    private void SetImage()
    {
        if(slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage().sprite != null)
        {
            imageslot.gameObject.SetActive(true);
            imageslot.sprite = slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage().sprite;
        }
        else if (slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage().sprite == null)
        {
            imageslot.gameObject.SetActive(false);
            imageslot.sprite = null;
        }
    }

    private void CheckStartUnlock()
    {
        if(PlayerPrefs.HasKey(slot))
        {
            unlockUI.SetActive(true);
            lockUI.SetActive(false);
        }
    }
}
