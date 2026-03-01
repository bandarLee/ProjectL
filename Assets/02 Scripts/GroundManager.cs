using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Raycast")]
    [SerializeField] private LayerMask tileLayer;
    [SerializeField] private float rayStartHeight = 0.6f;
    [SerializeField] private float rayDistance = 3f;

    private Tile currentTile;

    private void Update()
    {
        if (player == null) return;

        Vector3 origin = player.position + Vector3.up * rayStartHeight;
        bool hit = Physics.Raycast(origin, Vector3.down, out RaycastHit hitInfo, rayDistance, tileLayer);

        if (!hit)
        {
            ClearCurrentTile();
            return;
        }

        Tile newTile = hitInfo.collider.GetComponent<Tile>();
        if (newTile == currentTile) return;

        ClearCurrentTile();

        if (newTile != null)
        {
            newTile.SetHighlight();
            currentTile = newTile;
        }
    }

    private void ClearCurrentTile()
    {
        if (currentTile == null) return;

        currentTile.ClearHighlight();
        currentTile = null;
    }
}
