using UnityEngine;

public class Hospital : MonoBehaviour
{
    public Pickup pickup;

    int soldiersRescued = 0;
    public int SoldiersRescued => soldiersRescued;

    void Awake()
    {
        if (pickup == null)
            pickup = FindFirstObjectByType<Pickup>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (pickup == null) return;
        if (!other.CompareTag("Player")) return;

        int dropped = pickup.DropOffAll();
        if (dropped > 0)
            soldiersRescued += dropped;
    }
}