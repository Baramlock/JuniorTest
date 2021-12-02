using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void OnButtonClick()
    {
        _text.color = Color.blue;
        Debug.Log("Click");
    }
}
