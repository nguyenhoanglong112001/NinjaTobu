using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] private GameObject objprefab;
    [SerializeField] private Transform shootpoint;
    [SerializeField] private float shootdelay;
    public GameObject bullet;
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
        if (bullet == null && !IsShoot)
        {
            bullet = Instantiate(objprefab, shootpoint.position, Quaternion.identity);
            IsShoot = true;
            Invoke("ResetShoot", shootdelay);
        }
    }

    private void ResetShoot()
    {
        IsShoot = false;
    }
}
