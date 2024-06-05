using System.Collections;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    private PowerCheck power;
    private Jump jumpcount;
    private SlowCount slowcount;
    [SerializeField] private PowerUI powerUI;
    [SerializeField] private Sprite jumpimage;
    public void EnableJumpEffect()
    {
        power = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        jumpcount = GameObject.FindWithTag("Player").GetComponent<Jump>();
        slowcount = GameObject.FindWithTag("Player").GetComponent<SlowCount>();
        powerUI = GameObject.Find("Power").GetComponent<PowerUI>();
        powerUI.ShowOnUI(jumpimage);
        StartCoroutine(JumpPower());
    }
    IEnumerator JumpPower()
    {
        power.JumpPower(true);
        jumpcount.JumpUp(1);
        slowcount.MaxSlowUp(1);
        yield return new WaitForSeconds(power.powertime);
        jumpcount.JumpUp(-1);
        slowcount.MaxSlowUp(-1);
        power.JumpPower(true);
    }
}
