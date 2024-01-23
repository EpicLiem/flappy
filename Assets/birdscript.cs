using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public float RoationRate;
    public bool birdIsAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( (Vector3.forward * -RoationRate) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            transform.eulerAngles = Vector3.zero;
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (Math.Abs(transform.position.y) > 22.2)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
