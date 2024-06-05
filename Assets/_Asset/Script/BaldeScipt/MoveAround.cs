using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float movingspeed;
    [SerializeField] private Animator anima;
    [SerializeField] private float angle1;
    [SerializeField] private float angle2;
    [SerializeField] private float threshold;
    public bool isangle1;
    void Start()
    {
        Vector3 rotation = new Vector3(0, 0, angle1);
        Quaternion newtotation = Quaternion.Euler(rotation);
        transform.rotation = newtotation;
    }

    // Update is called once per frame
    void Update()
    {
        Checklookdir();
    }


    private void Checklookdir()
    {
        transform.Rotate(Vector3.forward * movingspeed);
        float rotation = transform.rotation.eulerAngles.z;
        if (Mathf.Approximately(rotation,angle1))
        {
            movingspeed *= -1;
        }
        if (Mathf.Approximately(rotation,angle2))
        {
            movingspeed *= 1;
        }
    }
}
