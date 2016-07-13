using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private bool grounded;
	private bool shooting;
	private Animator anim;
	private Rigidbody2D rigid;

	
	void Start () {
	
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();

	}	

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.W) && grounded)
		{
			Jump ();
		}
	
		if (Input.GetKey (KeyCode.D)) 
		{
			MoveRight ();
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			MoveLeft ();

		}

		if (Input.GetKey (KeyCode.Space)) 
		{
			shooting = true;

		}

		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
		anim.SetFloat ("Jump", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.y));
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("Shoot", shooting);
	}

	public void MoveRight()
	{
		FaceDirection(Vector2.right);
		rigid.velocity = new Vector2 (moveSpeed, rigid.velocity.y);
	}

	public void MoveLeft()
	{
		FaceDirection(Vector2.left);
		rigid.velocity = new Vector2 (-moveSpeed, rigid.velocity.y);
	}

	public void Shoot()
	{
		
	}

	public void Jump()
	{
		if(grounded)
			rigid.velocity = new Vector2 (0, jumpHeight);
	}

	private void FaceDirection(Vector2 direction)
	{
		Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back); 
		transform.rotation = rotation3D;
	}


}
