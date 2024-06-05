using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject CoinUI;
    [SerializeField] private GameObject ingameUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitUI(Canvas UI)
    {
        UI.gameObject.SetActive(false);
        CoinUI.SetActive(false);
        ingameUI.SetActive(true);
    }

    public void EnableUI(Canvas UI)
    {
        UI.gameObject.SetActive(true);
    }
}
