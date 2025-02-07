using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedTutle : MonoBehaviour
{
    public Transform postA;
    public Transform postB;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        Move();
    }

    public void Move()
    {
        gameObject.transform.DOMoveX(postA.position.x, 2).SetEase(Ease.Flash).OnComplete(delegate
        {
            spriteRenderer.transform.localScale = new Vector3(-1,1,1);
            gameObject.transform.DOMoveX(postB.position.x, 2).SetEase(Ease.Flash).OnComplete(delegate
            {
                spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
                Move();
            });
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
        }
        if(collision.tag == "foot")
        {
            Destroy(gameObject);
        }
    }
}
