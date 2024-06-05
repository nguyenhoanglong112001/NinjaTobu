using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public bool alive = true;
    public bool a = true;
    [SerializeField] private GameObject effectdeath;
    private GameObject effect;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            Death();
        }
    }

    public void Death()
    {
        StartCoroutine(StartEffect());
        alive = false;
        DeathSound.Play();
    }

    IEnumerator StartEffect()
    {
        if(effect == null)
        {
            effect = Instantiate(effectdeath, transform.position, Quaternion.identity);
            effect.GetComponentInChildren<ParticleSystem>().Play();
            sprite.enabled = false;
            rig2d.gravityScale = 0.0f;
            yield return new WaitForSeconds(1.0f);
            Destroy(effect);
            Destroy(gameObject);
        }
    }
}
