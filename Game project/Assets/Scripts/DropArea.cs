using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropArea
{
    protected List<DragDrop> itemsInDropArea = new List<DragDrop>();
    public Camera mainCamera;
    public Button actionButton;
    public DragDrop dragDrop;
    public bool occupied = false;

    public virtual void OnItemDrop(DragDrop dragDrop)
    {
            if (!itemsInDropArea.Contains(dragDrop))
            {
                itemsInDropArea.Add(dragDrop);
            }
            UpdateItemsInDropArea();
            dragDrop.transform.position = this.transform.position + new Vector3(0,0,-0.01f);
            dragDrop.transform.rotation = this.transform.rotation;

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
        if (mainCamera != null && totalScore > 13)
        {
            mainCamera.transform.position = new Vector3(-20, 12, -10);
            Debug.Log("Camera position changed!");
            foreach (DragDrop item in itemsInDropArea)
            {
                item.transform.position = item.transform.position + new Vector3(-20, 12, 0);
            }
        }
        else if (mainCamera != null && totalScore <= 13)
        {
            mainCamera.transform.position = new Vector3(-22, -14, -10);
            Debug.Log("Camera position changed!");
            foreach (DragDrop item in itemsInDropArea)
            {
                item.transform.position = item.transform.position + new Vector3(-22, -14, 0);
            }
        }
        else
        {
            Debug.LogError("Main Camera reference is missing!");
        }


        // Disable the button
        if (actionButton != null)
        {
            actionButton.gameObject.SetActive(false); // Make the button disappear
            Debug.Log("Button has been disabled!");
        }
        else
        {
            Debug.LogError("Action Button reference is missing!");
        }
    }
}