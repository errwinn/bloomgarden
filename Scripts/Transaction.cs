using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transaction : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] GameObject player, bucketOfTulip, bucketOfMawar, bucketOfSaffron, gagalButton, canvas, meja, kursi;
    int sisa;
    float speedTulip, speedMawar, speedSaffron;
    bool isTransact;

    void Start()
    {
        sisa = 0;
        speedTulip = 0;
        speedSaffron = 0;
        speedMawar = 0;
    }

    public void transact()
    {
        bool isTulipEnough = false, isAnggrekEnough = false, isMawarEnough = false;
        if (manager.inventoryBungaOrderan[0] - manager.jumlahOrderan[0] >= 0)
        {
            isTulipEnough = true;
        }
        if (manager.inventoryBungaOrderan[1] - manager.jumlahOrderan[1] >= 0)
        {
            isAnggrekEnough = true;
        }
        if (manager.inventoryBungaOrderan[2] - manager.jumlahOrderan[2] >= 0)
        {
            isMawarEnough = true;
        }
        if (isTulipEnough && isAnggrekEnough && isMawarEnough)
        {
            if (manager.inventoryBungaOrderan[0] - manager.jumlahOrderan[0] >= 0)
            {
                if (manager.inventoryBungaOrderanBintang1[0] - manager.jumlahOrderan[0] >= 0)
                {

                    sisa += 1;
                }
                else
                {
                    int sisabunga = manager.jumlahOrderan[0] - manager.inventoryBungaOrderanBintang1[0];
                    if (manager.inventoryBungaOrderanBintang2[0] - sisabunga >= 0)
                    {
                        sisa += 5;
                    }
                    else
                    {
                        int sisabunga2 = sisabunga - manager.inventoryBungaOrderanBintang2[0];
                        if (manager.inventoryBungaOrderanBintang3[0] - sisabunga2 >= 0)
                        {
                            sisa += 15;
                        }
                    }
                }
            }
            if (manager.inventoryBungaOrderan[1] - manager.jumlahOrderan[1] >= 0)
            {
                if (manager.inventoryBungaOrderanBintang1[1] - manager.jumlahOrderan[1] >= 0)
                {
                    sisa += 10;
                }
                else
                {
                    int sisabunga = manager.jumlahOrderan[1] - manager.inventoryBungaOrderanBintang1[1];
                    if (manager.inventoryBungaOrderanBintang2[1] - sisabunga >= 0)
                    {
                        sisa += 5;
                    }
                    else
                    {
                        int sisabunga2 = sisabunga - manager.inventoryBungaOrderanBintang2[1];
                        if (manager.inventoryBungaOrderanBintang3[1] - sisabunga2 >= 0)
                        {
                            sisa += 10;
                        }
                    }
                }
            }
            if (manager.inventoryBungaOrderan[2] - manager.jumlahOrderan[2] >= 0)
            {
                if (manager.inventoryBungaOrderanBintang1[2] - manager.jumlahOrderan[2] >= 0)
                {
                    sisa += 10;
                }
                else
                {
                    int sisabunga = manager.jumlahOrderan[2] - manager.inventoryBungaOrderanBintang1[2];
                    if (manager.inventoryBungaOrderanBintang2[2] - sisabunga >= 0)
                    {
                        sisa += 5;
                    }
                    else
                    {
                        int sisabunga2 = sisabunga - manager.inventoryBungaOrderanBintang2[2];
                        if (manager.inventoryBungaOrderanBintang3[2] - sisabunga2 >= 0)
                        {
                            sisa += 10;
                        }
                    }
                }
            }
            DecreaseInventoryForTransaction();
            manager.tulipSeedInventory += sisa - 15;
            manager.anggrekSeedInventory += sisa - 10;
            manager.mawarSeedInventory += sisa - 9;
            manager.wheatSeedInventory += sisa - 12;
            manager.sunSeedInventory += sisa - 10;
            canvas.SetActive(false);
            meja.SetActive(false);
            kursi.SetActive(false);
            player.SetActive(false);
            manager.isTransactCompleted = true;
            isTransact = true;
        }
        else
        {
            StartCoroutine(showFail());
        }
    }

    void DecreaseInventoryForTransaction()
    {
        int i = 0;
        if (manager.orderan.ContainsKey(0))
        {
            manager.tulipFlowerInventory -= manager.jumlahOrderan[i];
            if(manager.tulipStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.tulipStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.tulipStar1;
                manager.tulipStar1 -= manager.tulipStar1;
                if(manager.tulipStar2 - sisa1 >= 0)
                {
                    manager.tulipStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.tulipStar2;
                    manager.tulipStar2 -= manager.tulipStar2;
                    if(manager.tulipStar3 - sisa2 >= 0)
                    {
                        manager.tulipStar3 -= sisa2;
                    }
                }
            }
            i++;
        }        
        if (manager.orderan.ContainsKey(1))
        {
            manager.anggrekFlowerInventory -= manager.jumlahOrderan[i];
            if(manager.anggrekStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.anggrekStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.anggrekStar1;
                manager.anggrekStar1 -= manager.anggrekStar1;
                if(manager.anggrekStar2 - sisa1 >= 0)
                {
                    manager.anggrekStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.anggrekStar2;
                    manager.anggrekStar2 -= manager.anggrekStar2;
                    if(manager.anggrekStar3 - sisa2 >= 0)
                    {
                        manager.anggrekStar3 -= sisa2;
                    }
                }
            }
            i++;
        }        
        if (manager.orderan.ContainsKey(2))
        {
            manager.mawarFlowerInventory -= manager.jumlahOrderan[i];
            if(manager.mawarStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.mawarStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.mawarStar1;
                manager.mawarStar1 -= manager.mawarStar1;
                if(manager.mawarStar2 - sisa1 >= 0)
                {
                    manager.mawarStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.mawarStar2;
                    manager.mawarStar2 -= manager.mawarStar2;
                    if(manager.mawarStar3 - sisa2 >= 0)
                    {
                        manager.mawarStar3 -= sisa2;
                    }
                }
            }
            i++;
        }
        if (manager.orderan.ContainsKey(3))
        {
            manager.wheatFlowerInventory -= manager.jumlahOrderan[i];
            if (manager.wheatStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.wheatStar1 -= manager.jumlahOrderan[i];
            }
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.wheatStar1;
                manager.wheatStar1 -= manager.wheatStar1;
                if (manager.wheatStar2 - sisa1 >= 0)
                {
                    manager.wheatStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.wheatStar2;
                    manager.wheatStar2 -= manager.wheatStar2;
                    if (manager.wheatStar3 - sisa2 >= 0)
                    {
                        manager.wheatStar3 -= sisa2;
                    }
                }
            }
            i++;
        }
        if (manager.orderan.ContainsKey(4))
        {
            manager.cornFruitInventory -= manager.jumlahOrderan[i];
            if(manager.cornStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.cornStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.cornStar1;
                manager.cornStar1 -= manager.cornStar1;
                if(manager.cornStar2 - sisa1 >= 0)
                {
                    manager.cornStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.cornStar2;
                    manager.cornStar2 -= manager.cornStar2;
                    if(manager.cornStar3 - sisa2 >= 0)
                    {
                        manager.cornStar3 -= sisa2;
                    }
                }
            }
            i++;
        }           
        if (manager.orderan.ContainsKey(5))
        {
            manager.apelTreeInventory -= manager.jumlahOrderan[i];
            if(manager.apelStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.apelStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.apelStar1;
                manager.apelStar1 -= manager.apelStar1;
                if(manager.apelStar2 - sisa1 >= 0)
                {
                    manager.apelStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.apelStar2;
                    manager.apelStar2 -= manager.apelStar2;
                    if(manager.apelStar3 - sisa2 >= 0)
                    {
                        manager.apelStar3 -= sisa2;
                    }
                }
            }
            i++;
        }        
        if (manager.orderan.ContainsKey(6))
        {
            manager.sunFlowerInventory -= manager.jumlahOrderan[i];
            if(manager.sun1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.sun1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.sun1;
                manager.sun1 -= manager.sun1;
                if(manager.sun2 - sisa1 >= 0)
                {
                    manager.sun2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.sun2;
                    manager.sun2 -= manager.sun2;
                    if(manager.sun3 - sisa2 >= 0)
                    {
                        manager.sun3 -= sisa2;
                    }
                }
            }
            i++;
        }        
        if (manager.orderan.ContainsKey(7))
        {
            manager.lilyFlowerInventory -= manager.jumlahOrderan[i];
            if(manager.lilyStar1 - manager.jumlahOrderan[i] >= 0)
            {
                manager.lilyStar1 -= manager.jumlahOrderan[i];
            } 
            else
            {
                int sisa1 = manager.jumlahOrderan[i] - manager.lilyStar1;
                manager.lilyStar1 -= manager.lilyStar1;
                if(manager.lilyStar2 - sisa1 >= 0)
                {
                    manager.lilyStar2 -= sisa1;
                }
                else
                {
                    int sisa2 = sisa1 - manager.lilyStar2;
                    manager.lilyStar2 -= manager.lilyStar2;
                    if(manager.lilyStar3 - sisa2 >= 0)
                    {
                        manager.lilyStar3 -= sisa2;
                    }
                }
            }
            i++;
        }       
    }

    IEnumerator showFail()
    {
        gagalButton.SetActive(true);
        yield return new WaitForSeconds(1);
        gagalButton.SetActive(false);
    }

    IEnumerator showFlower()
    {
        speedTulip = 40f;
        yield return new WaitForSeconds(0.3f);
        speedTulip = 0;
        yield return new WaitForSeconds(1f);
        bucketOfTulip.SetActive(false);
        speedSaffron = 40f;
        yield return new WaitForSeconds(0.3f);
        speedSaffron = 0;
        yield return new WaitForSeconds(1f);
        bucketOfSaffron.SetActive(false);
        speedMawar = 40f;
        yield return new WaitForSeconds(0.3f);
        speedMawar = 0;
        yield return new WaitForSeconds(1f);
        isTransact = false;
        SceneManager.LoadScene(3); 
    }

    private void Update()
    {
        if (isTransact)
        {
            StartCoroutine(showFlower());
        }
        bucketOfTulip.transform.Translate(Vector2.up * Time.deltaTime * speedTulip);
        bucketOfSaffron.transform.Translate(Vector2.up * Time.deltaTime * speedSaffron);
        bucketOfMawar.transform.Translate(Vector2.up * Time.deltaTime * speedMawar);
    }
}

   