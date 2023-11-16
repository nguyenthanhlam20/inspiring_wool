using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Fields
    [Header("Offset")]
    [SerializeField] private float timeOffset;

    [SerializeField] private Vector2 posOffset;

    [Header("Limitation")]
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float topLimit;
    [SerializeField] private float bottomLimit;


    private Transform player;
    #endregion


    #region LifeCycle Methods
    private void Start()
    {
        Player p = FindObjectOfType<Player>();
        if (p != null)
        {
            player = p.GetComponent<Transform>();
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(transform.position.x, player.position.y, -10f);

            endPos.y += posOffset.y;

            //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

            //// restrict limits
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, float.MaxValue),
                transform.position.z
                );
        }

    }

    #endregion
    #region Gizmoz Drawing

    private void OnDrawGizmos()
    {
        // draw a box around camera boundary
        Gizmos.color = Color.red;

        // top boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit),
            new Vector2(rightLimit, topLimit));

        // right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit),
            new Vector2(rightLimit, bottomLimit));

        // left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit),
            new Vector2(leftLimit, topLimit));


        // bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit),
            new Vector2(leftLimit, bottomLimit));
    }

    #endregion

}
