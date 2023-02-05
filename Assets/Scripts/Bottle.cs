using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    [SerializeField] GameObject wholeBottle;
    [SerializeField] GameObject brokenBottle;

    [SerializeField] int maxHealth = 3;

    [SerializeField] AudioClip[] hitAudioClips;
    [SerializeField] AudioClip[] breakAudioClips;

    private ScoreHandler scoreHandler;

    private SoundManager soundManager;

    private int health;
    [SerializeField] int breakScore = 10;
    private bool isBroken = false;

    public BottleSpawn spawner;

    public float hitSFXVolume;
    public float breakVolume;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.Instance;
        scoreHandler = ScoreHandler.Instance;

        health = maxHealth;

        wholeBottle.SetActive(true);
        brokenBottle.SetActive(false);

        spawner = BottleSpawn.instance;
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isBroken) { return; }

        PlaySound();

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
            BreakBottle();
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
        isBroken = true;
        PlaySound(true);
        scoreHandler.AddToScore(breakScore);
        wholeBottle.SetActive(false);
        brokenBottle.SetActive(true);

        spawner.SpawnBottle();
    }

    void PlaySound(bool isBreak=false)
    {
        if (isBreak)
        {
            soundManager.RandomSoundEffect(breakVolume, breakAudioClips);
        }
        soundManager.RandomSoundEffect(hitSFXVolume, hitAudioClips);
    }
}
