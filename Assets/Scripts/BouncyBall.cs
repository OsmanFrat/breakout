using System;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float speed = 5f;
    private bool isLaunched = false;
    private Rigidbody2D rb;
    public GameObject gameOverPanel;   
    public GameObject youWinPanel;
    public GameObject levelGenerator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        levelGenerator.SetActive(true);
    }

    private void Update()
    {
        if(transform.position.y < -6f)
        {
            levelGenerator.SetActive(false);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        
        // Brick check
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0 && levelGenerator.activeSelf)
        {
            // if all bricks are destroyed, you win panel will be active
            youWinPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isLaunched)
        {
            // Let the ball move on the pallet
            float paddleX = GameObject.Find("Paddle").transform.position.x;
            transform.position = new Vector3(paddleX, transform.position.y, transform.position.z);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // When pressed space, launch the ball
                LaunchBall();
            }

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
    }


    private void LaunchBall()
    {
        isLaunched = true;
        rb.velocity = Vector2.up * speed;
    }
}