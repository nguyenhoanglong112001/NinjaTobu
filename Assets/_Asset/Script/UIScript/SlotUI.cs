using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private CheckSlotPower SLotAvaliavle;
    [SerializeField] private int index;
    [SerializeField] private UnlockSlot checkunlock;
    [SerializeField] private Image imageslot;
    [SerializeField] private SaveData savecoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetImagePower();
        ShiftSlot();
    }

    public void GetImagePower()
    {
        //imageslot.sprite = power.sprite;
        if (checkunlock.GetUnlock() && SLotAvaliavle.GetObject(index) != null)
        {
            var parent = SLotAvaliavle.GetObject(index);
            var child = parent.transform.GetChild(0);
            imageslot.gameObject.SetActive(true);
            imageslot.sprite = child.gameObject.GetComponent<Image>().sprite;
        }
    }

    public void UnPick()
    {
        if(imageslot.sprite != null)
        {
            var parent = SLotAvaliavle.GetObject(index);
            var child = parent.transform.GetChild(1);
            imageslot.sprite = null;
            imageslot.gameObject.SetActive(false);
            //savecoin.SaveCoinData("currentcoin",SLotAvaliavle.GetPowerArr()[index].GetComponent<SetGoldPower>().GetPrice());
            SLotAvaliavle.GetPowerArr()[index].GetComponent<PickButton>().SetBuyPower(false);
            SLotAvaliavle.RemoveImageobj(index);
            SLotAvaliavle.UnUseEffect(index);
            child.gameObject.SetActive(false);
        }
    }

    private void ShiftSlot()
    {
        if(SLotAvaliavle.GetObject(index) == null)
        {
            imageslot.sprite = null;
            imageslot.gameObject.SetActive(false);
            return;
        }
    }

    public Image GetImage()
    {
        return imageslot;
    }
}
