using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    private bool isTarget = false;
    private int id;
    private int count;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public void init(int itemId, int itemCount)
    {
        id = itemId;
        count = itemCount;
        Item itemData = ItemList.Instance.GetItem(id);
        if (itemData != null)
        {
            spriteRenderer.sprite = itemData.icon;
        }
    }

    public int GetId()
    {
        return id;
    }
    public int GetCount()
    {
        return count;
    }
    public bool IsTarget()
    {
        return isTarget;
    }
    public void SetTarget(bool isTarget)
    {
        this.isTarget = isTarget;
    }
    public void SetColor(bool isTarget)
    {
        Color color = spriteRenderer.color;
        color.a = isTarget ? 0.5f : 1f;
        spriteRenderer.color = color;
    }
}