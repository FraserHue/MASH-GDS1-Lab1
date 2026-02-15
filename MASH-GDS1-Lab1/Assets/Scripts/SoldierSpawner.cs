using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public Transform[] spawnPoints;
    public int soldiersToSpawn = 8;

    void Start()
    {
        if (soldierPrefab == null) return;
        if (spawnPoints == null || spawnPoints.Length == 0) return;

        int count = Mathf.Min(soldiersToSpawn, spawnPoints.Length);

        int[] indices = new int[spawnPoints.Length];
        for (int i = 0; i < indices.Length; i++)
            indices[i] = i;

        for (int i = 0; i < indices.Length; i++)
        {
            int j = Random.Range(i, indices.Length);
            int temp = indices[i];
            indices[i] = indices[j];
            indices[j] = temp;
        }

        for (int k = 0; k < count; k++)
        {
            Transform sp = spawnPoints[indices[k]];
            Instantiate(soldierPrefab, sp.position, Quaternion.identity);
        }
    }
}