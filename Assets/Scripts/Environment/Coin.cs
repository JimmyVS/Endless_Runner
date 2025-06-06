using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int rotationSpeed = 1;

    public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollactableControl.coinCount += 1;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}
