using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(UnactiveObject), 2f);
    }

    private void UnactiveObject()
    {
        this.gameObject.SetActive(false);
    }
}
