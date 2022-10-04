using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IObserver
    {
        void OnNotify();
        void UpdateData();
    }

    public interface IObserver<T>
    {
        void OnNotify(T t);
        void UpdateData(T t);
    }
}
