using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class playerControl : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator animator;

    [SerializeField] float speed = 10;
    [SerializeField] float jump = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    
    // Update is called once per frame
    void Update()
    {

        //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"),0) * speed;

        animator.SetBool("walking", !(rb2d.velocity.x > -.5f && rb2d.velocity.x < .5f));

        if (rb2d.velocity.x < -.5f)
        {

            transform.rotation = Quaternion.Euler(0,180,0);

        }

        else if(rb2d.velocity.x > .5f)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        //jumps
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);

        }

        rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime / .02f);

    }

    private void FixedUpdate()
    {

        //rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);



    }
}
