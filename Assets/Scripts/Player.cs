using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("[Speed]")]
    public float speed;

    [Header("[Health]")]
    public GameObject potionEffect;
    public Text healthDisplay;
    public int health;


    [Header("[Shield]")]
    public GameObject shieldEffect;
    public GameObject shield;
    public Shield shieldTimer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;

    private bool facingRight = true;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (moveInput.x == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            ChangeHealth(5);
            Instantiate(potionEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Shield"))
        {
            if (!shield.activeInHierarchy)
            {
            shield.SetActive(true);
            shieldTimer.gameObject.SetActive(true);
            shieldTimer.isCooldown = true;
            Instantiate(shieldEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            }
            else
            {
                shieldTimer.ResetTimer();
                Instantiate(shieldEffect, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            
        }
    }
    public void ChangeHealth(int healthValue)
    {
        if (!shield.activeInHierarchy || shield.activeInHierarchy && healthValue > 0)
        {
            health += healthValue;
            healthDisplay.text = "HP: " + health;
        }
        //else if (shield.activeInHierarchy && healthValue < 0)
        //{
        //    shieldTimer.ReduceTime(healthValue);
        //}
    }
}