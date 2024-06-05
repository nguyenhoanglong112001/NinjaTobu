using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] private GameObject shuriken;
    [SerializeField] private Transform[] point;
    private GameObject shurikenup;
    private GameObject shurikendown;
    private GameObject shurikenleft;
    private GameObject shurikenright;
    [SerializeField] private float speed;

    public void SetShurikenSprite(Sprite shurikensprite)
    {
        shuriken.GetComponent<SpriteRenderer>().sprite = shurikensprite;
    }

    private void Update()
    {
    }

    public void LaunchShuriken()
    {
        if(shurikendown == null && shurikenleft == null && shurikenright == null && shurikenup == null)
        {
            shurikenup = Instantiate(shuriken, point[0].position, Quaternion.identity);
            Rigidbody2D shuriup = shurikenup.GetComponent<Rigidbody2D>();
            shuriup.velocity = Vector2.up * speed;

            shurikendown = Instantiate(shuriken, point[1].position, Quaternion.identity);
            Rigidbody2D shuridown = shurikendown.GetComponent<Rigidbody2D>();
            shuridown.velocity = Vector2.down * speed;

            shurikenleft = Instantiate(shuriken, point[2].position, Quaternion.identity);
            Rigidbody2D shurileft = shurikenleft.GetComponent<Rigidbody2D>();
            shurileft.velocity = Vector2.left * speed;

            shurikenright = Instantiate(shuriken, point[3].position, Quaternion.identity);
            Rigidbody2D shuriright = shurikenright.GetComponent<Rigidbody2D>();
            shuriright.velocity = Vector2.right * speed;
            shurikenright.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
