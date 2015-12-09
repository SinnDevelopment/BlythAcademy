using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour 
{
    public float JumpForce = 700f;
    public float Speed = 1f;
    public float MaxSpeed = 10f;
    public float groundRadius = 0.2f;
    public float wallRadius = 0.3f;
  
    bool grounded = true;
    bool facingRight = true;
    bool onWall;
    bool doubleJump;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;

    Animator anim;
    CircleCollider2D cc;
    BoxCollider2D bc;

	public void Start () 
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CircleCollider2D>();
        bc = GetComponent<BoxCollider2D>();
	}
	public void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        onWall = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.acceleration.x * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.acceleration.x));

        if (Input.acceleration.x > 0 && !facingRight)
            Flip();
        else if (Input.acceleration.x < 0 && facingRight)
            Flip();
	}
    public void Update()
    {
        if(grounded || onWall)
            doubleJump = true;

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
                StopCoroutine("DisableCollision");
                StartCoroutine("DisableCollision");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -JumpForce));
                StartCoroutine("ReEnableCollision");
        }
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
                doubleJump = true;
            }
            else if(!grounded && doubleJump)
            {
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));

                doubleJump = false;
            }
        }
        if(onWall)
        {
            anim.SetBool("OnWall", true);
        }
    }

    public void OnGUI()
    {
        // Debug
        //GUI.Label(new Rect(0, 0, 100, 100), "On Wall: " + onWall.ToString());
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public IEnumerator DisableCollision()
    {
        cc.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator ReEnableCollision()
    {       
        cc.enabled = true;
        bc.enabled = true;
        yield return null;
    }
}
