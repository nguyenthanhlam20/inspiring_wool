using System.Collections.Generic;
using UnityEngine;

public class FloatingTextContainer : MonoBehaviour
{
    [SerializeField] GameObject FloatingTextPrefab; // Floating text prefab

    public static FloatingTextContainer Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ShowFloatingText(string text, Color color, Transform target)
    {
        // Get instance of floating text
        var floatingText = Instantiate(FloatingTextPrefab, 
            new Vector3(target.position.x + 1f, target.position.y + 1f, 1), 
            Quaternion.identity);

        // Set floating text attributes
        floatingText.GetComponent<FloatingText>()
            .SetText(text, color);
    }


}
