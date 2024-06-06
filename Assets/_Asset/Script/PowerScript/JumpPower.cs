using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    [SerializeField] private GameObject JumpEffect;
    private GameObject jumpeffect;
    [SerializeField] private Transform pointtransform;
    [SerializeField] private AudioSource triplesound;
    // Start is called before the first frame update
    void Start()
    {
        pointtransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        triplesound = GameObject.Find("TriplePowerSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(triplesound!=null)
            {
                triplesound.Play();
            }
            if (jumpeffect == null)
            {
                jumpeffect = Instantiate(JumpEffect, pointtransform.position, Quaternion.identity);
                jumpeffect.GetComponent<JumpEffect>().EnableJumpEffect();   
            }
            Destroy(gameObject);
        }
    }
}
