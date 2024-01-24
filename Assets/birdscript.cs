using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public float roationRate;
    public bool birdIsAlive = true;
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( (Vector3.forward * -roationRate) * Time.deltaTime);
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
        gameObject.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
