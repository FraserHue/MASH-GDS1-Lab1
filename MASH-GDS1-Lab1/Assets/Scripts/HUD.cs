using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text rescuedText;
    public TMP_Text inHelicopterText;
    public TMP_Text timerText;

    Pickup pickup;
    GameManager gameManager;

    void Awake()
    {
        pickup = FindFirstObjectByType<Pickup>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (pickup == null) pickup = FindFirstObjectByType<Pickup>();
        if (gameManager == null) gameManager = FindFirstObjectByType<GameManager>();

        int inHeli = pickup != null ? pickup.SoldiersInHelicopter : 0;
        int rescued = gameManager != null ? gameManager.SoldiersRescued : 0;

        if (rescuedText != null)
            rescuedText.text = "Soldiers Rescued: " + rescued;

        if (inHelicopterText != null)
            inHelicopterText.text = "Soldiers in Helicopter: " + inHeli;

        if (timerText != null && gameManager != null)
        {
            int secondsLeft = Mathf.CeilToInt(gameManager.TimeRemaining);
            timerText.text = "Time: " + secondsLeft;
        }
    }
}