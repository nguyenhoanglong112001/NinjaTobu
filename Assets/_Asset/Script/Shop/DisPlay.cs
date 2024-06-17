using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisPlay : MonoBehaviour
{
    [SerializeField] private ShopManager manager;
    [SerializeField] private Text ninjaname;
    [SerializeField] private Image ninjapic;
    [SerializeField] private SetCoin rarety;
    [SerializeField] private Text costtext;
    [SerializeField] private GameObject[] raretydisplay;
    [SerializeField] private GameObject[] button;
    [SerializeField] private GameObject costdisplay;
    [SerializeField] private GameObject[] listdisplayeffect;
    private int cost;


    [SerializeField] private Sprite imortal;
    [SerializeField] private Sprite lucky;
    [SerializeField] private Sprite heavy;
    [SerializeField] private Sprite lighter;
    [SerializeField] private Sprite strong;
    [SerializeField] private Sprite slowmo;
    [SerializeField] private Sprite slow;
    [SerializeField] private Sprite fast;
    [SerializeField] private Sprite shuriken;
    private GameObject currentchoice;
    // Start is called before the first frame update
    void Start()
    {
        currentchoice = manager.GetChoice();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCharacter();
    }

    public int GetCost()
    {
        return cost;
    }

    private void DisplayCharacter()
    {
        var choice = manager.GetChoice();
        var name = choice.transform.GetChild(1).GetComponent<Text>();
        var checkbuy = choice.GetComponent<ChoiceCharacter>();
        rarety = choice.GetComponent<SetCoin>();
        cost = rarety.GetComponent<SetCoin>().GetCost();
        ninjaname.text = name.text;
        ninjapic.sprite = manager.GetImage();
        costtext.text = cost.ToString();
        if (rarety.GetRarety() == Rarety.heroics)
        {
            raretydisplay[0].SetActive(true);
            raretydisplay[1].SetActive(false);
            raretydisplay[2].SetActive(false);
            raretydisplay[3].SetActive(false);
            raretydisplay[4].SetActive(false);
        }
        else if (rarety.GetRarety() == Rarety.mythical)
        {
            raretydisplay[0].SetActive(false);
            raretydisplay[1].SetActive(true);
            raretydisplay[2].SetActive(false);
            raretydisplay[3].SetActive(false);
            raretydisplay[4].SetActive(false);
        }
        else if (rarety.GetRarety() == Rarety.legendary)
        {
            raretydisplay[0].SetActive(false);
            raretydisplay[1].SetActive(false);
            raretydisplay[2].SetActive(true);
            raretydisplay[3].SetActive(false);
            raretydisplay[4].SetActive(false);
        }
        else if (rarety.GetRarety() == Rarety.etheral)
        {
            raretydisplay[0].SetActive(false);
            raretydisplay[1].SetActive(false);
            raretydisplay[2].SetActive(false);
            raretydisplay[3].SetActive(true);
            raretydisplay[4].SetActive(false);
        }
        else if (rarety.GetRarety() == Rarety.transcendent)
        {
            raretydisplay[0].SetActive(false);
            raretydisplay[1].SetActive(false);
            raretydisplay[2].SetActive(false);
            raretydisplay[3].SetActive(false);
            raretydisplay[4].SetActive(true);
        }

        if(checkbuy.GetBool())
        {
            button[0].SetActive(true);
            button[1].SetActive(false);
            costdisplay.SetActive(false);
        }    
        else
        {
            button[0].SetActive(false);
            button[1].SetActive(true);
            costdisplay.SetActive(true);
        }
    }   

    public void DisplayEffect()
    {
        if (manager.GetChoice() != currentchoice)
        {
            foreach (var a in listdisplayeffect)
            {
                a.GetComponent<Image>().sprite = null;
                a.SetActive(false);
            }
        }
        currentchoice = manager.GetChoice();
        var choice = manager.GetChoice();
        var checkeffect = choice.GetComponent<ChoiceCharacter>().GetListEffect();
        int i = 0;
        foreach (var effect in checkeffect)
        {
            if (effect == "imortal")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = imortal;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Imortal";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "luckycoin")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = lucky;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Lucky coin";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "lighter")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = lighter;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Light";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "fast")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = fast;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Fast";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "shuriken")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = shuriken;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Shuriken";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "slowmo")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = slowmo;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Slow-mo";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "strong")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = strong;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Strong";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "heavy")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = heavy;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Heavy";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
            if (effect == "slow")
            {
                listdisplayeffect[i].GetComponent<Image>().sprite = slow;
                listdisplayeffect[i].transform.GetChild(0).GetComponent<Text>().text = "Slow";
                listdisplayeffect[i].SetActive(true);
                i++;
            }
        }
    }
}
