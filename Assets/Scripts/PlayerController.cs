using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	 public float speed = 5.0f;
	 public int health;
     public Text scoreText;

	 private int _score = 0;
	 private int _initialHealth = 5;

    void Start()
    {
		health = _initialHealth;
		_score = 0;
	}

	private void Update()
	{
	    if (health <= 0)
	    {
	        Debug.Log("Game Over!");
	        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }

        SetScoreText();
	}
	
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Pickup"))
        {
            _score++;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
	}

    private void SetScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
    }
}
