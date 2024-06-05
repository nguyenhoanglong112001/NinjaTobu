using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackon;
    [SerializeField] private float maxatk;
    [SerializeField] private Animator anima;
    [SerializeField] private float atkcount;
    [SerializeField] private float timedelay;
    [SerializeField] private GameObject vision;
    [SerializeField] private FlipEnemy flipcomponent;
    private bool hasattack = false;
    // Start is called before the first frame update
    void Start()
    {
        atkcount = maxatk;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ResetAtk());
    }

    private void EnableAttack()
    {
        if (atkcount > 0 && !hasattack)
        {
            attackon.SetActive(true);
            atkcount -= 1;
            hasattack = true;
        }
    }

    private void DisableAttack()
    {
        attackon.SetActive(false);
        hasattack = false;
    }

    IEnumerator ResetAtk()
    {
        if (atkcount == 0)
        {
            anima.SetBool("EndAtk", true);
            vision.SetActive(false);
            flipcomponent.enabled = false;

            yield return new WaitForSeconds(timedelay);

            anima.SetBool("EndAtk", false);
            vision.SetActive(true);
            flipcomponent.enabled = true;
            atkcount = maxatk;
        }
    }
}
