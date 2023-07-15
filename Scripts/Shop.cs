using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] Sprite[] bunga;
    int orderBunga1star1, orderBunga1star2, orderBunga1star3, orderBunga2star1, orderBunga2star2, orderBunga2star3, orderBunga3star1, orderBunga3star2, orderBunga3star3; 
    [SerializeField] TextMeshProUGUI tulipStar1, tulipStar2, tulipStar3, anggrekStar1, anggrekStar2, anggrekStar3, mawarStar1, mawarStar2, mawarStar3;
    [SerializeField] Image bunga1_g, bunga2_g, bunga3_g;
    [SerializeField] Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        bunga = new Sprite[8];
        for (int i = 0; i < 4; i++)
        {
            manager.jenis_bunga.Add(i);
        }
    }

    private void Update()
    {
        getInventoryDetailBunga();
        tulipStar1.SetText(orderBunga1star1.ToString());
        tulipStar2.SetText(orderBunga1star2.ToString());
        tulipStar3.SetText(orderBunga1star3.ToString());
        anggrekStar1.SetText(orderBunga2star1.ToString());
        anggrekStar2.SetText(orderBunga2star2.ToString());
        anggrekStar3.SetText(orderBunga2star3.ToString());
        mawarStar1.SetText(orderBunga3star1.ToString());
        mawarStar2.SetText(orderBunga3star2.ToString());
        mawarStar3.SetText(orderBunga3star3.ToString());
    }

    void getInventoryDetailBunga()
    {
        int i = 0;
        int[] orderanBungastar1 = new int[3];
        int[] orderanBungastar2 = new int[3];
        int[] orderanBungastar3 = new int[3];
        
        Sprite[] spArray = new Sprite[3];
        if (manager.orderan.ContainsKey(0) && i <= 2)
        {
            orderanBungastar1[i] = manager.tulipStar1;
            orderanBungastar2[i] = manager.tulipStar2;
            orderanBungastar3[i] = manager.tulipStar3;
            spArray[i] = bunga[0];
            i++;
        }
        if (manager.orderan.ContainsKey(1) && i <= 2)
        {
            orderanBungastar1[i] = manager.anggrekStar1;
            orderanBungastar2[i] = manager.anggrekStar2;
            orderanBungastar3[i] = manager.anggrekStar3;
            spArray[i] = bunga[1];
            i++;
        }
        if (manager.orderan.ContainsKey(2) && i <= 2)
        {
            orderanBungastar1[i] = manager.mawarStar1;
            orderanBungastar2[i] = manager.mawarStar2;
            orderanBungastar3[i] = manager.mawarStar3;
            spArray[i] = bunga[2];
            i++;
        }
        if (manager.orderan.ContainsKey(3) && i <= 2)
        {
            orderanBungastar1[i] = manager.wheatStar1;
            orderanBungastar2[i] = manager.wheatStar2;
            orderanBungastar3[i] = manager.wheatStar3;
            spArray[i] = bunga[3];
            i++;
        }
        if (manager.orderan.ContainsKey(4) && i <= 2)
        {
            orderanBungastar1[i] = manager.cornStar1;
            orderanBungastar2[i] = manager.cornStar2;
            orderanBungastar3[i] = manager.cornStar3;
            spArray[i] = bunga[4];
            i++;
        }
        if (manager.orderan.ContainsKey(5) && i <= 2)
        {
            orderanBungastar1[i] = manager.apelStar1;
            orderanBungastar2[i] = manager.apelStar2;
            orderanBungastar3[i] = manager.apelStar3;
            spArray[i] = bunga[5];
            i++;
        }
        if (manager.orderan.ContainsKey(6) && i <= 2)
        {
            orderanBungastar1[i] = manager.sun1;
            orderanBungastar2[i] = manager.sun2;
            orderanBungastar3[i] = manager.sun3;
            spArray[i] = bunga[6];
            i++;
        }        
        if (manager.orderan.ContainsKey(7) && i <= 2)
        {
            orderanBungastar1[i] = manager.lilyStar1;
            orderanBungastar2[i] = manager.lilyStar2;
            orderanBungastar3[i] = manager.lilyStar3;
            spArray[i] = bunga[7];
            i++;
        }        
        orderBunga1star1 = orderanBungastar1[0];
        orderBunga1star2 = orderanBungastar2[0];
        orderBunga1star3 = orderanBungastar3[0];   
        
        orderBunga2star1 = orderanBungastar1[1];
        orderBunga2star2 = orderanBungastar2[1];
        orderBunga2star3 = orderanBungastar3[1];
        
        orderBunga3star1 = orderanBungastar1[2];
        orderBunga3star2 = orderanBungastar2[2];
        orderBunga3star3 = orderanBungastar3[2];

        bunga1_g.sprite = spArray[0];
        bunga2_g.sprite = spArray[1];
        bunga3_g.sprite = spArray[2];
    }
}
