using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;

    public GameObject countdownGO;

    public GameObject FadeIn;
    public AudioSource chime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(2);
        countdown3.SetActive(true);

        chime.Play();

        yield return new WaitForSeconds(1);
        countdown3.SetActive(false);
        countdown2.SetActive(true);

        chime.Play();

        yield return new WaitForSeconds(1);
        countdown2.SetActive(false);
        countdown1.SetActive(true);

        chime.Play();

        yield return new WaitForSeconds(1);
        countdown1.SetActive(false);
        countdownGO.SetActive(true);

        chime.Play();

        yield return new WaitForSeconds(1);
        countdownGO.SetActive(false);

        PlayerMove.canMove = true;
    }
}
