using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class HUDManager : MonoBehaviour {

	public Text speedTextPrefab;
	public Text distanceTextPrefab;
	public Text instructionsTextPrefab;
	public GameObject player;
	public Image imagePrefab;
	public Text highscoreNotificationPrefab;

	bool tutorial = true, highscoreNotificationCreated = false;
	Text instructions, distance, speed;
	PlayerController playerController;
	Image image;
	FileInfo[] fileInfo;

	void Awake() {
		playerController = player.GetComponent<PlayerController>();
	}

	// Use this for initialization
	void Start() {
		fileInfo = (new DirectoryInfo(Application.dataPath + "/Resources")).GetFiles("*.*", SearchOption.TopDirectoryOnly);
		image = Instantiate (imagePrefab, new Vector3 (Screen.width / 2, Screen.height / 2, 0), Quaternion.identity) as Image;
		image.color = new Color32 (200, 200, 200, 175);
		image.transform.SetParent (transform);
		instructions = Instantiate(instructionsTextPrefab, new Vector3(Screen.width/2, Screen.height/2, 0), Quaternion.identity) as Text;
		instructions.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update() {
		if (ScoreList.getList().Count > 0) {
			if (ScoreList.getList()[0] < playerController.transform.position.z && !highscoreNotificationCreated) {
				highscoreNotificationCreated = true;
				instantiateHighscoreNotification();
			}
		} else {
			instantiateHighscoreNotification();
		}

		// if enter key or button 0 pressed, and in tutorial, launch game 
		if ((Input.GetKeyDown ("joystick button 0") || Input.GetKeyDown (KeyCode.Return)) && tutorial) { 
			tutorial = false;
			Destroy(instructions);
			Destroy(image);
			displayInformations ();
			MusicManager.play(getRandomMusic(),0.5f,0.5f);
		} else if (!tutorial) {
			speed.text = "Speed: " + Mathf.Round(playerController.getSpeed() * 10f) / 10f + " km/h";
			distance.text = "Distance: " + Mathf.Round(playerController.getDistance() * 10f) / 10f + " m";
		}
	}

	void displayInformations() {
		distance = Instantiate(distanceTextPrefab, new Vector3(10, Screen.height-10, 0), Quaternion.identity) as Text;
		distance.transform.SetParent(transform);
		speed = Instantiate(speedTextPrefab, new Vector3(10, Screen.height-30, 0), Quaternion.identity) as Text;
		speed.transform.SetParent(transform);
	}

	public bool inTutorial() {
		return tutorial;
	}

	public Text instantiateHighscoreNotification() {
		Text text = Instantiate(highscoreNotificationPrefab, new Vector3(10, Screen.height - 50, 0), Quaternion.identity) as Text;
		text.transform.SetParent(transform);
		return text;
	}

	string getRandomMusic() {
		List<FileInfo> playlist = new List<FileInfo>();
		foreach (FileInfo file in fileInfo) {
			if (".mp3".Equals(file.Extension) || ".wav".Equals(file.Extension)) {
				playlist.Add(file);
			}
		}
		int songIndex = Random.Range(0, playlist.Count);
		FileInfo song = playlist[songIndex];
		return song.Name.Remove(song.Name.IndexOf(song.Extension), song.Extension.Length);
	}
}
