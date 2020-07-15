using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int speedChange = 2;

    public Material fast_mat;
    public Material slow_mat;

    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        int rand = Random.Range(0,2);

        if (rand == 0){
            speedChange = 2;
            rend.material = fast_mat;
        }else{
            speedChange = -2;
            rend.material = slow_mat;

        }

    }

}
