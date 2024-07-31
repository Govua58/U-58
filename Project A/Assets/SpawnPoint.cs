using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
    }
}
