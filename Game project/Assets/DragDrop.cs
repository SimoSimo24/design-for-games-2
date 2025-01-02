using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class DragDrop : MonoBehaviour{

    private Collider2D col;
    private Vector3 startDragPosition;
    private Vector3 beginPosition;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        beginPosition = transform.position;
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePositionInWorldSpace();
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
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }

    public void InteractLogic()
    {
        throw new NotImplementedException();
    }
}
