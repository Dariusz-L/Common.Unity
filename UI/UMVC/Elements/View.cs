using Common.Basic.UMVC.Elements;
using Common.Unity.GameObjects;
using System.Linq;
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

        public T GetParent<T>() where T : IView => this.GetComponentInParentButNotThis<T>();
        public T GetParentTopMost<T>() where T : IView => this.GetComponentsInParentButNotThis<T>().Last();

        public IView GetParent() => transform.parent.GetOrAddComponent<View>();

        public virtual void FitToChildren() {}

        T[] IView.GetChildren<T>() => this.GetChildren<T>().ToArray();
    }
}
