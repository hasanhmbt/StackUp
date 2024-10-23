namespace StackUp.Domain.Entities.Common
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
