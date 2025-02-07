using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellObject : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    float coolDownTime = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "foot" )
        {
            var temp = collision.gameObject.transform.position;
            if (temp.x < transform.position.x)
            {
                rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            }
            StartCoroutine(countCoolDown());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            if(coolDownTime == 3)
            {
                GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
            }
        }
        if (collision.gameObject.tag == "Pile")
        {
            var temp = collision.gameObject.transform.position;
            if (temp.x < transform.position.x)
            {
                rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            }
        }
    }

    private IEnumerator countCoolDown()
    {
        coolDownTime -= 1;
        yield return new WaitForSeconds(1);
        if(coolDownTime > 0)
        {
            StartCoroutine(countCoolDown());
        }
        else
        {
            coolDownTime = 3;
        }
    }

}
