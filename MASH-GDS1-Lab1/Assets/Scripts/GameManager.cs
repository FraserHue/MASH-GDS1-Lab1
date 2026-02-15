using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winText;

    public Pickup pickup;

    bool gameEnded = false;

    void Start()
    {
        gameOverText.SetActive(false);
        winText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        gameOverText.SetActive(true);
        DisableHelicopter();
    }

    public void CheckWinCondition()
    {
        if (gameEnded) return;

        if (AllSoldiersCollected())
        {
            gameEnded = true;
            winText.SetActive(true);
            DisableHelicopter();
        }
    }

    bool AllSoldiersCollected()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
        return soldiers.Length == 0 && pickup.SoldiersInHelicopter == 0;
    }

    void DisableHelicopter()
    {
        HelicopterController controller = FindFirstObjectByType<HelicopterController>();
        if (controller != null)
            controller.enabled = false;
    }
}