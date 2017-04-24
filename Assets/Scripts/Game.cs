using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public GameObject temp;

	VerticalLayoutGroup tools;
	VerticalLayoutGroup energy;
	VerticalLayoutGroup refine;
	VerticalLayoutGroup raw;

	// Use this for initialization
	void Start () {
		List<VerticalLayoutGroup> cols = new List<VerticalLayoutGroup>( GetComponentsInChildren<VerticalLayoutGroup>());
		tools = cols.Find ((VerticalLayoutGroup obj) => {return obj.gameObject.name.Equals("Tools");});
		energy = cols.Find ((VerticalLayoutGroup obj) => {return obj.gameObject.name.Equals("Energy");});
		refine = cols.Find ((VerticalLayoutGroup obj) => {return obj.gameObject.name.Equals("Refine");});
		raw = cols.Find ((VerticalLayoutGroup obj) => {return obj.gameObject.name.Equals("Raw");});


		ItemRecipie ax = Instantiate(temp, tools.transform).GetComponent<ItemRecipie>();
		ax.name = "Axe";
		ax.item = Item.Axe;
		ax.recipie = new Recipie (20, 10, new Item[] {Item.Wood, Item.Iron}, new int[] {2, 8});
		//ax.init ();

		ItemRecipie pick = Instantiate(temp, tools.transform).GetComponent<ItemRecipie>();
		pick.name = "Pickaxe";
		pick.item = Item.Pickaxe;
		pick.recipie = new Recipie (20, 10, new Item[] {Item.Wood, Item.Iron}, new int[] {2, 8});

		ItemRecipie shovel = Instantiate(temp, tools.transform).GetComponent<ItemRecipie>();
		shovel.name = "shovel";
		shovel.item = Item.Shovel;
		shovel.recipie = new Recipie (20, 10, new Item[] {Item.Wood, Item.Iron}, new int[] {2, 8});





		ItemRecipie ir = Instantiate(temp, energy.transform).GetComponent<ItemRecipie>();
		EnergyRecipe campfire = ir.gameObject.AddComponent<EnergyRecipe>();
		GameObject.Destroy (ir);
		campfire.name = "Light Bonfire";
		campfire.energy = Energy.Fire;
		campfire.recipie = new Recipie (0, 10, new Item[] {Item.Wood}, new int[] {3});









		ItemRecipie wood = Instantiate(temp, raw.transform).GetComponent<ItemRecipie>();
		wood.name = "Chop Tree";
		wood.item = Item.Wood;
		wood.recipie = new Recipie (1, 1, new Item[] {Item.Axe}, new int[] {1});

		ItemRecipie ore = Instantiate(temp, raw.transform).GetComponent<ItemRecipie>();
		ore.name = "Mine Ore";
		ore.item = Item.Ore;
		ore.recipie = new Recipie (1, 1, new Item[] {Item.Pickaxe}, new int[] {1});

		ItemRecipie clay = Instantiate(temp, raw.transform).GetComponent<ItemRecipie>();
		clay.name = "Dig Clay";
		clay.item = Item.Shovel;
		clay.recipie = new Recipie (1, 1, new Item[] {Item.Shovel}, new int[] {1});




		ItemRecipie charcoal = Instantiate(temp, refine.transform).GetComponent<ItemRecipie>();
		charcoal.name = "Char Wood";
		charcoal.item = Item.Charcoal;
		charcoal.recipie = new Recipie (1, 1.5f, new Item[] {Item.Wood}, new int[] {1}, new Energy[] {Energy.Fire});

		ItemRecipie iron = Instantiate(temp, refine.transform).GetComponent<ItemRecipie>();
		iron.name = "Smelt Ore";
		iron.item = Item.Iron;
		iron.recipie = new Recipie (2, 3, new Item[] {Item.Ore}, new int[] {2}, new Energy[] {Energy.Fire});

		ItemRecipie brick = Instantiate(temp, refine.transform).GetComponent<ItemRecipie>();
		brick.name = "Bake Brick";
		brick.item = Item.Brick;
		brick.recipie = new Recipie (1, 2, new Item[] {Item.Clay}, new int[] {1}, new Energy[] {Energy.Fire});
	}
}
