using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public List<GameObject> levelList = new List<GameObject>();
    [SerializeField] private GameObject levelPrefab;

    [SerializeField] private int towerMax = 6;
    [SerializeField] private int towerAmount = 3;
    [SerializeField] private float levelHeight = 2.5f;
    [SerializeField] private Vector3 lastLevelPos;

    Level _level;

    public bool isLevelSelected = false;
 
    void Start() 
    {
        GenerateTower();
    }
    
    void GenerateTower()
    {
        for (int i = 0; i < towerAmount; i++)
        {
            var spawnLevel = Instantiate(levelPrefab, new Vector3(0,-2.75f + i * levelHeight), Quaternion.identity,gameObject.transform);
            spawnLevel.name = $"Level {i + 1}";
            levelList.Add(spawnLevel);
            lastLevelPos = levelList[i].transform.position;
            
            _level = levelList[i].GetComponent<Level>();
            _level.levelRank = i + 1;
        }
    }

    public void AddLevel()
    {
        if(levelList.Count < towerMax)
        {
            lastLevelPos = new Vector3(lastLevelPos.x, lastLevelPos.y + 2.5f);

            var spawnLevel = Instantiate(levelPrefab, lastLevelPos, Quaternion.identity,gameObject.transform);
            spawnLevel.name = $"Level {levelList.Count + 1}";
            levelList.Add(spawnLevel);

            _level = spawnLevel.GetComponent<Level>();
            _level.levelRank = levelList.Count;
        }
    }

    public void RemoveLevel()
    {
        if(levelList.Count > towerAmount)
        {
            Destroy(levelList[levelList.Count -1].gameObject);
            levelList.RemoveAt(levelList.Count-1);
            lastLevelPos = levelList[levelList.Count - 1].transform.position;
        }
    }


}

