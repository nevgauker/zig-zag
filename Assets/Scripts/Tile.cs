using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private float fallDealy = 1;

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Spawn tile");
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
        }     
    }
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDealy);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        switch (gameObject.name)
        {
            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

        }
    }
}
