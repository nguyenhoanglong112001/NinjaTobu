using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStartUI : MonoBehaviour
{
    [SerializeField] private GameObject PowerChoice;
    [SerializeField] private GameObject powerstart;
    [SerializeField] private GameObject CoinUI;
    [SerializeField] private GameObject ingameUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIChoicePower()
    {
        CoinUI.SetActive(true);
        ingameUI.SetActive(false);
        powerstart.SetActive(false);
        PowerChoice.SetActive(true);
    }
}
