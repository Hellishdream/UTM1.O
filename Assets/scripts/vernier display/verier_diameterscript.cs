using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class verier_diameterscript : MonoBehaviour
{
    public TextMeshProUGUI numberText; // Reference to your TMP text component
    public float updateInterval = 0.1f; // Time between number updates in seconds

    private int currentNumber = 80; // Starting number
    private float timer = 0f;

    void Start()
    {
        // If not assigned in inspector, try to get the TextMeshProUGUI component
        if (numberText == null)
        {
            numberText = GetComponentInChildren<TextMeshProUGUI>();
        }

        // Set initial number
        UpdateNumberDisplay();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to update the number
        if (timer >= updateInterval)
        {
            timer = 0f; // Reset timer

            // Decrease the number if we haven't reached 40
            if (currentNumber > 20)
            {
                currentNumber--;
                UpdateNumberDisplay();
            }
        }
    }

    void UpdateNumberDisplay()
    {
        // Update the text display
        numberText.text = currentNumber.ToString();
    }
}
