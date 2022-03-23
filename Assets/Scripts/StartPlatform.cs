using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Platform
{
    public Transform spawnPoint;

    public Vector3 SpawnBallPosition => spawnPoint.position;
}
