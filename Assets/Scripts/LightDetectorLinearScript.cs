using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	
	public bool inverse = false; // If true, reverse the energy slope

	public override float GetOutput()
	{
		if(inverse)
			return 1.0f - output;
		return output;
	}

	// YOUR CODE HERE


}
