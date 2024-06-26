using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private string keyname;
    //[SerializeField] private int value;
    [SerializeField] private GetData getdata;

    EasyFileSave myfile;
    private List<string> characterbuy;
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
        int currentcoin = getdata.GetIntData(keyname, 0);
        currentcoin += value;
        PlayerPrefs.SetInt(keyname, currentcoin);
    }

    public void SaveFloat(string keyname, float value)
    {
        PlayerPrefs.SetFloat(keyname, value);
    }

    public void SaveList(string character)
    {
        characterbuy.Add(character);
    }
}
