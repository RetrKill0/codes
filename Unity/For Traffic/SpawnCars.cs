using System.Collections.Generic;
using UnityEngine;

//By RetrKill0
[System.Serializable]
public class CarList
{
    public string listName;
    public GameObject[] carPrefabs; 
}

[System.Serializable]
public class CarSpawnInfo
{
    public Transform spawnPoint; 
    [Range(0, 100)]
    public int spawnChance = 50; 
    public string selectedCarListName; 
}

public class SpawnCars : MonoBehaviour
{
    public CarList[] carLists; 
    public List<CarSpawnInfo> spawnPoints = new List<CarSpawnInfo>(); 

    void OnEnable()
    {
        SpawnCarsAtPoints(spawnPoints); 
    }

    void SpawnCarsAtPoints(List<CarSpawnInfo> spawnPoints)
    {
        foreach (CarSpawnInfo spawnInfo in spawnPoints)
        {
            if (Random.Range(0, 100) >= spawnInfo.spawnChance)
                continue;

            CarList selectedCarList = FindCarListByName(spawnInfo.selectedCarListName);
            if (selectedCarList != null && selectedCarList.carPrefabs.Length > 0)
            {
                GameObject selectedCarPrefab = selectedCarList.carPrefabs[Random.Range(0, selectedCarList.carPrefabs.Length)];
                Instantiate(selectedCarPrefab, spawnInfo.spawnPoint.position, spawnInfo.spawnPoint.rotation, transform);
            }
        }
    }

    CarList FindCarListByName(string listName)
    {
        foreach (CarList carList in carLists)
        {
            if (carList.listName == listName)
            {
                return carList;
            }
        }
        return null;
    }
}
