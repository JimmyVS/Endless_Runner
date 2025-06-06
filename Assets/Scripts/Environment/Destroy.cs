using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string parentName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(50);

        if (parentName == "Section(Clone")
        {
            Destroy(gameObject);
        }
    }
}
