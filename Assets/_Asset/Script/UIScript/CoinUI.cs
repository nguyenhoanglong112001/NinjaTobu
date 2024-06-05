using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text currentcointtext;
    [SerializeField] private GetIntData getdata;
    [SerializeField] private int currentcoin;
    // Start is called before the first frame update
    void Awake()
    {
        getdata = GameObject.FindWithTag("Data").GetComponent<GetIntData>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTextcoin();
    }

    private void SetTextcoin()
    {
        currentcoin = getdata.GetData("currentcoin", 0);
        currentcointtext.text = currentcoin.ToString();
    }
}
