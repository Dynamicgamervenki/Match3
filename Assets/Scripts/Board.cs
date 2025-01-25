using System;
using UnityEditor.Media;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    
    public GameObject bgTilePrefab;

    public Gem[] gems;
    
    public Gem[,] allGems;

    public float gemSpeed;
    
    private MatchFinder matchFind;

    private void Awake()
    {
        matchFind = FindObjectOfType<MatchFinder>();
    }

    void Start()
    {
        allGems = new Gem[width, height];
        SetUp();
    }

    private void Update()
    {
        matchFind.FindAllMatches();
    }

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 position = new Vector2(i, j);
                GameObject bgTile = Instantiate(bgTilePrefab,position,Quaternion.identity);
                bgTile.transform.SetParent(transform);
                bgTile.name = "BgTile - " + i + "," + j;
                
                int gemToUse = Random.Range(0, gems.Length);
                SpawnGem(new Vector2Int(i, j), gems[gemToUse]);
            }
        }
    }

    private void SpawnGem(Vector2Int pos,Gem gemToSpawn)
    {
       Gem gem =  Instantiate(gemToSpawn, new Vector3(pos.x,pos.y,0f), Quaternion.identity);
       gem.transform.SetParent(transform);
       gem.name = "Gem - " + pos.x + "," + pos.y + "," + gemToSpawn;
       allGems[pos.x, pos.y] = gem;

       gem.SetupGem(pos, this);
    }


}
