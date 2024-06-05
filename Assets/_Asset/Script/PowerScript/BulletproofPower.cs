using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletproofPower : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private GameObject proofobj;
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
    public void BulletProofChoice()
    {
        if (effect == null && slotcheck.CheckEffectAvaliable() && check.CoinCheck(price.GetPrice()))
        {
            effect = Instantiate(proofobj, point.position, Quaternion.identity);
            powercheck.BulletProofPower(true);
            effect.GetComponent<BulletProofEffect>().EnableEffect();
            slotcheck.AvaliableEffect(effect);
            choicemanager.SelectPower(gameObject);
        }
    }
}
