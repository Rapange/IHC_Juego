using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text winText;
    public Text loseText;

    private bool flag;
    private Rigidbody rb;
    public GameObject restartButton;
    public AudioClip wining, losing;
    private AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
        restartButton.SetActive(false);
    	flag = false;
        rb = GetComponent<Rigidbody>();
	    loseText.text = "";
        winText.text = "";
    }

    IEnumerator Grow()
    {
	    yield return new WaitForSeconds(0.5f);
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
	    flag = false;
    }

    void Update()
    {
	if(!flag && winText.text == "")
	{
	    if(transform.localScale.x > 2.0f)
	    {
	       if(winText.text == "")
           {
                loseText.text = "¡Has perdido! :(";
                restartButton.SetActive(true);
                    music.clip = losing;
                    music.Play();
           }	         
	    }
	    else
	    {
	       StartCoroutine("Grow");
	    }
	    flag = true;
	    
	}
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
	if(other.gameObject.CompareTag("Finish") && loseText.text == "")
	{
	    winText.text = "¡Ganaste! :)";
            restartButton.SetActive(true);
            music.clip = wining;
            music.Play();
	}
    }
}
