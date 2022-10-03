using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float isTriggerPressed = pinchAnimationAction.action.ReadValue<float>();

        Debug.Log(isTriggerPressed);
        
    }
}
