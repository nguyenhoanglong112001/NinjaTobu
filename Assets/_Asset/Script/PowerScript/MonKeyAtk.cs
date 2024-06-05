using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonKeyAtk : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject MonketAtk;
    [SerializeField] private Transform Mkspawnpoint;
    [SerializeField] private CheckSlotPower slotcheck;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerChoiceManager choicemanager;
    private GameObject MKspawn;
    [SerializeField] private CheckCoin check;
    [SerializeField] private SetGoldPower price;
    void Start()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonKeyAttacker()
    {
        if (MKspawn == null && slotcheck.CheckEffectAvaliable() && check.CoinCheck(price.GetPrice()))
        {
            MKspawn = Instantiate(MonketAtk, Mkspawnpoint.position, Quaternion.identity);
            powercheck.MonkeyAtkPower(true);
            MKspawn.GetComponent<MKAttackerEffect>().EnableEffect();
            slotcheck.AvaliableEffect(MKspawn);
            choicemanager.SelectPower(gameObject);
        }
    }
}
