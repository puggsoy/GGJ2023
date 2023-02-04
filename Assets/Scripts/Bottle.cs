using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    [SerializeField] GameObject wholeBottle;
    [SerializeField] GameObject brokenBottle;

    [SerializeField] int maxHealth = 3;

    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        wholeBottle.SetActive(true);
        brokenBottle.SetActive(false);
    }

    void OnCollisionEnter(Collision other) 
    {

        if(other.gameObject.GetComponent<Ball>() != null)
        {
            health = 0;
        }

        if(other.gameObject.GetComponent<Bottle>() != null)
        {
            // health -= 1;
        }

        if (health <= 0) 
        {
            // BreakBottle();
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        // if(other.gameObject.GetComponent<Ball>() != null) { return; }

        // if(other.gameObject.GetComponent<Bottle>() != null) { return; }
        
        if(other.tag == "Floor")
        {
            BreakBottle();
        }
    }

    void BreakBottle()
    {
        wholeBottle.SetActive(false);
        brokenBottle.SetActive(true);
    }
}