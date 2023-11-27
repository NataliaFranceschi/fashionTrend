public class DraftContract : BaseEntity
{
    public Supplier User { get; set; }
    public string Description { get; set; }
    public bool Accepted { get; set; }
}