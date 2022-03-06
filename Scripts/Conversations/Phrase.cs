using System;
using UnityEngine.Localization;

namespace Common.Unity.Scripts.Conversations
{
    [Serializable]
    public class Phrase
    {
        public Side Side;
        public LocalizedString LocalizedString;
    }
}