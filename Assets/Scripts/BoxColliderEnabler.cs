using UnityEngine;
using System.Collections;

public class BoxColliderEnabler : MonoBehaviour {
	void Start () {
        // Bug Fix: adding the BoxCollider2D directly in the
        // editor prevented the Mouse Events from happening
        this.gameObject.AddComponent<BoxCollider2D>();
    }
	
	void Update () {
	
	}
}
