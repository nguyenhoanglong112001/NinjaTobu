using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    [SerializeField] private bool ismusicon;
    [SerializeField] private SaveData savesetting;
    [SerializeField] private GetData data;
    void Start()
    {
        if(data.GetIntData("music",0) == 0)
        {
            ismusicon = false;
        }
        else
        {
            ismusicon = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ismusicon)
        {
            on.SetActive(true);
            off.SetActive(false);
            ismusicon = true;
            savesetting.Save("music", 1);
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
            ismusicon = false;
            savesetting.Save("music", 0);
        }
    }
    public void MusicOn()
    {
        on.SetActive(true);
        off.SetActive(false);
        ismusicon = true;
        savesetting.Save("music", 1);
    }

    public void MusicOff()
    {
        on.SetActive(false);
        off.SetActive(true);
        ismusicon = false;
        savesetting.Save("music", 0);
    }

    public bool CheckMusic()
    {
        return ismusicon;
    }
}
