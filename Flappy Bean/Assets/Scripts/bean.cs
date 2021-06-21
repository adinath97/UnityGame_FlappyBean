using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bean : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    public static bool startBeanMovement,playerDead;
    private Rigidbody2D myRigidbody;
    private Vector2 startingGravityValue;
    
    // Start is called before the first frame update
    void Start()
    {
        startBeanMovement = false;
        playerDead = false;
        myRigidbody = this.GetComponent<Rigidbody2D>();
        startingGravityValue = Physics2D.gravity;
        if(startingGravityValue == Vector2.zero) {
            startingGravityValue = new Vector2(0,-9.8f);
        }
        Physics2D.gravity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(startBeanMovement) {
            Physics2D.gravity = startingGravityValue;
            if(Input.GetMouseButtonDown(0)) {
                myRigidbody.velocity = Vector2.zero;
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,moveSpeed);
                //myRigidbody.AddForce(new Vector2(0,moveSpeed), ForceMode2D.Impulse);
            }
            if(myRigidbody.velocity.y > 0) {
                //Debug.Log("ONE");
                RotateBean.ChangeCurrentAngle(Quaternion.Euler(0,0,25f));
            }
            if(myRigidbody.velocity.y <= 0) {
                //Debug.Log("TWO");
                RotateBean.ChangeCurrentAngle(Quaternion.Euler(0,0,0f));
                //RotateBean.ChangeCurrentAngle(Quaternion.Euler(0,0,-25f));
            }
            if(myRigidbody.velocity.y == 0) {
                //Debug.Log("THREE");
                //RotateBean.ChangeCurrentAngle(Quaternion.Euler(0,0,0f));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.name != "ground") {
            GameManager.gameOver = true;
            playerDead = true;
            startBeanMovement = false;
            Physics2D.gravity = new Vector2(0,-9.8f);
            RotateBean.ChangeCurrentAngle(Quaternion.Euler(0,0,-90f));
            this.GetComponent<Animator>().enabled = false;
        }
    }
}
