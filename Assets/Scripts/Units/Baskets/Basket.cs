using System.Collections;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int direction = 0;
    [SerializeField] private BasketType basketType;
    private Player player;
    private Vector3 targetPosition;
    private float screenWidth;
    private void Awake()
    {
        if (basketType != BasketType.BasketStart)
        {
            gameObject.SetActive(false);
        }
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect - 0.9f;
    }

    public BasketType GetBasketType()
    {
        return basketType;
    }

    private void OnEnable()
    {
        direction = Random.Range(-1, 2);
        moveSpeed = Random.Range(4f, 4.5f);
        if (direction != (int)Direction.Standstill)
        {
            MoveBackAndForth();
        }
    }
    private void Start()
    {
        player = Player.Instance;
    }

    void MoveBackAndForth()
    {
        // Calculate the target position on the other side of the screen
        targetPosition = new Vector3(screenWidth * direction, transform.position.y, transform.position.z);

        // Move the object to the target position
        LeanTween.moveX(gameObject, targetPosition.x, moveSpeed)
            .setEase(LeanTweenType.linear)
            .setOnComplete(() =>
            {
                direction *= -1;
                MoveBackAndForth();
            });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.ReparentGameObject(gameObject.transform, basketType);

            if (basketType == BasketType.PerforatedBasket && player.gameObject.activeSelf)
            {
                player.StartWaitToLose();
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (player != null)
        {
            if (transform.position.y < player.transform.position.y)
            {
                LeanTween.cancel(gameObject);
                gameObject.SetActive(false);
            }
        }
    }

}
