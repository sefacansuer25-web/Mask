using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerControllerLVL1 : MonoBehaviour
{
    public bool mask;
    int health = 5;
    public GameObject canPanel;
    public GameObject Mask;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mask = !mask;
        }

        Mask.SetActive(mask);

        if(health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;

            if (canPanel.transform.childCount > 0)
            {
                Destroy(canPanel.transform.GetChild(0).gameObject);
            }
        }

    }
}
