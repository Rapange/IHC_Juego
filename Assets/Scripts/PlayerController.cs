using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private GameObject end;
	private GameObject master;
	private GameObject wall;
    public float speed;
    public Text winText;
    public Text loseText;
	public Text resetText;

    private bool flag;
    private Rigidbody rb;
    void Start()
    {
		wall = GameObject.Find("Walls");
		end = GameObject.Find ("Lost");
		master = GameObject.Find ("Master");
	flag = false;
        rb = GetComponent<Rigidbody>();
	loseText.text = "";
        winText.text = "";
		resetText.text = "";
    }

    IEnumerator Grow()
    {
	yield return new WaitForSeconds(0.5f);
        transform.localScale += new Vector3(0.015f, 0.015f, 0.015f);
	flag = false;
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene (0);
		}
	if(!flag && winText.text == "")
	{
	    if(transform.localScale.x > 1.5f)
	    {
				if (winText.text == "") {
					loseText.text = "¡Has perdido! :(";
					//resetText.text = "Presiona R para reiniciar.";
					end.GetComponent<AudioSource> ().Play ();
					master.GetComponent<AudioSource> ().Stop ();
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
        /*if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }*/
	    if(other.gameObject.CompareTag("Finish") && loseText.text == "")
	    {
	        winText.text = "¡Ganaste! :)";
			//resetText.text = "Presiona R para reiniciar.";
			other.GetComponent<AudioSource> ().Play ();
			master.GetComponent<AudioSource> ().Stop ();
	    }
    }
	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}
}
