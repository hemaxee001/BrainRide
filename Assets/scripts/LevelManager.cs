using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   // public level[] levels;
   //public LevelData[] levels; // Array of LevelData objects

   // public Image backgroundImage; // UI Image behind the gameplay
   // public Transform carSpawnPoint;
   // public Transform roadSpawnPoint;

   // private GameObject currentCar;
   // private GameObject currentRoad;

   // public int currentLevelIndex = 0;
   // internal static LevelManager Instance;

   // void Start()
   // {
   //     LoadLevel(currentLevelIndex);
   // }

   // public void LoadLevel(int Index)
   // {
   //     if (currentCar != null) Destroy(currentCar);
   //     if (currentRoad != null) Destroy(currentRoad);
   //     LevelData level = levels[Index];
   //     Debug.Log("Loading Level: " + level.name);
   //     currentCar = Instantiate(level.carPrefab, carSpawnPoint.position, Quaternion.identity);
   //     currentRoad = Instantiate(level.roadPrefab, roadSpawnPoint.position, Quaternion.identity);
   //     backgroundImage.sprite = level.backgroundImage;
   // }

   // private GameObject Instantiate(object carPrefab, Vector3 position, Quaternion identity)
   // {
   //     throw new NotImplementedException();
   // }

   // public void NextLevel()
   // {
   //     currentLevelIndex++;
   //     if (currentLevelIndex < levels.Length)
   //     {
   //         LoadLevel(currentLevelIndex);
   //     }
   //     else
   //     {
   //         Debug.Log("All levels completed!");
   //     }
   // }
   

}
