using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject currentTile;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    public Stack<GameObject> LeftTiles
    {
        get { return leftTiles; }
        set {leftTiles = value; }
    }

    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles
    {
        get { return topTiles; }
        set { topTiles = value; }
    }

    private static TileManager instance;
    public static TileManager Instance
    {
        get { 
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<TileManager>();
                }
                return instance;
             }
    }


    public  GeneralManager managerScript;

     private void Start() {
        GameObject manager = GameObject.FindWithTag("GeneralManager");
        if (manager != null){
            managerScript = manager.GetComponent<GeneralManager>();
        }
        else {
            Debug.Log("Can not find the game manager");
        }

         CreateTiles(20);

        for(int i=0; i<20; i++)
        {
            SpawnTile();
        }

    }


    public void CreateTiles(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));
            topTiles.Peek().name = "TopTile";
            topTiles.Peek().SetActive(false);
            leftTiles.Peek().name = "LeftTile";
            leftTiles.Peek().SetActive(false);

        }
    }
    public void SpawnTile()
    {
        if (leftTiles.Count == 0 || topTiles.Count == 0)
        {
            CreateTiles(10);
        }

        int randomIndex = Random.Range(0,2);

        GameObject tmp = null;
        if (randomIndex == 0)
        {
            tmp = leftTiles.Pop();
        }else
        {
            tmp = topTiles.Pop();
        }
        tmp.SetActive(true);
        tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
        currentTile = tmp;

        int max = 10;

        if (managerScript.isProd)
        {
           max = managerScript.frequency;
        }

        int spawnPickup = Random.Range(0,max);
        if (spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}
