
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D my_rigidbody;
    private Vector3 change;
    private Animator anim;

    public bool canMove = true;
    public Object[] trail;
    public int trailIndex = 0;
    public int playerNum = 0;
    
    
    private int framecount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void GetInput(ref Vector3 change, KeyCode left, KeyCode right, KeyCode up, KeyCode down, KeyCode attack)
    {
        if (Input.GetKey(left))
            change.x = -1;
        if (Input.GetKey(right))
            change.x = 1;
        
        if (Input.GetKey(up))
            change.y = 1;
        if (Input.GetKey(down))
            change.y = -1;
        
        if (Input.GetKeyDown(attack))
            anim.SetTrigger("Attack");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            change = Vector3.zero;

            if (playerNum == 0 || playerNum == 1)
                GetInput(ref change, KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.Space);
            
            if (playerNum == 0 || playerNum == 2)
                GetInput(ref change, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.Return);
        }
    }


    private void FixedUpdate()
    {
        // bug fix (If p1 go through p2)
        my_rigidbody.velocity = Vector2.zero;
        
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        my_rigidbody.MovePosition(transform.position + change.normalized * speed * Time.fixedDeltaTime);

        if (change.x < 0f && change.y < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 225);
        else if (change.x < 0f && change.y > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 135);
        else if (change.x > 0f && change.y < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 315);
        else if (change.x > 0f && change.y > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 45);
        else if (change.x < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (change.x > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (change.y < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (change.y > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 90);

        // Trail
        if (framecount % 10 == 0)
            GameObject.Instantiate(trail[trailIndex], transform.position, transform.rotation);
        
        framecount++;
    }
}
