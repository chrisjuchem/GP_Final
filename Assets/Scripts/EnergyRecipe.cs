using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyRecipe : MonoBehaviour {

	public Energy energy;
	public string name;

	public Recipie recipie;

	private bool producing;
	public float timeLeft;

	private Text title;
	private Text info;
	private ProgressBar bar;
	private Button button;

	private string recipieString = "";

	public List<ItemRecipie> dependant = new List<ItemRecipie> ();

	// Use this for initialization
	void Start() {
		init ();
	}

	public void init () {
		button = GetComponentInChildren<Button> ();
		bar = GetComponentInChildren<ProgressBar> ();
		Text[] texts = GetComponentsInChildren<Text> ();
		foreach (Text t in texts) {
			if (t.gameObject.tag.Equals ("Info")) {
				info = t;
			}
			if (t.gameObject.tag.Equals ("Title")) {
				title = t;
			}
		}

		title.text = name;
		button.onClick.AddListener(Clicked);

		bar.gameObject.GetComponent<Image> ().color = Color.red;

		int lines = 2; //time to produce
		for (int i = 0; i < Mathf.Min (recipie.ingredients.Length, recipie.ingredientCounts.Length); i++) {
			recipieString += recipie.ingredientCounts [i].ToString () + " " + recipie.ingredients [i].name () + "\n"; 
			lines += 1;
		}
		foreach (Energy e in recipie.energy) {
			recipieString += e.name() + "\n";
			lines += 1;
		}
		recipieString += "\u231a " + recipie.timeToProduce.ToString ();
		info.text = recipieString;

		GetComponent< RectTransform > ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 75 + 16 * lines);
	}
	
	// Update is called once per frame
	void Update () {
		if (producing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
				producing = false;
				energy.stop (this);
				foreach (ItemRecipie ir in dependant) {
					ir.timeLeft = 0;
					ir.producing = false;
				}
				dependant = new List<ItemRecipie> ();
			}

			/*if (needsHeat) {
				Recipie p = Recipie.find (Item.Fire, 1); //TODO tracked fire source
				Debug.Log(p);
				if (p == null) {
					timeLeft = 0;
					producing = false;
				}
			}*/
		}

		bar.UpdateBar (timeLeft / recipie.timeToProduce);
	}

	public void Clicked() {
		if (!producing) {
			int count = Mathf.Min (recipie.ingredients.Length, recipie.ingredientCounts.Length);
			bool enough = true;
			for (int i = 0; i < count; i++) {
				if (recipie.ingredients [i].amntOwned () < recipie.ingredientCounts [i]) {
					enough = false;
					break;
				}
			}
			/*if (needsHeat && enough) {
				//find fire
				//TODO Save longest heat source, stop if exactly that one goes out
			}*/

			if (enough) {
				producing = true;
				timeLeft = recipie.timeToProduce;
				for (int i = 0; i < count; i++) {
					recipie.ingredients [i].add(- recipie.ingredientCounts [i]);
				}

				energy.start (this);
			}
		}
	}

}
