using System;

public class CustomEvents
{
    public static event Action<Item> OnPickupItem;
    public static void FirePickupItem(Item item)
    {
        OnPickupItem?.Invoke(item);
    }

    public static event Action OnDropItem;
    public static void FireDropItem()
    {
        OnDropItem?.Invoke();
    }

    public static event Action<bool> OnAimToggle;
    public static void FireAimToggle(bool state)
    {
        OnAimToggle?.Invoke(state);
    }

    public static event Action OnPlayerChangeDirection;
    public static void FirePlayerChangeDirection()
    {
        OnPlayerChangeDirection?.Invoke();
    }
}
