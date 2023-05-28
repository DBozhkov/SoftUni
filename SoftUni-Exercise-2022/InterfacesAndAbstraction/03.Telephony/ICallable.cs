using System.Collections;
using System.Collections.Generic;

namespace _03.Telephony
{
    public interface ICallable
    {
        IEnumerable Numbers { get; }
        void Call();
    }
}
