using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializedField] GameObject [] _segmentPrefabs;
    public void NewHighestScoreHandler() 
    {
        SpawnNewMapSegment();
    }

    private void SpawnNewMapSegment()
    {
        Debug.Log("New higest score,spawning a new map segment");
    }
}
