using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(2);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);

        yield return new WaitForSeconds(4);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
