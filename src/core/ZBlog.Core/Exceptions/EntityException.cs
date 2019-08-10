namespace ZBlog.Core.Exceptions
{
    public class RecordNotFoundException : ZBLogException
    {
        public RecordNotFoundException(string entityName, object value) : base(400, $"There is no record of this {value} in '{entityName}'")
        {

        }

        public RecordNotFoundException() : base(400, null)
        {

        }
    }
    public class ObjectAlreadyExistsException : ZBLogException
    {
        public ObjectAlreadyExistsException(string message) : base(400, message)
        {

        }
    }

}
