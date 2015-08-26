using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed = 10;

  	public float angle = 0;

  	public Vector2 movement;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 direction = GetXYDirection(Mathf.Deg2Rad* angle,1);
		movement = new Vector2(speed * direction.x,speed * direction.y);

		if(transform.position.x > 25.5f || transform.position.x < -25.5 || transform.position.y > 13 || transform.position.y < -12)
		{
			Destroy(gameObject);
		}

		// Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, speed, 0.0F);
		// newDir = new Vector3(0,0,newDir.z);
		// transform.rotation = Quaternion.LookRotation(newDir);
		//Debug.Log("iswalk" + ps.timeThing);
		float angle2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
	}

	void FixedUpdate()
  	{
    // Apply movement to the rigidbody
    	GetComponent<Rigidbody2D>().velocity = movement;
  	}


  	public Vector2 GetXYDirection(float angle, float magnitude)
	{
		return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitude;
	}
}
