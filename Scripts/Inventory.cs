using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    bool isOpenDetail;
    [SerializeField] Manager manager;
    [SerializeField] TextMeshProUGUI tulipstar1, tulipstar2, tulipstar3, anggrekstar1, anggrekstar2, anggrekstar3, mawarStar1, mawarStar2, mawarStar3, tulipFlowerInventory, mawarFlowerInventory, anggrekFlowerInventory;
    [SerializeField] GameObject inventoryTulip, inventoryAnggrek, inventoryMawar, inventoryDetailTulip, inventoryDetailAnggrek, inventoryDetailMawar;
    [SerializeField] GameObject buttonOpen, buttonClose;
    // Start is called before the first frame update
    void Start()
    {
        isOpenDetail = false;
        if (manager.isFirstTimePlaying)
        {
            manager.tulipSeedInventory = 10;
            manager.anggrekSeedInventory = 10;
            manager.mawarSeedInventory = 10;
            manager.sunSeedInventory = 10;
            manager.sunFlowerInventory = 0;
            manager.wheatSeedInventory = 10;
            manager.wheatFlowerInventory = 0;
            manager.sun1 = 0;
            manager.sun2 = 0;
            manager.sun3 = 0;
            manager.cornFruitInventory = 0;
            manager.cornSeedInventory = 10;
            manager.cornStar1 = 0;
            manager.cornStar2 = 0;
            manager.cornStar3 = 0;
            manager.apelTreeInventory = 0;
            manager.apelSeedInventory = 10;
            manager.apelStar1 = 0;
            manager.apelStar2 = 0;
            manager.apelStar3 = 0;
            manager.tulipFlowerInventory = 0;
            manager.anggrekFlowerInventory = 0;
            manager.mawarFlowerInventory = 0;
            manager.tulipStar1 = 0;
            manager.tulipStar2 = 0;
            manager.tulipStar3 = 0;
            manager.anggrekStar1 = 0;
            manager.anggrekStar2 = 0;
            manager.anggrekStar3 = 0;
            manager.mawarStar1 = 0;
            manager.mawarStar2 = 0;
            manager.mawarStar3 = 0;
            manager.lilyFlowerInventory = 0;
            manager.lilySeedInventory = 0;
            manager.lilyStar1 = 0;
            manager.lilyStar2 = 0;
            manager.lilyStar3 = 0;
            manager.isFirstTimePlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tulipFlowerInventory.SetText(manager.tulipFlowerInventory.ToString());
        mawarFlowerInventory.SetText(manager.mawarFlowerInventory.ToString());
        anggrekFlowerInventory.SetText(manager.anggrekFlowerInventory.ToString());

        tulipstar1.SetText(manager.tulipStar1.ToString());
        tulipstar2.SetText(manager.tulipStar2.ToString());
        tulipstar3.SetText(manager.tulipStar3.ToString());
        anggrekstar1.SetText(manager.anggrekStar1.ToString());
        anggrekstar2.SetText(manager.anggrekStar2.ToString());
        anggrekstar3.SetText(manager.anggrekStar3.ToString());
        mawarStar1.SetText(manager.mawarStar1.ToString());
        mawarStar2.SetText(manager.mawarStar2.ToString());
        mawarStar3.SetText(manager.mawarStar3.ToString());
    }

    public void openDetailTulipInventory()
    {
        isOpenDetail = true;
        inventoryMawar.SetActive(false);
        inventoryAnggrek.SetActive(false);
        inventoryDetailTulip.SetActive(true);
    }

    public void openDetailAnggrekInventory()
    {
        isOpenDetail = true;
        inventoryMawar.SetActive(false);
        inventoryTulip.SetActive(false);
        inventoryAnggrek.SetActive(true);
        inventoryDetailAnggrek.SetActive(true);
    }
    public void openDetailMawarInventory()
    {
        isOpenDetail = true;
        inventoryAnggrek.SetActive(false);
        inventoryTulip.SetActive(false);
        inventoryMawar.SetActive(true);
        inventoryDetailMawar.SetActive(true);
    }

    public void closeAllDetail()
    {
        if (isOpenDetail)
        {
            inventoryDetailAnggrek.SetActive(false);
            inventoryDetailTulip.SetActive(false);
            inventoryDetailMawar.SetActive(false);
            inventoryAnggrek.SetActive(true);
            inventoryMawar.SetActive(true);
            inventoryTulip.SetActive(true);
            isOpenDetail = false;
        } 
        else
        {
            inventoryMawar.SetActive(false);
            inventoryTulip.SetActive(false);
            inventoryAnggrek.SetActive(false);
            buttonClose.SetActive(false);
            buttonOpen.SetActive(true);
        }
    }


    public void openInventory()
    {
        buttonOpen.SetActive(false);
        buttonClose.SetActive(true);
        inventoryTulip.SetActive(true);
        inventoryMawar.SetActive(true);
        inventoryAnggrek.SetActive(true);
    }
}
