using UnityEngine;

public class DropAreaTop : DropArea, IDropArea
{
    public override void OnItemDrop(DragDrop dragDrop)
    {
        base.OnItemDrop(dragDrop);

        dragDrop.transform.position = this.transform.position;
    }
}
