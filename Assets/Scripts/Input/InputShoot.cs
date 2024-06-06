using System;
using UnityEngine;

public class InputShoot : BaseInput
{
    public event Action Executed;

    public override void Execute()
    {
        if(Input.GetKeyDown(InputKeyCodesData.Shoot))
            Executed?.Invoke();
    }
}
