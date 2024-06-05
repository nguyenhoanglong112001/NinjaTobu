using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDitection : MonoBehaviour
{
    public int totalkill;
    [SerializeField] private GamePoint score;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            totalkill += 1;
            score.AddScore(10);
            collision.GetComponent<EnemyDeath>().Death();
        }
    }
}
