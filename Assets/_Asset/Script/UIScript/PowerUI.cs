using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PowerCheck check;
    [SerializeField] private Image[] imageSlot;
    [SerializeField] private SpriteRenderer[] imagePower;
    [SerializeField] private CheckSlotPower slotpower;
    [SerializeField] private GameFlow gameflow;
    void Start()
    {
        check = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowOnUI(Sprite imagine)
    {
        StartCoroutine(ShowImagePower(imagine));
    }

    public void ShowPower(Sprite imagine)
    {
        foreach(var power in imageSlot)
        {
            if(power.sprite == null)
            {
                power.gameObject.SetActive(true);
                power.sprite = imagine;
                break;
            }
        }
    }

    public void UnShowPower(Sprite imagine)
    {
        foreach (var power in imageSlot)
        {
            if (power.sprite == imagine)
            {
                power.gameObject.SetActive(false);
                power.sprite = null;
                break;
            }
        }
    }
    IEnumerator ShowImagePower(Sprite powerimage)
    {
        foreach (var power in imageSlot)
        {
            if (power.sprite == null)
            {
                power.gameObject.SetActive(true);
                power.sprite = powerimage;
                yield return new WaitForSeconds(check.powertime);
                power.sprite = null;
                power.gameObject.SetActive(false);
                break;
            }
        }  
    }
}
