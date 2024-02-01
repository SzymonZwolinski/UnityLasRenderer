using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlyModelChanger : MonoBehaviour
{
	private GameObject gameObj;
	public Camera cumera;
	public InputField ScaleXField;

	public void OnEnable()
	{
		gameObj = GameObject.Find("MyLoadedMesh");

		UpdateScaleXInputField();
	}

	#region rotations
	public void ChangeObjRotateRight()
    {
		if(gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

        gameObj.transform.Rotate(0.0f, 15.0f, 0.0f, Space.Self);
    }

	public void ChangeObjRotateLeft() 
	{
		if(gameObj is null) 
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		gameObj.transform.Rotate(0.0f, -15.0f, 0.0f, Space.Self);
	}

	public void ChangeObjRotateUp()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		gameObj.transform.Rotate(15.0f, 0.0f, 0.0f, Space.Self);
	}

	public void ChangeObjRotateDown()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		gameObj.transform.Rotate(-15.0f, 0.0f, 0.0f, Space.Self);
	}

	#endregion

	#region scale
	public void ScaleXUp()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x + 0.05f,
			gameObjScale.y,
			gameObjScale.z);

		UpdateScaleXInputField();
	}

	public void ScaleXDown()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x - 0.05f,
			gameObjScale.y,
			gameObjScale.z);

		UpdateScaleXInputField();
	}

	public void ScaleYUp()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x,
			gameObjScale.y + 0.05f,
			gameObjScale.z);
	}

	public void ScaleYDown()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x,
			gameObjScale.y - 0.05f,
			gameObjScale.z);
	}

	public void ScaleZUp()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x,
			gameObjScale.y,
			gameObjScale.z + 0.05f);
	}

	public void ScaleZDown()
	{
		if (gameObj is null)
		{
			gameObj = GameObject.Find("MyLoadedMesh");
		}

		var gameObjScale = gameObj.transform.localScale;
		gameObj.transform.localScale = new Vector3(
			gameObjScale.x,
			gameObjScale.y,
			gameObjScale.z - 0.05f);
	}

	private void UpdateScaleXInputField()
	{
		ScaleXField.text = gameObj.GetComponent<Renderer>().bounds.size.ToString();
	}
	#endregion

	public void ResetCam()
	{
		var vecZero = new Vector3(589, 273, 820);
		cumera.gameObject.transform.localPosition = Vector3.zero;
	}
}
