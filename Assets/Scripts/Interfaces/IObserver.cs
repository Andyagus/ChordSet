using System;

namespace Interfaces
{
    public interface IObserver
    {
        public void OnNotify(Object entity);
    }
}
