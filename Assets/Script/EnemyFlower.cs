using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyFlower : MonoBehaviour
{
    private int cool = 3;
    private void Start()
    {
        move();
    }
    void move()
    {
        this.gameObject.transform.DOMoveY(1.9f, 3).OnComplete(delegate
        {
            StartCoroutine(cooldown()); 
        });
    }

    private IEnumerator MoveDownAfterCooldown()
    {
        yield return new WaitForSeconds(3); 
        this.gameObject.transform.DOMoveY(0.45f, 3).OnComplete(delegate
        {
            move(); 
        });
    }


    public IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
        }
    }
}
