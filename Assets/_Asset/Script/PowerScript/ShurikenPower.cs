using System.Collections.Generic;
using UnityEngine;

public class ShurikenPower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shirieffect;
    private GameObject shurikeneff;
    [SerializeField] private Transform point;
    [SerializeField] private AudioSource ShurikenSound;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ShurikenSound = GameObject.Find("ShurikenPowerSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(ShurikenSound != null)
            {
                ShurikenSound.Play();
            }
            if(shurikeneff == null)
            {
                shurikeneff = Instantiate(shirieffect, point.position, Quaternion.identity);
                shurikeneff.GetComponent<ShurikenEffect>().EneableShuriken();
            }
            Destroy(gameObject);
        }
    }
}
