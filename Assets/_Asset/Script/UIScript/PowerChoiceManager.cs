using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerChoiceManager : MonoBehaviour
{
    [SerializeField] private GameObject powerselect;
    [SerializeField] private GameObject powerremove;
    [SerializeField] private PowerUI powerui;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectPower(GameObject power)
    {
        powerselect = power;
        var price = powerselect.GetComponent<SetGoldPower>().GetPrice();
        powerui.ShowPower(power.transform.GetChild(0).GetComponent<Image>().sprite);
        //if (currentcoin.GetData("currentcoin", 0) > powerselect.GetComponent<SetGoldPower>().GetPrice())
        //{
        //    var price = powerselect.GetComponent<SetGoldPower>().GetPrice();
        //    powerui.ShowPower(power.transform.GetChild(0).GetComponent<Image>().sprite);
        //    savecoin.SaveCoinData("currentcoin", -price);
        //}
        //else
        //{
        //    powerselect = null;
        //}
    }

    public void RemovePower(GameObject power)
    {
        //powerselect.RemoveAt(powerselect.IndexOf(power));
        powerremove = power;
        powerui.UnShowPower(power.transform.GetChild(0).GetComponent<Image>().sprite);
    }

    public GameObject GetSelect()
    {
        return powerselect;
    }

    public GameObject GetRemove()
    {
        return powerremove;
    }
}
