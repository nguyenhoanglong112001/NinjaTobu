using UnityEngine;
using Lean.Pool;
using System.Collections;

public class ShurikenDitect : MonoBehaviour
{
    public int kills;
    [SerializeField] private AudioSource hitwallsound;
    [SerializeField] private AudioSource hitenemysound;
    [SerializeField] private Vector3 rotationspeed;
    [SerializeField] private float time;
    private void Start()
    {
        hitwallsound = GameObject.Find("ShurikenHitWall").GetComponent<AudioSource>();
        hitenemysound = GameObject.Find("ShurikenHitEnemy").GetComponent<AudioSource>();
        StartCoroutine(ExistenceTime());
    }

    private void Update()
    {
        this.transform.Rotate(rotationspeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            kills += 1;
            collision.GetComponent<EnemyDeath>().Death();
            hitenemysound.Play();
        }
        if(!collision.CompareTag("Player") && !collision.CompareTag("Projectile") && !collision.CompareTag("Map"))
        {
            Debug.Log("abc");
            //Destroy(gameObject);
            LeanPool.Despawn(gameObject);
            hitwallsound.Play();
        }
        else
        {
            return;
        }
    }

    IEnumerator ExistenceTime()
    {
        yield return new WaitForSeconds(time);
        LeanPool.Despawn(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(ExistenceTime());
    }
}
