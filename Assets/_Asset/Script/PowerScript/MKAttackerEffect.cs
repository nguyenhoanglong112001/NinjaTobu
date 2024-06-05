using UnityEngine;

public class MKAttackerEffect : MonoBehaviour
{
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimage;

    public void EnableEffect()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        //if(powercheck.MonkeyAtkCheck())
        //{
        //    powerui.ShowPower(powerimage);
        //}
    }

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimage);
        powercheck.MonkeyAtkPower(false);
    }
}
