using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [Tooltip("Drops health for the player")] [SerializeField] int increaseLife;
    [SerializeField] string text;
    [SerializeField] string color;
    public void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Kid picked up by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent)
            {
                //destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));        // co-routines
                //other.                                                                             // NOTE: If you just call "StartCoroutine", then it will not work, 
                                                                                             //       since the present object is destroyed!
                // ShieldTemporarily(destroyComponent);                                      // async-await
                Destroy(gameObject);  // Destroy the kid itself - prevent double-use
            }
        }
        else
        {
            Debug.Log("Kid triggered by " + other.name);
        }
    }

}
