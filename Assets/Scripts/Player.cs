using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public GameObject ps;
    public GameObject ps2;

    public GameObject resetBtn;
    public GameObject scoreTxt;
    private  GameObject generalManager;

    private int score = 0;
    public bool isDead;

    void Start()
    {
        generalManager = GameObject.Find("GeneralManager");

        if (generalManager != null){
            if (generalManager.GetComponent<GeneralManager>().isProd)
            {
                speed = generalManager.GetComponent<GeneralManager>().initialSpeed;
                if (generalManager.GetComponent<GeneralManager>().activeCamera == 2)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                }else
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else {
            Debug.Log("Can not find the game manager");
        }

        scoreTxt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        dir = Vector3.zero;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir =Vector3.forward;
            }

            score++;
            scoreTxt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        }
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.GetComponent<Pickup>().speedChange > 0)
            {
                Instantiate(ps2, transform.position, Quaternion.identity);

            }else
            {
                 Instantiate(ps, transform.position, Quaternion.identity);
            }
            speed += other.gameObject.GetComponent<Pickup>().speedChange;

        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);
            if (!Physics.Raycast(downRay, out hit))
            {
                Debug.Log("Kill Player");
                isDead = true;
                if (transform.childCount > 1)
                {
                    transform.GetChild(1).transform.parent = null;
                    transform.GetChild(0).transform.parent = null;
                }
                resetBtn.SetActive(true);
            }
        }
    }
}
