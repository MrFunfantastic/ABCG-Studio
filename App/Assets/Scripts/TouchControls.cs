using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	private PlayerController player;

	private bool right;
	private bool left;
	private bool jump;

	// Use this for initialization
	void Start () {
	
		player = FindObjectOfType<PlayerController> ();
		right = false;
		left = false;
		jump = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//RIGHT ARROW
		if (right) {
			RightArrow ();
		} 			
		//LEFT ARROW
		else if (left) {
			LeftArrow ();
		} 

	}

	//RIGHT BUTTON
	public void onPointerDownRight()
	{
		right = true;	
	}
	public void onPointerUpRight()
	{
		right = false;	
	}

	//LEFT BUTTON
	public void onPointerDownLeft()
	{
		left = true;	
	}
	public void onPointerUpLeft()
	{
		left = false;	
	}

	//JUMP
	public void onPointerDownJump()
	{
		jump = true;	
	}
	public void onPointerUpJump()
	{
		jump = false;	
	}

	public void LeftArrow()
	{
		player.MoveLeft ();
	}

	public void RightArrow()
	{
		player.MoveRight ();
	}

	public void UnpressedArrow()
	{
		player.Unpress ();
	}

	public void Jump()
	{
		player.Jump ();
	}

	public void Shoot()
	{

	}



}
