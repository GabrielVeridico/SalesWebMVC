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

        public async Task<List<Seller>> FindAllSellerAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            // Same thing as an include
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertSellerAsync(Seller seller)
        {
            if (seller == null)
                return;

            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);

            _context.Seller.Remove(obj);
            await  _context.SaveChangesAsync();
        }

        public async Task UpdateSellerAsync(Seller seller)
        {
            var hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Seller not found.");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
            
        }

    }
}
