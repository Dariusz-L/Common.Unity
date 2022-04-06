using Common.Basic.UMVC.Elements;
using Common.Unity.GameObjects;
using UnityEngine;

namespace Common.Unity.UI.UMCV
{
    public class View : MonoBehaviour, IView
    {
        public string ID { get; set; }

        public virtual void Hide() => gameObject.SetActive(false);
        public virtual void Show() => gameObject.SetActive(true);

        public virtual bool IsVisible => gameObject.activeSelf;

        public IView AsParent() => gameObject.GetOrAddComponent<View>();

        T IView.GetParent<T>() => this.GetComponentInParentExceptThis<T>();

        IView IView.GetParent() => transform.parent.GetOrAddComponent<View>();
    }
}
