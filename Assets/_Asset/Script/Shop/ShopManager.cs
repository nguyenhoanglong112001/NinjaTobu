using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject characterchoice;
    [SerializeField] private Sprite imagecharacter;
    [SerializeField] private RuntimeAnimatorController animatorchoice;
    [SerializeField] private GameObject[] listcharacter;
    [SerializeField] private GetIntData objequiped;
    [SerializeField] private GameObject ninja;
    [SerializeField] private Sprite shuriken;
    [SerializeField] private Sprite defaultshuriken;
    [SerializeField] private AudioSource EquipSound;
    [SerializeField] private AudioClip equipsound;
    [SerializeField] private SaveData saveconfig;
    void Start()
    {
        CheckIsBuy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataConfig()
    {
        var characterconfig = characterchoice.GetComponent<ChoiceCharacter>();
        saveconfig.SaveFloat("speed", characterconfig.GetSpeed());
        saveconfig.SaveFloat("slowtime", characterconfig.GetSlow());
        saveconfig.SaveFloat("GravityScale", characterconfig.GetGravity());
        saveconfig.SaveFloat("KnockForce", characterconfig.GetKnockForce());
        if(characterconfig.CheckLucky())
        {
            saveconfig.Save("LuckyCoin", 1);
        }
        else
        {
            PlayerPrefs.DeleteKey("LuckyCoin");
        }
        if(characterconfig.CheckImortal())
        {
            saveconfig.Save("Imortal", 1);
        }
        else
        {
            PlayerPrefs.DeleteKey("Imortal");
        }
    }

    public void SetSoundClip(AudioClip soundclip)
    {
        equipsound = soundclip;
    }

    public void PlaySound()
    {
        EquipSound.clip = equipsound;
        EquipSound.Play();
    }

    public void SetShuriken(Sprite shurikensprite)
    {
        if (shurikensprite == null)
        {
            shuriken = defaultshuriken;
        }
        else
        {
            shuriken = shurikensprite;
        }
    }

    private void CheckIsBuy()
    {
        foreach (var obj in listcharacter)
        {
            if (PlayerPrefs.HasKey(obj.name))
            {
                obj.GetComponent<ChoiceCharacter>().SetBuy(true);
            }
        }
    }

    public void SetAnimator(RuntimeAnimatorController animator)
    {
        animatorchoice = animator;
    }

    public GameObject[] GetListCharacter()
    {
        return listcharacter;
    }    

    public void SetCharacter(GameObject character)
    {
        characterchoice = character;
    }

    public void SetImageCharacte(Sprite imagecha)
    {
        imagecharacter = imagecha;
    }

    public GameObject GetChoice()
    {
        return characterchoice;
    }

    public Sprite GetImage()
    {
        return imagecharacter;
    }
    
    public RuntimeAnimatorController GetAnimator()
    {
        return animatorchoice;
    }

    public Sprite GetShurikenSprite()
    {
        return shuriken;
    }
}
