using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject Enemy;

	void OnCollisionEnter2D (Collision2D collision) {
		if (Enemy.tag == "Enemy") {
			if (collision.gameObject.tag == "Arrow") {
				Destroy (Enemy);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Axe") {
			Destroy(Enemy);
		}
	}
}
