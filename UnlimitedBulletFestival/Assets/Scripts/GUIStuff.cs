using UnityEngine;
using System.Collections;

public class GUIStuff : MonoBehaviour {

	GUIStyle greenStyle;
	public GUIStyle cutscene;

	public string cuttext = "";

	public float greenness = 0;

	public string hero;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(cuttext != "")
		{
			if(Input.GetKeyDown("z"))
			{
				cuttext = "";
				Time.timeScale = 1;
			}
		}
	}

	public void Cutscene(string text)
	{

	}

	void OnGUI()
	{
		if (greenness > 0) {
					greenness -= 0.03f;
			}

		greenStyle = new GUIStyle( GUI.skin.box );
        greenStyle.normal.background = MakeTex( 2, 2, new Color( 1f, 0f, 0f, greenness ) );
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", greenStyle);

		GUI.Label(new Rect(20,Screen.height-100,Screen.width-20,Screen.height-20), cuttext,cutscene);

		if(hero == "mc" && cuttext != "")
		{
			GUI.DrawTexture(new Rect(10, 10, 384, 448), Resources.Load<Texture2D>("guy"), ScaleMode.StretchToFill, true, 10.0F);
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
	    Color[] pix = new Color[width * height];
	    for( int i = 0; i < pix.Length; ++i )
	    {
	        pix[ i ] = col;
	    }
	    Texture2D result = new Texture2D( width, height );
	    result.SetPixels( pix );
	    result.Apply();
	    return result;
	}
}
