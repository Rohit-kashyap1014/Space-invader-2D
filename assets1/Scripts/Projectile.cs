using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

public float damage = 100.0f;

public void Hit() {

Destroy(gameObject);

}
public float GetDamage() {

return damage;
}
}
