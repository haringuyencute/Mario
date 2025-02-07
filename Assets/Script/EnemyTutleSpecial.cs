using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTutleSpecial : MonoBehaviour
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
        this.gameObject.transform.DOMoveX(postA.position.x, 2).OnComplete(delegate
        {
            spriteRenderer.transform.localScale = new Vector3(-1,1, 1);
            this.gameObject.transform.DOMoveX(postB.position.x, 2).OnComplete(delegate
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
        if (collision.tag == "foot")
        {
            Destroy(gameObject);
        }
    }
}
