using System.Collections;
using UnityEngine;

public class GenerateSections : MonoBehaviour
{
    public GameObject[] sections;
    public int initialSections = 1;
    public float spawnDelay = 2f;
    
    private float zPos;
    private bool isSpawningSections = false;

    void Start()
    {
        zPos = 39*3f;
    }

    void Update()
    {
        if (!isSpawningSections)
        {
            isSpawningSections = true;
            StartCoroutine(SpawnSection());
        }
    }

    IEnumerator SpawnSection()
    {
        int secNum = Random.Range(0, sections.Length);
        GameObject section = Instantiate(sections[secNum]);

        Transform StartPoint = section.transform.Find("StartPoint");
        Transform EndPoint  = section.transform.Find("EndPoint");

        if (StartPoint != null && EndPoint != null)
        {
            Vector3 pos = section.transform.position;
            pos.z = zPos - StartPoint.localPosition.z;
            section.transform.position = pos;

            zPos = section.transform.position.z + EndPoint.localPosition.z;
        }
        else
        {
            Bounds bounds = GetCombinedBounds(section);

            float pivotToFrontOffset = section.transform.position.z - bounds.min.z;

            Vector3 sectionPos = section.transform.position;
            sectionPos.z = zPos + pivotToFrontOffset;
            section.transform.position = sectionPos;

            zPos += bounds.size.z;
        }

        yield return new WaitForSeconds(spawnDelay);
        isSpawningSections = false;
    }

    Bounds GetCombinedBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            Bounds combinedBounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
            {
                combinedBounds.Encapsulate(renderers[i].bounds);
            }
            return combinedBounds;
        }
        return new Bounds(obj.transform.position, Vector3.zero);
    }
}
