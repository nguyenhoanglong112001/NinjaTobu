using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlowPower : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private GameObject spikeeffect;
    [SerializeField] private CheckSlotPower slotcheck;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerChoiceManager choicemanager;
    private GameObject effect;
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

    public void SpikeChoice()
    {
        if (effect == null && slotcheck.CheckEffectAvaliable() && check.CoinCheck(price.GetPrice()))
        {
            effect = Instantiate(spikeeffect, point.position, Quaternion.identity);
            powercheck.SpikeSlowPower(true);
            effect.GetComponent<SpikeSlowEffect>().EnableEffect();
            slotcheck.AvaliableEffect(effect);
            choicemanager.SelectPower(gameObject);
        }
    }
}
