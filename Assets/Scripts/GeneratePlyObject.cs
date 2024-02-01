using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneratePlyObject : MonoBehaviour
{
	private string MyResourcesFilePath;
	public Button generateButton;
	public Button restartButton;
	public Canvas ButtonGameMenu;
	public Material test;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;

		Cursor.visible = true;

		Time.timeScale = 1.0f;
	}
	public void InstatiateFromPath( )
	{
		MyResourcesFilePath = Application.dataPath + "\\Resources";
		if ( !Directory.Exists( MyResourcesFilePath ) )
		{
			Directory.CreateDirectory( MyResourcesFilePath );
		}

		(var path, var resourcesFilePath) = CopyFile();
		var meshName = Path.GetFileNameWithoutExtension( path );
		var mesh = Resources.Load<Mesh>(meshName);

		if (mesh is null)
		{
			File.Delete(resourcesFilePath);
			File.Delete(resourcesFilePath + ".meta");
			return;
		}

		var gameObj = new GameObject("MyLoadedMesh");
		gameObj.AddComponent<MeshFilter>().mesh = mesh;
		gameObj.AddComponent<MeshRenderer>();

		var matList = new List<Material>();
		matList.Add(test);
		gameObj.GetComponent<MeshRenderer>().materials = matList.ToArray();
			
		DontDestroyOnLoad( gameObj );
		SceneManager.LoadScene("test", LoadSceneMode.Single); //Change Test to your named scene
	}

	private (string,string) CopyFile()
	{
		var path = EditorUtility.OpenFilePanel("Dodaj plik ply", "", "");

		if (string.IsNullOrWhiteSpace(path) || !path.Contains(".ply"))
		{
			return (null,null);
		}

		var fileNameExtension = Path.GetFileName(path);

		var myResourcesFilePathWithExtension = Path.Combine(MyResourcesFilePath, fileNameExtension);

		if (!File.Exists(myResourcesFilePathWithExtension))
		{
			Debug.Log("asd");
			File.Copy(path, myResourcesFilePathWithExtension);
		}

		AssetDatabase.Refresh();
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();

		return (path, myResourcesFilePathWithExtension);
	}
}
