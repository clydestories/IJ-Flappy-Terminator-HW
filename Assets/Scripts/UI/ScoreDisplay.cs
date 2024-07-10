using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _score.ValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _score.ValueChanged -= UpdateValue;
    }

    private void UpdateValue(float value)
    {
        _text.text = value.ToString();
    }
}
