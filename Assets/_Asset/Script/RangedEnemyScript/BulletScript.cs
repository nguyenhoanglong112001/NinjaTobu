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
    }

    private void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Map"))
        {
            return;
        }
        LeanPool.Despawn(gameObject);
        if (collision.CompareTag("Player"))
        {
            if(powercheck.BulletProofCheck())
            {
                return;
            }
            else
            {
                collision.GetComponent<PlayerControll>().Death();
            }
        }
    }
}
