using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float velocity;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * velocity;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Enemy"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Hit");
            rb.velocity = new Vector2(0, 0).normalized * 0;
        }
        // for further usage: if the enemy sends a projectile, take this block of code to enemy and destroy projectile on hit
        //Destroy(gameObject);
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
