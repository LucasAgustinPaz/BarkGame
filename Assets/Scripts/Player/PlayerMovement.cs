using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    public Transform player;
    bool inGround;
    Rigidbody2D rb;
    int jumpsCount;
    public int maxJumps;
    public SpriteRenderer SpriteRenderer;
    public BoxCollider2D Collider;

    public Sprite Idle;
    public Sprite Crouching;
    public Sprite Jumping;
    bool isCrouching;
    Sprite actualSprite;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
        actualSprite = SpriteRenderer.sprite;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Jump();
        }
        if (Input.GetKey("d"))
        {
            MoveRight();
        }
        if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        
        if (Input.GetKey("s") && inGround)
        {
            Crouch();
        }
        else if (isCrouching && Input.GetKeyUp("s"))
        {
            isCrouching = false;
            SpriteRenderer.sprite = actualSprite;
            Collider.size = StandingSize;
            player.transform.position = new Vector3(player.transform.position.x, 1.811f, player.transform.position.z);
            Debug.Log("Stands");
            Debug.Log(Collider.size);
        }

        if(!isCrouching && inGround && jumpsCount == 0){
            actualSprite = SpriteRenderer.sprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground" && !isCrouching)
        {
            SpriteRenderer.sprite = actualSprite;
            inGround = true;
        }

    }

    void Jump()
    {
        if (inGround)
        {
            SpriteRenderer.sprite = Jumping;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsCount++;

            if (jumpsCount == maxJumps)
            {
                inGround = false;
                jumpsCount = 0;
            }
        }
    }

    void Crouch()
    {
        if (inGround && !isCrouching)
        {
            isCrouching = true;
            player.transform.position += Vector3.down * speed * Time.deltaTime;
            SpriteRenderer.sprite = Crouching;
            Collider.size = CrouchingSize;
            Debug.Log("Crouch");
            Debug.Log(Collider.size);
            
        }
    }

    void MoveRight()
    {
        player.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void MoveLeft()
    {
        player.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
