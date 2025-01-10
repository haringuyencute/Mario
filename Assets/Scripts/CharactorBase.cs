using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ActionType
{
    Left,
    Right, 
    Jump
}
public abstract class CharactorBase : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public float speed;
    public Rigidbody2D rigidbody2D;
    public bool groudCheck = true;
    public abstract void Init();
    public abstract void Hit();

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(ActionType.Right);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Move(ActionType.Jump);
        }
        if (!Input.anyKey)
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.Play("Idle");
        }
    }

    public virtual void Die()
    {

    }
    
    public virtual void Move(ActionType actionTypeParam)
    {
        if (!groudCheck)
        {
            return;
        }
        
        switch (actionTypeParam)
        {
            case ActionType.Left:
                rigidbody2D.velocity = new Vector2(-speed, 0);
                spriteRenderer.transform.localScale = new Vector3(-1,1,1);
                animator.Play("Move");
                break;
            case ActionType.Right:
                rigidbody2D.velocity = new Vector2(speed, 0)  ;
                spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
                animator.Play("Move");
                break;
            case ActionType.Jump:
                if(groudCheck)
                {
                    animator.Play("Jump");
                    rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, 2) * jumpForce);
                }
                break;
        }
    }
}
