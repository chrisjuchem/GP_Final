using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipie {


	public int amntProduced;
	public float timeToProduce;

	public Item[] ingredients;
	public int[] ingredientCounts;
	public Energy[] energy;

	public Recipie(int amntProduced, float time, Item[] ingredients, int[] ingredientCounts) :
		this (amntProduced, time, ingredients, ingredientCounts, new Energy[] {})
	{}
	public Recipie(int amntProduced, float time, Item[] ingredients, int[] ingredientCounts, Energy[] energy) {
		this.timeToProduce = time;
		this.amntProduced = amntProduced;
		this.energy = energy;
		this.ingredients = ingredients;
		this.ingredientCounts = ingredientCounts;
	}
}
