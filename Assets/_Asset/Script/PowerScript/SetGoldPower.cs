using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGoldPower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int price;
    [SerializeField] private Text pricetext;
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetText()
    {
        pricetext.text = price.ToString();
    }

    public int GetPrice()
    {
        return price;
    }
}
