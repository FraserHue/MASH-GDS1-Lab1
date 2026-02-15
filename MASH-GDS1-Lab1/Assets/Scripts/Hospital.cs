using UnityEngine;

public class Hospital : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Pickup heliPickup = other.GetComponentInParent<Pickup>();
        if (heliPickup == null) return;

        int dropped = heliPickup.DropOffAll();
        if (dropped <= 0) return;

        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.AddRescued(dropped);
            gm.CheckWinCondition();
        }
    }
}