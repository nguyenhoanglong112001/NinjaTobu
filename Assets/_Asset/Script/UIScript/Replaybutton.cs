using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replaybutton : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerpoint;
    private GameObject playerspawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgian()
    {
        SceneManager.LoadScene(1);
        if (playerspawn == null)
        {
            playerspawn = Instantiate(player, playerpoint.position, Quaternion.identity);
        }
    }
}
