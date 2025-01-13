using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isAction = false;
        
        if (collision.gameObject.tag == "Player")
        {
            if (!isAction)
            {
                isAction = true;
                GamePlaycontroller.instance.currentCharector.Hit(HitType.RedMusrom);
                Destroy(this.gameObject);
            }
        }
    }
}
