using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject trg;
    public float speed = 3f;
    public float patrolDistance = 3f;

    PLayerControllerLVL1 player;
    Vector3 startPos;

    void Start()
    {
        player = trg.GetComponent<PLayerControllerLVL1>();
        startPos = transform.position;
    }

    void Update()
    {
        if (player.mask)
        {
            Devriye();
        }
        else
        {
            TakipEt();
        }
    }

    void Devriye()
    {
        float xOffset = Mathf.PingPong(Time.time * speed, patrolDistance * 2) - patrolDistance;
        transform.position = new Vector3(
            startPos.x + xOffset,
            startPos.y,
            startPos.z
        );
    }

    void TakipEt()
    {
        Vector3 direction = (trg.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
