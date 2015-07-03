using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed;
	
	// 2 - Store the movement
	private Vector2 movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		transform.position += new Vector3 (movement.x, movement.y, 0);
	}

}
