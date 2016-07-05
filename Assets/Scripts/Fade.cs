using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fade : MonoBehaviour {

	public GameObject[] cube;
	GameObject currentMat;

	[SerializeField] private float fadePerSecond = 2.5f;

	void Start(){
		
	}


	public void FadeOut(string nextStep){
		
		foreach(GameObject go in cube){
			ChangeAlpha(go ,1,0);
		}

		GameObject nSt = Instantiate((GameObject)Resources.Load(""+nextStep));

		nSt.GetComponent<Fade>().FadeIn();
			
	}


	public void FadeIn(){
		foreach(GameObject go in cube){
			ChangeAlpha(go, 0, 1);
		}
	}


	void ChangeAlpha(GameObject m ,int a ,int b){
		if(a == 1){
			des = true;
		}
		iTween.ValueTo(gameObject,iTween.Hash("from", a,
			"to",b,
			"easetype", iTween.EaseType.linear, 
			"time", 1.0f,
			"onupdate","UpdateAlpha",
			"oncomplete","CompleteAlpha"));
	}
	void UpdateAlpha(float a ){
		foreach(GameObject go in cube){
			Material material;
			if(go.GetComponent<SpriteRenderer>() != null){
				material = go.GetComponent<Renderer>().sharedMaterial;
			}else{
				material = go.GetComponent<Renderer>().sharedMaterial;
			}
			material.color = new Color(material.color.r ,material.color.g ,material.color.b ,a);
		}
	}
	bool des = false;
	void CompleteAlpha(){
		if(des)
			Destroy(this.gameObject);
	}

}
