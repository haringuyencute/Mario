using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyBrown : MonoBehaviour
{
    public Transform postA;
    public Transform postB;
    bool isAction = false;
    public SpriteRenderer spriteRenderer;
    public Sprite nomalSprite;
    public Sprite dieSprite;
    private void Start()
    {
        spriteRenderer.sprite = nomalSprite;
        Move();
    }
    private void Move()
    {
        this.transform.DOMoveX(postA.transform.position.x, 10).SetEase(Ease.Linear).OnComplete(delegate
        {
            //spriteRenderer.gameObject.transform.localScale = new Vector3(-1,1,1);
            if (postB != null)
            {
                this.transform.DOMoveX(postB.transform.position.x, 10).SetEase(Ease.Linear).OnComplete(delegate
                {
                    //spriteRenderer.gameObject.transform.localScale = new Vector3(1,1,1);
                    Move();
                });
            }
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isAction)
            {
                GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
            }
        }
        if (collision.tag == "foot")
        {
            if (!isAction)
            {
                isAction = true;
                spriteRenderer.sprite = dieSprite;
                this.transform.DOKill();
                this.transform.position -= new Vector3(0,0.25f,0);
               // Destroy(gameObject);
            }
        }
    }
}
