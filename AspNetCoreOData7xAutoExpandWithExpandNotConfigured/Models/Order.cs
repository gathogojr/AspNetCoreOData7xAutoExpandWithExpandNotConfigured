using Microsoft.AspNet.OData.Builder;

namespace AspNetCoreOData7xAutoExpandWithExpandNotConfigured.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [AutoExpand]
        public Customer Customer { get; set; }
    }
}
