using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	 public float speed = 5.0f;
	 public int health;
     public Text scoreText;
     public Text healthText;
     public Text winLoseText;
     public Image winLoseBG;

	 private int _score = 0;
	 private int _initialHealth = 5;

    void Start()
    {
		health = _initialHealth;
		_score = 0;
        winLoseBG.gameObject.SetActive(false);
	}

	private void Update()
	{
	    if (health <= 0)
	    {
	        Debug.Log("Game Over!");
	        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }

        SetScoreText();
        SetHealthText();
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
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            SetWinLoseText();
        }
	}

    private void SetScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    private void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    private void SetWinLoseText()
    {
        winLoseText.text = "You Win!";
    }
}
