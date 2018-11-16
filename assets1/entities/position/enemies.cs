using UnityEngine;
using System.Collections;

public class enemies : MonoBehaviour {

public GameObject enemyPrefab;

public float height = 5f;
public float width = 10f;
private bool movingright = true;
public float speed= 5f;

public float xmax;
public float xmin;
public float spawndelay = 0.5f;

	// Use this for initialization
	void Start () {
	
		float distanceTocam = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceTocam));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceTocam));
		xmin = leftBoundary.x;
		xmax = rightBoundary.x;
		spawnuntilFull();
	
	 
	 
	}
	
//	void spawnenemies() {
	
	//	foreach(Transform child in transform) {
			
	//		
	//		GameObject enemy = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
	//		enemy.transform.parent = child;
			
	//	}
	
	
	//}
	
	void spawnuntilFull() {
	Transform freeposition = NextFreePosition();
	if(freeposition) {
	
			GameObject enemy = Instantiate(enemyPrefab,freeposition.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = freeposition;
	
	}
	if(NextFreePosition()) {
	
	Invoke("spawnuntilFull",spawndelay);
	}
	
	
	
	}
	public void OnDrawGizmos() {
	
	Gizmos.DrawWireCube(transform.position,new Vector3(width,height,0));
	
	}
	
	// Update is called once per frame
	void Update () {
	 if(movingright) {
			transform.position+= Vector3.right*speed * Time.deltaTime;
	 
	 }else {
	 
			transform.position+= Vector3.left*speed * Time.deltaTime;
	 }
	 float leftEdgeFormation = transform.position.x - (0.5f*width);
	 float rightEdgeFormation = transform.position.x + (0.5f*width); 
	 if (leftEdgeFormation < xmin) {
	 
	 movingright = true;
		}else if(rightEdgeFormation > xmax) {
		movingright = false;
		}
		if(AllMembersDead()) {
		Debug.Log("empty forma");
		spawnuntilFull();
		}
	}
	Transform NextFreePosition() {
	
		foreach(Transform childformationGameObject in transform) {
			
			if(childformationGameObject.childCount == 0) {
				
				return childformationGameObject;
			}
			
		}
		return null;
	
	
	
	}
	
	bool AllMembersDead() {
	
	foreach(Transform childformationGameObject in transform) {
	
	if(childformationGameObject.childCount > 0) {
	
	return false;
	}
	
	}
	return true;
	
	}
	
}
