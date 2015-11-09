using System;

namespace Matrix
{
    public sealed class ElementModifiedEventArgs<T> : EventArgs
    {
        public int FirstIndex { get; }
        public int SecondIndex { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public ElementModifiedEventArgs(int i, int j, T oldValue, T newValue)
        {
            FirstIndex = i;
            SecondIndex = j;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}