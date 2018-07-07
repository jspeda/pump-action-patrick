using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Vector2 direction;
    private 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		Move();
        Rotate();
	}

	public void Move() {
		transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    public void Rotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position
        Quaternion look = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        //make a Rotation object by subtracting the mouse coords from the player coords (vectors are wild!!!)
        transform.rotation = look;
        transform.localEulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //change the player rotation to that rotation, set its x & y rotations to zero
        if (Input.GetKey(KeyCode.Q)) {
            Debug.Log(transform.position + " || " + mousePosition + " || " + transform.eulerAngles.z);
        }
    }

    private void GetInput(){
		direction = Vector2.zero;

		if (Input.GetKey(KeyCode.W)) {
			direction += Vector2.up;
		}
		if (Input.GetKey(KeyCode.A)) {
			direction += Vector2.left;
		}
		if (Input.GetKey(KeyCode.S)) {
			direction += Vector2.down;
		}
		if (Input.GetKey(KeyCode.D)) {
			direction += Vector2.right;
		}
	}
}
