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
		output = 1.0f/(stdDev * (float) Math.Sqrt(2*Math.PI)) * (float) Math.Exp(-0.5f*Math.Pow(output - mean, 2)/(float) Math.Pow(stdDev, 2));

		if(inverse)
			return 1.0f - Math.Max(output, min_y);
		return (float) Math.Max(output, min_y);
	}


}
