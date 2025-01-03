using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour, IDropArea
{
    private List<DragDrop> itemsInDropArea = new List<DragDrop>();

    public void OnItemDrop(DragDrop dragDrop)
    {
        if (!itemsInDropArea.Contains(dragDrop))
        {
            itemsInDropArea.Add(dragDrop);
        }
        UpdateItemsInDropArea();
    }

    public void RemoveItem(DragDrop dragDrop)
    {
        if (dragDrop.transform.position == dragDrop.beginPosition)
        {
            itemsInDropArea.Remove(dragDrop);
            Debug.Log($"Removed: {dragDrop.name}");
        }
    }

    private void UpdateItemsInDropArea()
    {
        // Iterate over a copy of the list to avoid modifying it during iteration
        List<DragDrop> itemsCopy = new List<DragDrop>(itemsInDropArea);

        foreach (DragDrop i in itemsCopy)
        {
            RemoveItem(i);
        }

        // Log current items in the DropArea
        Debug.Log("Items in DropArea:");
        foreach (DragDrop item in itemsInDropArea)
        {
            Debug.Log($"- {item.name}");
        }
    }
}
