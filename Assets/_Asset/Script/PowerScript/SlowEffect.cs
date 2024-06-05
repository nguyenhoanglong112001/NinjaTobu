using System.Collections;
using UnityEngine;

public class SlowEffect :MonoBehaviour
{
    [SerializeField] private PowerCheck power;
    [SerializeField] private SlowCheck slowtime;
    [SerializeField] private PowerUI powerUI;
    [SerializeField] private Sprite powerimage;
    void Start()
    {
    }
    public void EnableSlowEffect()
    {
        power = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        slowtime = GameObject.FindWithTag("Player").GetComponent<SlowCheck>();
        powerUI = GameObject.Find("Power").GetComponent<PowerUI>();
        powerUI.ShowOnUI(powerimage);
        StartCoroutine(SlowPowerTime());
    }

    IEnumerator SlowPowerTime()
    {
        power.SlowPower(true);
        slowtime.SlowTimeUp(-0.3f);
        yield return new WaitForSeconds(power.powertime);
        slowtime.SlowTimeUp(0.3f);
        power.SlowPower(false);
    }
}
