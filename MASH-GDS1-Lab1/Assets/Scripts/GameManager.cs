using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverText;
    public GameObject winText;

    public Pickup pickup;

    public float baseTimeSeconds = 6f;
    public float secondsPerSoldier = 2f;
    public float secondsPerTree = 1f;
    public float minTimeSeconds = 18f;
    public float maxTimeSeconds = 40f;

    bool gameEnded = false;

    float timeRemaining = 0f;
    bool timeConfigured = false;

    int soldiersRescued = 0;
    public int SoldiersRescued => soldiersRescued;
    public float TimeRemaining => timeRemaining;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        if (gameOverText != null) gameOverText.SetActive(false);
        if (winText != null) winText.SetActive(false);

        if (!timeConfigured)
            timeRemaining = Mathf.Clamp(baseTimeSeconds, minTimeSeconds, maxTimeSeconds);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            GameOver();
        }
    }

    public void ConfigureTimerFromCounts(int soldierCount, int treeCount)
    {
        float t = baseTimeSeconds + (soldierCount * secondsPerSoldier) + (treeCount * secondsPerTree);
        timeRemaining = Mathf.Clamp(t, minTimeSeconds, maxTimeSeconds);
        timeConfigured = true;
    }

    public void AddRescued(int amount)
    {
        if (amount <= 0) return;
        soldiersRescued += amount;
    }

    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (gameOverText != null) gameOverText.SetActive(true);
        DisableHelicopter();
    }

    public void CheckWinCondition()
    {
        if (gameEnded) return;

        if (pickup == null)
            pickup = FindFirstObjectByType<Pickup>();

        if (AllSoldiersCollected())
        {
            gameEnded = true;
            if (winText != null) winText.SetActive(true);
            DisableHelicopter();
        }
    }

    bool AllSoldiersCollected()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
        int inHeli = pickup != null ? pickup.SoldiersInHelicopter : 0;
        return soldiers.Length == 0 && inHeli == 0;
    }

    void DisableHelicopter()
    {
        HelicopterController controller = FindFirstObjectByType<HelicopterController>();
        if (controller != null)
            controller.enabled = false;
    }
}