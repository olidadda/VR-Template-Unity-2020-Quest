using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputSyntaxExamples : MonoBehaviour
{

    ActionBasedController controller;


    void Start()
    {
        controller = GetComponent<ActionBasedController>(); //get controller script from this object

        bool isPressed = controller.selectAction.action.ReadValue<bool>();
        //selectAction is contained in the ActionBasedController class,
        //which has a serielized field that takes in an object of type InputPropertyAction, 
        //where "action" and methods like ReadValue() are contained

        // we are using a bool with Readvalue (pressed or not), but we could use a float to check the amount the button is pressed, 
        // or even a Vector2 if our input takes a Vector2 input 
        //we can then use this in an Update function or somewhere else


        controller.selectAction.action.performed += MethodToCallWhenActionPerformed; //press on tab 2 times after += to create method automatically           
        
        //we can also add methods to be called when the action is performed with delegate syntax

    }

    private void MethodToCallWhenActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //code to be excecuted
    }

    void Update()
    {
        
    }
}
