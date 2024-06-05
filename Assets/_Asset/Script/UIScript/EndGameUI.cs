using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int totalcoin;
    [SerializeField] private Text coin;
    [SerializeField] private CoinUpdate coinup;
    private int totalkills;
    [SerializeField] private Text killshow;
    [SerializeField] private AttackDitection[] killcount;
    [SerializeField] private ShurikenDitect shurikenkill;
    [SerializeField] private GamePoint score;
    [SerializeField] private Text scoretext;
    [SerializeField] private SaveData highscore;
    [SerializeField] private GetIntData currenthighscore;
    void Start()
    {
        killcount[0] = GameObject.FindWithTag("Player").transform.GetChild(1).GetComponent<AttackDitection>();
        killcount[1] = GameObject.FindWithTag("Player").transform.GetChild(2).GetComponent<AttackDitection>();
        totalcoin = coinup.GetTotalCoin();
        foreach(var kill in killcount)
        {
            totalkills += kill.totalkill;
        }
        totalkills += shurikenkill.kills;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = totalcoin.ToString();
        killshow.text = totalkills.ToString();
        scoretext.text = Mathf.Round(score.GetScore()).ToString();
        if (score.GetScore() > currenthighscore.GetData("highscore",0))
        {
            highscore.Save("highscore", (int)Mathf.Round(score.GetScore()));
            if(Social.localUser.authenticated)
            {
                Social.ReportScore((long)score.GetScore(), GPGSIds.leaderboard_ninjatobuscore, LeaderboardUpdate);
            }
            
        }
    }

    private void LeaderboardUpdate(bool success)
    {
        if (success)
        {
            Debug.Log("Update LeaderBoard");
        }
        Debug.Log("Failed");
    }
}
