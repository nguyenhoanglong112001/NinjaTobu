using UnityEngine;

public class DisableBox : MonoBehaviour
{
    [SerializeField] private GameObject attackbox;
    private void DisableHitBox()
    {
        attackbox.SetActive(false);
    }
}
