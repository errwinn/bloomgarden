using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] InventoryManager invManager;
    public int idFlower, quality, level;
    bool hasPassed, isAlive, spawned;
    public bool isNeedWatering, isHarvested, isReadyToHarvest, isWatered;
    float growingIntervalTime, wateringNeededIntervalTime;
    [SerializeField] GameObject watering_icon, watering_icon_prefab, harvest_icon, harvest_icon_prefab, teko_ikon, bWater;
    [SerializeField] Sprite mawar1, mawar2, mawar3, mawar4, mawar5;
    [SerializeField] Sprite anggrek1, anggrek2, anggrek3, anggrek4, anggrek5, anggreklayu;
    [SerializeField] Sprite tulip1, tulip2, tulip3, tulip4, tulip5;
    [SerializeField] Sprite wheat1, wheat2, wheat3, wheat4, wheat5, wheatlayu;
    [SerializeField] Sprite sun1, sun2, sun3, sun4, sun5, sunlayu;
    [SerializeField] Sprite corn1, corn2, corn3, corn4, corn5, cornlayu;
    [SerializeField] Sprite apel1, apel2, apel3, apel4, apel5, apellayu;
    [SerializeField] Sprite pisang1, pisang2, pisang3, pisang4, pisang5, pisanglayu;
    [SerializeField] Sprite lily1, lily2, lily3, lily4, lily5, lililayu;
    SpriteRenderer spriterenderer;
    AudioSource audioCut;
    void Awake()
    {
        isWatered = false;
        manager.isbWaterActive = false;
        audioCut = GetComponent<AudioSource>();
        spawned = false;
        isAlive = true;
        quality = 3;
        level = 0;
        hasPassed = true;
        idFlower = manager.currentPressed;
        isReadyToHarvest = false;
        isNeedWatering = true;
        spriterenderer = GetComponent<SpriteRenderer>();
        wateringNeededIntervalTime = Time.time;
        if (idFlower == 3)
        {
            spriterenderer.sprite = mawar1;
        } 
        else if(idFlower == 2)
        {
            spriterenderer.sprite = anggrek1;
        } 
        else if(idFlower == 1)
        {
            spriterenderer.sprite = tulip1;
        } 
        else if(idFlower == 4)
        {
            spriterenderer.sprite = wheat1;
        }        
        else if(idFlower == 5)
        {
            spriterenderer.sprite = corn1;
        }        
        else if(idFlower == 6)
        {
            spriterenderer.sprite = apel1;
        }        
        else if(idFlower == 7)
        {
            spriterenderer.sprite = sun1;
        } 
        else if(idFlower == 8)
        {
            spriterenderer.sprite = lily1;
        }
        watering_icon_prefab = Instantiate(watering_icon, new Vector2(transform.position.x, transform.position.y + 0.7f), watering_icon.transform.rotation);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        if (Time.time - growingIntervalTime > 8.5 && !isReadyToHarvest && isAlive && !isNeedWatering) //tumbuhan tumbuh
        {
            growingIntervalTime = Time.time;
            level++;
            growPlant();
        }

        if (isWatered && isNeedWatering && !isReadyToHarvest) //player melakukan aksi siram
        {
            isWatered = false;
            wateringNeededIntervalTime = Time.time;
            growingIntervalTime = Time.time;
            isNeedWatering = false;
            hasPassed = false;
            Destroy(watering_icon_prefab);
            Instantiate(teko_ikon, new Vector2(transform.position.x, transform.position.y + 0.7f), teko_ikon.transform.rotation);
            manager.isbWaterActive = false;
        }

        if ((Time.time - wateringNeededIntervalTime > 25.7 && !hasPassed) && !isReadyToHarvest) //Waktunya siram air
        {
            watering_icon_prefab = Instantiate(watering_icon, new Vector2(transform.position.x, transform.position.y + 0.7f), watering_icon.transform.rotation);
            isNeedWatering = true;
            wateringNeededIntervalTime = Time.time;
            hasPassed = true;
        }

        if((Time.time - wateringNeededIntervalTime > 16.5 && isAlive) && !isReadyToHarvest && isNeedWatering) //Player melewati waktu siraman selama 30 detik
        {
            Debug.Log("Kualitas bunga menurun!");
            wateringNeededIntervalTime = Time.time;
            quality--;
            switch (quality)
            {
                case 0:
                    isAlive = false;
                    break;
                case 1:
                    watering_icon_prefab.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                    break;
                case 2:
                    watering_icon_prefab.GetComponent<SpriteRenderer>().color = new Color32(255, 141, 141, 255);
                    break;
            }
        }

        if (isReadyToHarvest && isAlive)
        {
            isNeedWatering = false;
            if(watering_icon_prefab != null)
            {
                Destroy(watering_icon_prefab);
            }
            if (!spawned)
            {
                harvest_icon_prefab = Instantiate(harvest_icon, new Vector2(transform.position.x, transform.position.y + 0.9f), harvest_icon.transform.rotation);
                spawned = true;
            }
            if(isHarvested)
            {
                saveToInventory();
                Destroy(harvest_icon_prefab);
                audioCut.Play();
                isHarvested = false;
                Destroy(gameObject);
            }
        }

        if (!isAlive)
        {
            isNeedWatering = false;
            hasPassed = true;
            if(idFlower == 2)
            {
                spriterenderer.sprite = anggreklayu;
            }
            else
            {
                spriterenderer.color = new Color(0, 0, 0);
            }
            StartCoroutine(passTime());
        }

        void growPlant()
        {
            if (idFlower == 3)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = mawar2;
                        break;
                    case 2:
                        spriterenderer.sprite = mawar3;
                        break;
                    case 3:
                        spriterenderer.sprite = mawar4;
                        break;
                    case 4:
                        spriterenderer.sprite = mawar5;
                        isReadyToHarvest = true;
                        break;
                }
            }
            else if (idFlower == 2)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = anggrek2;
                        break;
                    case 2:
                        spriterenderer.sprite = anggrek3;
                        break;
                    case 3:
                        spriterenderer.sprite = anggrek4;
                        break;
                    case 4:
                        spriterenderer.sprite = anggrek5;
                        isReadyToHarvest = true;
                        break;
                }
            }
            else if (idFlower == 1)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = tulip2;
                        break;
                    case 2:
                        spriterenderer.sprite = tulip3;
                        break;
                    case 3:
                        spriterenderer.sprite = tulip4;
                        break;
                    case 4:
                        spriterenderer.sprite = tulip5;
                        isReadyToHarvest = true;
                        break;
                }
            }            
            else if (idFlower == 4)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = wheat2;
                        break;
                    case 2:
                        spriterenderer.sprite = wheat3;
                        break;
                    case 3:
                        spriterenderer.sprite = wheat4;
                        break;
                    case 4:
                        spriterenderer.sprite = wheat5;
                        isReadyToHarvest = true;
                        break;
                }
            }            
            else if (idFlower == 5)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = corn2;
                        break;
                    case 2:
                        spriterenderer.sprite = corn3;
                        break;
                    case 3:
                        spriterenderer.sprite = corn4;
                        break;
                    case 4:
                        spriterenderer.sprite = corn5;
                        isReadyToHarvest = true;
                        break;
                }
            }            
            else if (idFlower == 6)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = apel2;
                        break;
                    case 2:
                        spriterenderer.sprite = apel3;
                        break;
                    case 3:
                        spriterenderer.sprite = apel4;
                        break;
                    case 4:
                        spriterenderer.sprite = apel5;
                        isReadyToHarvest = true;
                        break;
                }
            }            
            else if (idFlower == 7)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = sun2;
                        break;
                    case 2:
                        spriterenderer.sprite = sun3;
                        break;
                    case 3:
                        spriterenderer.sprite = sun4;
                        break;
                    case 4:
                        spriterenderer.sprite = sun5;
                        isReadyToHarvest = true;
                        break;
                }
            }            
            else if (idFlower == 8)
            {
                switch (level)
                {
                    case 1:
                        spriterenderer.sprite = lily2;
                        break;
                    case 2:
                        spriterenderer.sprite = lily3;
                        break;
                    case 3:
                        spriterenderer.sprite = lily4;
                        break;
                    case 4:
                        spriterenderer.sprite = lily5;
                        isReadyToHarvest = true;
                        break;
                }
            }
        }
    }

    void saveToInventory()
    {
        if (idFlower == 1)
        {
            switch (quality) 
            {
                case 1:
                    manager.tulipStar1 += 1;
                    break;
                case 2:
                    manager.tulipStar2 += 1;
                    break;
                case 3:
                    manager.tulipStar3 += 1;
                    break;
            }

        }
        else if (idFlower == 2)
        {
            switch (quality)
            {
                case 1:
                    manager.anggrekStar1 += 1;
                    break;
                case 2:
                    manager.anggrekStar2 += 1;
                    break;
                case 3:
                    manager.anggrekStar3 += 1;
                    break;
            }
        }
        else if (idFlower == 3)
        {
            switch (quality)
            {
                case 1:
                    manager.mawarStar1 += 1;
                    break;
                case 2:
                    manager.mawarStar2 += 1;
                    break;
                case 3:
                    manager.mawarStar3 += 1;
                    break;
            }
        }        
        else if (idFlower == 4)
        {
            switch (quality)
            {
                case 1:
                    manager.wheatStar1 += 1;
                    break;
                case 2:
                    manager.wheatStar2 += 1;
                    break;
                case 3:
                    manager.wheatStar3 += 1;
                    break;
            }
        }        
        else if (idFlower == 5)
        {
            switch (quality)
            {
                case 1:
                    manager.cornStar1 += 1;
                    break;
                case 2:
                    manager.cornStar2 += 1;
                    break;
                case 3:
                    manager.cornStar3 += 1;
                    break;
            }
        }        
        else if (idFlower == 6)
        {
            switch (quality)
            {
                case 1:
                    manager.apelStar1 += 1;
                    break;
                case 2:
                    manager.apelStar2 += 1;
                    break;
                case 3:
                    manager.apelStar3 += 1;
                    break;
            }
        }        
        else if (idFlower == 7)
        {
            switch (quality)
            {
                case 1:
                    manager.sun1 += 1;
                    break;
                case 2:
                    manager.sun2 += 1;
                    break;
                case 3:
                    manager.sun3 += 1;
                    break;
            }
        }        
        else if (idFlower == 8)
        {
            switch (quality)
            {
                case 1:
                    manager.lilyStar1 += 1;
                    break;
                case 2:
                    manager.lilyStar2 += 1;
                    break;
                case 3:
                    manager.lilyStar3 += 1;
                    break;
            }
        }
    }

    IEnumerator passTime()
    {
        yield return new WaitForSeconds(5);
        if(watering_icon != null)
        {
            Destroy(watering_icon);
        }
        Destroy(this.gameObject);
    }
}
