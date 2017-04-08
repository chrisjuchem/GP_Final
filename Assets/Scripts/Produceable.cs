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

	public int amntOwned;

	private bool producing;
	private float timeLeft;

	private Text title;
	private Text info;
	private ProgressBar bar;
	private Button button;

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
		}
		info.text = amntOwned.ToString ();
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
