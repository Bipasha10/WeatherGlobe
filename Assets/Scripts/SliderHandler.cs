using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    [SerializeField] private Slider longitudeSlider;
    [SerializeField] private Slider latitudeSlider;
    [SerializeField] private RotationController rotationController;

    private void OnEnable()
    {
        longitudeSlider.onValueChanged.AddListener((value) => SetVerticalRotaition(value));
        latitudeSlider.onValueChanged.AddListener((value) => SetHorizontalRotaition(value));
    }

    private void OnDisable()
    {
        longitudeSlider.onValueChanged.RemoveAllListeners();
        latitudeSlider.onValueChanged.RemoveAllListeners();
    }

    void SetVerticalRotaition(float value)
    {
        rotationController.VerticalRotation = value;
    }
    void SetHorizontalRotaition(float value)
    {
        rotationController.HorizontalRotation = value;
    }
}
