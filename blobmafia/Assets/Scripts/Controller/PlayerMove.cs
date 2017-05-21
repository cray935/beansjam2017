using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5;
    public Rigidbody2D rb;

	public void moveLeft()
    {
        this.transform.position += Vector3.left * Time.deltaTime * speed;
        rb.AddForce(Vector3.left);
    }

    public void moveRight()
    {
        this.transform.position += Vector3.right * Time.deltaTime * speed;
       // rb.AddForce(Vector2.right, ForceMode2D.Force);
    }


    public void moveUp()
    {
        this.transform.position += Vector3.up * Time.deltaTime * speed;
    }

    public void moveDown()
    {
        this.transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
