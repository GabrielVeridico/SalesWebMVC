using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SalesWebMVC.Services.Exceptions;

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

        public Seller FindById(int id)
        {
            // Same thing as an include
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void InsertSeller(Seller seller)
        {
            if (seller == null)
                return;

            _context.Add(seller);
            _context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var obj = _context.Seller.Find(id);

            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void UpdateSeller(Seller seller)
        {
            if(!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Seller not found.");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
            
        }

    }
}
