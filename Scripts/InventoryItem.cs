using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public TextMeshProUGUI textCount;
    [SerializeField] GameObject label;
    public TextMeshProUGUI labelText;
    public Manager manager;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count;
    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Item newitem)
    {
        switch (newitem.name)
        {
            case "Mawar":
                count = manager.mawarSeedInventory;
                break;
            case "Saffron":
                count = manager.anggrekSeedInventory;
                break;
            case "Tulip":
                count = manager.tulipSeedInventory;
                break;
            case "Sun":
                count = manager.sunSeedInventory;
                break;
            case "Wheat":
                count = manager.wheatSeedInventory;
                break;
            case "Apel":
                count = manager.apelSeedInventory;
                break;
            case "Corn":
                count = manager.cornSeedInventory;
                break;
            case "Lily":
                count = manager.lilySeedInventory;
                break;
            case "MawarFlower":
                count = manager.mawarFlowerInventory;
                break;
            case "SaffronFlower":
                count = manager.anggrekFlowerInventory;
                break;
            case "TulipFlower":
                count = manager.tulipFlowerInventory;
                break;
            case "SunFlower":
                count = manager.sunFlowerInventory;
                break;
            case "CornFlower":
                count = manager.cornFruitInventory;
                break;
            case "WheatFlower":
                count = manager.wheatFlowerInventory;
                break;
            case "LilyFlower":
                count = manager.lilyFlowerInventory;
                break;
            case "Hand":
                count = 1;
                break;
        }
        if (count <= 0)
        {
            Destroy(this.gameObject);
        }
        item = newitem;
        image.sprite = newitem.image;
    }

    public void Update()
    {
        if(count > 0)
        {
            textCount.SetText(count.ToString());
        }
        if(item.name == "Hand")
        {
            textCount.gameObject.SetActive(false);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    IEnumerator showLabel()
    {
        label.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        label.SetActive(false);
    }

    public void startShowLabel()
    {
        StartCoroutine(showLabel());
    }
}