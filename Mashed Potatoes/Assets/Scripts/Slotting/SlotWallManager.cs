//using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SlotWallManager : MonoBehaviour
{
    public GameObject[] holeWalls;
    public Transform spawnPoint;

    private List<GameObject> holeWallsList = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < holeWalls.Length; i++)
        {
            holeWallsList.Add(holeWalls[i]);
        }
    }

    private void Update()
    {
        if(spawnPoint.childCount == 0)
        {
            SpawnWall();
        }
    }

    private void SpawnWall()
    {
        if (holeWallsList.Count > 0)
        {
            int randomNumber = Random.Range(0, holeWallsList.Count - 1);
            Instantiate(holeWallsList[randomNumber], spawnPoint);
            holeWallsList.RemoveAt(randomNumber);
            //Debug.Log(holeWallsList);
        }
        
    }
}
