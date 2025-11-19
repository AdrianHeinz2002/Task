namespace Task.Shopping.Domain.Exceptions
{
    [Serializable]
    public class TooMuchWeightException : Exception
    {
        public TooMuchWeightException()
        { }

        public TooMuchWeightException(string message)
            : base(message)
        { }

    }
}
