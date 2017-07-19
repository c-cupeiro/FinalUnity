using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public int points = 0;
	public Sprite[] numbers;
	public GameObject Number_1, Number_2;

	private SpriteRenderer spriteNumber1, spriteNumber2;

	void Start(){
		spriteNumber1 = Number_1.transform.GetChild (0).GetComponent<SpriteRenderer> ();
		spriteNumber2 = Number_2.transform.GetChild (0).GetComponent<SpriteRenderer> ();
	}

	
	// Update is called once per frame
	void Update () {
		if (points == 0) {
			spriteNumber1.sprite = numbers [0];
			spriteNumber2.sprite = numbers [0];
		} else {
			if (points < 10) {
				spriteNumber1.sprite = numbers [0];
				spriteNumber2.sprite = numbers [points];
			} else {
				int part1 = (int)points / 10;
				int part2 = points % 10;
				spriteNumber1.sprite = numbers [part1];
				spriteNumber2.sprite = numbers [part2];
			}
		}
	}
}
