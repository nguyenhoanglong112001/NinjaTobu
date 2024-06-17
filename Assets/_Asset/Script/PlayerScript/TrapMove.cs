using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float gospeed = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform ground;
    [SerializeField] private float distancethrehod;
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
            var distance = Vector2.Distance(player.position, ground.position);
            if (distance > distancethrehod)
            {
                transform.Translate(Vector2.up * gospeed * Time.deltaTime);
            }
            else if (distance < distancethrehod)
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
