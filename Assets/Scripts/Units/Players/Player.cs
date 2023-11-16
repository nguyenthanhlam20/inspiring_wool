using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public float throwHeight = 5f;
    public float throwDuration = 2f;
    public float rotationSpeed = 620f;
    public float moveDistance = 4f;
    public float moveDuration = 1f;
    public float newPositionY = 0f;
    private InputManager inputManager;
    private Transform previousParent;

    private bool anableThrowing = false;
    private CircleCollider2D col;

    Coroutine waitToLose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        inputManager = InputManager.Instance;
        col = GetComponent<CircleCollider2D>();
        previousParent = transform.parent;
    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += Throw;
    }

    private void Start()
    {
        EnableCollider(false);
        StartCoroutine(WaitAndEnableThrowing());
        
    }

    private IEnumerator WaitAndEnableThrowing()
    {
        yield return new WaitForSeconds(0.2f);
        anableThrowing = true;
    }

    private void EnableCollider(bool enable)
    {
        col.enabled = enable;
    }

    private void Throw()
    {
        if (anableThrowing)
        {
            if (waitToLose != null)
            {
                StopCoroutine(waitToLose);
            }
            AudioManager.Instance.PlayEffectByIndex(AudioIndex.Jump);
            EnableCollider(false);

            anableThrowing = false;
            transform.SetParent(null);
            LeanTween.rotateAround(gameObject, Vector3.forward, rotationSpeed, 1f)
                       .setEase(LeanTweenType.linear)
                       .setLoopClamp();

            //// Move the object along the Y-axis
            LeanTween.moveY(gameObject, transform.position.y + throwHeight, throwDuration / 2)
                .setEase(LeanTweenType.easeOutQuad)
                .setOnComplete(() =>
                {
                    Fall();
                });
        }
    }

    public void Fall()
    {
        EnableCollider(true);
        LeanTween.moveY(gameObject, -transform.position.y - 10, throwDuration)
                    .setEase(LeanTweenType.easeInQuad);
    }

    public void StartWaitToLose()
    {
        waitToLose = StartCoroutine(WaitToLose());
    }

    public IEnumerator WaitToLose()
    {
        yield return new WaitForSeconds(15f);

        EnableCollider(false);
        LeanTween.moveY(gameObject, -transform.position.y - 10, throwDuration / 2)
                    .setDelay(0.1f)
                    .setEase(LeanTweenType.easeInQuad)
                    .setOnComplete(() =>
                    {
                        PlayerStatManager.Instance.RemoveAllHearts();
                        gameObject.SetActive(false);
                    });
    }

    public void StopMoving()
    {
        anableThrowing = true;
        LeanTween.cancel(gameObject);
    }


    // Use this method when you want to reparent the GameObject
    public void ReparentGameObject(Transform newParent, BasketType basketType)
    {
        if (!anableThrowing)
        {
            StopMoving();

            Vector3 newPosition = Vector3.zero;

            if (basketType == BasketType.BasketStart)
            {
                newPosition = new Vector3(newParent.position.x + 0.6f, newParent.position.y - 0.5f, 1f);
            }
            else
            {
                newPosition = new Vector3(newParent.position.x, newParent.position.y, 1f);
            }

            transform.parent = newParent;
            transform.position = newPosition;

            if (newParent == previousParent)
            {
                ThrowFailed();
            }
            else
            {
                AudioManager.Instance.PlayEffectByIndex(AudioIndex.GainScore);
                PlayerStatManager.Instance.InscreaseScore();
            }
            previousParent = newParent;
        }
    }

    private void ThrowFailed()
    {
        AudioManager.Instance.PlayEffectByIndex(AudioIndex.ThrowFailed);
        FloatingTextContainer.Instance.ShowFloatingText("-1", Color.red, transform);
        PlayerStatManager.Instance.DescreaseHealth();
    }

    public void ReturnToPreviousParent()
    {
        BasketType basketType = previousParent.gameObject.GetComponent<Basket>().GetBasketType();
        ReparentGameObject(previousParent, basketType);
    }

}
