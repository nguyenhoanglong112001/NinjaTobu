using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEffect : MonoBehaviour
{
    [SerializeField] private GameObject effectchoice;
    [SerializeField] private Transform playerposition;
    [SerializeField] private GameObject effect;
    private GameObject effectprefab;
    [SerializeField] private GameObject[] listeffect;
    [SerializeField] private GetIntData getdata;
    // Start is called before the first frame update
    void Start()
    {
        listeffect[0].GetComponent<ChoiceEffect>().SetBuy(true);
        SetStart();
    }

    public void SetEffect(GameObject e)
    {
        effect = e;
        EffectChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoice(GameObject choice)
    {
        effectchoice = choice;
    }

    public GameObject[] GetArr()
    {
        return listeffect;
    }


    private void SetStart()
    {
        foreach(var e in listeffect)
        {
            if(PlayerPrefs.HasKey(e.name))
            {
                e.GetComponent<ChoiceEffect>().SetBuy(true);
            }
        }
        listeffect[getdata.GetData("Effect", 0)].GetComponent<ChoiceEffect>().SetChoice();
    }

    public void EffectChoice()
    {
        if (effectprefab == null)
        {
            effectprefab = Instantiate(effect, playerposition.position, Quaternion.identity);
            effectprefab.transform.SetParent(playerposition);
        }
        else if (effectprefab != null)
        {
            Destroy(effectprefab);
            effectprefab = Instantiate(effect, playerposition.position, Quaternion.identity);
            effectprefab.transform.SetParent(playerposition);
        }
    }
}
