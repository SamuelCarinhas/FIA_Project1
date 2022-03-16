using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorGaussScript : LightDetectorScript {

	public float stdDev = 1.0f;
	public float mean = 0.0f;
	public float min_y;
	public bool inverse = false;
	// Get gaussian output value
	public override float GetOutput()
	{
		if(ApplyThresholds) {
			if(output < MinX)
				return MinY;
			if(output > MaxX)
				return MinY;
		}

		output = 1.0f/(stdDev * (float) Math.Sqrt(2*Math.PI)) * (float) Math.Exp(-0.5f*Math.Pow(output - mean, 2)/(float) Math.Pow(stdDev, 2));

		float mx = 1.0f/(stdDev * (float) Math.Sqrt(2*Math.PI)) * (float) Math.Exp(-0.5f*Math.Pow(0, 2)/(float) Math.Pow(stdDev, 2));

		// output /= mx;

		// output = (stdDev/Mathf.Sqrt(2*Mathf.PI)) * Mathf.Exp(-Mathf.Pow(output-mean, 2) / (2*Mathf.Pow(stdDev, 2)));

		if(inverse)
			output =  mx - output;


		if(ApplyLimits) {
			output = (float) Math.Min(output, MaxY);
			output = (float) Math.Max(output, MinY);
		}

		return (float) Math.Max(output, min_y);
	}


}
