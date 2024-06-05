using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] Menu;
    [SerializeField] private GameObject option;
    void Start()
    {
        //option.SetActive(!option.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option()
    {
        foreach (var canvas in Menu)
        {
           canvas.SetActive(!canvas.activeSelf);
        }
        option.SetActive(!option.activeSelf);
    }
}
