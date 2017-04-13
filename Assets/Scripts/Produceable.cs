using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Produceable : MonoBehaviour {

	public Item item;

	public int amntProduced;
	public float timeToProduce;

	public Item[] ingredients;
	public int[] ingredientCounts;
	public bool needsHeat;

	public int amntOwned;

	private bool producing;
	private float timeLeft;

	private Text title;
	private Text info;
	private ProgressBar bar;
	private Button button;

	private string recipieString = "";

	// Use this for initialization
	void Start () {
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

		title.text = item.name ();
		button.onClick.AddListener(Clicked);

		if (item.Equals (Item.Fire)) {
			bar.gameObject.GetComponent<Image> ().color = Color.red;
		}


		for (int i = 0; i < Mathf.Min (ingredients.Length, ingredientCounts.Length); i++) {
			recipieString += ingredientCounts [i].ToString () + " " + ingredients [i].name () + "\n"; 
		}
		if (needsHeat) {
			recipieString += "Heat\n";
		}
		recipieString += "\u231a " + timeToProduce.ToString ();
		if (!item.Equals (Item.Fire)) {
			recipieString += " \u2192 " + amntProduced;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (producing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
				producing = false;
				amntOwned += amntProduced;
			}
				
			if (needsHeat) {
				Produceable p = Produceable.find (Item.Fire, 1); //TODO tracked fire source
				Debug.Log(p);
				if (p == null) {
					timeLeft = 0;
					producing = false;
				}
			}
		}


		if (item.Equals (Item.Fire)) {
			amntOwned = Mathf.CeilToInt (timeLeft);
		}

		info.text = amntOwned.ToString () + "\n" + recipieString;
		bar.UpdateBar (timeLeft / timeToProduce);
	}

	public void Clicked() {
		if (!producing) {
			List<Produceable> prods = new List<Produceable> ();
			bool anyNull = false;
			for (int i = 0; i < Mathf.Min (ingredients.Length, ingredientCounts.Length); i++) {
				Produceable p = Produceable.find(ingredients[i], ingredientCounts[i]);
				if (p == null) {
					anyNull = true;
					break;
				} else {
					prods.Add (p);
				}
			}
			if (needsHeat && !anyNull) {
				Produceable p = Produceable.find (Item.Fire, 1);//TODO Save longest heat source, stop if exactly that one goes out
				anyNull = (p == null);
			}

			if (!anyNull) {
				producing = true;
				timeLeft = timeToProduce;
				for (int i = 0; i < prods.Count; i++) {
					prods [i].amntOwned -= ingredientCounts [i];
				}
			}
		}
	}

	public static Produceable find(Item t, int count) {
		foreach (GameObject i in GameObject.FindGameObjectsWithTag ("Item")) {
			Produceable p = i.GetComponent<Produceable> ();
			if (p.item == t && p.amntOwned >= count) {
				return p;
			}
		}

		return null;
	}
}
