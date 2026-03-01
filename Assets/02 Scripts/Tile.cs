using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;

    private Renderer tileRenderer;
    private Material defaultMaterial;

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
        defaultMaterial = tileRenderer.sharedMaterial;
    }

    public void SetHighlight()
    {
        if (highlightMaterial == null) return;
        tileRenderer.sharedMaterial = highlightMaterial;
    }

    public void ClearHighlight()
    {
        tileRenderer.sharedMaterial = defaultMaterial;
    }
}
