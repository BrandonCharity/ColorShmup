using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
