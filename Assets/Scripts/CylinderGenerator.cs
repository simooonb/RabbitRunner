using UnityEngine;
using System.Collections.Generic;
using System;

public class CylinderGenerator : MonoBehaviour {

    public GameObject cylinder;

    PatternGenerator PG;
	float cylinderLength = 200f;
    int nPattern = 4;
    int nPatternInFirst = 2;

    void Awake()
    {
        PG = GetComponent<PatternGenerator>();
    }


    public GameObject newCylinder(Vector3 position, Quaternion rotation, bool firstCylinder = false)
    {
		GameObject newCylinder = Instantiate(cylinder, position, rotation) as GameObject;

        int n = firstCylinder ? nPatternInFirst : nPattern;

        for (int i = 0; i < n; i++)
        {
            GameObject pattern = PG.newPattern(0);

            float zDistance = -cylinderLength / 2;
            zDistance += i * PG.getPatternLength();
            zDistance += position.z;

            if (firstCylinder)
				zDistance += (nPattern - nPatternInFirst) * PG.getPatternLength();

            pattern.transform.Translate(zDistance * Vector3.forward);
            pattern.transform.parent = newCylinder.transform;
        }

        return newCylinder;
    }
}
