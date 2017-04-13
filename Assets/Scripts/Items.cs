using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item {

	Tool,
	Iron,
	Ore,
	Wood,
	Fire

}

public static class itemMethods{
	public static string name(this Item i){
		switch (i) {
		case Item.Tool:
			return "Tool";
		case Item.Iron:
			return "Iron";
		case Item.Ore:
			return "Ore";
		case Item.Wood:
			return "Wood";
		case Item.Fire:
			return "Fire";
		default:
			return "";
		}
	}

}
