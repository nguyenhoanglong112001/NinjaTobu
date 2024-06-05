using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCharacter : MonoBehaviour
{
    [SerializeField] private ShopManager shopmanager;
    [SerializeField] private GameObject display;
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject costobj;
    [SerializeField] private GameObject check;
    [SerializeField] private GameObject equip;
    [SerializeField] private RuntimeAnimatorController animator;
    [SerializeField] private AudioSource equipcharacter;
    [SerializeField] private AudioSource equipfail;
    [SerializeField] private bool isbuy;
    [SerializeField] private bool isequip;
    [SerializeField] private AudioSource EquipSound;
    [SerializeField] private AudioClip soundVO;
    [SerializeField] private AudioClip soundequip;

    [SerializeField] private float speed;
    [SerializeField] private float timeslow;
    [SerializeField] private float gravity;
    [SerializeField] private float knockback;
    [SerializeField] private Sprite Shuriken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBuy();
        CheckEquip();
    }
    public void Choice()
    {
        shopmanager.SetCharacter(gameObject);
        shopmanager.SetImageCharacte(image);
        shopmanager.SetAnimator(animator);
        shopmanager.SetShuriken(Shuriken);
        shopmanager.SetSoundClip(soundequip);
        SetSoundClip();
        if (!display.activeSelf)
        {
            display.SetActive(true);
        }
        if (!isbuy)
        {
            equipfail.Play();
        }
        else if (isbuy)
        {
            equipcharacter.Play();
        }
    }

    private void SetSoundClip()
    {
        EquipSound.clip = soundVO;
        EquipSound.Play();
    }

    public void SetBuy(bool active)
    {
        isbuy = active;
    }

    public bool GetBool()
    {
        return isbuy;
    }

    public void SetEquip(bool equip)
    {
        isequip = equip;
    }    

    public bool GetEquip()
    {
        return isequip;
    }

    private void CheckBuy()
    {
        if (isbuy)
        {
            costobj.SetActive(false);
            check.SetActive(true);
        }
        else
        {
            costobj.SetActive(true);
            check.SetActive(false);
        }    
    }

    private void CheckEquip()
    {
        if (isequip)
        {
            equip.SetActive(true);
        }
        else
        {
            equip.SetActive(false);
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetSlow()
    {
        return timeslow;
    }

    public float GetGravity()
    {
        return gravity;
    }

    public float GetKnockForce()
    {
        return knockback;
    }

    public Sprite GetImage()
    {
        return image;
    }

    public RuntimeAnimatorController GetAnimator()
    {
        return animator;
    }
}
