using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        UI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        UI.SetActive(false);
    }
}
