using UnityEngine;

public class NamNam : MonoBehaviour
{
    public GameObject spawnpos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnpos.transform.position;
        }
    }
}
