using UnityEngine;

public class DropArea : MonoBehaviour, IDropArea
{
    public void OnItemDrop(DragDrop dragDrop)
    {
        dragDrop.transform.position = dragDrop.transform.localPosition;
        Debug.Log("item dropped");
    }
}
