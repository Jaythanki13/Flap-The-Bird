using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public static PlayerMove instance;

    public Rigidbody2D rb;
   
    private float forwardSpeed = 3f;
    private float bounceSpeed = 4f;

    private bool didFly;
    public bool isAlive;

    private Button flapButton;
    public Text ScoreText, healthText, tapText;

    int score;
    int health = 3;

    public AudioSource audioSource;
    public AudioClip coinClip, lifeClip, hitClip;

    public Animator anim;

    public Image damageImage;
    private float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool damaged;


    void Awake () {
        healthText.text = "X" + health;

        if (instance == null) {
            instance = this;
        }

        isAlive = true;
        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlyBird());

        CameraX();

        score = 0;
    }
	
	void FixedUpdate () {
        if (isAlive) {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFly) {
                didFly = false;
                rb.velocity = new Vector2(0, bounceSpeed);
            }

            if (rb.velocity.y >= 0) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else {
                float angle = 0;
                angle = Mathf.Lerp(0, -10, -rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0,0,angle);
            }

            if (damaged) {
                damageImage.color = flashColor;
            }
            else {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }

        ScoreText.text = "" + score;
        if (health <= 0) {
            anim.SetTrigger("Died");
            Debug.Log("Game Over!!");
            GameplayScript.instance.GameOver();
            GameplayScript.instance.IfGameIsOver(score);
            StartCoroutine(StopMoving());
            health = 0;
            healthText.text = "X" + health;
            flapButton.gameObject.SetActive(false);
        }
    }

    IEnumerator StopMoving() {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }

    public void FlyBird() {
        didFly = true;
        tapText.gameObject.SetActive(false);
    }

    void CameraX() {
        CameraScript.offSetX = (Camera.main.transform.position.x - transform.position.x);
    }

    public float GetPositionX() {
        return transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Coin") {
            audioSource.PlayOneShot(coinClip);
            score++;
            Debug.Log("Coin Count");
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Life") {
            audioSource.PlayOneShot(lifeClip);
            Destroy(collision.gameObject);
            health++;
            healthText.text = "X" + health;
        }

        if (collision.tag == "Enemy") {
            audioSource.PlayOneShot(hitClip);
            Destroy(collision.gameObject);
            health--;
            healthText.text = "X" + health;
            damaged = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Foreground") {
            audioSource.PlayOneShot(hitClip);
            health--;
            healthText.text = "X" + health;
            damaged = true;
        }
    }
}
