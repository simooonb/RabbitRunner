using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CylinderManager : MonoBehaviour {

	public Transform playerTransform;
    public CylinderGenerator CG;
	public TextMesh positionTextPrefab;

    int cylinderLength = 400;
	int shift = 100;
	int textMeshOffset = 15;
	Transform currentCylinder;
	Transform frontCylinder;
	TextMesh first, second, third, fourth, fifth;
	List<float> offsets = new List<float>();

	// Use this for initialization
	void Start () {
		int count = (ScoreList.getList().Count >= 5 ? 5 : ScoreList.getList().Count);
		for (int i = 0; i < count; i++) {
			offsets.Add(ScoreList.getList()[i]);
		}

		currentCylinder = CG.newCylinder(new Vector3(0, 0, 0), Quaternion.identity, true).transform;
		frontCylinder = CG.newCylinder(new Vector3(0, 0, cylinderLength), Quaternion.identity).transform;

		TextMesh textMesh;
		for (int i = 0; i < offsets.Count; i++) {
			textMesh = Instantiate(positionTextPrefab, new Vector3(0, 0, offsets[i]), Quaternion.identity) as TextMesh;
			switch (i) {
				case 4:
					textMesh.text = "5th";
					break;
				case 3:
					textMesh.text = "4th";
					break;
				case 2:
					textMesh.text = "3rd";
					break;
				case 1:
					textMesh.text = "2nd";
					break;
				case 0:
					textMesh.text = "1st";
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerAfterCurrentCylinder()) {
			Destroy(currentCylinder.gameObject);
			currentCylinder = frontCylinder;
            frontCylinder = CG.newCylinder(
                new Vector3(0, 0, cylinderLength + currentCylinder.transform.position.z), 
                Quaternion.identity
            ).transform;
		}
	}

	bool isPlayerAfterCurrentCylinder() {
		return playerTransform.position.z > currentCylinder.transform.position.z + cylinderLength / 2 + shift;
	}
}
