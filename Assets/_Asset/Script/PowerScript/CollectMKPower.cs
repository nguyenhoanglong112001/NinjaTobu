using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMKPower : MonoBehaviour
{
    [SerializeField] private GameObject MonkeyCollect;
    [SerializeField] private Transform Mkspawnpoint;
    [SerializeField] private CheckSlotPower slotcheck;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerChoiceManager choicemanager;
    private GameObject spawnMK;
    [SerializeField] private CheckCoin check;
    [SerializeField] private SetGoldPower price;
    // Start is called before the first frame update
    void Start()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonKeyCollect()
    {
        if (spawnMK == null && slotcheck.CheckEffectAvaliable() && check.CoinCheck(price.GetPrice()))
        {
            spawnMK = Instantiate(MonkeyCollect, Mkspawnpoint.position, Quaternion.identity);
            powercheck.MonkeycollectPower(true);
            spawnMK.GetComponent<MKCollectEffect>().EnableEffect();
            slotcheck.AvaliableEffect(spawnMK);
            choicemanager.SelectPower(gameObject);
        }
    }
}
