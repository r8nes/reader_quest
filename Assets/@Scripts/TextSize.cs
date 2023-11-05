using UnityEngine;

public class TextSize : MonoBehaviour
{
    [SerializeField] private RectTransform _text;
    [SerializeField] private RectTransform _content;

    private void Update()
    {
        var size = _content.sizeDelta;
        size.y = _text.sizeDelta.y;
        _content.sizeDelta = size;
    }
}
