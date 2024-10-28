using CustomerRankSystem.Core;
using CustomerRankSystem.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace CustomerRankSystem.Services
{
    public class CustomerService
    {
        private IMemoryCache MCache { get; set; }

        public CustomerService(IMemoryCache mCache)
        {
            MCache = mCache;
        }

        public Customer UpdateCustomerScore(Int64 customerid, int score)
        {
            var rankList = MCache.Get<List<Customer>>("RankList");
            if (rankList == null)
                rankList = new List<Customer>();

            var customer = rankList.FirstOrDefault(x => x.CustomerId == customerid);
            if (customer != null)
            {
                customer.Score = score;
            }
            else
            {
                rankList.Add(new Customer { CustomerId = customerid, Score = score });
            }

            rankList.Sort((l, r) =>
            {
                if (l.Score > r.Score || l.Score == r.Score && l.CustomerId < r.CustomerId)
                    return -1;
                return 1;
            });
            rankList = rankList.Select((c, index) => new Customer { CustomerId = c.CustomerId, Score = c.Score, Rank = index + 1 }).ToList();

            MCache.Set("RankList", rankList);

            var customerResult = rankList.FirstOrDefault(x => x.CustomerId == customerid);
            return customerResult;
        }

        public List<Customer> GetCustomersByRank(GetCustomersByRankReq args)
        {
            var rankList = MCache.Get<List<Customer>>("RankList");
            if (rankList == null)
                rankList = new List<Customer>();

            var result = rankList.Where(x => x.Rank >= args.Start && x.Rank <= args.End).ToList();
            return result;
        }

        public List<Customer> GetCustomersById(Int64 customerid, int high, int low)
        {
            var rankList = MCache.Get<List<Customer>>("RankList");
            if (rankList == null)
                rankList = new List<Customer>();

            var customer = rankList.FirstOrDefault(x => x.CustomerId == customerid);
            if (customer == null)
                throw new CustomException(EnumResultCode.Record_NotExists, $"No record with customerID {customerid} was found.");

            var startRank = customer.Rank - high;
            var endRank = customer.Rank + low;
            var result = rankList.Where(x => x.Rank >= startRank && x.Rank <= endRank).ToList();
            return result;
        }

        public void InitData()
        {
            var rankList = new List<Customer>()
            {
                new Customer{CustomerId = 15514665, Score= 124,Rank = 1 },
                new Customer{CustomerId = 81546541 , Score= 113,Rank = 2  },
                new Customer{CustomerId = 1745431  , Score=100 ,Rank = 3  },
                new Customer{CustomerId = 76786448 , Score= 100,Rank =  4 },
                new Customer{CustomerId = 254814111, Score= 96 ,Rank = 5  },
                new Customer{CustomerId = 53274324 , Score= 95 ,Rank =  6 },
                new Customer{CustomerId = 6144320  , Score=93  ,Rank =  7 },
                new Customer{CustomerId = 8009471  , Score=93  ,Rank =  8 },
                new Customer{CustomerId = 11028481 , Score= 93 ,Rank =   9},
                new Customer{CustomerId = 38819    , Score=92  ,Rank =  10},
            };
            MCache.Set("RankList", rankList);
        }
    }
}
