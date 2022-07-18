using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    public static SkeletonSpawner instance;
    private float seconds;
    public GameObject skeleton;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        seconds = 8;
        StartCoroutine(spawnRateModifier());
        StartCoroutine(skeletonSpawner());
    }


    Vector2 randomLocation()
    {
        Vector2 location = new Vector2(0,0);
        int edge = Random.Range(1, 4);
        switch (edge)
        {
            case 1:
                location = new Vector2(Random.Range(-13, 13), 10.5f);
                return location;
                break;
            case 2:
                location = new Vector2(19.5f, Random.Range(-6.5f, 6.5f));
                return location;
                break;
            case 3:
                location = new Vector2(Random.Range(-13, 13), -10.5f);
                return location;
                break;
            case 4:
                location = new Vector2(-19.5f, Random.Range(-6.5f, 6.5f));
                return location;
                break;
        }
        return location;
    }

    public IEnumerator spawnRateModifier()
    {
        while (GameScript.instance.playState == true)
        {
            yield return new WaitForSeconds(8);
            if (seconds > 1)
            {
                seconds--;
            }
        }

        yield return 0;
    }

    public IEnumerator skeletonSpawner()
    {
        while (GameScript.instance.playState == true)
        {
            Instantiate(skeleton, randomLocation(), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(seconds);
        }

        yield return 0;
    }
    
}
