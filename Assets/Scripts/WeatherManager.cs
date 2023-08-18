using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private string weatherBaseURL = $"https://api.openweathermap.org/data/2.5/weather";//
    private string weatherFinalURL = "";
    public string apiKey = "de195e7ebbd7e4d741c7c06108db15f4";

    // Start is called before the first frame update
    void Start()
    {
        Delegates.OnUpdatedPointerPosition += CallWeatherAPI;
    }

    private void OnDestroy()
    {
        Delegates.OnUpdatedPointerPosition -= CallWeatherAPI;
    }

    private void CallWeatherAPI(float lat, float lon)
    {
        StartCoroutine(CallAPI(lat, lon));
    }
    private IEnumerator CallAPI(float latitude, float longitude)
    {
        Debug.Log("Calling Weather API");
        UnityWebRequest request = UnityWebRequest.Get($"{weatherBaseURL}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Weather API request failed: {request.error}");
            yield break;
        }

        string response = request.downloadHandler.text;
        Debug.Log($"{response}");
        WeatherData data = JsonUtility.FromJson<WeatherData>(response);
        ShowWhetherData(data);
    }

    public void ShowWhetherData(WeatherData weatherData)
    {
        string temperature = $"Temperature: {weatherData.main.feels_like} °C";
        string humidity = $"Humidity: {weatherData.main.humidity}%";
        string windSpeed = $"Wind Speed: {weatherData.wind.speed} m/s";
        string description = weatherData.weather[0].description;
        Delegates.OnCollectedWeatherData?.Invoke($"{temperature}\n{humidity}\n{windSpeed}\n{description}");
    }
}
