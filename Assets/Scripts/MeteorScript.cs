using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeteorScript : MonoBehaviour
{
    [SerializeField] bool testing = false;
    [SerializeField] GameObject child;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    [SerializeField] GameObject explosion;

    GameObject ship;
    GameObject meteorSpawner;
    GameObject scoreManager;
    ScoreManager scoreManagerScript;
    float despawnRange = 1000;

    public bool isChild;

    private void Start()
    {
        if (!testing)
        {
            meteorSpawner = GameObject.Find("MeteorSpawner");
            ship = GameObject.Find("Ship");
            scoreManager = GameObject.Find("ScoreManager");
            scoreManagerScript = scoreManager.GetComponent<ScoreManager>();
            despawnRange = meteorSpawner.GetComponent<MeteorSpawner>().GetDespawnRange();
        }
    }

    private void FixedUpdate()
    {
        if (!testing)
        {
            if (ship != null)
            {
                if (gameObject.activeSelf && (ship.transform.position - transform.position).magnitude > despawnRange)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if(testing && Input.GetKeyDown(KeyCode.Space))
        {
            Pop();
        }
    }

    public void Pop()
    {
        //play explosion
        //explosion effect
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        exp.transform.localScale = transform.localScale/10;
        //add to score
        scoreManagerScript.IncreaseScore(1);

        if(!isChild)
        {
            int times = Random.Range(2, 5);

            for(int i = 0; i < times; i++)
            {
                GameObject jr = Instantiate(child, transform.position, Quaternion.identity);
                jr.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed));
                MeteorScript script = jr.GetComponent<MeteorScript>();
                script.isChild = true;
                jr.transform.localScale = gameObject.transform.localScale / 2;
            }
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Meteor")
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
