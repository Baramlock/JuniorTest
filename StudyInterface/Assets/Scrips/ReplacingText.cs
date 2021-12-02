using System.Collections;
using TMPro;
using UnityEngine;

public class ReplacingText : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTMP;

    private Coroutine _startCoroutine;
    
    public void OnClickButton()
    {
        _startCoroutine ??= StartCoroutine(ChangeButton());
    }
    
    private IEnumerator ChangeButton()
    {
        var originalText = _textTMP.text;
        var originalColor = _textTMP.color;
        _textTMP.color = Color.red;
        _textTMP.text = "Dont Touch";
        yield return new WaitForSeconds(1);
        _textTMP.color = originalColor;
        _textTMP.text = originalText;
        _startCoroutine = null;
    }
    
    
}
