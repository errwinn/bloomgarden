using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    [SerializeField] GameObject order, bunga1, bunga2, bunga3;
    [SerializeField] TextMeshProUGUI bunga1s1, bunga2s1, bunga3s1, bunga1s2, bunga2s2, bunga3s2, bunga1s3, bunga2s3, bunga3s3, text;
    [SerializeField] Manager manager;
    // Start is called before the first frame update
    void Update()
    {
        if(!manager.isTransactCompleted)
        {
            text.gameObject.SetActive(false);
            order.SetActive(true);
            bunga1.GetComponent<Image>().sprite = manager.orderanBungaGambar[0];
            bunga2.GetComponent<Image>().sprite = manager.orderanBungaGambar[1];
            bunga3.GetComponent<Image>().sprite = manager.orderanBungaGambar[2];
            bunga1s1.SetText(manager.inventoryBungaOrderanBintang1[0].ToString());
            bunga1s2.SetText(manager.inventoryBungaOrderanBintang2[0].ToString());
            bunga1s3.SetText(manager.inventoryBungaOrderanBintang3[0].ToString());
            bunga2s1.SetText(manager.inventoryBungaOrderanBintang1[1].ToString());
            bunga2s2.SetText(manager.inventoryBungaOrderanBintang2[1].ToString());
            bunga2s3.SetText(manager.inventoryBungaOrderanBintang3[1].ToString());
            bunga3s1.SetText(manager.inventoryBungaOrderanBintang1[2].ToString());
            bunga3s2.SetText(manager.inventoryBungaOrderanBintang2[2].ToString());
            bunga3s3.SetText(manager.inventoryBungaOrderanBintang3[2].ToString());
        }
        else
        {
            order.SetActive(false);
            text.gameObject.SetActive(true);
        }
    }   
}