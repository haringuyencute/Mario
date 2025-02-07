using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTutle : MonoBehaviour
{
    public Transform postA;
    public Transform postB;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject sellObject;
    private void Start()
    {
        animator.Play("Move");
        Move();
    }

    public void Move()
    {
        //animator.Play("Move");
        this.transform.DOMoveX(postA.transform.position.x, 2).SetEase(Ease.Linear).OnComplete(delegate
        {
            spriteRenderer.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.DOMoveX(postB.transform.position.x, 2).SetEase(Ease.Linear).OnComplete(delegate
            {
                spriteRenderer.transform.localScale = new Vector3(1,1,1);
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
           // GamePlaycontroller.instance.currentCharector.rigidbody2D.AddForce(Vector2.up*2f, ForceMode2D.Impulse);
            this.gameObject.transform.DOKill();
            this.gameObject.SetActive(false);
            var shell = Instantiate(sellObject);
            shell.transform.position = this.transform.position - new Vector3(0,0.2f,0 );
        }
    }
}
