using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Manager : ScriptableObject
{
    public int currentPressed;
    public int coin;
    public int difficulty;
    public int currentscene;

    public Dictionary<int, int> orderan;
    public ArrayList jenis_bunga;

    public int tulipPOm, saffronPOm, mawarPOm, apelPOm, wheatPOm, cornPOm, sunPOm, LilyPOm;
    public bool isTransactCompleted;
    public bool isbWaterActive;
    public bool isOrderInitialised = true;
    public bool hasOrderInitialised = false;
    public bool isFirstTime = true;
    public bool isFirstTimePlaying = true;

    public Vector3 playerPosition;
    public Vector3 playerPositionFromFlower;
    public float playerPositionFromBirdX;
    public float playerPositionFromBirdY;

    public int tulipSeedInventory;
    public int tulipFlowerInventory;
    public int tulipStar1;
    public int tulipStar2;
    public int tulipStar3;
    public int anggrekSeedInventory;
    public int anggrekFlowerInventory;
    public int anggrekStar1;
    public int anggrekStar2;
    public int anggrekStar3;
    public int mawarSeedInventory;
    public int mawarFlowerInventory;
    public int mawarStar1;
    public int mawarStar2;
    public int mawarStar3;
    public int apelSeedInventory;
    public int apelTreeInventory;
    public int apelStar1;
    public int apelStar2;
    public int apelStar3;
    public int wheatSeedInventory;
    public int wheatFlowerInventory;
    public int wheatStar1;
    public int wheatStar2;
    public int wheatStar3;
    public int cornSeedInventory;
    public int cornFruitInventory;
    public int cornStar1;
    public int cornStar2;
    public int cornStar3;
    public int sunSeedInventory;
    public int sunFlowerInventory;
    public int sun1;
    public int sun2;
    public int sun3;
    public int lilySeedInventory;
    public int lilyFlowerInventory;
    public int lilyStar1;
    public int lilyStar2;
    public int lilyStar3;

    public Sprite[] orderanBungaGambar = new Sprite[3];
    public int[] inventoryBungaOrderan = new int[3];
    public int[] jumlahOrderan = new int[3];
    public int[] inventoryBungaOrderanBintang1 = new int[3];
    public int[] inventoryBungaOrderanBintang2 = new int[3];
    public int[] inventoryBungaOrderanBintang3 = new int[3];
    
    
    
}
