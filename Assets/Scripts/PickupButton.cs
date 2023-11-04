using UnityEngine;

public class PickupButton : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;
    [SerializeField] private PlayerPickup _playerPickup;
    

    public void PickupOrDrop()
    {
        if (_equipment.IsEquipItemNow())
        {
            _equipment.Dropitem();
        }
        else
        {
            _playerPickup.PickUp();
        }
    }
}
