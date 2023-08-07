using Models;
using SportClubProject.Repository;

namespace SportClubProject.Services
{
    public class UserService
    {

        private SportsDbContext sportsDbContext;

        public UserService()
        {
        }

        public UserService(SportsDbContext sportsDbContext)
        {
            this.sportsDbContext = sportsDbContext;
        }



        //getting courts from sports dbcontext
        //getting courts from sports dbcontext

        public List<Courts> GetCourts(string sportname, string date)
        {
            /*List<Courts> resultCourts = new List<Courts>();
            var res = sportsDbContext.Sports.Where(e => e.SportName.Equals(sportname)).Select(e => e.Courts).ToList();
            foreach (var coupon in res)
            {
                foreach (var val in coupon)
                {
                    Courts court = new Courts
                    {
                        CourtId=val.CourtId,
                        CourtImageUrl=val.CourtImageUrl,
                        CourtsName = val.CourtsName,
                        CourtPrice = val.CourtPrice
                    };
                    resultCourts.Add(court);
                }
            }

            List<string> courtlist = sportsDbContext.BookingDetails.Where(e => e.SportName.Equals(sportname) && e.Bookingdate.Equals(date)).Select(e => e.CourtName).ToList();

            if (courtlist.Count == 0)
            {
                return resultCourts;
            }
            else
            {
                foreach (var court in resultCourts)
                {
                    int count = courtlist.Count(cout => cout.Equals(court.CourtsName));
                    if (count < 4)
                    {
                        courtlist.Add(court.CourtsName);
                    }
                }
            }

            return resultCourts;*/
            List<Courts> courts = new List<Courts>();
            List<string> totalcourts = new List<string>();
            List<Courts> resultcourts = new List<Courts>();
            var res = sportsDbContext.Sports.Where(e => e.SportName.Equals(sportname)).Select(e => e.Courts).ToList();
            foreach (var coupon in res)
            {
                foreach (var val in coupon)
                {
                    courts.Add(val);
                }
            }
            List<string> courtlist = sportsDbContext.BookingDetails.Where(e => e.SportName.Equals(sportname) && e.Bookingdate.Equals(date)).Select(e => e.CourtName).ToList();
            if (courtlist.Count == 0)
            {

                return courts;
            }
            else
            {
                foreach(var court in courts)
                {
                    int count = 0;
                    foreach(string courtname in courtlist)
                    {
                        if(court.CourtName.Equals(courtname)) {  
                            count++;
                        }
                    }
                    if (count < 4)
                    {
                        resultcourts.Add(court);

                    }
                }
            }
            return resultcourts;

       
    }




        //get all slots from db context

        public List<string> GetSlots(string sportname, string date, string courtname)
        {
            List<string> totalslots = sportsDbContext.Slots.Select(e => e.SlotTime).ToList();
            List<string> bookedslots = sportsDbContext.BookingDetails.Where(e => e.SportName.Equals(sportname) && e.Bookingdate.Equals(date)
                                       && e.CourtName.Equals(courtname)).Select(e => e.SlotTime).ToList();
            foreach (string slot in bookedslots)
            {
                if (totalslots.Contains(slot))
                {
                    totalslots.Remove(slot);
                }
            }
            return totalslots;
        }



        //checking mobile number present or not
        public bool ValidateMobileNumber(long mobileNumber)
        {

            bool isMobileNumberExist= sportsDbContext.UserDetails.Any(user => user.UserMobile == mobileNumber);
            return isMobileNumberExist;
        }


        public List<Cart> GetAllCarts(int userId)
        {
            return sportsDbContext.Carts.Where(id => id.UserId == userId).ToList();
        }

        public string SaveCart(Cart carts)
        {
            sportsDbContext.Carts.Add(carts);
            sportsDbContext.SaveChanges();
            return "saved";
        }

        public void Savedetails(UserDetails userDetails)
        {
            sportsDbContext.UserDetails.Add(userDetails);
            sportsDbContext.SaveChanges();
        }
    }
}
