using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GooglePlayManager : MonoBehaviour
{
    [SerializeField] private bool connectedToGooglePlay;
    private void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoginToGooglePlay();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    void LoginToGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthenticate);
    }


    private void ProcessAuthenticate(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            connectedToGooglePlay = true;
            Debug.Log("Login success");
            Debug.Log(connectedToGooglePlay);
        }
        else
        {
            connectedToGooglePlay = false;
        }
    }

    public void ShowLeaderBoard()
    {
        if(Social.localUser.authenticated)
        {
            Debug.Log(Social.localUser.authenticated);
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchivement()
    {
        if (Social.localUser.authenticated)
        {
            Debug.Log(Social.localUser.authenticated);
            Social.ShowAchievementsUI();
        }
    }

    public bool CheckConnect()
    {
        return connectedToGooglePlay;
    }
}
