using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 3.5f;
    public float slideDuration = 0.1f;
    public LayerMask groundLayer;
    
    private Rigidbody2D rb;

    private BoxCollider2D slideBoxCollider;
    private BoxCollider2D defaultBoxCollider;
    private bool isGrounded;
    private bool isSliding = false;
    private bool isActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void OnEnable()
    {
        if(defaultBoxCollider == null){
            BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
            defaultBoxCollider = (colliders[0].bounds.size.y > colliders[1].bounds.size.y) ? colliders[0] : colliders[1];
            slideBoxCollider = (defaultBoxCollider == colliders[0]) ? colliders[1] : colliders[0];
        }
        UpdateIsSliding(false);
    }

    void Update()
    {
        // Move the character to the right
        if(isActive)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        // Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, defaultBoxCollider.bounds.size.y / 2 + 0.1f, groundLayer);
    }

    public void Jump()
    {
        if(isGrounded && isActive){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }        
    }

    public void Slide()
    {
        if(!isSliding && isGrounded && isActive)
        {
            StartCoroutine(SlideCoroutine());
        }
    }

    private System.Collections.IEnumerator SlideCoroutine()
    {
        UpdateIsSliding(true);

        yield return new WaitForSeconds(slideDuration);

        UpdateIsSliding(false);     
    }

    private void UpdateIsSliding(bool newIsSliding)
    {
        isSliding = newIsSliding;
        defaultBoxCollider.enabled = !isSliding;
        slideBoxCollider.enabled = isSliding;
    }

    public void TurnActive(bool activeState)
    {
        isActive = activeState;
    }
}
