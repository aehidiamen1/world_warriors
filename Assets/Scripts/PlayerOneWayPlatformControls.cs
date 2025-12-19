using UnityEngine;

public class PlayerOneWayPlatformControls : MonoBehaviour
{
    public bool fallThrough;

    //Update is called once per frame
    void Update()
    {
        //If the player presses the down key, allow them to fall through the platform
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            fallThrough = true;
        }
        else
        {
            fallThrough = false;
        }
    }
}
