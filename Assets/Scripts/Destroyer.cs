using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject resetBtn;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.gameObject.SetActive(false);
            Debug.Log("Kill Player");
            other.gameObject.GetComponent<Player>().isDead = true;
            if (other.gameObject.transform.childCount > 1)
            {
                other.gameObject.transform.GetChild(1).transform.parent = null;
                other.gameObject.transform.GetChild(0).transform.parent = null;
            }
            resetBtn.SetActive(true);

        }


    }
}
