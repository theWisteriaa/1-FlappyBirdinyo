using UnityEngine;
// Yeni kütüphaneyi dahil edin
using UnityEngine.InputSystem;

public class BirdinyoScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpForce = 10f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Yeni sistem, bir "action" tetiklendiğinde çağrılan bir metot kullanır
    public void OnJump(InputValue value)
    
   
    {
        if (birdIsAlive == false)
            return;
        // Tetiklenme kontrolü genellikle gerekmez, action tetiklendiğinde çağrılır
        myRigidBody.linearVelocity = Vector2.up * jumpForce;
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        myRigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        PipeMove[] pipes = FindObjectsOfType<PipeMove>();

        foreach (PipeMove pipe in pipes)
        {
            pipe.SlowDown();
        }
    }
}



