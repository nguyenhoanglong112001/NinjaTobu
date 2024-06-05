using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] attackbox;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layertarget;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AudioSource attacksoundsource;
    private bool HasAttack = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDitect();
    }

    private void EnemyDitect()
    {
        var hit = Physics2D.CircleCast(transform.position, radius, transform.position, 0f, layertarget);
        if(hit.collider != null)
        {
            if(sprite.flipX && !HasAttack)
            {
                attackbox[0].SetActive(true);
                attackbox[1].SetActive(false);
                HasAttack = true;
                attacksoundsource.Play();
            }
            else if(!sprite.flipX && !HasAttack)
            {
                attackbox[0].SetActive(false);
                attackbox[1].SetActive(true);
                HasAttack = true;
                attacksoundsource.Play();
            }
        }
        else
        {
            HasAttack = false;
        }
    }
}
