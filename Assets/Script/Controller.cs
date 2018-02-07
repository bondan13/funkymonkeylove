using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	public GameObject banana;
	public GameObject yoyo;
	public Player playerScript;

	// Use this for initialization
	void Start () {
		banana = GameObject.Find ("banana");
		yoyo = GameObject.Find ("Yoyo");
		playerScript = yoyo.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update () {
		clickEvent ();
	}

	void clickEvent(){
		if (Input.GetMouseButtonDown (0)) {
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			GameObject.Instantiate(this.banana, (Vector3) pos, Quaternion.identity);
			playerScript.setMovement(pos);
		}
	}
}
