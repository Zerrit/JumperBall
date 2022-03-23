using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{
    public int platformCount;
    private int platformPrefubLimit;

    private GameObject tower;
    public GameObject columnPrefub;
    public BollJumper ball;
    public Platform[] platformTemplates;
    public StartPlatform startPlatformPrefub;
    public Platform finalPlatform;

    public float ColumnScaleY => platformCount + 2;

   
    public void BuildLevel(int lvl)
    {
        platformCount = GameManager.instance.GetPlatformCount();
        platformPrefubLimit = GameManager.instance.GetPrefubLimit();

        tower = new GameObject("Tower");
        tower.transform.SetParent(transform);

        GameObject column = Instantiate(columnPrefub, tower.transform);
        column.transform.localScale = new Vector3(1f, ColumnScaleY, 1f);
        Vector3 spawnPosition = column.transform.position;
        
        SpawnPlatform(finalPlatform, spawnPosition, tower.transform, false);

        spawnPosition.y += 1;

        for (int i = 0; i < platformCount; i++)
        {
            SpawnPlatform(platformTemplates[Random.Range(0, platformPrefubLimit)], spawnPosition, tower.transform, true);
            spawnPosition.y += 1;
        }

        StartPlatform startPlatform = (StartPlatform)SpawnPlatform(startPlatformPrefub, spawnPosition, tower.transform, false);

        ball.transform.position = startPlatform.SpawnBallPosition;
    }

    private Platform SpawnPlatform(Platform platform, Vector3 spawnPosition, Transform parent, bool isRotate)
    {
        if (isRotate) return Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        else return Instantiate(platform, spawnPosition, Quaternion.identity, parent);
    }

    public void ClearTower()
    {
        if (tower) Destroy(tower);
        ball.transform.position = new Vector3(.4f, .6f, .4f);
    }


    
}