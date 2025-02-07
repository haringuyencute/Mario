using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SmallCharector : CharectorBase
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
                break;
            case HitType.Enemy:
                GamePlaycontroller.instance.currentCharector.Die();
                break;
            case HitType.DeadZone:
                GamePlaycontroller.instance.currentCharector.Die();
                break;
        }
    }
}
