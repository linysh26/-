using UnityEngine;
using System.Collections;


public class HorseAnima : MonoBehaviour {

	public float speedX;
	public float speedY;
	public float X;
	public float Y;
	// Use this for initialization
	void Start () {
		speedX = 10;		
		speedY = 200;
		X = 0;
		Y = 0;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update(){
		float translationF = Input.GetAxis ("Vertical");
		float translationX = Input.GetAxis ("Mouse X");
		float translationY = Input.GetAxis ("Mouse Y");
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		X += translationX * 40;
		Y += translationY * 40;
		this.transform.rotation = Quaternion.identity;
		this.transform.RotateAround (this.transform.position, Vector3.right, -Y);
		this.transform.RotateAround (this.transform.position, Vector3.up, X);
		this.transform.Translate (Vector3.forward * translationF * Time.deltaTime * speedX);
		Camera.main.transform.rotation = this.transform.rotation;
	}
}
