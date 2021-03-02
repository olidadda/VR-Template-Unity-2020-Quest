using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;  



    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
       
        foreach (var item in devices)
        {

            print("name: " + item.name + "characteristics: " + item.characteristics);

        }


        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);

            }
            else 
            {
                print("did not find controller model");
            
            }
        }



        

        

    }

   

    void Update()
    {
        //the second parameter can be a bool for button, float for trigger, a vector2 for 2-axis thumbstick
        //TrygetFeaturevalue returns a boolean so we can put it in an if statement in case controller does not have this value
        
        
        //if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue)  &&  primaryButtonValue)
        //{
        //    print("pressing primary button on left controller");
        //}


        //if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)   &&   triggerValue > 0.1f)
        //{
        //    print("pressing trigger button on left controller at an intensity of " + triggerValue);
        //}


        //if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 thumbstickValue)  &&  thumbstickValue != Vector2.zero)
        //{ 
        //    print("thumbstick value is: " + thumbstickValue);
        //}
    }
}
