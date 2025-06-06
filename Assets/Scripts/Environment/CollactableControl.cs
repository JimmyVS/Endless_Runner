using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollactableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;

    public GameObject coinEndDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = " " + coinCount;
        coinEndDisplay.GetComponent<Text>().text = " " + coinCount;
    }
}
