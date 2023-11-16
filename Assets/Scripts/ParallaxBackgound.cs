using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgound : MonoBehaviour
{

    #region Feilds
    private float lengthX, lengthY; // Length of the sprite in X and Y directions
    private float startPosX; // Starting position of the sprite in the X direction
    private float startPosY; // Starting position of the sprite in the Y direction

    private float relativeCamDistX; // Relative distance of the camera in the X direction
    private float relativeCamDistY; // Relative distance of the camera in the Y direction
    private float relativeDistX; // Relative distance of the sprite in the X direction
    private float relativeDistY; // Relative distance of the sprite in the Y direction

    [SerializeField] private Camera cam; // Reference to the camera
    [SerializeField] private float parallaxSpeed; // Parallax speed in the X direction
    [SerializeField] private float parallaxSpeedY = 0.1f; // Parallax speed in the Y direction
    #endregion

    #region LifeCycle Methods

    /// <summary>
    /// This function is called before the first frame update
    /// </summary>
    private void Start()
    {
        // Store the initial position and length of the sprite
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;

        // Find and assign the main camera in the scene
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        // Calculate the relative camera distance and relative distance of the sprite based on the parallax speed
        relativeCamDistX = (cam.transform.position.x * (1 - parallaxSpeed));
        relativeCamDistY = (cam.transform.position.y * (1 - parallaxSpeedY));

        relativeDistX = (cam.transform.position.x * parallaxSpeed);
        relativeDistY = (cam.transform.position.y * parallaxSpeedY);

        // Update the position of the sprite based on the parallax effect
        transform.position = Vector2.Lerp(
            new Vector2(startPosX + relativeDistX, startPosY + relativeDistY),
             new Vector2(startPosX + relativeDistX, startPosY + relativeDistY),
             0.3f * Time.deltaTime);

        // Check if the camera has moved beyond the boundaries of the sprite in the X direction
        if (relativeCamDistX >= startPosX + lengthX)
        {
            // Move the starting position of the sprite to the next section
            startPosX += lengthX;
        }
        else if (relativeCamDistX <= startPosX - lengthX)
        {
            // Move the starting position of the sprite to the previous section
            startPosX -= lengthX;
        }
    }

    /// <summary>
    /// This function is used for physics-related calculations and is called at a fixed interval. 
    /// It calculates the relative camera distance and relative distance of the sprite based on the parallax speed
    /// </summary>
    private void FixedUpdate()
    {
       
    }

    #endregion
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ParallaxBackgound : MonoBehaviour
//{

//    #region Feilds
//    private float startPosY; // Starting position of the sprite in the Y direction
//    private float lengthY; // Starting position of the sprite in the Y direction
//    [SerializeField] private float parallaxSpeedY = 5f; // Parallax speed in the Y direction
//    #endregion

//    #region LifeCycle Methods

//    private void Start()
//    {
//        // Store the initial position and length of the sprite
//        startPosY = transform.position.y;
//        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;

//    }

//    private void Update()
//    {
//        // Update the position of the sprite based on the parallax effect
//        transform.position = Vector2.Lerp(transform.position,
//             new Vector2(transform.position.x, transform.position.y - parallaxSpeedY),
//             0.3f * Time.deltaTime);

//        startPosY = transform.position.y;

//        if (startPosY <= -lengthY)
//        {
//            transform.position = new Vector2(0f, lengthY);
//        }
//    }


//    #endregion
//}
