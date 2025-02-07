using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemy : MonoBehaviour
{
    private struct PointInSpace
    {
        public Vector3 Position;
        public float Time;
    }

    [SerializeField]
    public Transform target;
    [SerializeField]
    public Vector3 offset;


    [SerializeField]
    private float delay = 0.5f;

    [SerializeField]

    private float speed = 5;

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();

    [SerializeField]
    private GameObject bullet;
    public int limitBullet = 2;
    public bool lockBullet;
    void FixedUpdate()
    {
        if(GamePlaycontroller.instance.currentCharector != null)
        {
            target = GamePlaycontroller.instance.currentCharector.transform;
        } 
        //this.gameObject.transform.position = offset;
        // Add the current target position to the list of positions
        pointsInSpace.Enqueue(new PointInSpace() { Position = new Vector2(target.transform.position.x, target.transform.position.y), Time = Time.time });
        // Move the camera to the position of the target X seconds ago 
        while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
        {
            transform.position = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
            transform.localScale = new Vector3(target.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (transform.localScale.x == -1)
        {
            offset.x = -1;
        }
        if (transform.localScale.x == 1)
        {
            offset.x = 1;
        }

        if(transform.position.x <= target.position.x +0.5 && transform.position.x <= target.position.x - 0.5)
        {
            SpawnBullet();
        }
    }

    

    private void SpawnBullet()
    {
        if (!lockBullet)
        {
            lockBullet = true;
            var temp = Instantiate(bullet);
            temp.transform.position = transform.position ;
            StartCoroutine(countTime());
        }
    }

    private IEnumerator countTime()
    {
        
        yield return new WaitForSeconds(limitBullet);
        Debug.Log("hihi");
        lockBullet = false;
    }
}
