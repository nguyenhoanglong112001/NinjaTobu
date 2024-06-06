using UnityEngine;

public class SoundButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    [SerializeField] private bool issoundon;
    [SerializeField] private SaveData savesetting;
    [SerializeField] private GetIntData data;
    void Start()
    {
        if (data.GetData("sound",0) == 0)
        {
            issoundon = false;
        }
        else
        {
            issoundon = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(issoundon)
        {
            on.SetActive(true);
            off.SetActive(false);
            savesetting.Save("sound", 1);
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
            savesetting.Save("sound", 0);
        }
    }
    public void SoundOn()
    {
        on.SetActive(true);
        off.SetActive(false);
        issoundon = true;
        savesetting.Save("sound", 1);
    }

    public void SoundOff()
    {
        on.SetActive(false);
        off.SetActive(true);
        issoundon = false;
        savesetting.Save("sound", 0);
    }

    public bool CheckMusic()
    {
        return issoundon;
    }
}