using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float lastpoint;
    private float currentpoint;
    [SerializeField] private Text scoretext;
    private float score;
    [SerializeField] private float scorepersec;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            lastpoint = player.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score();
        scoretext.text = Mathf.Round(score).ToString();
    }

    private void Score()
    {
        currentpoint = player.transform.position.y;
        float distance = currentpoint - lastpoint;
        if (distance > 0)
        {
            score += scorepersec * Time.deltaTime;
        }
        lastpoint = currentpoint;
    }

    public float GetScore()
    {
        return score;
    }

    public void AddScore(float point)
    {
        score += point;
    }
}
