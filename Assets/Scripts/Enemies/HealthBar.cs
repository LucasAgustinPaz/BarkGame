using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void updateHealthBar(float currVal, float maxVal)
    {
        slider.value = currVal / maxVal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
