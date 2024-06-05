using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    [SerializeField] private ShopManager listcharacter;
    [SerializeField] private GetIntData getdata;
    [SerializeField] private SpriteRenderer ninjasprite;
    [SerializeField] private Animator aniamtor;
    // Start is called before the first frame update
    void Start()
    {
        SetStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStart()
    {
        foreach(var obj in listcharacter.GetListCharacter())
        {
            if(obj.name == getdata.GetStringData("equiped","no"))
            {
                var chocie = obj.GetComponent<ChoiceCharacter>();
                ninjasprite.sprite = chocie.GetImage();
                aniamtor.runtimeAnimatorController = chocie.GetAnimator();
                chocie.SetEquip(true);
            }
        }
    }
}
