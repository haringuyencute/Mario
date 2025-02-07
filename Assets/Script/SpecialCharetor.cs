using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCharetor : CharectorBase
{


    public override void Init()
    {

    }
    public override void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.RedMusrom:
                Debug.Log("An Nam");
                break;
            case HitType.Flower:
                Debug.Log("An hoa");
                break;
            case HitType.Enemy:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Big);
                break;
            case HitType.DeadZone:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Big);
                GamePlaycontroller.instance.HandleSetCurrentToFirstPosition();
                break;
        }
    }
}
