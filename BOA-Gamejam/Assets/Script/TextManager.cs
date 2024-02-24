using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject uiElement;
    public float delay = 5f;

    void Start()
    {
        Invoke("HideUIElement", delay);
    }

    void HideUIElement()
    {
        uiElement.SetActive(false);
    }
}
