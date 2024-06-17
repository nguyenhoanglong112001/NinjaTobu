using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour
{
    [SerializeField] private ShopManager manager;
    [SerializeField] private GameObject ninja;
    [SerializeField] private SaveData saveequip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEquip()
    {
        GameObject[] listcharacter = manager.GetListCharacter();
        GameObject objchocie = manager.GetChoice();
        var sprite = ninja.transform.GetChild(0).GetComponent<SpriteRenderer>();
        var animator = ninja.transform.GetChild(0).GetComponent<Animator>();
        var shurike = ninja.GetComponent<Shuriken>();
        sprite.sprite = manager.GetImage();
        animator.runtimeAnimatorController = manager.GetAnimator();
        shurike.SetShurikenSprite(manager.GetShurikenSprite());
        saveequip.SaveString("equiped", objchocie.name);
        saveequip.Save("equied", Array.IndexOf(listcharacter, objchocie));
        
        foreach (var obj in listcharacter)
        {
            if (obj == manager.GetChoice())
            {
                obj.GetComponent<ChoiceCharacter>().SetEquip(true);
            }
            else
            {
                obj.GetComponent<ChoiceCharacter>().SetEquip(false);
                obj.GetComponent<ChoiceCharacter>().SetEquip(false);
            }
        }
    } 
}
