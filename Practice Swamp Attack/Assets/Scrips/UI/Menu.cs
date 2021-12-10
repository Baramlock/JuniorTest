using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpenPanel(GameObject _panel)
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
    }

    public void ClosePanel(GameObject _panel)
    {
        Time.timeScale = 1;
        _panel.SetActive(false);
    }
}
