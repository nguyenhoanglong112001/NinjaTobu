using UnityEngine;

public class MKCollectEffect :MonoBehaviour
{
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimage;

    public void EnableEffect()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        //if(powercheck.MonkeyCollectCheck())
        //{
        //    powerui.ShowPower(powerimage);
        //}
    }

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimage);
        powercheck.MonkeycollectPower(false);
    }
}
