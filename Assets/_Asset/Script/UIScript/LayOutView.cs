using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayOutView : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastposition;
    [SerializeField] private HorizontalLayoutGroup layoutgroup;
    [SerializeField] private int scrollspeed;
    void Start()
    {
        lastposition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 currentposition = Input.mousePosition;

            float deltaX = currentposition.x - lastposition.x;
            if (deltaX > 0)
            {
                layoutgroup.padding.left += scrollspeed;
            }
            else if (deltaX < 0)
            {
                layoutgroup.padding.left -= scrollspeed;
            }
            if(layoutgroup.padding.left == -6200 || layoutgroup.padding.left >=0)
            {
                return;
            }
        }
    }
}
