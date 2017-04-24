using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Energy  {
	Fire,
	Electricity
}

public static class energyMethods{
	private static List<List<EnergyRecipe>> producing;

	private static void initList() {
		producing = new List<List<EnergyRecipe>> ();
		foreach (Item i in Enum.GetValues(typeof(Energy))) {
			producing.Add(new List<EnergyRecipe>());
		}
	}


	public static void start(this Energy e, EnergyRecipe er) {
		if (producing == null) {initList ();}
		producing [(int)e].Add (er);
	}  

	public static void stop(this Energy e, EnergyRecipe er) {
		if (producing == null) {initList ();}
		producing [(int)e].Remove (er);
	}  

	public static EnergyRecipe use(this Energy e, ItemRecipie ir) { //TODO generalize Recipie
		if (producing == null) {initList ();}
		EnergyRecipe longest = null;
		foreach (EnergyRecipe er in producing[(int)e]) {
			if (longest == null || er.timeLeft > longest.timeLeft) {
				longest = er;
			}
		}

		return longest;
	}


	public static string name(this Energy e){
		switch (e) {
		case Energy.Fire:
			return "Fire";
		case Energy.Electricity:
			return "Electricity";
		default:
			return "";
		}
	}
}