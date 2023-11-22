using System;

namespace Counters
{
    public interface ICounter
    {
        public event Action<int> OnCounterValueChanged;
        public int Number { get; set; }
    }
}