using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D my_rigidbody;
    private Vector3 change;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

        if (Input.GetButtonDown("Jump"))
            anim.SetTrigger("Attack");
    }

    void MoveCharacter()
    {
        my_rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);

        if (change.x < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (change.x > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (change.y < 0f)
            transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (change.y > 0f)
            transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
