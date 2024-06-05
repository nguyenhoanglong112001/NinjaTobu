using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject[] Menu;
    [SerializeField] private GameObject option;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Option()
    {
        foreach (var canvas in Menu)
        {
            canvas.SetActive(true);
        }
        option.SetActive(false);
    }
}
