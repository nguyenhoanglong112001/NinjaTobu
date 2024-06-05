using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSlotPower : MonoBehaviour
{
    [SerializeField] private GameObject[] SlotPower;
    [SerializeField] private List<GameObject> AvaliableSlot;
    [SerializeField] private List<GameObject> Effect;
    [SerializeField] private List<GameObject> Power;
    // Start is called before the first frame update
    void Start()
    {
        CheckSlotUnlock();
        CheckListAvaliable();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public GameObject GetObject(int index)
    {
        if (index < Power.Count)
            return Power[index];
        else
            return null;
    }

    public void SLotAdd(GameObject Slot)
    {
        AvaliableSlot.Add(Slot);
    }

    public bool CheckEffectAvaliable()
    {
        if(Effect.Count < AvaliableSlot.Count && AvaliableSlot.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckSlotAvaliable()
    {
        if (Power.Count < AvaliableSlot.Count && AvaliableSlot.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AvaliableEffect(GameObject effect)
    {
        Effect.Add(effect);
    }

    public void UnUseEffect(int index)
    {
        Destroy(Effect[index]);
        Effect.RemoveAt(index);
    }

    public void RemoveImageobj(int index)
    {
        Power.RemoveAt(index);
    }

    public List<GameObject> GetPowerArr()
    {
        return Power;
    }
    
    public void PowerChoice(GameObject power)
    {
        if(CheckSlotAvaliable())
            Power.Add(power);
    }

    public GameObject[] GetSlotArr()
    {
        return SlotPower;
    }

    private void CheckSlotUnlock()
    {
        for (int i =0;i<SlotPower.Length;i++)
        {
            if (PlayerPrefs.HasKey(SlotPower[i].name))
            {
                SlotPower[i].GetComponent<UnlockSlot>().CheckUnlock(true);
            }
        }
    }

    private void CheckListAvaliable()
    {
        foreach (var slot in SlotPower)
        {
            if(PlayerPrefs.HasKey(slot.name))
            {
                if(!AvaliableSlot.Contains(slot))
                {
                    AvaliableSlot.Add(slot);
                }
            }
        }
    }
}
