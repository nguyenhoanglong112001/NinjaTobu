using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIScript : MonoBehaviour
{
    [SerializeField] private CheckSlotPower slotpower;
    [SerializeField] private GetIntData getdata;
    [SerializeField] private GameObject[] power;
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        slotpower.GetSlotArr()[0].GetComponent<UnlockSlot>().CheckUnlock(true);
    }
    void Start()
    {
        SetBuyPower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBuyPower()
    {
        foreach (var poweruse in power)
        {
            Debug.Log(poweruse.name);
            if (PlayerPrefs.HasKey(poweruse.name))
            {
                poweruse.GetComponent<PickButton>().SetBuy(true);
            }
        }
    }
}
