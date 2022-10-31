using Films.Core.Entities;

namespace Films.Entities.Concreate
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
