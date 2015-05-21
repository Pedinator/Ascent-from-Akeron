using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//public variables
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject Player;
	public GameObject arrow;
	public GameObject axe;
	public GameObject bomb;

	//private variables
	private bool CanJump = true;
	private float t = 0;
	private bool moving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//playerbuttons on top of screen
		GameObject[] playerButtons = GameObject.FindGameObjectsWithTag ("PlayerButton");

		//Changing Players
		if (Input.GetKeyDown ("1")) {//Atleet
			foreach (GameObject playerButton in playerButtons) {
				if (playerButton.name == "Player"){
					playerButton.transform.localScale = new Vector3 (0.55F, 0.55F, 1F);
				} else {
					playerButton.transform.localScale = new Vector3 (0.4F, 0.4F, 1F);
				}
			}
			GameObject clone = (GameObject)Instantiate(player1, transform.position, new Quaternion());
			clone.name = "Atleet";
			Destroy(Player);
		}
		if (Input.GetKeyDown ("2")) {//Tank
			foreach (GameObject playerButton in playerButtons) {
				if (playerButton.name == "Player2"){
					playerButton.transform.localScale = new Vector3 (0.55F, 0.55F, 1F);
				} else {
					playerButton.transform.localScale = new Vector3 (0.4F, 0.4F, 1F);
				}
			}
			GameObject clone = (GameObject)Instantiate(player2, transform.position, new Quaternion());
			clone.name = "Tank";
			Destroy(Player);
		}
		if (Input.GetKeyDown ("3")) {//Archer
			foreach (GameObject playerButton in playerButtons) {
				if (playerButton.name == "Player3"){
					playerButton.transform.localScale = new Vector3 (0.55F, 0.55F, 1F);
				} else {
					playerButton.transform.localScale = new Vector3 (0.4F, 0.4F, 1F);
				}
			}
			GameObject clone = (GameObject)Instantiate(player3, transform.position, new Quaternion());
			clone.name = "Archer";
			Destroy(Player);
		}
		if (Input.GetKeyDown ("4")) {//Techneut
			foreach (GameObject playerButton in playerButtons) {
				if (playerButton.name == "Player4"){
					playerButton.transform.localScale = new Vector3 (0.55F, 0.55F, 1F);
				} else {
					playerButton.transform.localScale = new Vector3 (0.4F, 0.4F, 1F);
				}
			}
			GameObject clone = (GameObject)Instantiate(player4, transform.position, new Quaternion());
			clone.name = "Techneut";
			Destroy(Player);
		}

		//Walking
		if ((Input.GetKeyDown ("space") || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && CanJump == true){
			Player.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 12), ForceMode2D.Impulse);
			CanJump = false;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			Player.transform.position += new Vector3 (0.08F, 0, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			Player.transform.position += new Vector3 (-0.08F, 0, 0);
		}

		//Attacking/Abillities
		if (Input.GetKeyDown (KeyCode.E)) {
			if (Player.name == "Atleet") {
				Player.transform.localScale = new Vector3 (1, 0.5F, 1);
			}
			if (Player.name == "Tank") {
				GameObject Axe = (GameObject)Instantiate(axe, transform.position + new Vector3(0, 0.4F, 0), new Quaternion());
				StartCoroutine(RotateFromTo(axe.transform.rotation, new Quaternion (0, 0, -90, 0), Axe));
			}
			if (Player.name == "Archer") {
				GameObject Arrow = (GameObject)Instantiate(arrow, transform.position, new Quaternion());
				Arrow.GetComponent<Rigidbody2D> ().AddForce (new Vector2(10, 0), ForceMode2D.Impulse);
			}
			if (Player.name == "Techneut") {
				GameObject Bomb = (GameObject)Instantiate(bomb, transform.position, new Quaternion());
				Bomb.GetComponent<Rigidbody2D> ().AddForce (new Vector2(5, 2), ForceMode2D.Impulse);
			}
		}
		if (Input.GetKeyUp (KeyCode.E)) {
			if (Player.name == "Atleet") {
				Player.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}

	//Collision enter is called on every collision
	void OnCollisionEnter2D (Collision2D collision) {
		if(collision.gameObject.tag == "Floor") { 
			CanJump = true;
		}
		if (collision.gameObject.tag == "Enemy") {
//			if (Player.name == "Tank") {
//				Destroy(collision.gameObject);
//			}else {
				Application.LoadLevel(0);
//			}
		}
	}

	IEnumerator RotateFromTo(Quaternion pointA, Quaternion pointB, GameObject Axe){
		if (!moving) {
			moving = true;
			while (t < 1f) {
				t += Time.deltaTime / .3F; // sweeps from 0 to 1 in time seconds
				Axe.transform.RotateAround(Player.transform.position, new Vector3 (0, 0, -1), t*10);
				yield return 0; // leave the routine and return here in the next frame
			}
			t = 0F;
			moving = false;
			Destroy(Axe);
		}
	}
}
