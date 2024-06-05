using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private float timeslow;
    [SerializeField] private GroundCheck groundcheck;
    [SerializeField] public float timedelay;
    [SerializeField] private SlowCount slowcount;
    public bool isslowpower;
    [SerializeField] private ShurikenPower powercheck;
    [SerializeField] private Shuriken shuriken;
    [SerializeField] private PowerCheck check;
    [SerializeField] private AudioSource SlowSound;
    void Update()
    {
        ActiveSlow();
    }

    private void ActiveSlow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!groundcheck.IsGround && slowcount.slowcount > 0)
            {
                SlowSound.Play();
                slowcount.slowcount -= 1;
                if(check.ShurikenCheck())
                {
                    shuriken.LaunchShuriken();
                }
                StartCoroutine(SlowTime());
            }
            else
            {
                return;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SlowSound.Stop();
            Time.timeScale = 1;
        }
    }

    IEnumerator SlowTime()
    {
        Time.timeScale = timeslow;

        yield return new WaitForSeconds(timedelay);

        Time.timeScale = 1;
    }

    public void SlowTimeUp(float slowtime)
    {
        timeslow += slowtime;
    }

    public void SetSlow(float slow)
    {
        timeslow = slow;
    }
}
