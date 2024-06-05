using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEffect : MonoBehaviour
{
    [SerializeField] private GameObject scaleplayer;
    [SerializeField] private PowerUI powerui;
    [SerializeField] private Sprite powerimagine;
    [SerializeField] private PowerCheck powercheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableEffect()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        scaleplayer = GameObject.FindWithTag("Player");
        if(powercheck.SmallPowerCheck())
        {
            //powerui.ShowPower(powerimagine);
            scaleplayer.transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    private void OnDestroy()
    {
        //powerui.UnShowPower(powerimagine);
        if(scaleplayer != null)
        {
            scaleplayer.transform.localScale = new Vector2(1.0f, 1.0f);
        }
        powercheck.SmallPower(false);
    }
}
