using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private string keyname;
    //[SerializeField] private int value;
    [SerializeField] private GetIntData getdata;

    public static SaveData instance { get; private set; }
    void Start()
    {
        
    }

    public void Save(string keyname, int value)
    {
        PlayerPrefs.SetInt(keyname, value);
    }

    public void SaveString(string keyname,string objname)
    {
        PlayerPrefs.SetString(keyname, objname);
    }

    public void SaveCoinData(string keyname, int value)
    {
        int currentcoin = getdata.GetData(keyname, 0);
        currentcoin += value;
        PlayerPrefs.SetInt(keyname, currentcoin);
    }

    public void SaveFloat(string keyname, float value)
    {
        PlayerPrefs.SetFloat(keyname, value);
    }
}
