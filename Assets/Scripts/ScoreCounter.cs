using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> OnScoreChanged;

    public void Add()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }
}
