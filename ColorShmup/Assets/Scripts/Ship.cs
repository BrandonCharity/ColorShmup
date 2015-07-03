using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public enum ColorState {
		Red, Blue
	};

	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 MovementSpeed;
	public GameObject projectileOne;
	public GameObject projectileTwo;
	public float bulletSpawnSpeed;

	[HideInInspector]
	public ColorState colorState;

	private Sprite shipSprite;
	private SpriteRenderer shipSpriteRenderer;
	
	// 2 - Store the movement
	private Vector2 movement;

	void Awake() {
		colorState = ColorState.Red;
		shipSpriteRenderer = this.GetComponent<SpriteRenderer> ();
		if (shipSpriteRenderer != null) {
			shipSprite = shipSpriteRenderer.sprite;
		}
	}

	void Start () {
		InvokeRepeating ("ShootProjectile", bulletSpawnSpeed, 1);
	}

	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			MovementSpeed.x * inputX,
			MovementSpeed.y * inputY);

		transform.position += new Vector3 (movement.x, movement.y, 0);

		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightControl)) {
			if (colorState == ColorState.Red) {
				colorState = ColorState.Blue;
				ChangeShip(Color.blue);
			}
			else {
				colorState = ColorState.Red;
				ChangeShip (Color.red);
			}
		}
	}

	void ChangeShip(Color color) {
		shipSpriteRenderer.color = color;
	}

	void ShootProjectile() {
		if (colorState == ColorState.Red) {
			Instantiate (projectileOne, this.transform.position, Quaternion.identity);
		} else {
			Instantiate (projectileTwo, this.transform.position, Quaternion.identity);
		}
	}



}
