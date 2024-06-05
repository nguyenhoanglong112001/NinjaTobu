using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUseDisplay : MonoBehaviour
{
    [SerializeField] private int timeuse;
    [SerializeField] private Text timedisplay;
    [SerializeField] private GetIntData data;
    [SerializeField] private SaveData savedata;
    [SerializeField] private PickButton checkbuy;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(gameObject.name))
        {
            timeuse = data.GetData(gameObject.name, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisPlayTime();
        CheckTime();
    }

    private void DisPlayTime()
    {
        float minute = timeuse / 60;
        float second = timeuse % 60;

        string FormatedTime = string.Format("{0:00} : {1:00}", minute, second);

        timedisplay.text = FormatedTime;
    }

    private void CheckTime()
    {
        if(timeuse <= 0)
        {
            PlayerPrefs.DeleteKey(gameObject.name);
            checkbuy.SetBuy(false);
        }
    }

    public int GetTimeUse()
    {
        return timeuse;
    }
}
