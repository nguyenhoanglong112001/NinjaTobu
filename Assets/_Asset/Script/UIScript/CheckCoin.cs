using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GetIntData coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CoinCheck(int price)
    {
        if (coin.GetData("currentcoin", 0) >= price)
        {
            return true;
        }
        return false;
    }
}
