using System;

namespace Counters
{
    public class Counter : ICounter
    {
        public event Action<int> OnCounterValueChanged;

        private int _number;
        
        public int Number
        {
            get => _number;
            set
            {
                _number = value >= 0 ? value : 0;
                OnCounterValueChanged?.Invoke(_number);
            }
        }
        
        public Counter(int number = 0)
        {
            _number = number;
        }
    }
}