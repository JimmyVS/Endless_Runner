using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject character;

    public AudioSource CrashThud;
    public GameObject camera;

    public GameObject levelControl;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        Player.GetComponent<PlayerMove>().enabled = false;
        character.GetComponent<Animator>().Play("Fallen");

        CrashThud.Play();

        camera.GetComponent<Animator>().enabled = true;

        levelControl.GetComponent<LevelDistance>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
