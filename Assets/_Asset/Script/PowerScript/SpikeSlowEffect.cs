using UnityEngine;

public class SpikeSlowEffect :MonoBehaviour
{
    [SerializeField] private GameObject Spike;
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimagine;
    [SerializeField] private PowerCheck powercheck;

    public void EnableEffect()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        Spike = GameObject.Find("SpikeGround");
        if(powercheck.SpikeSlowCheck())
        {
            //powerui.ShowPower(powerimagine);
            Spike.GetComponent<TrapMove>().SetSpeed(-0.4f);
        }
    }

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimagine);
        if(Spike != null)
        {
            Spike.GetComponent<TrapMove>().SetSpeed(0.4f);
            powercheck.SpikeSlowPower(false);
        }
    }
}
