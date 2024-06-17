using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinUpdate coin;
    [SerializeField] private GameObject effectcoin;
    [SerializeField] private SpriteRenderer coindis;
    [SerializeField] private AudioSource coinsound;
    [SerializeField] private GetIntData getdata;
    private GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        if(IsObjectActive("coinnum"))
        {
            coin = GameObject.Find("coinnum").GetComponent<CoinUpdate>();
        }
        getdata = GameObject.FindWithTag("Data").GetComponent<GetIntData>();
        if (getdata.GetData("sound",0) == 1)
        {
            coinsound = GameObject.Find("CollectCoinSound").GetComponent<AudioSource>();
        }
    }

    public bool IsObjectActive(string objectName)
    {
        GameObject obj = GameObject.Find(objectName);
        if (obj != null)
        {
            return obj.activeSelf;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MonkeyCollector"))
        {
            coin.UpdateCoin(coin.GetCoinPoint());
            StartCoroutine(StartEffect());
            Destroy(gameObject);
            if (coinsound != null)
            {
                coinsound.Play();
            }
        }
    }

    IEnumerator StartEffect()
    {
        if (effect == null)
        {
            effect = Instantiate(effectcoin, transform.position, Quaternion.identity);
            effect.GetComponentInChildren<ParticleSystem>().Play();
            coindis.enabled = false;
            yield return new WaitForSeconds(1.0f);
            Destroy(effect);
        }
    }
}
