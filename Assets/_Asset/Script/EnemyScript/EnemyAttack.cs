using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackon;
    [SerializeField] private Animator anima;
    [SerializeField] private float timedelay;
    [SerializeField] private GameObject vision;
    [SerializeField] private FlipEnemy flipcomponent;
    [SerializeField] private EnemyDetection detect;
    private bool hasattack = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void EnableAttack()
    {
        attackon.SetActive(true);
        hasattack = true;
    }

    private void DisableAttack()
    {
        attackon.SetActive(false);
        hasattack = false;
    }
}
