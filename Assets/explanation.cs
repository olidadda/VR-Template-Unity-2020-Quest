using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explanation : MonoBehaviour
{
    /*When adding model prefabs to left/right controllers, put the model INSIDE empty game object, save whole thing as prefab, 
     then add that to the model slot in left/right controller


      Simple Grab mechanics: 
  
    1) add XR Grab Interactable script to the object to be interacted with (sphere in this case) 
    2) remove from controller objects XR Ray interactor, line renderer, and XR interactor line visual (can't have these as well as an XR Direct interactor)
    3) add XR Direct Interactor to right & left controller
    4) add sphere collider (0.2m) to right & left controller, set to trigger (to detect if we're interacting with interactible object)
    5) should now work

    Issues: reduce clipping when object near face --> in VR camera settings lower clipping planes 




    */
}
