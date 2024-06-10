using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float speedMultiplier = 3f;
    [SerializeField] private Rigidbody2D player;
    void Start()
    {
    }

    void Update()
    {
        MoveTrap();
    }

    void MoveTrap()
    {
        if(player != null)
        {
            if (player.velocity.y > 0.1f)
            {
                transform.Translate(Vector2.up * moveSpeed * speedMultiplier * Time.deltaTime);
            }
            else if (player.velocity.y < -0.1f)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
        }
    }


    public void SetSpeed(float speed)
    {
        moveSpeed += speed;
    }
}
