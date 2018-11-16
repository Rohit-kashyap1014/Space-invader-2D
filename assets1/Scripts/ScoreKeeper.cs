using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	private Text mytext; 
	
	
	void Start() {
	
	mytext = GetComponent<Text>();
	reset();
	}
	public void Score(int points) {
	
	score+= points;
	mytext.text = score.ToString();
	
	}
    public static void reset() {
    
    score=0;
    }
}
