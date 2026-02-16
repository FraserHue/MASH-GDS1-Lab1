using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject soldierPrefab;
    public Transform[] soldierSpawnPoints;
    public int minSoldiers = 8;
    public int maxSoldiers = 12;

    public GameObject treePrefab;
    public Transform[] treeSpawnPoints;
    public int minTrees = 2;
    public int maxTrees = 4;

    void Awake()
    {
        int soldiersSpawned = SpawnUnique(soldierPrefab, soldierSpawnPoints, minSoldiers, maxSoldiers);
        int treesSpawned = SpawnUnique(treePrefab, treeSpawnPoints, minTrees, maxTrees);

        if (gameManager == null)
            gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
            gameManager.ConfigureTimerFromCounts(soldiersSpawned, treesSpawned);
    }

    int SpawnUnique(GameObject prefab, Transform[] points, int minCount, int maxCount)
    {
        if (prefab == null) return 0;
        if (points == null || points.Length == 0) return 0;

        int desired = Random.Range(minCount, maxCount + 1);
        int count = Mathf.Min(desired, points.Length);

        int[] indices = new int[points.Length];
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
            Transform sp = points[indices[k]];
            Instantiate(prefab, sp.position, Quaternion.identity);
        }

        return count;
    }
}