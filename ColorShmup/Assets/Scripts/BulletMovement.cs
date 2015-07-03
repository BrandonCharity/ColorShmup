using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed;
	public Direction direction;

	[HideInInspector]
	public enum Direction {
		Up, Down, Left, Right
	};

	private Vector3 vectorToAdd;

	void Awake() {
		if (direction == Direction.Down) {
			vectorToAdd = new Vector3 (0, -1 * speed * Time.deltaTime, 0);
		} else if (direction == Direction.Left) {
			vectorToAdd = new Vector3 (-1 * speed * Time.deltaTime, 0, 0);
		} else if (direction == Direction.Right) {
			vectorToAdd = new Vector3 (speed * Time.deltaTime, 0, 0);
		} else {
			vectorToAdd = new Vector3 (0, speed * Time.deltaTime, 0);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position += vectorToAdd;
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
