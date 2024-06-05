using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFlow : MonoBehaviour
{
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
    [SerializeField] private CheckDistance checkdistance;
    [SerializeField] private List<MonoBehaviour> scriptCom;

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
        checkpower = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        checkdistance = GameObject.FindWithTag("Player").GetComponent<CheckDistance>();
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
        scriptCom.Add(checkdistance);
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

    private void Awake()
    {
        GetCom();
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
