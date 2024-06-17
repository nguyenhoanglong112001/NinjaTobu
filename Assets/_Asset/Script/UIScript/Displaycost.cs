using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaycost : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text costdisplay;
    [SerializeField] private SetCoin cost;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        costdisplay.text = cost.GetCost().ToString();
    }
}
