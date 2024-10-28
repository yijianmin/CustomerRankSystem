namespace CustomerRankSystem.Dto
{
    public class GetCustomersByIdReq
    {
        public Int64 CustomerId { get; set; }

        public int High { get; set; }

        public int Low { get; set; }
    }
}
