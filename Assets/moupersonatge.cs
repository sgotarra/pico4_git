using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class moupersonatge : MonoBehaviour {

	private Transform myTransform;
	private AudioSource source;
	public AudioClip motor1;
	public AudioClip motor2;
	public AudioClip tocabola;

 	private void OnCollisionEnter(Collision collision)

    {
       Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + collision.gameObject.name);   
	   source.Stop();
	   source.clip =tocabola;
       source.Play();
    }

	// Use this for initialization
	void Start() {
			myTransform = GetComponent<Transform>();
			source = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {

		float smooth = 2.0F;
		Quaternion target;
		float velocidadTraslac = 2f;
    	float velocidadRotac = 60f; // X grados por segundo
		float spped=15f;

		
		if (transform.position.y < -30f)  
			{ 
			
			Debug.Log ("FIIIN");	
			Application.Quit();
			}


		if (Input.GetKey("w")) 
			{
			myTransform.Translate(new Vector3(0, 0,1) * spped*Time.deltaTime);
			
			if (!source.isPlaying)
        		{
				source.clip=motor1;
       			source.Play();
				}
			}
		if (Input.GetKey("s")) myTransform.Translate(new Vector3(0, 0,-1) * spped*Time.deltaTime);
		if (Input.GetKey("d")) myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
		if (Input.GetKey("a")) myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);

        

		switch (Controller.UPvr_GetTouchPadClick(0))
        	{
            case TouchPadClick.No:
				if(source.clip!=tocabola) source.Stop();
                break;
            case TouchPadClick.ClickUp:
                myTransform.Translate(new Vector3(0, 0, 1) * spped * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=motor1;
       			source.Play();
				}
				break;
            case TouchPadClick.ClickDown:
                myTransform.Translate(new Vector3(0, 0, -1) * spped* Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=motor1;
       			source.Play();
				}
                break;
            case TouchPadClick.ClickRight:
                myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=motor2;
       			source.Play();
				}
                break;
            case TouchPadClick.ClickLeft:
                myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=motor2;
       			source.Play();
				}
                break;
            default:
                break;
        	}
	}
}
