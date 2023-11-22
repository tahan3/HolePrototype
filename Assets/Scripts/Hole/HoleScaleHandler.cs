using UnityEngine;

namespace Hole
{
    public class HoleScaleHandler
    {
        private float _scaleFactor;

        private int _prevNumber;
        private int _diffToScale;

        private Transform _scaleTarget;

        public HoleScaleHandler(float scaleFactor, int scaleDiff, Transform scaleTarget)
        {
            _scaleFactor = scaleFactor;
            _diffToScale = scaleDiff;
            _scaleTarget = scaleTarget;
        }

        public void ScaleUp(int number)
        {
            if (TryToScale(number))
            {
                _prevNumber = number;
                _scaleTarget.localScale *= _scaleFactor;
            }
        }
        
        private bool TryToScale(int number)
        {
            return number - _prevNumber >= _diffToScale;
        }
    }
}