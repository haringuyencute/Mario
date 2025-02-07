using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTurtle : MonoBehaviour
{
    public Transform targetCharactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePlaycontroller.instance.currentCharector != null)
        {
            targetCharactor = GamePlaycontroller.instance.currentCharector.transform;
        }
    }
}
