using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource equip;
    [SerializeField] private AudioSource equipfail;
    [SerializeField] private AudioClip backgroundsound;
    [SerializeField] private AudioSource deathsound;
    [SerializeField] private AudioClip deathsoundV;
    [SerializeField] private AudioClip Attacksound;
    [SerializeField] private AudioSource soundattack;
    [SerializeField] private AudioClip[] jumpsoundclip;
    [SerializeField] private AudioSource jumpsound;

    [SerializeField] private GetIntData getdata;
    [SerializeField] private AudioSource[] sound;
    // Start is called before the first frame update
    void Start()
    {
        background.clip = backgroundsound;
        background.Play();
        if(Attacksound != null)
            soundattack.clip = Attacksound;
    }

    // Update is called once per frame
    void Update()
    {
        if(getdata.GetData("music",0) == 0)
        {
            background.gameObject.SetActive(false);
        }
        else
        {
            background.gameObject.SetActive(true);
        }

        foreach (var s in sound)
        {
            if(getdata.GetData("sound",0) == 0)
            {
                s.gameObject.SetActive(false);
            }
            else
            {
                s.gameObject.SetActive(true);
            }
        }
    }

    public void PlaySoundUI()
    {
        button.Play();
    }

    public void EquipSound()
    {
        equip.Play();
    }

    public void EquipFail()
    {
        equipfail.Play();
    }


    public void SetDeathSound(AudioClip sound1)
    {
        deathsoundV = sound1;
        deathsound.clip = deathsoundV;
    }

    public void SetSoundAttack(AudioClip attack)
    {
        Attacksound = attack;
        soundattack.clip = Attacksound;
    }

    public void SetJumpSound()
    {
        int index = Random.Range(0, jumpsoundclip.Length);
        jumpsound.clip = jumpsoundclip[index];
    }
        
    public void SetJumpSoundClip(AudioClip sound)
    {
        jumpsoundclip[1] = sound;
    }
}
