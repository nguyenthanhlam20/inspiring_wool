using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputHandler : MonoBehaviour
{
    private InputAction touchAction;

    private void OnEnable()
    {
        touchAction.Enable();
    }

    private void OnDisable()
    {
        touchAction.Disable();
    }

    private void Awake()
    {
        touchAction = new InputAction("touchAction", binding: "<Touch>/position");
        touchAction.performed += context => TouchPerformed(context.ReadValue<Vector2>());
    }

    private void TouchPerformed(Vector2 touchPosition)
    {
        // Handle touch input using touchPosition
        Debug.Log("Touch position: " + touchPosition);
    }
}
