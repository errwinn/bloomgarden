using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemName;
    public Image image;
    public Color selectedColor, notSelectedColor;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] TextMeshProUGUI text;

    public void select()
    {
        image.color = selectedColor;
    }

    public void deselect()
    {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem inventoryItem = pointerEventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform; 
        }
    }
}
