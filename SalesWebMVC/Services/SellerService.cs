using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAllSeller()
        {
            return _context.Seller.ToList();
        }

        public void InsertSeller(Seller seller)
        {
            if (seller == null)
                return;

            _context.Add(seller);
            _context.SaveChanges();
        }

    }
}
