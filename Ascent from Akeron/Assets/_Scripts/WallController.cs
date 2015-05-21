using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {
	public GameObject Wall;

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Bomb") {
			Destroy(collision);
			Destroy(Wall);
		}
	}
}
