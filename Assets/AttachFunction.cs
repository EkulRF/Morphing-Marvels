using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachFunction : MonoBehaviour
{
    // Boolean variable indicating whether the object is attached
    public AttachableObject attachscript;

    void Update()
    {
        // Check if the object is attached
        if (attachscript != null && attachscript.IsAttached())
        {
            // Perform the continuous function
            PerformContinuousFunction();
        }
    }

    void PerformContinuousFunction()
    {
        // Replace this with the actual function you want to perform
        // This function will be executed continuously while isAttached is true
        Debug.Log("Performing continuous function");
    }
}