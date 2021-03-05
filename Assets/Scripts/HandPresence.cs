using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HandPresence : MonoBehaviour
{
    public bool showController;

    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    public GameObject handModelPrefab;
   

    private GameObject spawnedController;
    private GameObject spawnedHandModel;

    Animator handAnimator;

    GameObject prefab;

    [SerializeField] GameObject IndexController;
    [SerializeField] GameObject HTCViveWand;

    //-------------------------------------------


    


    void Start()
    {

        TryInitialize();

        //StartCoroutine(InitializeDevices());


        //IEnumerator InitializeDevices()
        //{
        //    WaitForEndOfFrame wait = new WaitForEndOfFrame();
        //    List<InputDevice> devices = new List<InputDevice>();
        //    InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
            
        //    while (devices.Count < 1)
        //    {
        //        yield return wait;
        //        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
                
        //    }
            


        //    foreach (var device in devices)
        //    {

        //        print("name: " + device.name + "characteristics: " + device.characteristics);

        //    }

            



        //    if (devices.Count > 0)
        //    {
        //        targetDevice = devices[0];

        //        print("targetDevice is: " + targetDevice.name);
               
        //        if (targetDevice.name != "Index Controller OpenXR" && targetDevice.name != "HTC Vive Controller OpenXR")
        //        {
        //            prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
        //        }
        //        else if (targetDevice.name == "Index Controller OpenXR")
        //        {
        //            prefab = IndexController;
        //        }           
                
        //        else if (targetDevice.name == "HTC Vive Controller OpenXR")
        //        {
        //            prefab = HTCViveWand; 
        //        }
                
               

        //        if (prefab)
        //        {
        //            spawnedController = Instantiate(prefab, transform);
        //            print("prefab is: " + prefab);
        //        }
        //        else
        //        {
        //            print("did not find controller model");

        //        }


        //        spawnedHandModel = Instantiate(/*handModelPrefab*/ andrewsHandPrefab, transform);
        //        handAnimator = spawnedHandModel.GetComponent<Animator>();
        //    }
        //}        
    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        foreach (var device in devices)
        {
            print("name: " + device.name + "characteristics: " + device.characteristics);
        }


        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            print("targetDevice is: " + targetDevice.name);

            if (targetDevice.name != "Index Controller OpenXR" && targetDevice.name != "HTC Vive Controller OpenXR")
            {
                prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            }
            else if (targetDevice.name == "Index Controller OpenXR")
            {
                prefab = IndexController;
            }

            else if (targetDevice.name == "HTC Vive Controller OpenXR")
            {
                prefab = HTCViveWand;
            }



            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
                print("prefab is: " + prefab);
            }
            else
            {
                print("did not find controller model");

            }


            //spawnedHandModel = Instantiate(handModelPrefab , transform);
           
            //handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    void UpdateHandAnimation()
    {
        //if (targetDevice.TryGetFeatureValue (CommonUsages.trigger, out float triggerValue))
        //{
        //    handAnimator.SetFloat("Trigger", triggerValue);
        //}
        //else
        //{
        //    handAnimator.SetFloat("Trigger", 0);
        //}

        //if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        //{
        //    handAnimator.SetFloat("Grip", gripValue);
        //}
        //else
        //{
        //    handAnimator.SetFloat("Grip", 0);
        //}





    }

    void Update()
    {

        UpdateHandAnimation();

        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (showController)
            {
                if (spawnedController != null) spawnedController.SetActive(true);
                //if (spawnedHandModel != null) spawnedHandModel.SetActive(false);
            }
            else
            {
                //if (spawnedHandModel != null) spawnedHandModel.SetActive(true);
                if (spawnedController != null) spawnedController.SetActive(false);
            }
        }
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
