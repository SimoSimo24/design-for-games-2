using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Collider2D col;
    public Vector3 beginPosition { get; private set; }
    private Vector3 startDragPosition;

    public int score;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        beginPosition = transform.position;
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;

        if (hitCollider != null && hitCollider.TryGetComponent(out IDropArea dropArea))
        {
            dropArea.OnItemDrop(this);
        }
        else
        {
            transform.position = beginPosition;
            transform.rotation = Quaternion.identity;
        }
    }

    private Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure it's on the 2D plane
        return mousePosition;
    }
}