using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spirte;
    [SerializeField] private float timedelay;
    private Coroutine coroutine;
    private void Update()
    {
        coroutine = StartCoroutine(AutoFlip());
    }
    
    IEnumerator AutoFlip()
    {
        var scale = transform.localScale;
        if (scale.x == 1)
        {
            yield return new WaitForSeconds(timedelay);
            scale.x = -1;
        }
        else if (scale.x == -1)
        {
            yield return new WaitForSeconds(timedelay);
            scale.x = 1;
        }
        transform.localScale = scale;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Debug.Log(1);
    }
}