using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;
	public float r = 100;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		GameObject[] cars = GetAllCars();
		GameObject closestCar = null;

		float min = 1000;
		foreach (GameObject car in cars) {
			Vector3 diff = this.transform.position - car.transform.position;
			float distance = diff.sqrMagnitude;
			if(distance < min) {
				min = distance;
				closestCar = car;
			}
		}

		output = 0;

		if (closestCar) {
			output = 1.0f - 1.0f / (min / r + 1);
		}

		


	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// YOUR CODE HERE


}