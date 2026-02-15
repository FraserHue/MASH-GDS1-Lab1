using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text rescuedText;
    public TMP_Text inHelicopterText;

    Pickup pickup;
    Hospital hospital;

    void Awake()
    {
        pickup = FindFirstObjectByType<Pickup>();
        hospital = FindFirstObjectByType<Hospital>();
    }

    void Update()
    {
        if (pickup == null) pickup = FindFirstObjectByType<Pickup>();
        if (hospital == null) hospital = FindFirstObjectByType<Hospital>();

        int inHeli = pickup != null ? pickup.SoldiersInHelicopter : 0;
        int rescued = hospital != null ? hospital.SoldiersRescued : 0;

        if (rescuedText != null)
            rescuedText.text = "Soldiers Rescued: " + rescued;

        if (inHelicopterText != null)
            inHelicopterText.text = "Soldiers in Helicopter: " + inHeli;
    }
}