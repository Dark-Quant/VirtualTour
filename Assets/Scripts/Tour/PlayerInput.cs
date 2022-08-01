using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    OVRInput.Button[] selectButton
    {
        get
        {
            return new[] {OVRInput.Button.One, OVRInput.Button.Three,  };
        }
    }
    
    OVRInput.Button[] rightButtons
    {
        get
        {
            return new[] { OVRInput.Button.One, OVRInput.Button.SecondaryIndexTrigger };
        }
    }

    OVRInput.Button[] leftButtons
    {
        get
        {
            return new[] { OVRInput.Button.Three, OVRInput.Button.PrimaryIndexTrigger };
        }
    }
    void Update()
    {
#if UNITY_ANDROID
        OculusControllerInput();
#endif

#if UNITY_EDITOR
        KeyboardInput();
#endif
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Events.onTouchStart.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Events.onTouchEnd.Invoke();
        }
    }

    private void OculusControllerInput()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Events.onTouchStart.Invoke();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)) 
        {
           Events.onTouchEnd.Invoke();
        }
    }
}
