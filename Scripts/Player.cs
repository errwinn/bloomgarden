using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] Manager manager;
    [SerializeField] InventoryManager inventoryManager;
    public GameObject seed, bPlant, detailInventory, bWater, bHarvest, noGoShopSign;
    IDictionary<string, Flower> flowerInstances = new Dictionary<string, Flower>();
    public Item itemTulip, itemSaffron, itemMawar, itemWheat, itemCorn, itemApel, itemSun, itemLily;
    public Button bOpenDetailInventory;
    List<Vector2> plantedArea = new List<Vector2>();
    bool isFacingLeft, isWateringButtonPressed, isPlantButtonPressed;
    float speed, factorScaler;
    // Start is called before the first frame update
    void Start()
    {
        manager.currentscene = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFacingLeft = true;
        speed = 3f;
        bOpenDetailInventory.onClick.AddListener(OpenDetailInventory);
        isWateringButtonPressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        Plant();
        WateringPlantMechanism();

        manager.playerPositionFromBirdX = transform.position.x;
        manager.playerPositionFromBirdY = transform.position.y;
        

        if(transform.position.x > 10.5 && transform.position.x < 13.5 && transform.position.y > -1 && transform.position.y < 1.5)
        {
            GameObject f = GameObject.FindGameObjectWithTag("Seed");
            if(f != null)
            {
                noGoShopSign.SetActive(true);
            } 
            else
            {
                manager.isTransactCompleted = false;
                noGoShopSign.SetActive(false);
                SceneManager.LoadScene(3);
            }
        } else
        {
            noGoShopSign.SetActive(false);
        }
    }

    void Plant()
    {
        bool isInArea = transform.position.x > -21 && transform.position.x < -6 && ((transform.position.y < 13 && transform.position.y > 6) || (transform.position.y < 0 && transform.position.y > -7));

        int positionX = roundOff(transform.position.x);
        int positionY = roundOff(transform.position.y);
        factorScaler = positionY <= 0 ? positionY - 0.8f : positionY + 0.15f;
        if (isInArea && !plantedArea.Contains(new Vector2(positionX, factorScaler)))
        {
            bPlant.SetActive(true);

            if (isPlantButtonPressed)
            {
                Item flowerSeed = inventoryManager.getSelectedItem();
                switch (flowerSeed.name)
                {
                    case "Mawar":
                        manager.currentPressed = 3;
                        break;
                    case "Saffron":
                        manager.currentPressed = 2;
                        break;
                    case "Tulip":
                        manager.currentPressed = 1;
                        break;
                    case "Wheat":
                        manager.currentPressed = 4;
                        break;
                    case "Corn":
                        manager.currentPressed = 5;
                        break;
                    case "Apel":
                        manager.currentPressed = 6;
                        break;
                    case "Sun":
                        manager.currentPressed = 7;
                        break;
                    case "Lily":
                        manager.currentPressed = 8;
                        break;
                    default:
                        manager.currentPressed = -1;
                        break;
                }

                if (!plantedArea.Contains(new Vector2(positionX, factorScaler)))
                {
                    string coordinate = positionX.ToString() + positionY.ToString();
                    if (manager.currentPressed == 1 && manager.tulipSeedInventory > 0)
                    {
                        manager.tulipSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }
                    else if (manager.currentPressed == 2 && manager.anggrekSeedInventory > 0)
                    {
                        manager.anggrekSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }
                    else if (manager.currentPressed == 3 && manager.mawarSeedInventory > 0)
                    {
                        manager.mawarSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }                    
                    else if (manager.currentPressed == 4 && manager.wheatSeedInventory > 0)
                    {
                        manager.wheatSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }                    
                    else if (manager.currentPressed == 5 && manager.cornSeedInventory > 0)
                    {
                        manager.cornSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }                    
                    else if (manager.currentPressed == 6 && manager.apelSeedInventory > 0)
                    {
                        manager.apelSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }                    
                    else if (manager.currentPressed == 7 && manager.sunSeedInventory > 0)
                    {
                        manager.sunSeedInventory--;
                        inventoryManager.decreaseCurrentInventory();
                        plantedArea.Add(new Vector2(positionX, factorScaler));
                        GameObject flowerGameObject = Instantiate(seed, new Vector2(positionX - 0.55f, factorScaler), seed.transform.rotation);
                        Flower flower = flowerGameObject.GetComponent<Flower>();
                        flowerInstances.Add(coordinate, flower);
                    }
                    isPlantButtonPressed = false;
                }
            }
        } 
        else
        {
            bPlant.SetActive(false);
            isPlantButtonPressed = false;
        }
    }

    void WateringPlantMechanism()
    {
        int positionX = roundOff(transform.position.x);
        int positionY = roundOff(transform.position.y);
        factorScaler = positionY <= 0 ? positionY - 0.8f : positionY + 0.15f;

        bool isInArea = transform.position.x > -21 && transform.position.x < -6 && ((transform.position.y < 13 && transform.position.y > 6) || (transform.position.y < 0 && transform.position.y > -7));
        Flower currentFlowerInstance;
        if(isInArea && plantedArea.Contains(new Vector2(positionX, factorScaler)))
        {
            currentFlowerInstance = flowerInstances[positionX.ToString() + positionY.ToString()];
            if (currentFlowerInstance.isNeedWatering && !currentFlowerInstance.isReadyToHarvest)
            {
                bWater.SetActive(true);
                bHarvest.SetActive(false);
            } 
            else if(currentFlowerInstance.isReadyToHarvest)
            {
                bWater.SetActive(false);
                bHarvest.SetActive(true);
            } 
            else
            {
                bWater.SetActive(false);
                bHarvest.SetActive(false);
            }

            if (isWateringButtonPressed)
            {
                currentFlowerInstance.isWatered = true;
                isWateringButtonPressed = false;
            }
        }
        else
        {
            bWater.SetActive(false);
            bHarvest.SetActive(false);
        }

    }

    public void HarvestPlant()
    {
        if(inventoryManager.getSelectedItem().name == "Hand")
        {
            float positionXforHarvest = roundOff(transform.position.x);
            float positionYforHarvest = roundOff(transform.position.y);
            factorScaler = positionYforHarvest <= 0 ? positionYforHarvest - 0.8f : positionYforHarvest + 0.15f;
            Flower currentHarvestedFlower = flowerInstances[positionXforHarvest.ToString() + positionYforHarvest.ToString()];
            flowerInstances.Remove(positionXforHarvest.ToString() + positionYforHarvest.ToString());
            plantedArea.Remove(new Vector2(positionXforHarvest, factorScaler));
            switch (currentHarvestedFlower.idFlower)
            {
                case 1:
                    manager.tulipFlowerInventory += 1;
                    inventoryManager.AddItem(itemTulip);
                    break;
                case 2:
                    manager.anggrekFlowerInventory += 1;
                    inventoryManager.AddItem(itemSaffron);
                    break;
                case 3:
                    manager.mawarFlowerInventory += 1;
                    inventoryManager.AddItem(itemMawar);
                    break;
                case 4:
                    manager.wheatFlowerInventory += 1;
                    inventoryManager.AddItem(itemWheat);
                    break;
                case 5:
                    manager.cornFruitInventory += 1;
                    inventoryManager.AddItem(itemCorn);
                    break;
                case 6:
                    manager.apelTreeInventory += 1;
                    inventoryManager.AddItem(itemApel);
                    break;
                case 7:
                    manager.sunFlowerInventory += 1;
                    inventoryManager.AddItem(itemSun);
                    break;
                case 8:
                    manager.lilyFlowerInventory += 1;
                    inventoryManager.AddItem(itemLily);
                    break;
            }
            currentHarvestedFlower.isHarvested = true;
        }
    }

    private int roundOff(float num)
    {
        return (int)num;
    }

    public void activateButtonPlant()
    {
        isPlantButtonPressed = true;
    }

    public void activateButtonWater()
    {
        isWateringButtonPressed = true;
    }

    private void FixedUpdate()
    {
        if(joystick.Horizontal > 0.5f || joystick.Horizontal < -0.5f)
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isFront", false);
            anim.SetBool("isBack", false);
        }
        else if(joystick.Vertical > 0)
        {
            anim.SetBool("isFront", false);
            anim.SetBool("isBack", true);
        }
        else if(joystick.Vertical < 0)
        {
            anim.SetBool("isBack", false);
            anim.SetBool("isFront", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isFront", false);
            anim.SetBool("isBack", false);
        } 

        if(joystick.Horizontal > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            speed = 3f;
            transform.Rotate(new Vector3(0, -180, 0));
        }
        else if (joystick.Horizontal < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            speed = 3f;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }

    public void OpenDetailInventory()
    {
        detailInventory.SetActive(true);
        bOpenDetailInventory.onClick.AddListener(CloseDetailInventory);
    }

    public void CloseDetailInventory()
    {
        detailInventory.SetActive(false);
        bOpenDetailInventory.onClick.AddListener(OpenDetailInventory);
    }

    public void closeNoGoShopSign()
    {
        noGoShopSign.SetActive(false);
    }

}
