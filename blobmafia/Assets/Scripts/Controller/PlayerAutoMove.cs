using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour {

    public PlayerMove moveScript;

    public int movesMax = 10;

    int moved = 0;

    float timeleft = 5.0f;

    bool stopMove = false;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (stopMove)
        {
            return;
        }
        
        if (timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            return;
        }

        if (moved < movesMax)
        {
            moveScript.moveRight();
            moved++;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GohstWall")
        {
            stopMove = true;
        }
    }

}
