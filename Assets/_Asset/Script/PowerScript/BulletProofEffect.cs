using UnityEngine;

public class BulletProofEffect : MonoBehaviour
{
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimagine;
    [SerializeField] private PowerCheck powercheck;

    public void EnableEffect()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        //if(powercheck.BulletProofCheck())
        //{
        //    powerui.ShowPower(powerimagine);
        //}
    }

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimagine);
        powercheck.BulletProofPower(false);
    }
}
