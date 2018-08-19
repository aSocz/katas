using System.Collections;
using System.Collections.Generic;

namespace Simplexer.Classes
{
    public abstract class Iterator<T> : IEnumerator<T>
    {
        public abstract bool MoveNext();

        public abstract T Current { get; }

        public void Reset() { }

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}