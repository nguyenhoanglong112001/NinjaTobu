using System.Collections.Generic;
using UnityEngine;

public class SlowPower : MonoBehaviour
{
    [SerializeField] private GameObject SlowEffect;
    private GameObject effectslow;
    [SerializeField] private Transform effectpoint;
    [SerializeField] private AudioSource slowsound;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        slowsound = GameObject.Find("SlowPowerSound").GetComponent<AudioSource>();
    }

    private void Start()
    {
        effectpoint = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(slowsound != null)
            {
                slowsound.Play();
            }
            if (effectslow == null)
            {
                effectslow = Instantiate(SlowEffect, effectpoint.position, Quaternion.identity);
                effectslow.GetComponent<SlowEffect>().EnableSlowEffect();
            }
            gameObject.SetActive(false);
        }
    }
}
