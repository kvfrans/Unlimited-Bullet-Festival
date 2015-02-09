using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour
{

  public static SoundEffectsHelper Instance;

  public AudioClip explosionSound;

  public float cooldown = 0;



  void Awake()
  {
    // Register the singleton
    if (Instance != null)
    {
      Debug.LogError("Multiple instances of SoundEffectsHelper!");
    }
    Instance = this;
  }

  void Update()
  {
  	if(cooldown > 0)
  	{
  		cooldown -= Time.deltaTime;
  	}
  }

  public void MakeExplosionSound()
  {
    MakeSound(explosionSound,0.2f);
  }


  AudioSource PlayClipAt(AudioClip clip, Vector3 pos){
    GameObject tempGO = new GameObject("TempAudio"); // create the temp object
    tempGO.transform.position = pos; // set its position
    AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
    aSource.clip = clip; // define the clip
    // set other aSource properties here, if desired
    aSource.Play(); // start the sound
    Destroy(tempGO, clip.length); // destroy object after clip duration
    return aSource; // return the AudioSource reference
}

  private void MakeSound(AudioClip originalClip, float volume)
  {
  		if(cooldown <= 0)
  		{
        //AudioSource.volume = 0.5;
    		AudioSource ad = PlayClipAt(originalClip, transform.position);
		    ad.volume = 0.08f;
    		cooldown = 0.1f;
    	}


  }
}