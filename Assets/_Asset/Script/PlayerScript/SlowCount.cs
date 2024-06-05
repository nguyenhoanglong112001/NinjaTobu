using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SlowCount :MonoBehaviour
{
    public int slowcount;
    [SerializeField] private int maxslow;
    [SerializeField] private PowerCheck check;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("WallLeft") || collision.CompareTag("WallRight") || collision.CompareTag("UpGround") || collision.CompareTag("DownGround") || collision.CompareTag("SideLeft") || collision.CompareTag("SideRight"))
        {
            slowcount = maxslow;
        }
    }

    public void MaxSlowUp(int maxslowcount)
    {
        maxslow += maxslowcount;
    }

    //private void SlowPower()
    //{
    //    if(check.isjumppower)
    //    {
    //        maxslow += 1;
    //        check.isjumppower = false;
    //    }
    //}
    private void Start()
    {
    }
}
