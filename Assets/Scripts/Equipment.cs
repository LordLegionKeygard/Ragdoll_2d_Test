using UnityEngine;
using Zenject;

public class Equipment : MonoBehaviour
{
    [Inject] private DiContainer _diContainer;
    [SerializeField] private Item _currentEquipItem;
    [SerializeField] private GameObject _currentEquipObject;
    [SerializeField] private Transform _handPoint;
    public bool IsEquipItemNow() => _currentEquipItem != null;

    private void Start()
    {
        CustomEvents.OnPickupItem += EquipItem;
    }

    public void EquipItem(Item item)
    {
        if (_currentEquipObject != null) Dropitem();
        _currentEquipItem = item;
        _currentEquipObject = _diContainer.InstantiatePrefab(_currentEquipItem.EquipItem, _handPoint.position, _handPoint.rotation, null).gameObject;
        _currentEquipObject.transform.SetParent(_handPoint.transform);
        CustomEvents.FireAimToggle(true);
    }

    public void Dropitem()
    {
        if (_currentEquipObject == null) return;
        Destroy(_currentEquipObject);
        _diContainer.InstantiatePrefab(_currentEquipItem.DropItem, _handPoint.position, Quaternion.identity, null);
        _currentEquipItem = null;
        CustomEvents.FireAimToggle(false);
    }


    private void OnDestroy()
    {
        CustomEvents.OnPickupItem -= EquipItem;
    }
}
