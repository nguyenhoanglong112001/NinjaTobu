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
    private int cost;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
