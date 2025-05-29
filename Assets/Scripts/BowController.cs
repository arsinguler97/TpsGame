using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform fireArrow;
    [SerializeField] private ArrowConfig arrowConfig;

    private float _chargeTime;
    private bool _isCharging;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _isCharging = true;
            _chargeTime = 0f;
        }

        if (Input.GetButton("Fire1") && _isCharging)
        {
            _chargeTime += Time.deltaTime;
            _chargeTime = Mathf.Min(_chargeTime, arrowConfig.maxChargeTime);
        }

        if (Input.GetButtonUp("Fire1") && _isCharging)
        {
            FireArrow();
            _isCharging = false;
        }
    }

    private void FireArrow()
    {
        if (arrowPrefab != null && fireArrow != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, fireArrow.position, fireArrow.rotation);

            float chargeValue = _chargeTime / arrowConfig.maxChargeTime;
            float finalSpeed = Mathf.Lerp(arrowConfig.minSpeed, arrowConfig.maxSpeed, chargeValue);

            arrow.GetComponent<Arrow>().SetInitialSpeed(finalSpeed);
        }
    }
}