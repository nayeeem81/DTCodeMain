using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationIdentityDbContext ( DbContextOptions options )
    : IdentityDbContext ( options )  
{
}
