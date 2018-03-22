using UnityEngine;
using System.Collections.Generic;

public class PatternGenerator : MonoBehaviour {

    ObstacleGenerator obstacleGenerator;
    static float cylinderRadius = 5f;
	static float patternLength = 100f;

    static List<Pattern> patternList;

    static int lastPatternIndex;

    static PatternGenerator()
    {
        patternList = new List<Pattern>();

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {

            List<GameObject> patternObstacles = new List<GameObject> {
				OG.generateVerticalLaser (0.25f,  randomColorList[0], 35f),
				OG.generateHorizontalLaser (0.25f,  randomColorList[1], -35f),
				OG.generateRopeLaser(0.75f, 0.4f, 90,  randomColorList[2]),
				OG.generateRopeLaser(0.75f, 0.4f, -90,  randomColorList[2]),
                OG.generateHalfWall(0.75f, 0.35f, 0.5f,  0, ObstacleColor.White)
            };
				
			return patternObstacles;
        });
		/*
		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject> {
				OG.generateHalfWall(0.4f, 0.5f, 0.25f, 35f, ObstacleColor.White),
				OG.generateRopeLaser(0.5f, 0.1f, 15f, randomColorList[0]),
				OG.generateRopeLaser(0.5f, 0.2f, 15f, randomColorList[0]),
				OG.generateRopeLaser(0.5f, 0.3f, 15f, randomColorList[0]),
				OG.generateRopeLaser(0.5f, 0.4f, 15f, randomColorList[0]),
				OG.generateRopeLaser(0.5f, 0.5f, 15f, randomColorList[0]),
				OG.generateHalfWall(0.6f, 0.5f, 0.25f, 35f, ObstacleColor.White)
			};

			return patternObstacles;
		});
		*/

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			for (float i = 1; i <= 5; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.25f, 0.1f * i, 0f, randomColorList [0], 0));
				patternObstacles.Add(OG.generateRopeLaser(0.25f, 0.1f * i, 180f, randomColorList [1], 0));

				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f * i, 0f, randomColorList [2], 5));
				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f * i, 180f, randomColorList [1], 5));


				patternObstacles.Add(OG.generateRopeLaser(0.75f, 0.1f * i, 0f, randomColorList [0], 10));
				patternObstacles.Add(OG.generateRopeLaser(0.75f, 0.1f * i, 180f, randomColorList [2], 10));

				patternObstacles.Add(OG.generateRopeLaser(1f, 0.1f * i, 0f, randomColorList [1], 20));
				patternObstacles.Add(OG.generateRopeLaser(1f, 0.1f * i, 180f, randomColorList [0], 20));
			}


			return patternObstacles;

		});


		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			for (float i = 0 ; i < 20 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.25f + (0.75f) * i/20, 1f, 10f*i, randomColorList[0]));
			}

			return patternObstacles;

		});

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			for (float i = 0 ; i < 20 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.25f + (0.75f) * i/20, 1f, -10f*i, randomColorList[0]));
			}

			return patternObstacles;

		});

		patternList.Add (delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject> ();

			for (float i = 0 ; i < 6 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.25f + (0.75f) * i/5, 1f, 36f * i, randomColorList[0], 20f*((-1)^(int) i)));
			}
				
			return patternObstacles;
		});



		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			patternObstacles.Add(OG.generateHalfWall(0.5f, 0.4f, 2f, 35f, ObstacleColor.White, 45f));

			for (float i = 1; i <= 10; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f * i, 0f, randomColorList [0]));
			}

			patternObstacles.Add(OG.generateRopeLaser(1f, 0.4f, 90,  randomColorList[1]));
			patternObstacles.Add(OG.generateRopeLaser(1f, 0.4f, -90,  randomColorList[1]));
			patternObstacles.Add(OG.generateRopeLaser(1f, 0.4f, 90,  randomColorList[2], 45));
			patternObstacles.Add(OG.generateRopeLaser(1f, 0.4f, -90,  randomColorList[2], 45));

			return patternObstacles;
		});

		patternList.Add(delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			patternObstacles.Add(OG.generateRopeLaser(0.25f, 0.8f, 0f, randomColorList[1], 35f));
			patternObstacles.Add(OG.generateRopeLaser(0.25f, 0.8f, 0f, randomColorList[1], -35f));
			patternObstacles.Add(OG.generateCircleWall(0.5f, 1f, 0.7f, 55, ObstacleColor.White, 25f));
			patternObstacles.Add(OG.generateCircleWall(0.5f, 1f, 0.7f, 55 + 180, ObstacleColor.White, 25f));
			patternObstacles.Add(OG.generateRopeLaser(0.75f, 0.8f, 0f, randomColorList[0], 35f));
			patternObstacles.Add(OG.generateRopeLaser(0.75f, 0.8f, 90f, randomColorList[0], -35f));

			return patternObstacles;
		});

		patternList.Add (delegate (ObstacleGenerator OG, List<ObstacleColor> randomColorList) {
			List<GameObject> patternObstacles = new List<GameObject>();

			for (float i = 0 ; i <= 6 ; i++) {
				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f*i, 0f, randomColorList[0], 15f));
				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f*(i+7), 0f, randomColorList[1], 15f));
				patternObstacles.Add(OG.generateRopeLaser(0.5f, 0.1f*(i+14), 0f, randomColorList[2], 15f));
			}

			patternObstacles.Add(OG.generateCylinderWall(1, randomColorList[0]));

			return patternObstacles;
		});
	}

    void Awake()
    {
        obstacleGenerator = GetComponent<ObstacleGenerator>();
    }

	public GameObject newPattern(int difficulty)
    {
        int i;

        do
            i = Random.Range(0, patternList.Count);
        while (i == lastPatternIndex);
            
        lastPatternIndex = i;

		List<GameObject> patternObstacles = patternList[i](obstacleGenerator, getRandomObstacleList());

		GameObject pattern = new GameObject ();

		foreach (GameObject obstacle in patternObstacles) {
			obstacle.transform.SetParent (pattern.transform);
		}
			
        pattern.transform.Rotate(Vector3.forward, Random.Range(0, 360));
        return pattern;
    }

	public List<ObstacleColor> getRandomObstacleList()
	{
		ObstacleColor[] randomObstacleArray = (ObstacleColor[]) System.Enum.GetValues (typeof(ObstacleColor));
		List<ObstacleColor> randomObstacleList = new List<ObstacleColor> (randomObstacleArray);

		randomObstacleList.Remove (ObstacleColor.White);

		randomObstacleList.Sort ((a, b) => 1 - 2 * Random.Range (0, 2));

		return randomObstacleList;
	}

	public float getPatternLength()
	{
		return patternLength;
	}

}
