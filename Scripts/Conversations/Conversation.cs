﻿using System.Collections.Generic;
using UnityEngine;

namespace MLU.Commands
{
    [CreateAssetMenu(fileName = "Conversation", menuName = "", order = 1)]
    public class Conversation : ScriptableObject
    {
        public Sprite LeftSprite;
        public Sprite RightSprite;

        public List<Phrase> Phrases;
    }
}