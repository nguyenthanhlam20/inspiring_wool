using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    private PlayerInput playerInput;

    private void Awake()
    {
        // Checking if the Instance variable is null
        if (Instance == null)
        {
            // Assigning the current instance to the Instance variable
            Instance = this;
        }
        else
        {
            // Destroys the duplicate instance of the SoundManager if it already exists
            Destroy(gameObject);
        }

        playerInput = GetComponent<PlayerInput>();

    }

    private void OnEnable()
    {
        // Subscribe to the touch press event
        playerInput.actions["TouchPress"].performed += OnTouchPress;
    }

    private void OnDisable()
    {
        // Unsubscribe from the touch press event
        playerInput.actions["TouchPress"].performed -= OnTouchPress;
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        //// Handle touch press
        //Vector2 touchPosition = context.ReadValue<Vector2>();
        //float touchTime = (float)context.startTime;

        //// Invoke the event
        //OnStartTouch?.Invoke(touchPosition, touchTime);

        Debug.Log("touch");
    }
}
