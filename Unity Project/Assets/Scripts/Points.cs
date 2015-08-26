using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public string target;
	public Transform player;
	Vector2 movement;

	public float speed = 100;

	// Use this for initialization
	void Start () {
		player = GameObject.Find(target).transform;
	}

	// Update is called once per frame
	void Update () {
		Vector2 heading = transform.position - player.position;



		float distance = heading.magnitude;
		Vector2 direction = heading / distance;

		// float mouseposx = player.position.x - transform.position.x;
	    // float mouseposy = player.position.y - transform.position.y;
	    // float angle = Mathf.Atan2(mouseposy, mouseposx) * Mathf.Rad2Deg;

		movement = new Vector2(speed * direction.x * -1,speed * direction.y * -1);


		if(distance < 2f)
		{
			Destroy(gameObject);
		}

	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
