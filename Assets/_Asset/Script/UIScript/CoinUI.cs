using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text currentcointtext;
    [SerializeField] private GetData getdata;
    [SerializeField] private int currentcoin;
    // Start is called before the first frame update
    void Awake()
    {
        getdata = GameObject.FindWithTag("Data").GetComponent<GetData>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTextcoin();
    }

    private void SetTextcoin()
    {
        currentcoin = getdata.GetIntData("currentcoin", 0);
        currentcointtext.text = currentcoin.ToString();
    }
}
