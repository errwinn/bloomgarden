using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    int selectedSlot = 0;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                for(int i=0; i<inventorySlots.Length; i++)
                {
                    if(touch.position.x >= inventorySlots[i].transform.position.x - 30f && touch.position.x <= inventorySlots[i].transform.position.x + 30f)
                    {
                        if (touch.position.y >= inventorySlots[i].transform.position.y - 30f && touch.position.y <= inventorySlots[i].transform.position.y + 30f)
                        {
                            ChangeSelectedSlot(i);
                        }
                    }
                }
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if(newValue >= 0)
        {
            inventorySlots[selectedSlot].deselect();

            inventorySlots[newValue].select();
            InventorySlot slot = inventorySlots[newValue];
            InventoryItem itemTemp = slot.GetComponentInChildren<InventoryItem>();
            selectedSlot = newValue;
            itemTemp.labelText.SetText(getSelectedItem().flowerName);
            itemTemp.startShowLabel();
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemTemp = slot.GetComponentInChildren<InventoryItem>();
            Debug.Log(itemTemp);
            if (itemTemp != null && itemTemp.item == item)
            {
                itemTemp.count++;
                return true;
            }
        }

        for (int i=0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemTemp = slot.GetComponentInChildren<InventoryItem>();
            if(itemTemp == null)
            {
                spawnItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void spawnItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item getSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null)
        {
            Item item = itemInSlot.item;
            return item;
        }
        return null;
    }

    public void decreaseCurrentInventory()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        itemInSlot.count--;
        if(itemInSlot.count <= 0)
        {
            Destroy(itemInSlot.gameObject);
        }
    }
}
