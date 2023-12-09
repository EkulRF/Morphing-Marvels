using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachment : MonoBehaviour
{
    public float scaleIncrease = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touching UwU");
        
        AttachableObject attachableObject = other.GetComponent<AttachableObject>();

        if (attachableObject != null)
        {
            if (!attachableObject.IsAttached())
            {
                Attach(attachableObject);
            }
            else
            {
                Detach(attachableObject);
            }
        }
    }

    private void Attach(AttachableObject attachableObject)
    {
        transform.localScale += new Vector3(scaleIncrease, scaleIncrease, 0f);
        attachableObject.Attach(this);
    }

    private void Detach(AttachableObject attachableObject)
    {
        transform.localScale -= new Vector3(scaleIncrease, scaleIncrease, 0f);
        attachableObject.Detach();
    }

    // Callback from AttachableObject when attached
    public void OnAttach(AttachableObject attachableObject)
    {
        // Handle any additional logic when an object is attached to the player
        // For example, you might change the player's state or update a score
    }


bool CheckConnectors(AttachableObject attachableObject)
    {
        // Add logic to check if the player's connectors match the attachment points on the object
        // This depends on how you've set up your connectors and attachment points
        // Return true if the connectors match, otherwise false
        return true; // Placeholder; replace with your implementation
    }
}