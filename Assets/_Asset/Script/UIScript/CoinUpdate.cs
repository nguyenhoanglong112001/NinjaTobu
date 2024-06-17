using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text coincount;
    [SerializeField] private int coinpoint;
    [SerializeField] private PowerCheck check;
    private int totalcoin;
    void Start()
    {
        check = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        totalcoin = 0;
        if(PlayerPrefs.HasKey("LuckyCoin"))
        {
            coinpoint = 2;
        }
        else
        {
            coinpoint = 1;
        }    
    }

    public void UpdateCoin(int point)
    {
        totalcoin += coinpoint;
    }

    public int GetCoinPoint()
    {
        return coinpoint;
    }

    public void SetCoinPoint(int point)
    {
        coinpoint = point;
    }

    public int GetTotalCoin()
    {
        return totalcoin;
    }

    // Update is called once per frame
    void Update()
    {
        coincount.text = totalcoin.ToString();
    }
}
