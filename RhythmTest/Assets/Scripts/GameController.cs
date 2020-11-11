using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController contoller;
    [SerializeField] LaneController leftLane, rightLane, upLane, downLane;
    [SerializeField] float spawnRate;
    [SerializeField] int allowedMisses;
    public int misses = 0;
    public int score = 0;
    public float arrowSpeed = 5;
    bool isPlaying = true;
    float spawnTimer;

    int[] arrowprobobility = { 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,2, 2, 2, 3 };
    private void Awake()
    {
        if(contoller == null)
        {
            contoller = this;
        }
    }
    private void Start()
    {
        SpawnArrow();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnArrow();
        }
        if (isPlaying)
        {
            if(spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                SpawnArrow();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                checkLane(leftLane);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                checkLane(rightLane);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                checkLane(downLane);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                checkLane(upLane);
            }

            if (misses >= allowedMisses)
            {
                isPlaying = false;
            }
        }
    }

    void checkLane(LaneController lane)
    {
        lane.CheckBox();
    }

    void SpawnArrow()
    {
        int toChoose = Random.Range(0, arrowprobobility.Length);
        int numberToSpawn = arrowprobobility[toChoose];
        Debug.Log(numberToSpawn);
        int[] spawnLanes = SampleRemove(4, numberToSpawn);
        for(int i = 0; i < spawnLanes.Length; i++)
        {
            Debug.Log("Spawn in Lane " + spawnLanes[i]);
            spawnTimer = spawnRate;
            switch (spawnLanes[i]) 
            {
                case 0:
                    {
                        downLane.SpawnArrow();
                        break;
                    }
                case 1:
                    {
                        leftLane.SpawnArrow();
                        break;
                    }
                case 2:
                    {
                        rightLane.SpawnArrow();
                        break;
                    }
                case 3:
                    {
                        upLane.SpawnArrow();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }


    public static float Rnd()
    {
        return Random.value;
    }

    //	Sample several items without replacement.
    public static int[] SampleRemove(int maxNum, int numSamples)
    {
        int[] result = new int[numSamples];
        int numNeeded = numSamples;

        for (int numLeft = maxNum; numLeft > 0; numLeft--)
        {
            float chance = (float)numNeeded / (float)numLeft;

            if (Rnd() < chance)
            {
                result[--numNeeded] = numLeft - 1;
            }

            if (numNeeded == 0)
            {
                break;
            }
        }

        if (numNeeded != 0)
        {
            result[0] = 0;
        }

        return result;
    }

}
