using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float speed = 0.2f;

	public Texture2D regular;
	public Texture2D left;
	public Texture2D right;

	float cooldown = 0;

	public Transform bullet;

 	void Update()
 	{

 		if(Input.GetKey(KeyCode.LeftShift))
		{
			speed = 0.07f;
		}
		else
		{
			speed = 0.3f;
		}
    	float inputY = 0;
    	float inputX = 0;

    	bool isWalking = false;
    	bool isShooting = false;

		if(Input.GetKey("up"))
		{
			inputY += 1;
			// isWalking = true;
		}
		if(Input.GetKey("down"))
		{
			inputY -= 1;
			// isWalking = true;
		}
		if(Input.GetKey("left"))
		{
			inputX -= 1;
			isWalking = true;
		}
		if(Input.GetKey("right"))
		{
			inputX += 1;
			isWalking = true;
		}

		if(Input.GetKey("z"))
		{
			isShooting = true;
		}

		if(cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}

		if(isShooting)
		{
			var shot = Instantiate(bullet) as Transform;
			shot.position = transform.position + new Vector3(Random.value * 3 - 1.5f, -1);
			cooldown = 0.005f;
		}

		if(isWalking)
		{
			if(inputX > 0)
			{
				Texture2D text = right;
				Sprite spr = Sprite.Create(text,new Rect(0,0,text.width,text.height),new Vector2(0.5f,0.5f),1);
				GetComponent<SpriteRenderer>().sprite = spr;
			}
			if(inputX < 0)
			{
				Texture2D text = left;
				Sprite spr = Sprite.Create(text,new Rect(0,0,text.width,text.height),new Vector2(0.5f,0.5f),1);
				GetComponent<SpriteRenderer>().sprite = spr;
			}
		}
		else
		{
			Texture2D text = regular;
			Sprite spr = Sprite.Create(text,new Rect(0,0,text.width,text.height),new Vector2(0.5f,0.5f),1);
			GetComponent<SpriteRenderer>().sprite = spr;
		}

		transform.position = new Vector2(transform.position.x + inputX*speed,transform.position.y + inputY*speed);
	}
}
