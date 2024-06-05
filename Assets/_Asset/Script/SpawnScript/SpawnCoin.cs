using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private GameObject coin;
    private GameObject coinobj;
    private bool isspawn;
    // Start is called before the first frame update
    void Start()
    {
        CoinSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CoinSpawn()
    {
        if (coinobj == null && !isspawn)
        {
            coinobj = Instantiate(coin, Spawnpoint.position, Quaternion.identity);
            isspawn = true;
        }
    }
}
