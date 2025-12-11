using UnityEngine;

public class FenceSpawn : MonoBehaviour
{
    public GameObject Mob;
    public GameObject MobBack;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public GoldManager Ggold;
    public GoldAutomator Gprice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SpawnMob()
    {
        if (Ggold.goldAmount >= Gprice.price)
        {
            Vector2 SpawnPoint = transform.position;
            Vector2 randomPosition = SpawnPoint + new Vector2(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));

            if ((randomPosition.y - SpawnPoint.y) <= 0)
            {
                Instantiate(MobBack, randomPosition, Quaternion.identity);
            }
            else {
                Instantiate(Mob, randomPosition, Quaternion.identity);
            }
                
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
