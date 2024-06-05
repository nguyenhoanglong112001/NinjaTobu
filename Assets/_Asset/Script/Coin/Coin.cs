using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinUpdate coin;
    [SerializeField] private GameObject effectcoin;
    [SerializeField] private SpriteRenderer coindis;
    [SerializeField] private PowerCheck check;
    [SerializeField] private AudioSource coinsound;
    private GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        check = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        coin = GameObject.Find("coinnum").GetComponent<CoinUpdate>();
        coinsound = GameObject.Find("CollectCoinSound").GetComponent<AudioSource>();
        if (!check.DoubleCoinCheck())
        {
            coin.SetCoinPoint(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MonkeyCollector"))
        {
            coinsound.Play();
            coin.UpdateCoin(coin.GetCoinPoint());
            Debug.Log(coin.GetCoinPoint());
            StartCoroutine(StartEffect());
            Destroy(gameObject);
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
