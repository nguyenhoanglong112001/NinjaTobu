using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image Arreffect;
    [SerializeField] private Image[] slotpower;
    [SerializeField] private CheckSlotPower poweradd;
    [SerializeField] private PowerChoiceManager powermanager;
    [SerializeField] private CheckCoin check;
    [SerializeField] private SetGoldPower price;
    [SerializeField] private SaveData savecoin;
    [SerializeField] private GameObject costtext;
    [SerializeField] private Text timetext;
    [SerializeField] private SaveData savedata;
    [SerializeField] private bool isuse;
    [SerializeField] private bool isbuy;
    [SerializeField] private AudioSource Equipsound;
    [SerializeField] private AudioSource Unequipsound;

    [SerializeField] private Text powername;
    [SerializeField] private Text description;
    [SerializeField] private string name;
    [SerializeField] private string powerdes;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckUse();
    }

    private void AddPower()
    {
        poweradd.PowerChoice(this.gameObject);
    }

    public void EffectPick()
    {
        if (!Arreffect.gameObject.activeSelf && !isuse)
        {
            if(poweradd.CheckSlotAvaliable())
            {
                Equipsound.Play();
                if (!isbuy)
                {
                    if (check.CoinCheck(price.GetPrice()))
                    {
                        Arreffect.gameObject.SetActive(true);
                        AddPower();
                        savecoin.SaveCoinData("currentcoin", -price.GetPrice());
                        isbuy = true;
                        savedata.Save(gameObject.name, 300);
                        isuse = true;
                    }
                }
               else
                {
                    Arreffect.gameObject.SetActive(true);
                    AddPower();
                    isuse = true;
                }
                powername.text = name;
                description.text = powerdes;
            }    
        }
        else if (Arreffect.gameObject.activeSelf && isuse)
        {
            Unequipsound.Play();
            powermanager.RemovePower(gameObject);
            int index = poweradd.GetPowerArr().IndexOf(gameObject);
            if (poweradd.GetPowerArr().Contains(gameObject))
            {
                poweradd.GetPowerArr().Remove(gameObject);
                poweradd.UnUseEffect(index);
            }
            //savecoin.SaveCoinData("currentcoin", price.GetPrice());
            Arreffect.gameObject.SetActive(false);
            isuse = false;
        }
    }

    public void SetBuyPower(bool active)
    {
        isuse = active;
    }

    public bool GetCheck()
    {
        return isuse;
    }

    public void SetBuy(bool buy)
    {
        isbuy = buy;
    }

    private void CheckUse()
    {
        if(isbuy)
        {
            costtext.SetActive(false);
            timetext.gameObject.SetActive(true);
        }
        else
        {
            costtext.SetActive(true);
            timetext.gameObject.SetActive(false);
        }
    }
}
