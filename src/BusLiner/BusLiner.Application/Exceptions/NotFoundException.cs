namespace BusLiner.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string name, object key) : base($"{name} ({key}) is not found") { }
        public NotFoundException(string name, object key, Exception inner) : base($"{name} ({key}) is not found", inner) { }
    }
}
