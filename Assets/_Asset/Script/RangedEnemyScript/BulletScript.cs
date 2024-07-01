using UnityEngine;
using TigerForge;
using Lean.Pool;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private GameObject aimpoint;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private float speed;
    private Vector3 direction;

    private void Start()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        //firepoint = GameObject.FindWithTag("FirePoint");
        //aimpoint = GameObject.FindWithTag("AimPoint");
        //if (firepoint != null)
        //{
        //    direction = aimpoint.transform.position - firepoint.transform.position;
        //    rig2d.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
        //    Debug.Log(direction);
        //}
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        //if (firepoint != null)
        //{
        //    direction = aimpoint.transform.position - firepoint.transform.position;
        //    rig2d.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
        //    Debug.Log(direction);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Map"))
        {
            return;
        }
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        LeanPool.Despawn(gameObject);
        if (collision.CompareTag("Player"))
        {
            if(powercheck.BulletProofCheck())
            {
                return;
            }
            else
            {
                //collision.GetComponent<PlayerControll>().Death();
            }
        }
    }
}
