using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCharector : CharectorBase
{


    public override void Init()
    {

    }
    public override void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.RedMusrom:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Big);
                break;
            case HitType.Flower:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Special);
                Debug.LogError("flower");
                break;
        }
    }
}
