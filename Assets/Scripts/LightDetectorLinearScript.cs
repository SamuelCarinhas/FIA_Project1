using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	
	public bool inverse = false; // If true, reverse the energy slope

	public override float GetOutput()
	{
		if(ApplyThresholds) {
			if(output < MinX)
				return MinY;
			if(output > MaxX)
				return MinY;
		}

		if(inverse)
			output = 1.0f - output;

		if(ApplyLimits) {
			output = (float) Math.Min(output, MaxY);
			output = (float) Math.Max(output, MinY);
		}
		
		return output;
	}

	// YOUR CODE HERE


}
