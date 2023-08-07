using Microsoft.EntityFrameworkCore;
using Models;




//dbcontext class
namespace SportClubProject.Repository
{
    public class SportsDbContext:DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options):base(options)
        { 

        }

      
        //sport dbset
        public DbSet<Sports> Sports { get; set; }


        //courts dbset
        public DbSet<Courts> Courts { get; set; }

        //slots dbset
        public DbSet<Slots> Slots { get; set; }

        public DbSet<Stadiums> Stadiums { get; set; }

        public DbSet<Cart> Carts { get; set; }


        //userdetails dbset
        public DbSet<UserDetails> UserDetails { get; set; }


        //payment dbset
        public DbSet<Payment> payments { get; set; }


        //bookingdetails dbset
        public DbSet<BookingDetails> BookingDetails { get; set; }

        //coupons dbset
        public DbSet<Coupons> Coupons { get; set; }

       

    }
}
