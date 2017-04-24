using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Item {

	Pickaxe,
	Axe,
	Shovel,

	Iron,
	Charcoal,
	Brick,

	Ore,
	Wood,
	Clay

}

public static class itemMethods{
	private static List<int> owned;

	private static void initList() {
		owned = new List<int> ();
		foreach (Item i in Enum.GetValues(typeof(Item))) {
			int amnt = 0;
			switch (i) {
			case Item.Axe:
			case Item.Pickaxe:
				amnt = 20;
				break;
			default:
				break;
			}
			owned.Add(amnt);
		}
	}

	public static int amntOwned(this Item i) {
		if (owned == null) {initList ();}
		return owned [(int)i];
	}
	public static void add(this Item i, int amnt) {
		if (owned == null) {initList ();}
		owned [(int)i] += amnt;
	}


	public static string name(this Item i){
		switch (i) {
		case Item.Pickaxe:
			return "Pickaxe";
		case Item.Axe:
			return "Axe";
		case Item.Shovel:
			return "Shovel";

		case Item.Iron:
			return "Iron";
		case Item.Charcoal:
			return "Charcoal";
		case Item.Brick:
			return "Brick";

		case Item.Ore:
			return "Ore";
		case Item.Wood:
			return "Wood";
		case Item.Clay:
			return "Clay";

		default:
			return "";
		}
	}

}
