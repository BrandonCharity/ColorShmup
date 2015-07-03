using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject projectile;
	public float bulletSpawnSpeed;

	void Start () {
		InvokeRepeating ("ShootProjectile", bulletSpawnSpeed, 1);
	}

	void ShootProjectile() {
		Instantiate (projectile, this.transform.position, Quaternion.identity);
	}
}
