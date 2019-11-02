using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

	public float destroyTime = 3.0f;

    // Start is called before the first frame update
    void Awake()
    {
		Destroy(gameObject, destroyTime);
    }

}
