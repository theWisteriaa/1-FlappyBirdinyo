using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Eðer sahnede baþka MusicManager varsa onu yok et
        var managers = FindObjectsOfType<MusicManager>();
        if (managers.Length > 1)
            Destroy(gameObject);
    }
}
