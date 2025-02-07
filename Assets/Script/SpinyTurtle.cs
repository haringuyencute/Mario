using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpinyTurtle : MonoBehaviour
{
    public Animator animator;
    public Transform postA;
    public Transform postB;
    public Transform objTarget;

    private void Start()
    {
        if (GamePlaycontroller.instance.currentCharector != null)
        {
            objTarget = GamePlaycontroller.instance.currentCharector.transform;
        }
        animator.Play("Move");

        Move();

    }

    public void Move()
    {
        //this.transform.DOMoveX(postA.transform.position.x, 2).SetEase(Ease.Linear).OnComplete(delegate
        //{
        //    this.transform.DOMoveX(postB.transform.position.x, 2).SetEase(Ease.Linear).OnComplete(delegate
        //    {
        //        Move();
        //    });
        //});
        this.gameObject.transform.DOMoveX(10, 3);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
        }
        if(collision.gameObject.tag == "Pile")
        {
            while(this.transform.position.x > -10)
            {
                this.transform.DOMoveX(-10, 3);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "foot")
        {
            Destroy(gameObject);
        }
    }
}
