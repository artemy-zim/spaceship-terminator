using System;
using UnityEngine;

public class InputImpulse : BaseInput
{
    public event Action OnExecuted;

    public override void Execute()
    {
        if(Input.GetKeyDown(InputKeyCodesData.Impulse))
            OnExecuted?.Invoke();
    }
}
