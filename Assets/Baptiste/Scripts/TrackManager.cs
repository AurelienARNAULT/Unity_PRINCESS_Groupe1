using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public Track[] Tracks;
        public Player Player;

        private int _currentTrack;

        private void Start()
        {
          if (Player && Tracks.Length > 0)
          {
            Player.SpawnTo(Tracks[0].SpawnPoint.position);
          }
        }

        public void NextTrack()
        {
          _currentTrack = (_currentTrack + 1) % Tracks.Length;

          Player.SpawnTo(Tracks[_currentTrack].SpawnPoint.position);
        }
}
