using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delegates
{
    public delegate void PointerPositionUpdated(float latValue, float lonValue);
    public static PointerPositionUpdated OnUpdatedPointerPosition;

    public delegate void CollectWeatherData(string weatherData);
    public static CollectWeatherData OnCollectedWeatherData;
}
