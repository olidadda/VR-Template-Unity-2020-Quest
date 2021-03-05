using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.Oculus;
using Unity.XR.OpenVR;

public class HandAnimator : MonoBehaviour
{

    public float speed = 5.0f;
    /*public XRController controller = null;*/ //does this need to be actionbasedcontroller

    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice controller;


    Animator animator = null;

    readonly List<Finger> thumbs = new List<Finger>()
    {
        new Finger (FingerType.Thumb),
    };

   readonly List<Finger> indexes = new List<Finger>()
    {
        new Finger (FingerType.Index),
    };

readonly List<Finger> gripFingers = new List<Finger>()
    {
        new Finger (FingerType.Ring),
        new Finger (FingerType.Pinky),
        new Finger (FingerType.Middle),
    };

  


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        TryInitialize();
    }



    private void Update()
    {
        if (!controller.isValid) { TryInitialize(); }

        //store input from trigger or grip press in the finger.target variable in the Finger script
        CheckGrip();
        CheckIndex();
        CheckThumb();

        //smooth input values
        SmoothFinger(gripFingers);
        SmoothFinger(thumbs);
        SmoothFinger(indexes);


        //Apply smoothed values
        AnimateFinger(gripFingers);
        AnimateFinger(thumbs);
        AnimateFinger(indexes);
    }

    private void CheckThumb()
    {

        if (controller.TryGetFeatureValue(OculusUsages.thumbTouch, out bool thumbValue))
        {
            SetThumbTargets(thumbs, thumbValue);
        }
    }

    private void CheckGrip()
    {
        if (controller.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            SetFingerTargets(gripFingers, gripValue);
        }
    }

    private void CheckIndex()
    {
        if (controller.TryGetFeatureValue(CommonUsages.trigger, out float indexValue))
        {
            SetFingerTargets(indexes, indexValue);
        }
    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach (Finger finger in fingers)
        {
            finger.target = value;
        }
    }

    private void SetThumbTargets(List<Finger> fingers, bool value)
    {
        foreach (Finger finger in fingers)
        {
            float numValue;
            numValue = value == true ? 1f : 0f;
            
            finger.target = numValue;
        }
    }






    private void SmoothFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
        {
            float time = speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
            //here the time Value in Movetowards represents the maximum change that should be applied to the value
        }
    }






    private void AnimateFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
        {
            AnimateFinger(finger.fingerType.ToString(), finger.current);
        }
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var device in devices)
        {
            print("name: " + device.name + "characteristics: " + device.characteristics);
        }

        if (devices.Count > 0)
        {
            controller = devices[0];
        }
    }
}