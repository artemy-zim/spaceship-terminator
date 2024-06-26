using System;
using UnityEngine;

public class InputImpulse : BaseInput
{
    public event Action Executed;

    public override void Execute()
    {
        if(Input.GetKeyDown(InputKeyCodesData.Impulse))
            Executed?.Invoke();
    }
}
