using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
	public float throwForce = 300; //Force of throwing object
	GameObject mainCamera;
	GameObject carriedObject;

	public bool isHolding;
	public float distance;
	public float smooth;
	// Use this for initialization
	void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera");
	}

	void Update()
	{

		if (isHolding)
		{
			carry(carriedObject);
			checkDrop();			
		}
		else
		{
			pickup();
		}
	}


	void carry(GameObject o)
	{
		o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup()
	{
		if (Input.GetMouseButtonDown(0) && !isHolding)
		{
			
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if (p != null)
				{
					SoundManager.PlayItempickUpClip();
					isHolding = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop()
	{
		if (Input.GetMouseButtonDown(1))
		{
			dropObject();
		}
	}

	void dropObject()
	{
		SoundManager.PlayItemDropClip();
		isHolding = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject.gameObject.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * throwForce);
		carriedObject = null;
	}
}
