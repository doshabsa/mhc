using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v2
{
    public class FormManager
    {
        /* Since the token (and possibly map) selection is done in Form1
        I needed a way to hide/show that main menu form as needed but without
        eating up additionl resources due to loading a new form each time
            https://stackoverflow.com/questions/3005732/showing-a-hidden-form

        Player tokens, maps, and creature tokens accredited to 2minutetabletop
            https://www.patreon.com/2minutetabletop
            https://tools.2minutetabletop.com/token-editor/index?type=beast&sort=default&page=2
        
        Music by Adrian von Ziegler:
            (Day) Spring Charm - https://www.youtube.com/watch?v=YGkuJlEZy04
            (Night) Winter Breath - https://www.youtube.com/watch?v=3oSMuTvDHCM 

        SoundPlayer.Stream function idea started with: (but had to be tweaked)
            https://stackoverflow.com/questions/4125698/how-to-play-wav-audio-file-from-resources
        
         TO DO:
        - Fix/create a working panel/pictureboxes loop on Form1

        - gameMaps list does not fully purge if Form2 is closed but the game is not reset; results in same map (night) on reload. Works after that?
        - Add invisible barriers to specific maps (might not do, this project)
        - Add functionality to select the night-map version
        ++ is there a way to lay the day map over the night, then opacity transition between?

        - Add more creature spawns
        ++ Will need to edit the if statement for checking for creatures, since it no ravens are present it will error out
            (it is checking if there are ANY creatures, since at this time ravens are the only creature. They need to remain
            at the top layer with this statement, otherwise they will "fly" UNDER the player if the player picks up an item.)

        - Move all item spawning code into their respective classes
        --- Just need to establish removal of picked up items within the class rather than For2
        ++ in future, could an inherited class be used for spawn items?

        - Add inventory class to monitor/trigger item spawns and track picked up inventory
        +++ Is there a way to attach a string/tag variable ("stick", "stone") rather than an Arr[ID#] to add/remove items?

        ++ Add moving sticks and stones on map resize
        
        */

        public static Form1 MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new Form1();
                }
                return _mainMenu;
            }
        }
        private static Form1 _mainMenu;
    }
}
