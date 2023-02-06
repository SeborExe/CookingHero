using System;

public interface IHasProgress
{
    public event EventHandler<OnProgressChangeEventArgs> OnProgressChange;
    public class OnProgressChangeEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}
