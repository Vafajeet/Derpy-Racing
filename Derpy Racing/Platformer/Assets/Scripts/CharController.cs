using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float height = 1;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float apex = 1;
    public GameObject dive;
    public float jumpVelocity;
    public float gravity;

    Rigidbody rb;

    CharacterController charController;
    public GameObject playerObject;
    public Vector3 playerSpawn;
    Quaternion playerrotation;

    RaycastHit hit;

    public Vector2 velocity;
    Vector3 moveDirection;

       [SerializeField]
     float dashMult = 2;

      float curDash;
      float maxDash = 1.0f;
     float sSpeed = .1f;
     float dashWait;
      float maxWait = 6.0f;

    bool died = false;




    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();

        charController = gameObject.GetComponent<CharacterController>();

        gravity = -(2 * height) / Mathf.Pow(apex, 2);
        jumpVelocity = Mathf.Abs(gravity) * apex;

        print("Gravity " + gravity + "  Jump Velocity: " + jumpVelocity);
        //curDash = maxDash;
        // dashWait = maxWait;


    }

    private void FixedUpdate()
    {

        if ((charController.collisionFlags & CollisionFlags.Below) != 0)
        {
            velocity.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpVelocity;
            }
        }
    }
    void Update()
    {
        if (died)
        {
            charController.enabled = true;
            died = false;
        }

        if (Input.GetButton("Slam"))
        {
            dive.GetComponent<MeshRenderer>().enabled = true;
            dive.GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            dive.GetComponent<MeshRenderer>().enabled = false;
            dive.GetComponent<BoxCollider>().enabled = false;
        }


        if (gameObject.transform.position.y < -7f)
        {
            charController.enabled = false;
            transform.position = playerSpawn;
            print("Reseting Position of Player");
        }
        else
        {
           // charController.enabled = true;
        }


        Vector2 buttons = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.y += gravity * Time.deltaTime;
        velocity.x = buttons.x * speed;

        Debug.DrawRay(transform.position, Vector3.down, Color.red, 1.0f);









        if (Input.GetButtonDown("Dash") && dashWait >= 6)
        {
            curDash = 0.0f;
            dashWait = 0.0f;
        }
         if (dashWait <= maxWait)
         {
            dashWait += sSpeed;

          }
          if (curDash < maxDash)
          {
            velocity.x = velocity.x * dashMult;
              curDash += sSpeed;
          }
    
           if (curDash == maxDash)
              velocity.x = buttons.x * speed;




        charController.Move(velocity * Time.deltaTime);
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ladder")
        {
           // print("touching ladder");
            if (Input.GetButton("Climb"))
            {
               // print("tryna climb");
                velocity.x = 0;
                velocity.y = 7;
            }

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawn")
        {
            playerSpawn = other.transform.position;
        }
        if(other.tag == "Spawn2")
        {
            playerSpawn = other.transform.position;
        }
        if (other.tag == "Spawn3")
        {
            playerSpawn = other.transform.position;
        }
        if (other.tag == "Finish")
        {
            charController.enabled = false;
            died = true;
            transform.position = playerSpawn;
        }
        if(other.tag == "CDoor")
        {
            SceneManager.LoadScene("Ending");
        }
    }
    public IEnumerator SpawnB(GameObject go)
    {
        print("respawn bubble");
        yield return new WaitForSeconds(.4f);
        go.SetActive(true);
    }
}

