/* SplitWood script 
 * Hızara değen odunların ikiye ayrılması 
 * İkiye ayırma işlemi, büyük odunun yok edilmesi ve yerine iki yeni küçük odun yaratılması şeklinde gerçekleşir 
 * Yeni yaratılan odunlara hem rastgelelik katmak hem de kullanıcıya gerçeklik hissi vermek için açıları değiştirilir 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitWood : MonoBehaviour { 

	public GameObject wood; //
	public Material mat; 
	public ParticleSystem particle; 

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Split") {
			//Debug.Log ("working"); 
			Vector3 position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
			Vector3 scale = new Vector3(other.transform.lossyScale.x, other.transform.lossyScale.y, other.transform.lossyScale.z);
			//Debug.Log ("position: " + position + "\nscale: " + scale + "\n"); 

			GameObject woodLeft = Instantiate(wood, new Vector3(position.x - (scale.y / 2), position.y, position.z), Quaternion.Euler(0, 0, 90 + Random.Range(10.0f, 40.0f)));
			woodLeft.transform.localScale = new Vector3(scale.x, scale.y / 2, scale.z); 
			woodLeft.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity; 
			woodLeft.GetComponent<MeshRenderer>().material = mat;

			GameObject woodRight = Instantiate(wood, new Vector3(position.x + (scale.y / 2), position.y, position.z), Quaternion.Euler(0, 0, 90 - Random.Range(10.0f, 40.0f)));
			woodRight.transform.localScale = new Vector3(scale.x, scale.y / 2, scale.z); 
			woodRight.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity; 
			woodRight.GetComponent<MeshRenderer>().material = mat;

			particle.Play(); 

			Destroy(other.gameObject);
		} //end if 
	} //end OnTriggerEnter 
}
