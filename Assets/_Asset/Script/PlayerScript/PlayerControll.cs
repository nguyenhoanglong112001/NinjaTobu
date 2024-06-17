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
    [SerializeField] private int life;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Imortal"))
        {
            life = 2;
        }
        else
        {
            life = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Death()
    {
        if(life > 1)
        {
            StartCoroutine(BlinkSprite(2.0f, 0.1f));
        }
        else if (life <= 1)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        StartCoroutine(StartEffect());
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

    IEnumerator BlinkSprite(float blinkduration,float blinkinterval)
    {
        float endtime = Time.time + blinkduration;
        while(Time.time < endtime)
        {
            sprite.enabled = !sprite.enabled;

            yield return new WaitForSeconds(blinkinterval);
        }
        sprite.enabled = true;
        life -= 1;
    }
}
