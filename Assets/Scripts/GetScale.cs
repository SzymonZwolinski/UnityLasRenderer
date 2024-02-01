using UnityEngine;
using UnityEngine.UI;

public class GetScale : MonoBehaviour
{
	public InputField length;
	public InputField width;
	public InputField depth;
	public InputField diameter;

	public InputField scaleX;
	public InputField scaleY;
	public InputField scaleZ;
	public GameObject gameObj;

	private float realLifeScale = 22.5131392857f; //Calibrate this to match your pointMesh

	private void OnEnable()
	{
		gameObj = GameObject.Find("MyLoadedMesh");

		var gameObjParameters = gameObj.GetComponent<Renderer>().bounds.size;
		scaleX.text = gameObj.transform.localScale.x.ToString();
		scaleY.text = gameObj.transform.localScale.y.ToString();
		scaleZ.text = gameObj.transform.localScale.z.ToString();
		length.text = (gameObjParameters.z / realLifeScale).ToString();

		width.text = (gameObjParameters.y / realLifeScale).ToString();

		depth.text = (gameObjParameters.x / realLifeScale).ToString();

		diameter.text = GetLowestDiameter(gameObjParameters);

	}

	private string GetLowestDiameter(Vector3 size)
	{
		if (size.x < size.y && size.x < size.z) 
		{
			return (size.x / realLifeScale).ToString();
		}

		if (size.y < size.x && size.y < size.z) 
		{
			return (size.y / realLifeScale).ToString();
		}

		if (size.z < size.x && size.z < size.y)
		{
			return (size.z / realLifeScale).ToString();
		}

		return (size.x / realLifeScale).ToString();
	}
}
