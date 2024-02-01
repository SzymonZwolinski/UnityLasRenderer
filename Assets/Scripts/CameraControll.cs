using UnityEngine;

public class CameraControll : MonoBehaviour
{

	[Header("Look Sensitivity")]
	public float sensX;
	public float sensY;

	[Header("Clamping")]
	public float minY;
	public float maxY;

	[Header("Spectator")]
	public float spectatorMoveSpeed;

	private float rotX;
	private float rotY;

	private bool isSpectator = true;

	void LateUpdate()
	{
		
		if( Input.GetMouseButtonDown(2))
		{
			HidePointer();
		}
		if( Input.GetMouseButtonUp(2))
		{ 
			ShowPointer();
		}
		if (Input.GetMouseButton(2))
		{
			
			rotX += Input.GetAxis("Mouse X") * sensX;
			rotY += Input.GetAxis("Mouse Y") * sensY;
			
		}
		
		rotY = Mathf.Clamp(rotY, minY, maxY);

		if (isSpectator)
		{
			transform.rotation = Quaternion.Euler(-rotY, rotX, 0);

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");
			float y = 0;
			float sprint = 1;

			if (Input.GetKey(KeyCode.E))
				y = 1;
			else if (Input.GetKey(KeyCode.Q))
				y = -1;

			if (Input.GetKey(KeyCode.LeftShift))
			{
				sprint = 10;
			}

			Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
  
			transform.position += dir * spectatorMoveSpeed * Time.deltaTime * sprint;

			if (Input.GetKey(KeyCode.Space))
			{
				var actPosition = transform.position;
				actPosition.y = actPosition.y + 0.1f;
				transform.position = actPosition;
			}

			if (Input.GetKey(KeyCode.LeftControl))
			{
				var actPosition = transform.position;
				actPosition.y = actPosition.y - 0.1f;
				transform.position = actPosition;
			}
		}
	}

	private void HidePointer()
	{ 
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void ShowPointer()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}
} 
