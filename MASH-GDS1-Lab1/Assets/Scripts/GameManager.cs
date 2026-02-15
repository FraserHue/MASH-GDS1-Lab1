using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winText;

    public Pickup pickup;

    bool gameEnded = false;

    int soldiersRescued = 0;
    public int SoldiersRescued => soldiersRescued;

    void Start()
    {
        if (gameOverText != null) gameOverText.SetActive(false);
        if (winText != null) winText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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