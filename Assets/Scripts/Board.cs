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
    
    [HideInInspector]
    public MatchFinder matchFind;

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

                int iterations = 0;
                while (MatchesAt(new Vector2Int(i,j),gems[gemToUse]) && iterations < 50)
                {
                     gemToUse = Random.Range(0, gems.Length);
                     iterations++;
                     Debug.Log(iterations);
                }
                
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

    private bool MatchesAt(Vector2Int posToCheck, Gem gemToCheck)
    {
        if (posToCheck.x > 1)
        {
            if (allGems[posToCheck.x - 1, posToCheck.y].type == gemToCheck.type &&
                allGems[posToCheck.x - 2, posToCheck.y].type == gemToCheck.type)
            {
                return true;
            }
        }

        if (posToCheck.y > 1)
        {
                if (allGems[posToCheck.x, posToCheck.y -1 ].type == gemToCheck.type &&
                    allGems[posToCheck.x, posToCheck.y - 2].type == gemToCheck.type)
                {
                    return true;
                }
        }
        
        return false;
    }

}
