using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCheck : MonoBehaviour
{
    [SerializeField] private Animator anima;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SideGround"))
        {
            anima.SetTrigger("IsWalling");
        }
        else if (collision.CompareTag("UpGround"))
        {
            anima.SetBool("IsGround", true);
        }
        else if (collision.CompareTag("DownGround"))
        {
            anima.SetBool("IsDown", true);
        }
    }
}
