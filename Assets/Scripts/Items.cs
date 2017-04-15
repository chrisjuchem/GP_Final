using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item {

	Pickaxe,
	Axe,
	Shovel,

	Iron,
	Charcoal,
	Brick,

	Ore,
	Wood,
	Clay,

	Fire

}

public static class itemMethods{
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

		case Item.Fire:
			return "Fire";
		default:
			return "";
		}
	}

}
