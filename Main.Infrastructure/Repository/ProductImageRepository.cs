using Microsoft.EntityFrameworkCore;
using Main.Common.Enums;
using Entity.Model;
using Data;
using IRepository;

namespace Repository;

public class ProductImageRepository : IProductImageRepository
{
    private readonly BussinessAppDbContext _context;

    public ProductImageRepository( BussinessAppDbContext context )
    {
        _context = context;
    }

    public async Task<List<Product>> GetSelectProducts(EnumCompanyName company) 
    {
            
        List<Product> list = await _context.Products
                                    .Where( a => a.HostCompanyName == company)
                                    .ToListAsync();
            
        return list;

    }
}

 