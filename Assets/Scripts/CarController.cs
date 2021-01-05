using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private int delta;
    private float movement;
 

    public float speed = 10.0f;
    public float force = 100f;
    public float kmh;
    public Rigidbody2D rb;
    private float anchor = 0f;
    private bool isgrounded = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        kmh = rb.velocity.magnitude * 3.6f;

        float move = Input.GetAxis("Horizontal") * speed;

        move *= Time.deltaTime;

        transform.Translate(move, 0, 0);

        if (kmh < 200 && Input.GetKeyDown("space"))
        {

            rb.AddForce(transform.right * force);
        }
        if (transform.rotation.eulerAngles.z != anchor && isgrounded == false)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 320)
        {
           
            SceneManager.LoadScene("Car");
        }



    }
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "floor")
        {
            isgrounded = true;
        }
    }


    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "floor")
        {
            isgrounded = false;
        }
    }





}
