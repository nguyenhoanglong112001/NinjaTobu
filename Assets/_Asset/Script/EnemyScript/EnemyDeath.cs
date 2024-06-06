using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject effectprefab;
    [SerializeField] private SpriteRenderer[] sprite;
    [SerializeField] private AudioSource deathaudio;
    [SerializeField] private GetIntData data;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindWithTag("Data").GetComponent<GetIntData>();
        //if(data.GetData("sound",0) == 1)
        //{
        //    deathaudio = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        //if(deathaudio != null)
        //{
        //    deathaudio.Play();
        //}
        StartCoroutine(StartEffect());
    }
    IEnumerator StartEffect()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            enemy = Instantiate(effectprefab, transform.position, Quaternion.identity);
            enemy.GetComponentInChildren<ParticleSystem>().Play();
            foreach(var spr in sprite)
            {
                spr.enabled = false;
            }
            yield return new WaitForSeconds(1.0f);
            Destroy(enemy);
        }
    }
}
