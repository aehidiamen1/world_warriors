using UnityEngine;

public class Level1ParallaxBackgrounf : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; //Allows me to determine the speed at which the background moves relative to the camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculate distance that the background moves based of camera movement
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
