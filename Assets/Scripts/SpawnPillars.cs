using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillars : MonoBehaviour
{
    public GameObject pillar;
    public Transform bottomSpawnner;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Countdown(2));
    }

    IEnumerator Countdown (float seconds) {
        float counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
        }
        float y = Random.Range(1f, 6f);
        GameObject nPillarTop = Instantiate(pillar, transform);
        nPillarTop.AddComponent(System.Type.GetType("PillarScript"));
        nPillarTop.transform.localPosition = Vector3.zero;
        nPillarTop.transform.localScale = new Vector3(1, y, 1);

        GameObject nPillarBottom = Instantiate(pillar, bottomSpawnner);
        nPillarBottom.AddComponent(System.Type.GetType("PillarScript"));
        nPillarBottom.transform.localPosition = Vector3.zero;
        nPillarBottom.transform.localScale = new Vector3(1, -1 * (7 - y), 1);

        
        StartCoroutine(Countdown(1.5f));
    }
}
