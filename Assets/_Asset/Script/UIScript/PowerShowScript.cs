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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUnlock();
        SetImage();
    }

    private void CheckUnlock()
    {
        if (checkunlock.GetUnlock())
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
            Debug.Log(slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage());
            imageslot.gameObject.SetActive(true);
            imageslot.sprite = slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage().sprite;
        }
        else if (slotpower.GetSlotArr()[index].GetComponent<SlotUI>().GetImage().sprite == null)
        {
            imageslot.gameObject.SetActive(false);
            imageslot.sprite = null;
        }
    }
}
