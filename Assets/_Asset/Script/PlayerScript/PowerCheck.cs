using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isslowpower;
    private bool isjumppower;
   [SerializeField] private bool isshuriken;
    private bool doublecoin;
    private bool isproof;
    public float powertime;
    private bool IsMonkeyKills;
    private bool IsMonkeyCollect;
    private bool smallpower;
    private bool spikepower;
    void Start()
    {
        
    }

    public void SlowPower(bool issactive)
    {
        isslowpower = issactive;
    }

    public void JumpPower(bool issactive)
    {
        isjumppower = issactive;
    }

    public void ShurikenPower(bool issactive)
    {
        isshuriken = issactive;
    }

    public void DoubleCoinPower(bool issactive)
    {
        doublecoin = issactive;
    }

    public bool ShurikenCheck()
    {
        return isshuriken;
    }

    public bool SlowPowerCheck()
    {
        return isslowpower;
    }

    public bool JumpPowerCheck()
    {
        return isjumppower;
    }

    public bool DoubleCoinCheck()
    {
        return doublecoin;
    }

    public bool BulletProofCheck()
    {
        return isproof;
    }    

    public void BulletProofPower(bool active)
    {
        isproof = active;
    }

    public void MonkeyAtkPower(bool active)
    {
        IsMonkeyKills = active;
    }

    public bool MonkeyAtkCheck()
    {
        return IsMonkeyKills;
    }

    public void MonkeycollectPower(bool active)
    {
        IsMonkeyCollect = active;
    }

    public bool MonkeyCollectCheck()
    {
        return IsMonkeyCollect;
    }

    public bool SmallPowerCheck()
    {
        return smallpower;
    }

    public void SmallPower(bool active)
    {
        smallpower = active;
    }

    public void SpikeSlowPower(bool active)
    {
        spikepower = active;
    }

    public bool SpikeSlowCheck()
    {
        return spikepower;
    }    
    // Update is called once per frame
    void Update()
    { 
    }
}
