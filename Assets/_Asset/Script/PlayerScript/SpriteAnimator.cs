using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] spritelist;
    [SerializeField] private RuntimeAnimatorController[] animatorlist;
    [SerializeField] private AudioClip[] jumpsound;
    [SerializeField] private AudioClip[] deathsound;
    [SerializeField] private AudioClip[] attacksound;
    [SerializeField] private GameObject[] effectlist;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite[] GetSpriteList()
    {
        return spritelist;
    }

    public RuntimeAnimatorController[] GetAnimatorlist()
    {
        return animatorlist;
    }

    public AudioClip[] GetJumpClips()
    {
        return jumpsound;
    }

    public AudioClip[] GetDeathClips()
    {
        return deathsound;
    }

    public AudioClip[] GetattackClips()
    {
        return attacksound;
    }

    public GameObject[] GetListEffect()
    {
        return effectlist;
    }
}
