using System;
using UnityEngine.Localization;

namespace MLU.Commands
{
    [Serializable]
    public class Phrase
    {
        public Side Side;
        public LocalizedString LocalizedString;
    }
}