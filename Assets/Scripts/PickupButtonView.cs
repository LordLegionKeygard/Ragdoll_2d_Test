using UnityEngine;
using TMPro;

public class PickupButtonView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        CustomEvents.OnAimToggle += UpdateView;
    }

    public void UpdateView(bool isHaveItem)
    {
        _text.text = (isHaveItem) ? "Drop" : "Pickup";
    }

    private void OnDestroy()
    {
        CustomEvents.OnAimToggle -= UpdateView;
    }
}
