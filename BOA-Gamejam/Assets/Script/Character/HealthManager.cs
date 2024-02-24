using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        if(slider != null)
        {
            slider.maxValue = health;
            slider.value = health;
        }
    }

    public void SetHealth(int health)
    {
        if (slider != null)
        {
            slider.value = health;
        }
    }
}
