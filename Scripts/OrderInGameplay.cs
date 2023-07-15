using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu]
public class OrderInGameplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bunga1_t, bunga2_t, bunga3_t;
    [SerializeField] Image imageBunga1, imageBunga2, imageBunga3;
    [SerializeField] Sprite[] bunga;
    [SerializeField] Manager manager;

    void Start()
    {
        if (manager.isTransactCompleted)
        {
            manager.orderan.Clear();
            manager.jenis_bunga.Clear();
            for (int i = 0; i < 7; i++)
            {
                if (i == 5 || i == 4)
                {
                    continue;
                }
                manager.jenis_bunga.Add(i);
            }
            addOrder();
            manager.isTransactCompleted = false;
        }
    }

    private void Update()
    {
        if (!manager.isTransactCompleted)
        {
            getOrderBunga();
        }
        bunga1_t.SetText(manager.jumlahOrderan[0].ToString());
        bunga2_t.SetText(manager.jumlahOrderan[1].ToString());
        bunga3_t.SetText(manager.jumlahOrderan[2].ToString());
    }

    void getOrderBunga()
    {
        int i = 0;
        int[] inventoryOrderanBunga = new int[3];

        Sprite[] spArray = new Sprite[3];
        if (manager.orderan.ContainsKey(0) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[0];
            inventoryOrderanBunga[i] = manager.tulipFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.tulipStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.tulipStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.tulipStar3;
            spArray[i] = bunga[0];
            i++;
        }
        if (manager.orderan.ContainsKey(1) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[1];
            inventoryOrderanBunga[i] = manager.anggrekFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.anggrekStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.anggrekStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.anggrekStar3;
            spArray[i] = bunga[1];
            i++;
        }
        if (manager.orderan.ContainsKey(2) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[2];
            inventoryOrderanBunga[i] = manager.mawarFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.mawarStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.mawarStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.mawarStar3;
            spArray[i] = bunga[2];
            i++;
        }       
        if (manager.orderan.ContainsKey(3) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[3];
            inventoryOrderanBunga[i] = manager.wheatFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.wheatStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.wheatStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.wheatStar3;
            spArray[i] = bunga[4];
            i++;
        }        
        if (manager.orderan.ContainsKey(4) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[4];
            inventoryOrderanBunga[i] = manager.cornFruitInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.cornStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.cornStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.cornStar3;
            spArray[i] = bunga[5];
            i++;
        }        
        if (manager.orderan.ContainsKey(5) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[5];
            inventoryOrderanBunga[i] = manager.apelTreeInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.apelStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.apelStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.apelStar3;
            spArray[i] = bunga[6];
            i++;
        }        
        if (manager.orderan.ContainsKey(6) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[6];
            inventoryOrderanBunga[i] = manager.sunFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.sun1;
            manager.inventoryBungaOrderanBintang2[i] = manager.sun2;
            manager.inventoryBungaOrderanBintang3[i] = manager.sun3;
            spArray[i] = bunga[7];
            i++;
        }        
        if (manager.orderan.ContainsKey(7) && i <= 2)
        {
            manager.jumlahOrderan[i] = manager.orderan[7];
            inventoryOrderanBunga[i] = manager.lilyFlowerInventory;
            manager.inventoryBungaOrderanBintang1[i] = manager.lilyStar1;
            manager.inventoryBungaOrderanBintang2[i] = manager.lilyStar2;
            manager.inventoryBungaOrderanBintang3[i] = manager.lilyStar3;
            spArray[i] = bunga[7];
            i++;
        }
        manager.inventoryBungaOrderan[0] = inventoryOrderanBunga[0];
        manager.inventoryBungaOrderan[1] = inventoryOrderanBunga[1];
        manager.inventoryBungaOrderan[2] = inventoryOrderanBunga[2];
        manager.orderanBungaGambar[0] = spArray[0];
        manager.orderanBungaGambar[1] = spArray[1];
        manager.orderanBungaGambar[2] = spArray[2];
        imageBunga1.sprite = spArray[0];
        imageBunga2.sprite = spArray[1];
        imageBunga3.sprite = spArray[2];
    }

    void addOrder()
    {
        shuffle();
        manager.difficulty++;
    }

    void shuffle()
    {
        //Mengacak jumlah bunga sesuai tingkat difficulty
        int bunga1 = (int)Random.Range(2 * manager.difficulty - 1, 3 * manager.difficulty - 1);
        int bunga2 = (int)Random.Range(2 * manager.difficulty - 1, 3 * manager.difficulty - 1);
        int bunga3 = (int)Random.Range(2 * manager.difficulty + 1, 3 * manager.difficulty - 1);
        int randomCounter = Random.Range(0, 4);
        manager.orderan.Add((int)manager.jenis_bunga[randomCounter], bunga1);
        manager.jenis_bunga.RemoveAt(randomCounter);
        int randomCounter2 = Random.Range(0, 3);
        manager.orderan.Add((int)manager.jenis_bunga[randomCounter2], bunga2);
        manager.jenis_bunga.RemoveAt(randomCounter2);
        int randomCounter3 = Random.Range(0, 2);
        manager.orderan.Add((int)manager.jenis_bunga[randomCounter3], bunga3);
        manager.jenis_bunga.RemoveAt(randomCounter3);
    }
}
