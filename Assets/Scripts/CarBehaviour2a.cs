using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void LateUpdate()
	{
		// YOUR CODE HERE
		float leftSensor = 0, rightSensor = 0;

		//Read sensor values
		if (DetectLights)
        {
			leftSensor = LeftLD.GetOutput();
			rightSensor = RightLD.GetOutput();
		}

		if (DetectCars)
        {
			leftSensor = LeftCD.GetOutput();
			if(m_Body.GetComponent<Renderer>())
				m_Body.GetComponent<Renderer>().material = LeftCD.GetMaterial();
			rightSensor = RightCD.GetOutput();

			// This is only to increase the difference between the 2 sensors
			// Because the car was to far away the difference is almost 0 and he doesn't follow the other cars
			if(leftSensor < rightSensor)
				rightSensor *= 1.2f;
			else
				leftSensor *= 1.2f;
		}
		

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
