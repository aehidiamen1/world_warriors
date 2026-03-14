using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneWayPlatformControls : MonoBehaviour
{
    public bool fallThrough;

    //Update is called once per frame
    void Update()
    {
        //If the player presses the down key, allow them to fall through the platform
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            fallThrough = true;
        }
        else
        {
            fallThrough = false;
        }
    }
}
