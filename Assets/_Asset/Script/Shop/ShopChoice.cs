using UnityEngine;

public class ShopChoice :MonoBehaviour
{
    [SerializeField] private ShopMenu setshop;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject effec;
    [SerializeField] private AudioSource soundclick;


    public void choice()
    {
        setshop.SetShop(gameObject);
        soundclick.Play();
    }

}
