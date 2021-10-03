using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audio : MonoBehaviour
{
	private AudioSource source; // composent qui reçoit les paramètres
	public AudioClip sound ; // son à définir dans l'inspecteur

	
	[Range(0f, 1f)]
	public float volume; //Gestion volume

	[Range(0.1f, 2.5f)]
	public float pitch; //Gestion de la vitesse du morceau

	void Awake(){
		gameObject.AddComponent<AudioSource>(); //ajout à l'objet un composant audio source
		source = GetComponent<AudioSource>();// ajout à la source le composant
		volume = 0.5f;
		pitch = 1f;

	}


    // Start is called before the first frame update
    void Start()
    {
    	source.clip = sound;
    	source.loop = true;
    	source.volume = volume;
    	source.pitch = pitch;
        
    }

    // Update is called once per frame
    void Update()
    {
    	Play();
    	source.volume = volume;
    	source.pitch = pitch;        
    }

    public void Playpause(){
    	if(!source.isPlaying){
    		source.Play();
    	}
    	else{
    		source.Pause();
    	}
    }

    public void Play(){
    	if(!source.isPlaying){
    		source.Play();
    	}
    }
}

