using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string kidTag;
    [SerializeField] string enemyTag;
    [SerializeField] NumberField kidField;
    [SerializeField] int scaler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == kidTag && kidField != null)
        {
            if (kidField.GetNumber() > 1)
            {
                kidField.SubNumber(scaler);
                Destroy(other.gameObject);
            }
            else
            {
                kidField.SetNumber(0);
                Destroy(other.gameObject);
                //Win scene;
            }
        }

        // on upgraded game, if kid and enemy field = 0 => then win
    }

    public void SetKidField(NumberField newTextField)
    {
        this.kidField = newTextField;
    }
}