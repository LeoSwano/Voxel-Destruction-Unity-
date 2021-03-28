using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Destruction : MonoBehaviour
{
	public GameObject mesh;

	float cubeWidth;
	float cubeHeight;
	float cubeDepth;

	public float cubeScale = 0.3f;

	void Start()
	{
		cubeWidth = transform.localScale.z;
		cubeHeight = transform.localScale.y;
		cubeDepth = transform.localScale.x;

		//gameObject.GetComponent<MeshRenderer>().enabled = false;
		mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
		
	}

	private void OnCollisionEnter(UnityEngine.Collision collision)
	{
		if (collision.gameObject.tag == "Projectile"){ 
			CreateCube();
		}
	}

	void CreateCube()
	{
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		//this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

		if (gameObject.CompareTag("box"))
		{
			for (float x = 0; x < cubeWidth; x += cubeScale)
			{
				for (float y = 0; y < cubeHeight; y += cubeScale)
				{
					for (float z = 0; z < cubeDepth; z += cubeScale)
					{
						Vector3 vec = transform.position;

						GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
						cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
					}
				}
			}
		}
	}
}
