namespace ZBlog.Core.Kernel
{
    public interface IEntity<out TPrimaryKey>
    {
        TPrimaryKey Id { get; }
    }
}
