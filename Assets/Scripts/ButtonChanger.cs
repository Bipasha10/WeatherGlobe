using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    public Button buttonHolographic;
    public Button buttonGlobe;
    public GameObject globeNormal;
    public GameObject globeHolographic;

    // Start is called before the first frame update
    void Start()
    {
        buttonHolographic.onClick.AddListener(SetHolographic);
        buttonGlobe.onClick.AddListener(SetNormal);
    }

    private void SetHolographic()
    {
        buttonGlobe.gameObject.SetActive(true);
        globeHolographic.SetActive(true);
        buttonHolographic.gameObject.SetActive(false);
        globeNormal.SetActive(false);
    }
    private void SetNormal()
    {
        buttonGlobe.gameObject.SetActive(false);
        globeHolographic.SetActive(false);
        buttonHolographic.gameObject.SetActive(true);
        globeNormal.SetActive(true);
    }
}
