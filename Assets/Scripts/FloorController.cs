using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

	public GameObject floor1, floor2;

	private void FixedUpdate() {
		if(!GameManager.instance.inGame) return;
		floor1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed,0f,0f);
		floor2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed,0f,0f);

		if(floor2.transform.position.x < 0f){
			floor1.transform.position += new Vector3(30.42f,0f,0f);

			var tmp = floor1;
			floor1 = floor2;
			floor2 = tmp;
		}
	}

}
