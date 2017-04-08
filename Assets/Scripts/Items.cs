using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item {

	Tool,
	Iron

}

public static class itemMethods{
	public static string name(this Item i){
		switch (i) {
		case Item.Tool:
			return "Tool";
		case Item.Iron:
			return "Iron";
		default:
			return "";
		}
	}
}
