using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour, IDropArea
{
    private List<DragDrop> itemsInDropArea = new List<DragDrop>();
    public Camera mainCamera;

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

    public void UpdateItemsInDropArea()
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
            Debug.Log($"- {item.name} (Score: {item.score})");
        }

        Debug.Log($"Total Score: {CalculateTotalScore()}");
    }

    public int CalculateTotalScore()
    {
        int totalScore = 0;
        foreach (DragDrop item in itemsInDropArea)
        {
            totalScore += item.score; // Add each item's score
        }
        return totalScore;
    }

    public void OnButtonClick()
    {
        UpdateItemsInDropArea();
        int totalScore = CalculateTotalScore();
        Debug.Log($"Final Total Score: {totalScore}");

        // Change camera position
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(0, 10, -10); // Example new position
            Debug.Log("Camera position changed!");
        }
        else
        {
            Debug.LogError("Main Camera reference is missing!");
        }
    }
}