using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnner : MonoBehaviour
{
    public GameObject background;

    GameObject nbackground;
    string createState = "false";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (background.transform.position.x < 0 && createState == "false") createState = "true";

        if (createState == "true")
        {
            nbackground = Instantiate(background, transform);
            nbackground.transform.localPosition = new Vector3(0, 0, 3);
            nbackground.transform.localScale = new Vector3(2.25f, 2, 1);
            createState = "created";
        }

        if(background.transform.position.x < -20)
        {
            Destroy(background);
            background = nbackground;
            createState = "true";
        }
    }
}
