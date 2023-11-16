using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{

    public float throwHeight = 5f;
    public float throwDuration = 2f;

    public float rotationSpeed = 620f;
    public float moveDistance = 4f;
    public float moveDuration = 1f;
    private InputManager inputManager;
    [SerializeField] private Vector3 defaultPosition = new Vector3(0.6f, -0.5f, 1f);


    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Throw;
    }

    private void Throw(Vector2 position, float startTime)
    {
        transform.SetParent(null);
        LeanTween.rotateAround(gameObject, Vector3.forward, rotationSpeed, 1f)
                   .setEase(LeanTweenType.linear)
                   .setLoopClamp();

        // Move the object along the Y-axis
        LeanTween.moveY(gameObject, transform.position.y + throwHeight, throwDuration / 2)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.moveY(gameObject, -transform.position.y - 2, throwDuration / 2)
                    .setEase(LeanTweenType.easeInQuad); // Use easeInQuad for a gradual slowdown
            });
    }

    public void StopMoving()
    {
        LeanTween.cancel(gameObject);
    }


    public void ResetPosition()
    {
        transform.position = defaultPosition;
    }

}
