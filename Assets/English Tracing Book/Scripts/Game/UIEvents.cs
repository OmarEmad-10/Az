using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIEvents : MonoBehaviour
{
		public void AlbumShapeEvent (TableShape tableShape)
		{
				if (tableShape == null) {
						return;
				}

				if (tableShape.isLocked) {
					return;
				}

				TableShape.selectedShape = tableShape;
				LoadGameScene ();
		}

		public void PointerButtonEvent (Pointer pointer)
		{
				if (pointer == null) {
						return;
				}
				if (pointer.group != null) {
						ScrollSlider scrollSlider = GameObject.FindObjectOfType (typeof(ScrollSlider)) as ScrollSlider;
						if (scrollSlider != null) {
								scrollSlider.DisableCurrentPointer ();
								FindObjectOfType<ScrollSlider> ().currentGroupIndex = pointer.group.Index;
								scrollSlider.GoToCurrentGroup ();
						}
				}
		}

		public void LoadMainScene(){
			StartCoroutine(SceneLoader.LoadSceneAsync ("Main"));
		}

		public void LoadGameScene(){
			StartCoroutine(SceneLoader.LoadSceneAsync ("Game"));
		}
	public void LoadCapitalsScene()
	{
		StartCoroutine(SceneLoader.LoadSceneAsync("Capitals"));
	}
	public void LoadNumbersScene()
	{
		StartCoroutine(SceneLoader.LoadSceneAsync("Numbers"));
	}
	public void LoadSmallsScene()
	{
		StartCoroutine(SceneLoader.LoadSceneAsync("Smalls"));
	}

	public void LoadAlbumScene ()
		{
			if(!string.IsNullOrEmpty(ShapesManager.shapesManagerReference))
				StartCoroutine(SceneLoader.LoadSceneAsync (GameObject.Find(ShapesManager.shapesManagerReference).GetComponent<ShapesManager>().sceneName));
		}

		public void LoadLowercaseAlbumScene ()
		{
			ShapesManager.shapesManagerReference = "LShapesManager";
			StartCoroutine(SceneLoader.LoadSceneAsync ("LowercaseAlbum"));
		}
	public void LoadLowercaseAlbumScene1()
	{
		ShapesManager.shapesManagerReference = "LShapesManagerTwo";
		StartCoroutine(SceneLoader.LoadSceneAsync("LowercaseAlbum1"));
	}
	public void LoadLowercaseAlbumScene2()
	{
		ShapesManager.shapesManagerReference = "LShapesManagerThree";
		StartCoroutine(SceneLoader.LoadSceneAsync("LowercaseAlbum2"));
	}
	public void LoadLowercaseAlbumScene3()
	{
		ShapesManager.shapesManagerReference = "LShapesManagerFour";
		StartCoroutine(SceneLoader.LoadSceneAsync("LowercaseAlbum3"));
	}
	public void LoadLowercaseAlbumScene4()
	{
		ShapesManager.shapesManagerReference = "LShapesManagerFive";
		StartCoroutine(SceneLoader.LoadSceneAsync("LowercaseAlbum4"));
	}
	public void LoadUppercaseAlbumScene ()
		{
			ShapesManager.shapesManagerReference = "UShapesManager";
			StartCoroutine(SceneLoader.LoadSceneAsync ("UppercaseAlbum"));
		}
	public void LoadUppercaseAlbumScene1()
	{
		ShapesManager.shapesManagerReference = "UShapesManager2";
		StartCoroutine(SceneLoader.LoadSceneAsync("UppercaseAlbum1"));
	}
	public void LoadUppercaseAlbumScene2()
	{
		ShapesManager.shapesManagerReference = "UShapesManager3";
		StartCoroutine(SceneLoader.LoadSceneAsync("UppercaseAlbum2"));
	}
	public void LoadUppercaseAlbumScene3()
	{
		ShapesManager.shapesManagerReference = "UShapesManager4";
		StartCoroutine(SceneLoader.LoadSceneAsync("UppercaseAlbum3"));
	}
	public void LoadUppercaseAlbumScene4()
	{
		ShapesManager.shapesManagerReference = "UShapesManager5";
		StartCoroutine(SceneLoader.LoadSceneAsync("UppercaseAlbum4"));
	}

	public void LoadNumbersAlbumScene ()
		{
			ShapesManager.shapesManagerReference = "NShapesManager";
			StartCoroutine(SceneLoader.LoadSceneAsync ("NumbersAlbum"));
		}

		public void LoadSentenceAlbumScene ()
		{
			ShapesManager.shapesManagerReference = "SShapesManager";
			StartCoroutine(SceneLoader.LoadSceneAsync ("NumbersAlbumN"));
		}

		public void NextClickEvent ()
		{
			try{
				GameObject.FindObjectOfType<GameManager> ().NextShape ();
			}catch(System.Exception ex){

			}
		}

		public void PreviousClickEvent ()
		{
			try{
				GameObject.FindObjectOfType<GameManager> ().PreviousShape ();
			}catch(System.Exception ex){
			
			}
		}

		public void SpeechClickEvent ()
		{
				Shape shape = GameObject.FindObjectOfType<Shape> ();
				if (shape == null) {
						return;
				}
				shape.Spell ();
		}

		public void ResetShape ()
		{
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
				if (gameManager != null) {
					if(!gameManager.shape.completed){
							gameManager.DisableGameManager ();
							GameObject.Find ("ResetConfirmDialog").GetComponent<Dialog> ().Show ();
					}else{
						gameManager.ResetShape();
					}
				}
		}

		public void PencilClickEvent (Pencil pencil)
		{
				if (pencil == null) {
						return;
				}
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
				if (gameManager == null) {
						return;
				}
				if (gameManager.currentPencil != null) {
						gameManager.currentPencil.DisableSelection ();
						gameManager.currentPencil = pencil;
				}
				gameManager.SetShapeOrderColor ();
				pencil.EnableSelection ();
		}

		public void ResetConfirmDialogEvent (GameObject value)
		{
				if (value == null) {
						return;
				}
		
				GameManager gameManager = GameObject.FindObjectOfType<GameManager> ();
		
				if (value.name.Equals ("YesButton")) {
						Debug.Log ("Reset Confirm Dialog : Yes button clicked");
						if (gameManager != null) {
								gameManager.ResetShape ();
						}
			
				} else if (value.name.Equals ("NoButton")) {
						Debug.Log ("Reset Confirm Dialog : No button clicked");
				}

				value.GetComponentInParent<Dialog> ().Hide ();

				if (gameManager != null) {
						gameManager.EnableGameManager ();
				}
		}


		public void ResetGame(){
			DataManager.ResetGame ();
		}

		public void LeaveApp(){
			Application.Quit ();
		}
}
