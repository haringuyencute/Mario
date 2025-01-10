using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public CharactorBase charactor;
    private void OnTriggerStay2D(Collider2D collision)
    {

       charactor.groudCheck = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        charactor.groudCheck = false;
    }
}
