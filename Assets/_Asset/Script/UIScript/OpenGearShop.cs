using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGearShop : MonoBehaviour
{
    [SerializeField] private GameObject displaygear;
    [SerializeField] private GameObject Choice;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject menu1;
    [SerializeField] private GameObject menu2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GearShop()
    {
        Shop.SetActive(true);
        displaygear.SetActive(false);
        menu1.SetActive(false);
        menu2.SetActive(false);
    }
}
