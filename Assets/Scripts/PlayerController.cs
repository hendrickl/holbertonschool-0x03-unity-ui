using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	 public float speed = 6.0f;
	 public int health;
     public Text scoreText;
     public Text healthText;
     public Text winLoseText;
     public Image winLoseBG;

	 private int _score = 0;
     private bool _isGoal;
	 private int _initialHealth = 5;

    void Start()
    {
		health = _initialHealth;
		_score = 0;
        _isGoal = false;
        winLoseBG.gameObject.SetActive(false);
	}

	private void Update()
	{
	    if (health <= 0)
	    {
            _isGoal = false;
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.red;
            winLoseText.color = Color.white;
            SetWinLoseText();
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
            _isGoal = true;
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
        if (_isGoal)
        {
            winLoseText.text = "You Win!";
        }
        else
        {
            winLoseText.text = "Game Over!";
        }
    }
}
