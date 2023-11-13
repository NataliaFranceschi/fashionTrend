public class ServiceOrderRepository : BaseRepository<ServiceOrder>, IServiceOrderRepository
{
    public ServiceOrderRepository(AppDbContext context) : base(context)
    {
    }
}
