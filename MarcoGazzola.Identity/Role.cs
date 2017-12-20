using MarcoGazzola.Identity.Interface;

namespace MarcoGazzola.Identity
{
    public class Role:IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}