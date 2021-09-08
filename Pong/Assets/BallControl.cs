using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    
     // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
       
        
    }

    void PushBall()
    {

        
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);


        float randomDirection = Random.Range(0, 2);

        
        if (randomDirection < 1.0f)
        {
            
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * 50 );
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * 50);
        }
        
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        

        // Mulai game
        RestartGame();

        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}