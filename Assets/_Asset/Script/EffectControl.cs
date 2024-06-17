using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    [SerializeField] private GameObject[] effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnableEffect();
    }

    private void EnableEffect()
    {
        if(Time.timeScale < 1)
        {
            foreach (var e in effect)
            {
                e.SetActive(true);
            }
        }
        else if (Time.timeScale >= 1)
        {
            foreach (var e in effect)
            {
                e.SetActive(false);
            }
        }
    }
}
