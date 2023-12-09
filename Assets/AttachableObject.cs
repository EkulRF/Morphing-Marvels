using UnityEngine;

public class AttachableObject : MonoBehaviour
{
    // Flag to check if the object is attached
    private bool isAttached = false;
    private FixedJoint2D joint;

    // This function is called when the player attaches to this object
    public void Attach(PlayerAttachment playerAttachment)
    {
        if (!isAttached)
        {
            isAttached = true;

            // Create a FixedJoint2D and connect it to the player's Rigidbody
            joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = playerAttachment.GetComponent<Rigidbody2D>();

            // Optionally, you can configure other properties of the joint
            joint.enableCollision = false;

            // Notify the playerAttachment script about the attachment
            playerAttachment.OnAttach(this);
        }
    }

    public void Detach()
    {
        if (isAttached)
        {
            isAttached = false;

            // Remove the joint component to detach the object
            Destroy(joint);

            // Optionally, add logic for the object's behavior upon detachment
        }
    }

    public bool IsAttached()
    {
        return isAttached;
    }
}