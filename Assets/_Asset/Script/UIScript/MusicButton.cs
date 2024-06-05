using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active()
    {
        if (on.activeSelf && !off.activeSelf)
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        else if (!on.activeSelf && off.activeSelf)
        {
            on.SetActive(true);
            off.SetActive(false);
        }
    }
}
