using UnityEngine;

public class PipeMove : MonoBehaviour
{



    public float moveSpeed = 3;
    public float deadZone = -26f;

    public bool isSlowingDown = false;
    private float slowDuration = 3f;  // 3 saniyede duracak
    private float initialSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlowingDown)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0f, Time.deltaTime / slowDuration);
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted.");
            Destroy(gameObject);
        }
    }

    public void SlowDown()
    {
        isSlowingDown = true;
    }
}
