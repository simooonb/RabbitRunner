using UnityEngine;
using System.Collections;

public class PlaylistManager : MonoBehaviour {

    public string NameRandomMusic()
    {
        Object[] playlist = Resources.LoadAll("");
        int size = playlist.GetLength(0);
        int j = Random.Range(0, size);
        return playlist[j].name;
        
    }
}
