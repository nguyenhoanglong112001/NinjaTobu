using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Launch : MonoBehaviour
{
    [SerializeField] private GameObject objprefab;
    [SerializeField] private Transform shootpoint;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private GameObject aimpoint;
    [SerializeField] private float speed;
    [SerializeField] private float shootdelay;
    [SerializeField] private LeanGameObjectPool pooler;
    private bool IsShoot = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot()
    {
        //pooler.Spawn(shootpoint.position);
        GameObject bullet = pooler.Spawn(shootpoint.position,Quaternion.identity);

        Rigidbody2D bulletrigi = bullet.GetComponent<Rigidbody2D>();

        if (bulletrigi != null)
        {
            var direction = aimpoint.transform.position - firepoint.transform.position;
            bulletrigi.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
        }
    }
}
