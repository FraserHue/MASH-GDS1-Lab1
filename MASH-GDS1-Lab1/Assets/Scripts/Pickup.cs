using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int capacity = 3;
    public AudioSource audioSource;
    public AudioClip pickupClip;

    int soldiersInHelicopter = 0;
    public int SoldiersInHelicopter => soldiersInHelicopter;

    void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (soldiersInHelicopter >= capacity) return;
        if (!other.CompareTag("Soldier")) return;

        soldiersInHelicopter++;

        if (audioSource != null && pickupClip != null)
            audioSource.PlayOneShot(pickupClip);

        Destroy(other.gameObject);
    }

    public int DropOffAll()
    {
        int dropped = soldiersInHelicopter;
        soldiersInHelicopter = 0;
        return dropped;
    }
}