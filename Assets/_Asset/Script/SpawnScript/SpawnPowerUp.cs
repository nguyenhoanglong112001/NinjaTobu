using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject[] power;
    [SerializeField] private int r;
    [SerializeField] private Transform spawnposition;
    private GameObject powerspawn;
    private bool isget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerSpawn();
    }

    private void PowerSpawn()
    {
        if (powerspawn == null && !isget)
        {
            r = Random.Range(0, power.Length);
            powerspawn = Instantiate(power[r], spawnposition.position, Quaternion.identity);
            isget= true;
        }
    }
}
