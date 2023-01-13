using System;

namespace Variables
{
    [Serializable]
    public class IntReference : ReferenceBase<int, IntVariable>
    {
        public IntReference() { }

        public IntReference(int value)
        {
            _useConstant = true;
            _constantValue = value;
        } 
        
        public static implicit operator int(IntReference reference)
        {
            return reference.GetValue();
        }
    }
}