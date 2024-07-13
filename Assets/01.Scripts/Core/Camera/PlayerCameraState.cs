using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraState : CameraState
{
   
    public override CameraState RegisterCamera()
    {
        base.RegisterCamera();

        return this;
    }
}
