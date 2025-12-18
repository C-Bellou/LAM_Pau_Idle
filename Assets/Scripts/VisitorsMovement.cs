using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class VisitorsMovement : MonoBehaviour
{
    public GameObject Visitors;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public Vector2 pos;
    public List<Transform> Fences;
    public GoldManager Ggold;
    private bool shouldRoll;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shouldRoll = false;
    }

    public void SpawnVisitors()
    {
        if (Ggold.goldAmount >= Ggold.powerAmount || shouldRoll == true)
        {
            print("Roll");
            var shouldSpawn = true;
            Vector2 SpawnPointWorld = transform.position;
            Vector2 randomPosition2 = SpawnPointWorld + new Vector2(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));
            
             foreach (var p in Fences)
             {
                var px = p.position.x -3;
                var py = p.position.y -2;
                var RectFence = new Rect(px, py, 5.5f, 4);
                print(RectFence);
                    if (RectFence.Contains(randomPosition2))
                    {
                        print("Dans la cage");
                        shouldSpawn = false;
                    }
                    else
                    {
                        print("Hors de la cage");                                       
                    }
                    
             }          
                
             if (shouldSpawn == true)
             {
                 print(shouldSpawn);
                 Instantiate(Visitors, randomPosition2, Quaternion.identity);
             }
             else 
             {
                print(shouldSpawn);
                shouldRoll = true;
                SpawnVisitors();
             }
             shouldRoll = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
