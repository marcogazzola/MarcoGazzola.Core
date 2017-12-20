namespace MarcoGazzola.Identity.Interface
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; set; }
    }
}