using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

	public void UpdateBar (float scale) {
		transform.localScale = new Vector3 (scale, 1f, 1f);
	}

}
