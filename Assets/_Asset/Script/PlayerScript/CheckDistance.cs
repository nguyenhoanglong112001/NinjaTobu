using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    private float previousdistance;
    private float currentdistance;
    [SerializeField] private Transform targetposition;
    private bool isgoingup;

    void Start()
    {
        targetposition = GameObject.FindWithTag("StartPoint").GetComponent<Transform>();
        previousdistance = Vector2.Distance(transform.position, targetposition.position);
    }
    private void Update()
    {
        DistanceCheck();
    }
    private void DistanceCheck()
    {
        currentdistance = Vector2.Distance(transform.position, targetposition.position);

        if(currentdistance <= previousdistance)
        {
            isgoingup = false;
        }
        if (currentdistance > previousdistance)
        {
            isgoingup = true;
        }
        currentdistance = previousdistance;
    }

    public bool GetCheck()
    {
        return isgoingup;
    }
}
