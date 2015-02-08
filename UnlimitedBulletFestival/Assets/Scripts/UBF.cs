using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UBF : MonoBehaviour {

	public string scriptname;
	public string category;

	private Transform dm;
	private List<string> commands;

	// Use this for initialization
	void Start () {
		dm = GameObject.Find("DungeonMaster").transform;
		commands = dm.GetComponent<ReadFile>().Load(scriptname);

		StartCoroutine(ParseCommand());
	}

	// Update is called once per frame
	void Update () {

	}

	float ExecuteLine(string toexecute)
	{
		string[] lineandmod = toexecute.Split(',');
		string line = lineandmod[0];
		// string xyz = "string1 string2 string3";
		string[] parts = line.Split(' ');
		float delay = 0;

		if(parts[0] == "set")
		{
			//set a value
			if(parts[1] == "speed")
			{
				GetComponent<MoveScript>().speed = float.Parse(parts[2]);
			}
			else if(parts[1] == "direction")
			{
				GetComponent<MoveScript>().angle = float.Parse(parts[2]);
			}
			else if(parts[1] == "size")
			{
				float size = float.Parse(parts[2]);
				transform.localScale = new Vector3(size/10.0f,size/10.0f,size/10.0f);
			}
			else if(parts[1] == "x")
			{
				transform.position = new Vector2(float.Parse(parts[2]),transform.position.y);
			}
			else if(parts[1] == "y")
			{
				transform.position = new Vector2(transform.position.x,float.Parse(parts[2]));
			}
		}
		if(parts[0] == "add")
		{
			//set a value
			if(parts[1] == "speed")
			{
				GetComponent<MoveScript>().speed += float.Parse(parts[2]);
			}
			else if(parts[1] == "rotation")
			{
				GetComponent<MoveScript>().angle += float.Parse(parts[2]);
			}
			else if(parts[1] == "size")
			{
				float size = float.Parse(parts[2]);
				transform.localScale += new Vector3(size/10.0f,size/10.0f,size/10.0f);
			}
			else if(parts[1] == "x")
			{
				transform.position = new Vector2(transform.position.x + float.Parse(parts[2]),transform.position.y);
			}
			else if(parts[1] == "y")
			{
				transform.position = new Vector2(transform.position.x,float.Parse(parts[2] + transform.position.y));
			}
		}
		else if(parts[0] == "delay")
		{
			delay = float.Parse(parts[1]);
		}
		else if(parts[0] == "make")
		{
			var ubf = Instantiate(Resources.Load<Transform>("UBF")) as Transform;
			ubf.GetComponent<UBF>().scriptname = parts[1];
			ubf.GetComponent<MoveScript>().speed = float.Parse(parts[2]);
			ubf.GetComponent<MoveScript>().angle = float.Parse(parts[3]);
			ubf.transform.position = transform.position;
		}
		else if(parts[0] == "destroy")
		{
			Destroy(gameObject);
		}
		else if(parts[0] == "clear")
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("UBF"))
			{
				if(go.GetComponent<UBF>().category == "bullet")
				{
					Destroy(go);
				}
			}
		}
		else if(parts[0] == "category")
		{
			category = parts[1];
		}
		else if(parts[0] == "sprite")
		{
			// Debug.Log(parts[1]);
			Texture2D text = Resources.Load<Texture2D>(parts[1]) as Texture2D;
			Sprite spr = Sprite.Create(text,new Rect(0,0,text.width,text.height),new Vector2(0.5f,0.5f),1);
			GetComponent<SpriteRenderer>().sprite = spr;
		}
		if(parts[0] == "loop")
		{
			// Debug.Log(lineandmod[0] + " ... " + lineandmod[1]);
			if(lineandmod.Length == 2)
			{
				for(int i = 0; i < int.Parse(parts[1]); i++)
				{
					ExecuteLine(lineandmod[1]);
				}
			}
			else
			{
				for(int i = 0; i < int.Parse(parts[1]); i++)
				{
					// ExecuteLine(lineandmod[1]);
					string[] lineparts = lineandmod[1].Split(' ');
					string[] modifyparts = lineandmod[2].Split(' ');


					string newcommand = lineparts[0] + " " + lineparts[1];

					for(int k = 1; k < lineparts.Length-1; k++)
					{
						float newval = float.Parse(lineparts[k+1]) + (float.Parse(modifyparts[k])*i);
						lineparts[k] = newval.ToString();
						newcommand += " ";
						newcommand += lineparts[k];
					}

					// Debug.Log(newcommand);
					StartCoroutine(ExecuteDelay(newcommand,float.Parse(lineandmod[3])*i));
				}
				delay = float.Parse(lineandmod[3])*int.Parse(parts[1]);
			}
		}

		return delay;
	}


	IEnumerator ExecuteDelay(string command, float delay)
    {
    	string[] parts = command.Split(' ');
    	yield return new WaitForSeconds(delay);
        if(parts[0] == "make")
		{
			var ubf = Instantiate(Resources.Load<Transform>("UBF")) as Transform;
			ubf.GetComponent<UBF>().scriptname = parts[1];
			ubf.GetComponent<MoveScript>().speed = float.Parse(parts[2]);
			ubf.GetComponent<MoveScript>().angle = float.Parse(parts[3]);
			ubf.transform.position = transform.position;
		}
    }


	IEnumerator ParseCommand()
	{
		foreach(string line in commands)
		{

			float delay = ExecuteLine(line);
			yield return new WaitForSeconds(delay);
		}
	}
}
