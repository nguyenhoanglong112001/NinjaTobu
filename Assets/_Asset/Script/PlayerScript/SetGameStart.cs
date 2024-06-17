using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameStart : MonoBehaviour
{
    [SerializeField] private SpriteAnimator listcharacter;
    [SerializeField] private SpriteRenderer ninja;
    [SerializeField] private Animator ninjaanimator;
    [SerializeField] private GetIntData getdata;
    [SerializeField] private SoundManager sound;
    [SerializeField] private Jump jumpspeed;
    [SerializeField] private PlayerDetection knockback;
    [SerializeField] private SlowCheck slowtime;
    [SerializeField] private Transform playerposition;
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
        int index = getdata.GetData("equied",0);
        ninja.sprite = listcharacter.GetSpriteList()[index];
        ninjaanimator.runtimeAnimatorController = listcharacter.GetAnimatorlist()[index];
        jumpspeed.SetSpeed(getdata.GetFloatData("speed", 0));
        jumpspeed.SetGravity(getdata.GetFloatData("GravityScale", 0));
        slowtime.SetSlow(getdata.GetFloatData("slowtime", 0));
        knockback.SetKnockBack(getdata.GetFloatData("KnockForce", 0));
        sound.SetJumpSoundClip(listcharacter.GetJumpClips()[index]);
        sound.SetDeathSound(listcharacter.GetDeathClips()[index]);
        sound.SetSoundAttack(listcharacter.GetattackClips()[index]);
        var effect = getdata.GetData("Effect", 0);
        var Effectpre = Instantiate(listcharacter.GetListEffect()[effect], playerposition.position, Quaternion.identity);
        Effectpre.transform.SetParent(playerposition);
    }
}
