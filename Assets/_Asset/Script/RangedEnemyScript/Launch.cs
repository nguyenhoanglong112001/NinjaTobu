using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class Launch : MonoBehaviour
{
    [SerializeField] private GameObject objprefab;
    [SerializeField] private Transform shootpoint;
    [SerializeField] private float shootdelay;
    [SerializeField] private EPObjectPoolerScriptableObject bulletpooler;
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
        GameObject bullet = bulletpooler.GetObject();
        bullet.transform.position = shootpoint.position;
        //if (bullet == null /*&& !IsShoot*/)
        //{
        //    bullet = Instantiate(objprefab, shootpoint.position, Quaternion.identity);
        //    //IsShoot = true;
        //    //Invoke("ResetShoot", shootdelay);
        //    //bullet = bulletpooler.GetObject();
        //    //bullet.transform.position = shootpoint.position;
        //    //IsShoot = true;
        //    //Invoke("ResetShoot", shootdelay);
        //}
    }
}
