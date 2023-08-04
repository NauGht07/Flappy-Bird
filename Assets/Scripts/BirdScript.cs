using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool flapping = false;
    public TMP_Text scoreUI;

    public Transform birdSprite;
    public GameObject deadUI;
    public static bool dead = false;
    public int flapForce;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deadUI.SetActive(false);
        dead = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = (score/2).ToString();

        if (Input.GetKeyDown("space") && dead == false)
            flapping = true;

        if (rb.velocity.y > 0)
        {
            birdSprite.rotation = Quaternion.Euler(transform.forward * 10);
        } else if (rb.velocity.y < 0)
        {
            birdSprite.rotation = Quaternion.Euler(transform.forward * -10);
        }

        if (dead) {
            Time.timeScale = 0;
            deadUI.SetActive(true);
            Debug.Log(score/2);
        } else 
        {
            Time.timeScale = 1;
        }

        if (dead && Input.GetKeyDown("space")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (rb.velocity.y >= flapForce) rb.velocity = new Vector2(rb.velocity.x, flapForce);
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

    public static void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
