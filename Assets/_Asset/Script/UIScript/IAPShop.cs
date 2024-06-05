using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPShop : MonoBehaviour
{
    [SerializeField] private GameObject IAPshopUI;
    [SerializeField] private GameObject Menu1;
    [SerializeField] private GameObject Menu2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowShop()
    {
        IAPshopUI.SetActive(true);
        Menu1.SetActive(false);
        Menu2.SetActive(false);
    }

    public void BackButton()
    {
        IAPshopUI.SetActive(false);
        Menu1.SetActive(true);
        Menu2.SetActive(true);
    }
}
