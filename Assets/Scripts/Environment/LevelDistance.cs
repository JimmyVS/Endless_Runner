using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;

    public int distanceRan;
    public bool addingDistance = false;
    public float distanceDelay = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distanceRan += 1;
        distanceDisplay.GetComponent<Text>().text = " " + distanceRan;
        distanceEndDisplay.GetComponent<Text>().text = " " + distanceRan;

        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;
    }
}
