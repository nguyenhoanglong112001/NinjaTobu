using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoin : MonoBehaviour
{
    [SerializeField] private GameObject doubleeffect;
    [SerializeField] private Transform point;
    [SerializeField] private CheckSlotPower slotcheck;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerChoiceManager choicemanager;
    private GameObject coineffect;
    [SerializeField] private CheckCoin check;
    [SerializeField] private SetGoldPower price;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.FindWithTag("Player").GetComponent<Transform>();
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DoubleCoinChoice()
    {
        if(coineffect == null && slotcheck.CheckEffectAvaliable() && check.CoinCheck(price.GetPrice()))
        {
            coineffect = Instantiate(doubleeffect, point.position, Quaternion.identity);
            powercheck.DoubleCoinPower(true);
            coineffect.GetComponent<DoubleCoinEffect>().EnableEffect();
            slotcheck.AvaliableEffect(coineffect);
            choicemanager.SelectPower(gameObject);
        }
    }
}
