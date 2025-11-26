using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PipeSpawn : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 3f;
    private float timer = 0;
    public float heightOffSet = 4f;
    public bool spawnAllowed = true;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnAllowed)
            return; // ? Kuþ ölürse spawner tamamen durur
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    public void StopSpawning()
    {
        spawnAllowed = false;
    }
}
