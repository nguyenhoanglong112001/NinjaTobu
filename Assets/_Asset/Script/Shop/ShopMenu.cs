using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] ListShop;
    [SerializeField] private GameObject shopchoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Manager();
    }

    private void Manager()
    {
        foreach(var shop in ListShop)
        {
            if (shop != shopchoice)
            {
                shop.transform.GetChild(0).gameObject.SetActive(false);
                shop.transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                shop.transform.GetChild(0).gameObject.SetActive(true);
                shop.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void SetShop(GameObject shop)
    {
        shopchoice = shop;
    }
}
