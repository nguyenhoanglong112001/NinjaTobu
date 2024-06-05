using UnityEngine;

public class ShurikenDitect : MonoBehaviour
{
    public int kills;
    [SerializeField] private AudioSource hitwallsound;
    [SerializeField] private AudioSource hitenemysound;
    [SerializeField] private Vector3 rotationspeed;
    private void Start()
    {
        hitwallsound = GameObject.Find("ShurikenHitWall").GetComponent<AudioSource>();
        hitenemysound = GameObject.Find("ShurikenHitEnemy").GetComponent<AudioSource>();
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
        if(!collision.CompareTag("Player") && !collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            hitwallsound.Play();
        }
    }
}
