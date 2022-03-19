using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	public bool inverseEnergy = false; // If true, reverse the energy slope
	private bool useAngle = true;
	public Material t_Material;

	public float output;
	public int numObjects;
	public float r = 1000; // Car radius

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
		GameObject[] cars = null;
		if(useAngle)
			cars = GetVisibleCars();
		else
			cars = GetAllCars();

		GameObject closestCar = null;

		float min = float.MaxValue;
		// Get the closest car
		foreach (GameObject car in cars)
		{
			Vector3 diff = this.transform.position - car.transform.position;
			float distance = diff.sqrMagnitude;
			if(distance <= 5f)
				continue;
			// Check if the current car is the closest
			if(distance < min)
			{
				min = distance;
				// Update the closest car
				closestCar = car;
			}
		}

		output = 0;

		// Only calculate the energy if there is a car to follow
		if (closestCar)
		{
			GameObject gameobject = closestCar.transform.GetChild(0).gameObject;
			if(gameobject.GetComponent<Renderer>())
				t_Material = gameobject.GetComponent<Renderer>().material;
			if(inverseEnergy)
				output = 1.0f - 1.0f / (min / r + 1);
			else
				output = 1.0f / (min / r + 1);
		}
	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	public virtual Material GetMaterial() { throw new NotImplementedException(); }

	// Returns all "CarToFollow" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// Returns all "CarToFollow" tagged objects that are within the view angle of the Sensor. 
	// Only considers the angle over the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] cars = GameObject.FindGameObjectsWithTag ("CarToFollow");

		foreach (GameObject car in cars)
		{
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle (forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleCars.Add (car);
			}
		}

		return (GameObject[]) visibleCars.ToArray(typeof(GameObject));
	}

}