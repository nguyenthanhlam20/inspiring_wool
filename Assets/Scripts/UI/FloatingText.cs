using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _displayTime;
    [SerializeField] private GameObject _displayText;
    private MeshRenderer _textMeshRenderer;
    private TextMesh _textMesh;

    private void Awake()
    {
        _textMeshRenderer = _displayText.GetComponent<MeshRenderer>();
        _textMesh = _displayText.GetComponent<TextMesh>();
        _textMeshRenderer.sortingLayerName = "UI";
        _textMeshRenderer.sortingOrder = 2;

    }
    void Start()
    {
        Destroy(gameObject, _displayTime);
    }

    public void SetText(string text, Color color)
    {
        _textMesh.text = text;
        _textMesh.color = color;
    }

}
