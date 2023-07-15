using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool flapping = false;

    public Transform birdSprite;
    public GameObject deadUI;
    public static bool dead = false;
    public int flapForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deadUI.SetActive(false);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && dead == false)
            flapping = true;

        if (rb.velocity.y > 0)
        {
            birdSprite.rotation = Quaternion.Euler(transform.forward * 10);
        } else if (rb.velocity.y < 0)
        {
            birdSprite.rotation = Quaternion.Euler(transform.forward * -10);
        }

        if (dead) deadUI.SetActive(true);

        if (dead && Input.GetKeyDown("space")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate() {
        if (flapping)
            Flap();   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Enemy")
            dead = true;
    }

    void Flap() {
        rb.AddForce(transform.up * flapForce, ForceMode2D.Impulse);
        flapping = false;
    }
}
