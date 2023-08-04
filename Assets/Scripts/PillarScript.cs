using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour
{
    public float pillarSpeed = 4;
    public string updateState = "false";
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -1 * pillarSpeed * Time.deltaTime);

        if (transform.position.x < -9 && !BirdScript.dead && updateState == "false") updateState = "true";

        if (updateState == "true")
        {
            updateState = "updated";
            BirdScript.score += 1;
        }

        if (transform.position.x < -15) Destroy(gameObject);
    }

    private void FixedUpdate() {
        
    }
}
