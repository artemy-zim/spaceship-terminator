using System;
using UnityEngine;

public class InputShoot : BaseInput
{
    public event Action OnExecuted;

    public override void Execute()
    {
        if(Input.GetKeyDown(InputKeyCodesData.Shoot))
            OnExecuted?.Invoke();
    }
}
