using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IObserverCharacter
    {
        void OnNotify(Character chara);
        void UpdateData<T>(T t);
    }
}
