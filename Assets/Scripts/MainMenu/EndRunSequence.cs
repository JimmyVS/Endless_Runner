using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence :MonoBehaviour
{
    public GameObject CoinDisplay;
    public GameObject DistanceDisplay;

    public GameObject liveCoins;
    public GameObject liveDis;

    public GameObject endScreen;
    public GameObject fadeOut;

    public AudioSource footsteps;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    public IEnumerator EndSequence()
    {
        footsteps.Stop();

        yield return new WaitForSeconds(3);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);

        CoinDisplay.SetActive(false);
        DistanceDisplay.SetActive(false);

        endScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}