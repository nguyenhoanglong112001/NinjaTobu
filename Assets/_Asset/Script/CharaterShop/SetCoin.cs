using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Rarety
{
    heroics,
    mythical,
    legendary,
    etheral,
    transcendent
}
public class SetCoin : MonoBehaviour
{
    [SerializeField] private Rarety rarety;
    [SerializeField] private Text raretytext;
    [SerializeField] private Text cointext;
    private int cost;
    // Start is called before the first frame update
    void Start()
    {
        raretytext.text = rarety.ToString();
        SetPrice();
        Debug.Log(GetCost());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetPrice()
    {
        switch(rarety)
        {
            case Rarety.heroics:
                {
                    cost = 100;
                    break;
                }
            case Rarety.mythical:
                {
                    cost = 250;
                    break;
                }
            case Rarety.legendary:
                {
                    cost = 600;
                    break;
                }
            case Rarety.etheral:
                {
                    cost = 1200;
                    break;
                }
            case Rarety.transcendent:
                {
                    cost = 2500;
                    break;
                }
        }
        cointext.text = cost.ToString();
    }

    public Rarety GetRarety()
    {
        return rarety;
    }

    public int GetCost()
    {
        return cost;
    }
}
