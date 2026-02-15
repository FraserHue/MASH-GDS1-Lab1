using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text rescuedText;
    public TMP_Text inHelicopterText;

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
    }
}