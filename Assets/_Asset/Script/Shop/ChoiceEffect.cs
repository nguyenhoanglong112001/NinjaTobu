using UnityEngine;

public class ChoiceEffect : MonoBehaviour
{
    [SerializeField] private ShopEffect shop;
    private GameObject effectprefab;
    [SerializeField] private Transform playerposition;
    [SerializeField] private GetData data;
    [SerializeField] private SaveData save;
    [SerializeField] private AudioSource equip;
    [SerializeField] private AudioSource equipfail;
    [SerializeField] private GameObject comfirmUI;
    private bool isbuy;
    [SerializeField] private bool isequip;

    public void SetChoice()
    {
        if (isbuy)
        {
            shop.SetChoice(gameObject);
            for (int i = 0; i < shop.GetArr().Length; i++)
            {
                if(shop.GetArr()[i] == gameObject)
                {
                    shop.GetArr()[i].transform.GetChild(0).gameObject.SetActive(true);
                    shop.GetArr()[i].GetComponent<ChoiceEffect>().isequip = true;
                    save.Save("Effect", i);
                }
                else
                {
                    shop.GetArr()[i].transform.GetChild(0).gameObject.SetActive(false);
                    shop.GetArr()[i].GetComponent<ChoiceEffect>().isequip = false;
                }
            }
            equip.Play();
        }
    }

    public void BuyEffect()
    {
        isbuy = true;
        SetChoice();
        for (int i = 0; i < shop.GetArr().Length; i++)
        {
            if (shop.GetArr()[i] == gameObject)
            {
                save.Save(shop.GetArr()[i].name, i);
            }
        }
        save.SaveCoinData("currentcoin", -gameObject.GetComponent<SetCoin>().GetCost());
        comfirmUI.SetActive(false);
        equip.Play();
        isequip = true;
    }

    public void DeclineButton()
    {
        comfirmUI.SetActive(false);
        equip.Play();
    }

    public void ConfirmPurchase()
    {
        if(isbuy == false)
        {
            if (data.GetIntData("currentcoin", 0) >= gameObject.GetComponent<SetCoin>().GetCost())
            {
                comfirmUI.SetActive(true);
                equip.Play();
                for (int i = 1; i < shop.GetArr().Length; i++)
                {
                    if (shop.GetArr()[i] != gameObject)
                    {
                        if(shop.GetArr()[i].transform.GetChild(7).gameObject.activeSelf)
                        {
                            shop.GetArr()[i].transform.GetChild(7).gameObject.SetActive(false);
                        }    
                    }
                }
            }
            else
            {
                equipfail.Play();
            }
        }
    }

    private void CheckBuy()
    {
        if (isbuy)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        CheckBuy();
    }

    public void SetBuy(bool check)
    {
        isbuy = check;
    }

    public bool CheckEquip()
    {
        return isequip;
    }
}
