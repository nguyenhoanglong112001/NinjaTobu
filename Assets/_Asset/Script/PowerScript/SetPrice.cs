using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPrice : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private GameObject[] slot;
    [SerializeField] private Text pricetext;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PriceSet();
    }

    public void PriceSet()
    {
        if (!slot[0].GetComponent<UnlockSlot>().GetUnlock())
        {
            price = 1000;
        }
        else if (slot[0].GetComponent<UnlockSlot>().GetUnlock())
        {
            price = 2000;
        }
        pricetext.text = price.ToString();
    }    

    public int GetPrice()
    {
        return price;
    }
}
