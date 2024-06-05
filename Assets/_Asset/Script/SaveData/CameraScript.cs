using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        cam.Follow = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
