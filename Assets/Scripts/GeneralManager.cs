using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GeneralManager : MonoBehaviour
{
    private static GeneralManager instance = null;
    public static GeneralManager Instance
    {
         get{ return instance;}
    }

    public float initialSpeed = 10.0f;
    public int frequency = 10;
    public int activeCamera = 1;
    public bool isProd = true;

    private void Awake()
     {
         if (instance != null && instance != this) 
         {
            Destroy(this.gameObject);
         }
 
        instance = this;
        DontDestroyOnLoad( this.gameObject );
     }
 
    void Start()
    {
      
    }
}
