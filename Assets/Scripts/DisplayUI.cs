using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weatherDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Delegates.OnCollectedWeatherData += ShowUI;
    }
    private void OnDestroy()
    {
        Delegates.OnCollectedWeatherData += ShowUI;
    }

    private void ShowUI(string weatherData)
    {
        weatherDisplay.text = weatherData;
    }
}
