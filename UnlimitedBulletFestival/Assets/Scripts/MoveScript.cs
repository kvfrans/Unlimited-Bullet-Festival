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
		//Debug.Log("iswalk" + ps.timeThing);
	}

	void FixedUpdate()
  	{
    // Apply movement to the rigidbody
    	rigidbody2D.velocity = movement;
  	}


  	public Vector2 GetXYDirection(float angle, float magnitude)
	{
	return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitude;
	}
}
