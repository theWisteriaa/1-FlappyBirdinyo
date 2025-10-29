using UnityEngine;
// Yeni kütüphaneyi dahil edin
using UnityEngine.InputSystem;

public class BirdinyoScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpForce = 10f;

    // Yeni sistem, bir "action" tetiklendiğinde çağrılan bir metot kullanır
    public void OnJump(InputValue value)

    {

        // Tetiklenme kontrolü genellikle gerekmez, action tetiklendiğinde çağrılır
        myRigidBody.linearVelocity = Vector2.up * jumpForce;
    }

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
}



