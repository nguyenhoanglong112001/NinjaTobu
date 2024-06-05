using System.Collections;
using UnityEngine;

public class ShurikenEffect:MonoBehaviour
{
    [SerializeField] private PowerCheck power;
    [SerializeField] private PowerUI powerUI;
    [SerializeField] private Sprite shurikenimage;
    public void EneableShuriken()
    {
        Debug.Log(3);
        power = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        powerUI = GameObject.Find("Power").GetComponent<PowerUI>();
        powerUI.ShowOnUI(shurikenimage);
        StartCoroutine(ShrurikenTime());
    }

    IEnumerator ShrurikenTime()
    {
        power.ShurikenPower(true);
        yield return new WaitForSeconds(power.powertime);
        power.ShurikenPower(false);
    }
}
