using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    static CollectibleSpawner instance;
    [SerializeField] List<Gem> gems;
    [SerializeField] int obstaclePoolCount;



    private List<Gem> gemPool = new List<Gem>();

    public static CollectibleSpawner Instance { get => instance; }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Init();
    }


    void Init()
    {
        for (int i = 0; i < obstaclePoolCount; i++)
        {
            Gem gem = Instantiate(gems[Random.Range(0, gems.Count)]);

            gem.gameObject.SetActive(false);
            gemPool.Add(gem);

        }
    }
    public void AddGem(Gem gem)
    {
        gemPool.Add(gem);
        gem.gameObject.SetActive(false);

    }

    public Gem getGem()
    {
        Gem gem = gemPool[Random.Range(0, gemPool.Count)];// 
        gem.gameObject.SetActive(true);
        gemPool.Remove(gem);

        return gem;

    }

}