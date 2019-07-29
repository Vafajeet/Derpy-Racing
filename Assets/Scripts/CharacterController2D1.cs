using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class CharacterController2D1 : MonoBehaviour
{
    [SerializeField]
    float speed = 9;
    [SerializeField]
    float walkAcceleration = 75;
    [SerializeField]
    float airAcceleration = 30;
    [SerializeField]
    float groundDeceleration = 70;
    [SerializeField]
    float jumpHeight = 4;
    private BoxCollider2D boxCollider;
    private Vector2 velocity;
    private bool grounded;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnBecameInvisible()
    {

        gameObject.SetActive(false);
    }
    private void Update()
    {
        //jump input
        if (grounded)
        {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump2"))
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));


        }

        //gravity
        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;
        //joystick for movement
        float buttons = Input.GetAxisRaw("MH2");

        //side to side movement
        if (buttons != 0)
            velocity.x = Mathf.MoveTowards(velocity.x, speed * buttons, acceleration * Time.deltaTime);
        else
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);

        transform.Translate(velocity * Time.deltaTime);

        //collision detection
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        grounded = false;
        foreach (Collider2D hits in hit)
        {
            if (hits == boxCollider)
                continue;

            ColliderDistance2D colDistance = hits.Distance(boxCollider);

            if (colDistance.isOverlapped && hits.gameObject.layer != 8)
            {
                if (Vector2.Angle(colDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
                transform.Translate(colDistance.pointA - colDistance.pointB);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Glue"))
        {
            Debug.Log("Hello");
            speed = 4;
            //jumpHeight = 0;
            //airAcceleration = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       
        speed = 9;
        //jumpHeight = 4;
        //airAcceleration = 30;
    }
}
