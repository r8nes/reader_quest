using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class TypeWritterUtility : MonoBehaviour
{
    [Range(0.01f, 0.1f)]
    public float TypingSpeed = 0.05f;
    public TextMeshProUGUI TextMeshProComponent;

    private string _originalText;
    private StringBuilder _currentText;

    private void Start()
    {
        _originalText = TextMeshProComponent.text;
        _currentText = new StringBuilder();
    }

    public IEnumerator UpdateText(string text)
    {
        TextMeshProComponent.text = "";

        for (int i = 0; i <= _originalText.Length - 1; i++)
        {
            _currentText.Append(text);
            TextMeshProComponent.text = _currentText.ToString();
            yield return new WaitForSeconds(TypingSpeed);
        }
    }
}