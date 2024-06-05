using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private List<BaseInput> _inputs;

    private void Update()
    {
        Handle();
    }

    private void Handle()
    {
        foreach (var input in _inputs)
            input.Execute();
    }
}
