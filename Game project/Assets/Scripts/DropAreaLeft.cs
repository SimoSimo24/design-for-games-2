using UnityEngine;

public class DropAreaLeft : DropArea, IDropArea
{
    public override void OnItemDrop(DragDrop dragDrop)
    {
        base.OnItemDrop(dragDrop);

        dragDrop.transform.position = this.transform.position;
        dragDrop.transform.rotation = this.transform.rotation;
    }
}
