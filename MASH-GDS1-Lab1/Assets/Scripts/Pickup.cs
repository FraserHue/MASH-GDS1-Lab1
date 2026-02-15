using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int capacity = 3;

    int soldiersInHelicopter = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (soldiersInHelicopter >= capacity) return;

        if (other.CompareTag("Soldier"))
        {
            soldiersInHelicopter++;
            other.gameObject.SetActive(false);
        }
    }

    public int GetSoldiersInHelicopter()
    {
        return soldiersInHelicopter;
    }
}