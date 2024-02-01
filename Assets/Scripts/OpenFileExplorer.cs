using UnityEngine;
using UnityEngine.UI;

public class OpenFileExplorer : MonoBehaviour
{
	// Start is called before the first frame update
	public Button generateButton;
	public Button restartButton;
	public Canvas ButtonMenuCanvas;

	public void DeleteExistingMesh()
	{
		var gameObject = GameObject.Find("MyLoadedMesh");
		GameObject.Destroy(gameObject);

		ManageButtons();
	}
	

	private void ManageButtons()
	{
		generateButton.gameObject.active = true;

		restartButton.gameObject.active = false;

		ButtonMenuCanvas.gameObject.SetActive(false);
	}
}
