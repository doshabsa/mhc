using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Resources;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    public class Audio
    {
        private const int NUMTRACKS = 4;   //Change for however many game audio tracks there are 
        private SoundPlayer _MusicPlayer = new SoundPlayer();   //The player that will be used to play all tracks

        private static List<Stream> _TrackList = new List<Stream>(NUMTRACKS);   //The list of all tracks
        private static Form gameForm;  //Holds the information from the Form calling in a bird

        public Audio(Form callform)  //Enters each song into tracklist
        {
            gameForm = callform;
            ResourceManager rm = Resource1.ResourceManager;
            for (int i = 0; i < NUMTRACKS; i++)
                _TrackList.Add((Stream)rm.GetObject("audio_" + i));
        }

        public void PlayMusic(int request)
        {
            _MusicPlayer.Stop();                         //After tinkering with this over four days:
            _TrackList[request].Position = 0;            //https://tenor.com/view/code-works-code-not-working-error-scaler-create-impact-gif-24991578
            _MusicPlayer.Stream = null;                  //something to do with the .Stop() though. How magical!
            _MusicPlayer.Stream = _TrackList[request];   //Reference to the starting point for the audio is in FormManager.cs
            _MusicPlayer.Play();
        }

        public void StopMusic()
        {
            _MusicPlayer.Stop();
        }
    }
}
