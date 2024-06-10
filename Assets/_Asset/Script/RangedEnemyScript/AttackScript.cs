using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private float findranged;
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private Animator anima;
    [SerializeField] private Transform findpoint;
    [SerializeField] private Transform aimrange;
    [SerializeField] private float aimradius;
    [SerializeField] private Transform target;
    [SerializeField] private Transform head;
    private bool warningstate = false;
    [SerializeField] private float speed;
    [SerializeField] private Launch launch;
    [SerializeField] private int timedelay;
    [SerializeField] private GameObject alert;
    [SerializeField] private Transform cone;
    private bool isalaert = false;
    [SerializeField] private FlipEnemy flip;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDitect();
    }

    private void PlayerDitect()
    {
        var ditection = Physics2D.CircleCast(findpoint.position, findranged, transform.position, 0.0f, targetlayer);
        if (ditection.collider != null)
        {
            anima.SetBool("IsEnemy", true);
            StartCoroutine(SetAlert());
            warningstate = true;
            flip.enabled = false;
        }
        var aimranged = Physics2D.CircleCast(aimrange.position, aimradius, transform.position, 0.0f, targetlayer);
        if (aimranged.collider != null && warningstate)
        {
            Vector2 dir = head.position - target.position;
            if (dir.x < 0)
            {
                angle = Mathf.Atan2(dir.y * -1, dir.x* -1) * Mathf.Rad2Deg;
            }
            else
            {
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            head.rotation = Quaternion.RotateTowards(head.rotation, rotation, speed * Time.deltaTime);
            StartCoroutine(ScaleDown());
            InvokeRepeating("Shoot", 3.0f, timedelay);
        }
        else
        {
            warningstate = false;
            anima.SetBool("IsEnemy", false);
            CancelInvoke("Shoot");
            isalaert = false;
            StopCoroutine(StartCoroutine(ScaleDown()));
            cone.gameObject.SetActive(false);
            flip.enabled = true;
        }
    }

    IEnumerator SetAlert()
    {
        if(!isalaert)
        {
            alert.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            alert.SetActive(false);
            isalaert = true;
        }
    }

    private void Shoot()
    {
        launch.Shoot();
    }

    IEnumerator ScaleDown()
    {
        cone.gameObject.SetActive(true);
        float timeelapse = 0f;
        while (timeelapse < timedelay)
        {
            float time = timeelapse / timedelay;
            float ScaleY = Mathf.Lerp(1f, 0f, time);
            cone.localScale = new Vector3(cone.localScale.x, ScaleY, cone.localScale.z);

            timeelapse += Time.deltaTime;

            yield return null;
        }
        cone.localScale = new Vector3(cone.localScale.x, 1.0f, cone.localScale.z);
        StartCoroutine(ScaleDown());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(findpoint.position, findranged);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aimrange.position, aimradius);
    }
}
