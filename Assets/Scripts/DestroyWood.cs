/* DestroyWood script 
 * Ekrandan aşağı düşen odun parçalarının yok edilerek uygulamanın hafifletilmesi 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWood : MonoBehaviour {
	
	//nesnelerin yok edilmesi 
	void OnTriggerEnter (Collider other) { 
		Destroy(other.gameObject); 
	} //end OnCollisionEnter 

} //eof 