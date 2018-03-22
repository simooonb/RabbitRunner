using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject laser;
	public GameObject halfWall;
	public GameObject circleWall;
	public GameObject cylindarWall;
    public GameObject player;

	static float patternLength = 100f;

	static float zMin = -patternLength/2;

	float cylinderRadius = 5f;

	public GameObject generateLaser(Vector3 point1, Vector3 point2, Quaternion quaternion, ObstacleColor color, float angularSpeed = 0)
	{
		GameObject laserInstance;

        Vector3 center = (point2 + point1)/2;

        laserInstance = Instantiate(laser, center, quaternion) as GameObject;

        LaserObstacleController obstacleController = laserInstance.GetComponent<LaserObstacleController> ();

		obstacleController.player = player;
		obstacleController.setColor (color);
        obstacleController.setAngularSpeed(angularSpeed);

        LineRenderer renderer = laserInstance.GetComponent<LineRenderer> ();
		renderer.SetPosition(0, new Vector3(-1, 0, 0));
		renderer.SetPosition(1, new Vector3(1, 0, 0));

		return laserInstance;
	}

	public GameObject generateVerticalLaser(float z, ObstacleColor color, float angularSpeed = 0)
	{
        return generateRopeLaser(z, 1, 90, color, angularSpeed);
    }

	public GameObject generateHorizontalLaser(float z, ObstacleColor color, float angularSpeed = 0)
	{
		return generateRopeLaser (z, 1, 0, color, angularSpeed);
	}

    public GameObject generateRopeLaser(float z, float distanceToWall, float angle, ObstacleColor color, float angularSpeed = 0)
    {   
		
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Vector3 leftPoint = rotation * new Vector3(-cylinderRadius, (1 - distanceToWall) * cylinderRadius, getPatternZ(z));
		Vector3 rightPoint = rotation * new Vector3(+cylinderRadius, (1 - distanceToWall) * cylinderRadius, getPatternZ(z));


        return generateLaser(leftPoint, rightPoint, rotation, color, angularSpeed);
    }

    public GameObject generateHalfWall (float z, float distanceToWall, float height, float angle, ObstacleColor color, float angularSpeed = 0)
    {
        GameObject halfWallInstance = Instantiate(halfWall) as GameObject;

        halfWallInstance.transform.localScale = new Vector3(halfWallInstance.transform.localScale.x, halfWallInstance.transform.localScale.y * height, halfWallInstance.transform.localScale.z);
		halfWallInstance.transform.Translate(Vector3.down * (1f - distanceToWall) * cylinderRadius);
		halfWallInstance.transform.position = new Vector3 (halfWallInstance.transform.position.x, halfWallInstance.transform.position.y, getPatternZ(z));
        halfWallInstance.transform.RotateAround(Vector3.zero, Vector3.forward, angle);
        

        SolidObstacleController obstacleController = halfWallInstance.GetComponent<SolidObstacleController>();

        obstacleController.player = player;
        obstacleController.setColor(color);
        obstacleController.setAngularSpeed(angularSpeed);

        return halfWallInstance;
    }

	public GameObject generateCircleWall (float z, float distanceToWall, float radius, float angle, ObstacleColor color, float angularSpeed = 0)
	{
		GameObject circleWallInstance = Instantiate(circleWall) as GameObject;

		circleWallInstance.transform.localScale = new Vector3(circleWallInstance.transform.localScale.x * radius, circleWallInstance.transform.localScale.y, circleWallInstance.transform.localScale.z * radius);
		circleWallInstance.transform.Translate(Vector3.down * (1.5f - distanceToWall) * cylinderRadius);
		circleWallInstance.transform.position = new Vector3 (circleWallInstance.transform.position.x, circleWallInstance.transform.position.y, getPatternZ(z));
		circleWallInstance.transform.RotateAround(Vector3.zero, Vector3.forward, angle);

		SolidObstacleController obstacleController = circleWallInstance.GetComponent<SolidObstacleController>();

		obstacleController.player = player;
		obstacleController.setColor(color);
		obstacleController.setAngularSpeed(angularSpeed);

        return circleWallInstance;
	}

	public GameObject generateCylinderWall (float z, ObstacleColor color)
	{
		GameObject cylinderWallInstance  = Instantiate(cylindarWall) as GameObject;

		cylinderWallInstance.transform.position = new Vector3 (cylinderWallInstance.transform.position.x, cylinderWallInstance.transform.position.y, getPatternZ(z));

		SolidObstacleController obstacleController = cylinderWallInstance.GetComponent<SolidObstacleController>();

		obstacleController.player = player;
		obstacleController.setColor(color);

        return cylinderWallInstance;
	}

	float getPatternZ(float z)
	{
		return zMin + patternLength * z;
	}
}
