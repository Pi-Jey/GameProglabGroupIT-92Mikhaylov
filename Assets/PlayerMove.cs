using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public LayerMask groundLayerMask;
    public float velocity = 1000f;
    public float jump_force = 500f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal_input * velocity * Time.deltaTime, rb.velocity.y);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded(bc))
            rb.AddForce(new Vector2(0, jump_force));
    }

    public bool isGrounded(BoxCollider2D character)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(character.bounds.center, Vector2.down, character.bounds.extents.y + 0.02f, groundLayerMask);
        return raycastHit2D.collider != null;
    }
}
