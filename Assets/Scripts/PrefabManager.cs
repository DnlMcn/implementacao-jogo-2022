using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject prefab;
    public int instanceLimit;
    public int rangeX;
    public int rangeY;
    public int rangeZ;
    int i = 0;

    public Vector3 RandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), Random.Range(-rangeZ, rangeZ));
        return position;        
    }

    void Update()
    {
        while(i++ < instanceLimit)
        {
            Instantiate(prefab, RandomPosition(), Quaternion.identity);
        }
    }
}
