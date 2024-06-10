using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerControll player;
    [SerializeField] private PowerCheck checkpower;
    [SerializeField] private GroundCheck groundcheckcom;
    [SerializeField] private WallCheck wallcheckcom;
    [SerializeField] private AnimationCheck animacheck;
    [SerializeField] private SlowCount slowcountcom;
    [SerializeField] private PlayerDetection playerditect;
    [SerializeField] private PlayerAttack playeratk;
    [SerializeField] private Shuriken shurikencom;
    [SerializeField] private Jump jumpcom;
    [SerializeField] private SlowCheck slowcheckcom;
    //[SerializeField] private SpawnCoin spawncoincom;
    [SerializeField] private TrapMove trapcomponent;
    [SerializeField] private MonkeyStart monketstartcom;
    [SerializeField] private MonkeyStart goldmkcom;
    [SerializeField] private GamePoint score;
    [SerializeField] private List<MonoBehaviour> scriptCom;

    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject PowerUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject CoinUI;

    [SerializeField] private SaveData data;
    [SerializeField] private GetIntData getdata;
    [SerializeField] private CoinUpdate cointotal;
    [SerializeField] private CoinUI coinui;

    [SerializeField] private CheckSlotPower checkslot;
    [SerializeField] private GooglePlayManager playmanager;

    private bool isplaying = false;
    private bool isadd;
    private bool iscollectadd;
    private bool isend;
    [SerializeField] private int timeplaying;
    [SerializeField] private float timer = 0;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InItMK();
        StartGame();
        CountTime();
        if (!isplaying)
        {
            return;
        }
        if(!player.alive && !isend)
        {
            EndGame();
        }
    }
    private void Awake()
    {
        GetCom();
        Init();
    }

    private void GetCom()
    {   
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControll>();
        groundcheckcom = GameObject.FindWithTag("Player").GetComponent<GroundCheck>();
        wallcheckcom = GameObject.FindWithTag("Player").GetComponent<WallCheck>();
        animacheck = GameObject.FindWithTag("Player").GetComponent<AnimationCheck>();
        slowcheckcom = GameObject.FindWithTag("Player").GetComponent<SlowCheck>();
        slowcountcom = GameObject.FindWithTag("Player").GetComponent<SlowCount>();
        playerditect = GameObject.FindWithTag("Player").GetComponent<PlayerDetection>();
        playeratk = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
        shurikencom = GameObject.FindWithTag("Player").GetComponent<Shuriken>();
        jumpcom = GameObject.FindWithTag("Player").GetComponent<Jump>();
        //spawncoincom = GameObject.FindWithTag("SpawnPoint").GetComponent<SpawnCoin>();
        checkpower = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        trapcomponent = GameObject.FindWithTag("SpikeGround").GetComponent<TrapMove>();
        playmanager = GameObject.Find("GooglePlayManager").GetComponent<GooglePlayManager>();

    }    
    private void AddMKReffent()
    {
        if (monketstartcom != null && !isadd)
        {
            scriptCom.Add(monketstartcom);
            DisableComponents();
            isadd = true;
        }
    }    
    private void AddMKcollectReffent()
    {
        if (goldmkcom != null && !iscollectadd)
        {
            scriptCom.Add(goldmkcom);
            DisableComponents();
            iscollectadd = true;
        }
    }
    private void Init()
    {
        GetReferrence();
        DisableComponents();
    }
    private void GetReferrence()
    {
        scriptCom = new List<MonoBehaviour>();

        scriptCom.Add(groundcheckcom);
        scriptCom.Add(wallcheckcom);
        scriptCom.Add(animacheck);
        scriptCom.Add(slowcountcom);
        scriptCom.Add(slowcheckcom);
        scriptCom.Add(playerditect);
        scriptCom.Add(playeratk);
        scriptCom.Add(shurikencom);
        scriptCom.Add(jumpcom);
        scriptCom.Add(slowcheckcom);
        //scriptCom.Add(spawncoincom);
        scriptCom.Add(trapcomponent);
        scriptCom.Add(goldmkcom);
        scriptCom.Add(score);
    }

    private void StartGame()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseposition = Input.mousePosition;
            if (!IsPointerOverUIObject(mouseposition))
            {
                isplaying = true;
                PowerUI.SetActive(false);
                CoinUI.SetActive(false);
                EnableComponents();
            }
            else if (IsPointerOverUIObject(mouseposition))
            {
                return;
            }
        }
    }

    private void GetMKReference()
    {
        if (checkpower.MonkeyAtkCheck())
        {
            monketstartcom = GameObject.FindWithTag("MonkeyAttacker").GetComponent<MonkeyStart>();
        }
        if(checkpower.MonkeyCollectCheck())
        {
            goldmkcom = GameObject.FindWithTag("MonkeyCollector").GetComponent<MonkeyStart>();
        }
    }
    private void EndGame()
    {
        endUI.SetActive(true);
        GameUI.SetActive(false);
        CoinUI.SetActive(true);
        data.Save("coin", cointotal.GetTotalCoin());
        data.SaveCoinData("currentcoin", getdata.GetData("coin", 0));
        foreach (var slot in checkslot.GetPowerArr())
        {
            if (PlayerPrefs.HasKey(slot.name))
            {
                int timeuse = getdata.GetData(slot.name, 0);
                timeuse -= timeplaying;
                data.Save(slot.name, timeuse);
            }
        }
        isend = true;
        isplaying = false;
        //DisableComponents();
        AddManager.Instance.interstitialAd.SetAdUnitId("Interstitial_Android");
        AddManager.Instance.interstitialAd.LoadAd();
        AddManager.Instance.interstitialAd.ShowAd();
    }

    private void InItMK()
    {
        GetMKReference();
        AddMKReffent();
        AddMKcollectReffent();
    }

    private void DisableComponents()
    {
        SetActiveComponents(false);
    }

    private void EnableComponents()
    {
        SetActiveComponents(true);
    }

    private void SetActiveComponents(bool isActive)
    {
        foreach (var component in scriptCom)
        {
            if (component != null)
            {
                component.enabled = isActive;
            }
        }
    }

    private bool IsPointerOverUIObject(Vector2 position)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void CountTime()
    {
        if(isplaying)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timeplaying += 1;
                timer = 0;
            }
            if(timeplaying >= 30)
            {
                if(Social.localUser.authenticated)
                {
                    PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_play_time, 100, (result) =>
                    {
                        if (result)
                        {
                            Debug.Log("success");
                        }
                        else
                        {
                            Debug.Log("failed");
                        }
                    });
                }
            }
        }
    }
}
