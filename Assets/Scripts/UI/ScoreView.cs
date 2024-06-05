using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _score.OnScoreChanged += UpdateView;
    }

    private void OnDisable()
    {
        _score.OnScoreChanged -= UpdateView;
    }

    private void UpdateView(int score)
    {
        _text.text = score.ToString();
    }
}
