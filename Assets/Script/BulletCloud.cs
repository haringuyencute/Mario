using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCloud : MonoBehaviour
{
    private Vector3 postTarget;
    public Animator animator;
    public GameObject spinyTurtlePrefab;

    public void Start()
    {
        animator.Play("fall");
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GroundTile")
        {
            var postSpawn = this.gameObject.transform.position;
            Destroy(this.gameObject);
            Instantiate(spinyTurtlePrefab, new Vector3(postSpawn.x,postSpawn.y,0),Quaternion.identity);
        }
        if(collision.gameObject.tag == "Player")
        {
            GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
        }
    }
}
