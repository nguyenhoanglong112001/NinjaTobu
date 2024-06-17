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
    [SerializeField] private SaveData save;

    [SerializeField] private float speed;
    [SerializeField] private float timeslow;
    [SerializeField] private float gravity;
    [SerializeField] private float knockback;
    [SerializeField] private Sprite Shuriken;
    [SerializeField] private bool luckycoin;
    [SerializeField] private bool imortal;
    [SerializeField] private bool slowmo;
    [SerializeField] private bool slow;
    [SerializeField] private bool strong;
    [SerializeField] private bool heavy;
    [SerializeField] private bool lighter;
    [SerializeField] private bool fast;
    [SerializeField] private bool shuriken;
    [SerializeField] private List<string> effect;
    // Start is called before the first frame update
    void Start()
    {
        if (luckycoin)
        {
            effect.Add(nameof(luckycoin));
        }
        if(slow)
        {
            effect.Add(nameof(slow));
        }
        if(slowmo)
        {
            effect.Add(nameof(slowmo));
        }
        if(strong)
        {
            effect.Add(nameof(strong));
        }
        if(imortal)
        {
            effect.Add(nameof(imortal));
        }
        if(lighter)
        {
            effect.Add(nameof(lighter));
        }
        if(heavy)
        {
            effect.Add(nameof(heavy));
        } 
        if(fast)
        {
            effect.Add(nameof(fast));
        }
        if(shuriken)
        {
            effect.Add(nameof(shuriken));
        }
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

    public bool CheckLucky()
    {
        return luckycoin;
    }

    public bool CheckImortal()
    {
        return imortal;
    }

    public List<string> GetListEffect()
    {
        return effect;
    }
}
