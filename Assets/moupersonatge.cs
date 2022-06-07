using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class moupersonatge : MonoBehaviour {

	private Transform myTransform;


 	private void OnCollisionEnter(Collision collision)

    {
       Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + collision.gameObject.name);   
	 
    }

	// Use this for initialization
	void Start() {
			myTransform = GetComponent<Transform>();
			
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
			
			
			}
		if (Input.GetKey("s")) myTransform.Translate(new Vector3(0, 0,-1) * spped*Time.deltaTime);
		if (Input.GetKey("d")) myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
		if (Input.GetKey("a")) myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);

        

		switch (Controller.UPvr_GetTouchPadClick(0))
        	{
            case TouchPadClick.No:
			
                break;
            case TouchPadClick.ClickUp:
                myTransform.Translate(new Vector3(0, 0, 1) * spped * Time.deltaTime);
			
				break;
            case TouchPadClick.ClickDown:
                myTransform.Translate(new Vector3(0, 0, -1) * spped* Time.deltaTime);
			
                break;
            case TouchPadClick.ClickRight:
                myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
			
                break;
            case TouchPadClick.ClickLeft:
                myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);
			
                break;
            default:
                break;
        	}
	}
}
