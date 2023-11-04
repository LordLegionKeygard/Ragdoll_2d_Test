using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item _item;

    public void PickUp()
    {
        CustomEvents.FirePickupItem(_item);
        Destroy(transform.parent.gameObject);
    }
}
