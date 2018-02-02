using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Data
{
    public enum InvalidReason
    {
        FileNotFound,
        HotkeyInUse
    }

    public enum ActionType
    {
        Sound,
        Option
    }

    /// <summary>
    /// Used to store invalid hotkey actions
    /// </summary>
    class InvalidAction
    {
        public string Filename { get; private set; }
        public string Nickname { get; private set; }
        public Hotkey Hotkey { get; private set; }

        public InvalidReason InvalidReason { get; private set; }
        public ActionType ActionType{ get; private set; }
        public string DisplayName 
        {
            get { return string.IsNullOrWhiteSpace(Nickname) ? Filename : Nickname; }
        }

        /// <summary>
        /// Construct based on a invalid sound.
        /// </summary>
        public InvalidAction(SoundInvalidException ex)
        {
            Filename = ex.Filename;
            Nickname = ex.Nickname;
            Hotkey = ex.Hotkey;
            InvalidReason = ex.InvalidReason;
            ActionType = ActionType.Sound;
        }
    }
}
