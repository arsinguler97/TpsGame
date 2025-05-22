using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform fireArrow;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireArrow();
        }
    }

    private void FireArrow()
    {
        if (arrowPrefab != null && fireArrow != null)
        {
            Instantiate(arrowPrefab, fireArrow.position, fireArrow.rotation);
        }
    }
}