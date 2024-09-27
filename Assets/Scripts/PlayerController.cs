using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to attach to Player Character GameObject on Scene
public class PlayerController : MonoBehaviour
{
    const string JUMP_ANIMATION_NAME = "Jump";
    const string SLIDE_ANIMATION_NAME = "Slide";
    const string RUN_ANIMATION_NAME = "Run";
    const string IDDLE_ANIMATION_NAME = "Iddle";

    //Value to Indicate Player speed
    [SerializeField]
    float moveSpeed = 1.85f;
    //Value to Indicate Player jump force
    [SerializeField]
    float jumpForce = 3.5f;
    //Value to Indicate Player Slide Duration
    [SerializeField]
    float slideDuration = 0.65f;
    //Value to Indicate which layer is identified as Ground Layer on the Scene
    [SerializeField]
    LayerMask groundLayer;
    //Value to Indicate the Animator of the Player Sprite contained on the Scene
    [SerializeField]
    Animator _animator;

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

    //Update should make the player keep running to the Right and checking if the player is grounded
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

    //If Jump is called and player is grounded and active, the player should start jumping
    public void Jump()
    {
        if(isGrounded && isActive){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            UpdateAnimation(JUMP_ANIMATION_NAME);
            AudioSingleton.Instance.TriggerJumpAudio();
        }        
    }


    //If Slide is called and the player is grounded and active and is not sliding, the player should start sliding by calling the Slide Coroutine
    public void Slide()
    {
        if(!isSliding && isGrounded && isActive)
        {
            StartCoroutine(SlideCoroutine());
        }
    }

    //Slide Coroutine to trigger audio and update Slide Status for the duration of the Slide Duration
    private System.Collections.IEnumerator SlideCoroutine()
    {
        UpdateIsSliding(true);

        AudioSingleton.Instance.TriggerSlideAudio();

        yield return new WaitForSeconds(slideDuration);

        UpdateIsSliding(false);     
    }

    //Update Slide Status and enables and disable corresponding BoxColliders on top of calling for Sliding Animation
    private void UpdateIsSliding(bool newIsSliding)
    {
        isSliding = newIsSliding;
        defaultBoxCollider.enabled = !isSliding;
        slideBoxCollider.enabled = isSliding;
        if(isActive)
        {
            UpdateAnimation(newIsSliding ? SLIDE_ANIMATION_NAME: RUN_ANIMATION_NAME);
        }        
    }

    //Turn Player active so it can start running or not Active, so it stays Iddle
    public void TurnActive(bool activeState)
    {
        isActive = activeState;
        UpdateAnimation(activeState ? RUN_ANIMATION_NAME : IDDLE_ANIMATION_NAME);
    }

    //Method to update which Animation is happening
    private void UpdateAnimation(string animName)
    {
        _animator.Play(animName);
    }
}
