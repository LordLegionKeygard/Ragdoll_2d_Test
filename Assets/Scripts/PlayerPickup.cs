using System.Collections;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private bool _pickUpToggle;

    public void PickUp()
    {
        StartCoroutine(nameof(PickupCoroutine));
    }

    private IEnumerator PickupCoroutine()
    {
        _pickUpToggle = true;
        yield return new WaitForSeconds(0.5f);
        _pickUpToggle = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_pickUpToggle) return;
        if (other.gameObject.TryGetComponent(out ItemPickup itemPickup))
        {
            itemPickup.PickUp();
        }
    }
}
