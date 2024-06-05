using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private GetIntData highscore;
    [SerializeField] private Text alltimescore;
    // Start is called before the first frame update
    void Start()
    {
        alltimescore.text = highscore.GetData("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
