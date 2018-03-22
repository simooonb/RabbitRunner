using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public GameObject canvas;   
    public GameObject fireWork;

    float speed;
	float distance;
	float angularSpeed;
	float timeElapsed;
	float direction;
	float smoothing;
	float tempSpeed = 20f;
	bool dead = false;
	bool inCollision = false;
	bool stopped;
	ObstacleColor color = ObstacleColor.White;
	HUDManager hudManager;

	void Awake() {
		hudManager = canvas.GetComponent<HUDManager>();
	}

    // Use this for initialization
    void Start() {
		startRunning();
	}

	void Update() {
		if (!dead && !stopped && !hudManager.inTutorial()) {
			direction = Input.GetAxis ("Horizontal");
			timeElapsed += Time.deltaTime;
			speed += Time.deltaTime * smoothing;

			turn (direction);
			moveForward ();
		}
	}

	public void startRunning() {
		angularSpeed = 500f;
		speed = tempSpeed;
		timeElapsed = 0f;
		smoothing = 1.5f;
		stopped = false;
	}

	public void stopRunning() {
		angularSpeed = 0f;
		tempSpeed = speed;
		speed = 0f;
		stopped = true;
	}

	public bool isStopped() {
		return stopped;
	}

    void turn(float direction) {
		float angle = direction * angularSpeed * Time.deltaTime;
		transform.RotateAround(Vector3.zero, Vector3.forward, angle);
	}

	void moveForward()	{
		float tempdistance = speed * Time.deltaTime;
		transform.Translate (transform.forward * tempdistance);
		distance = transform.position.z;
	}

	public float getSpeed() {
		return speed;
	}

	public float getDistance() {
		return distance;
	}

	public ObstacleColor getColor()
    {
        return color;
    }

    public void setObstacleColor(ObstacleColor color)
    {
        this.color = color;
    }

	public void setColor(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.color = color;

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<LightController>().setColor(color);
        }

    }

	public void death() {
        ScoreList.add(distance);

       if (ScoreList.getList()[0] == distance)
            onNewHighScore();

       dead = true;
	}


    public void onNewHighScore() {
        emitFireWork();
    }

    public bool isDead() {
		return dead;
	}

	public bool isInCollision() {
		return inCollision;
	}

	public void setInCollision(bool coll) {
		inCollision = coll;
	}

	public HUDManager getHUDManager() {
		return hudManager;
	}

    public void emitFireWork()
    {
        GameObject fireWorkInstance = Instantiate(fireWork);
        fireWorkInstance.transform.parent = transform;
        fireWorkInstance.transform.position = (transform.position.z + 10) * Vector3.forward;
    }
}
