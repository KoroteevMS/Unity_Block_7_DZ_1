using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Awake()
    {
        _text.text = _counter.StartedNumber.ToString();
        _counter.Changed += UpdateText;
    }

    private void OnDestroy()
    {
        _counter.Changed -= UpdateText;
    }

    private void UpdateText(int number)
    {
        _text.text = number.ToString();
    }
}