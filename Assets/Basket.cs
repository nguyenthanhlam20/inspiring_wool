using UnityEngine;

public class Basket : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int direction = 0;


    private void Awake()
    {
        transform.position = new Vector3(-0.5f, 0f, 1f);

        direction = Random.Range(-1, 1);
        moveSpeed = Random.Range(2f, 4f);
        if (direction != 0)
        {
            MoveBackAndForth(direction);
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector3(-0.5f, 0f, 1f);

        direction = Random.Range(-1, 1);
        moveSpeed = Random.Range(2f, 4f);
        if (direction != 0)
        {
            MoveBackAndForth(direction);
        }
    }

    void MoveBackAndForth(int direction)
    {
        // Get the screen width in world coordinates
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // Calculate the target position on the other side of the screen
        Vector3 targetPosition = new Vector3(screenWidth * direction, transform.position.y, transform.position.z);

        // Move the object to the target position
        LeanTween.moveX(gameObject, targetPosition.x, moveSpeed)
            .setEase(LeanTweenType.linear)
            .setOnComplete(() =>
            {
                MoveBackAndForth(-direction);
            });
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.StopMoving();
            player.ResetPosition();
            player.transform.SetParent(transform);
        }
    }
}
