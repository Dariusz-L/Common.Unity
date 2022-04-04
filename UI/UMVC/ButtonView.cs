using Common.Basic.UMVC.Elements;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Unity.UI.UMCV
{
    public class ButtonView : View, IButtonView
    {
        [SerializeField] private Button _button;

        public Action OnUp { set => _button.RemoveAllAndAddListener(value); }
        public bool Interactable { set => _button.interactable = value; }
    }
}
