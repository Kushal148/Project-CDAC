using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseLib;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace Testdal
{
    public class DalImp:DalInter
    {
        TourismWebsiteDBEntities dbcon;
        public DalImp()
        {
            dbcon = new TourismWebsiteDBEntities();
        }
        public bool CreateBlog(BlogSpace UserBlog)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.BlogSpaces.Add(UserBlog);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }

            dbcon.Dispose();
            return status;
        }

        public bool CreateUser(User obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Users.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool DeleteBlog(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.BlogSpaces.Find(id);
                dbcon.BlogSpaces.Remove(Todel);
                int change = dbcon.SaveChanges();
                dbcon.Dispose();
                if (change > 0)
                    status = true;
            }
            return status;

        }

        public Hotel DeleteHotel(int id)
        {
            //bool status = false;
            Hotel hotel = new Hotel();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                hotel = dbcon.Hotels.Find(id);
                dbcon.Hotels.Remove(hotel);
                int change = dbcon.SaveChanges();
                dbcon.Dispose();
               
                   
            }
            return hotel;
        }

        public bool DeleteLocation(int id)
        {
            bool status = false;
            var Todel = dbcon.Locations.Find(id);
            dbcon.Locations.Remove(Todel);
            int change = dbcon.SaveChanges();
            dbcon.Dispose();
            if (change > 0)
                status = true;
            return status;
        }

        public bool DeletePlace(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.TouristPlaces.Find(id);
                dbcon.TouristPlaces.Remove(Todel);
                int change = dbcon.SaveChanges();

                if (change > 0)
                    status = true;
            }
            dbcon.Dispose();
            return status;
        }

        public bool DeleteReview(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.UserReviews.Find(id);
                dbcon.UserReviews.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }
            dbcon.Dispose();
            return status;
        }

        public bool DeleteUser(int id)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var Todel = dbcon.Users.Find(id);
                dbcon.Users.Remove(Todel);
                int change = dbcon.SaveChanges();
                if (change > 0)
                    status = true;
            }
            dbcon.Dispose();
            return status;
        }

        public List<BlogSpace> GetAllBlogs()
        {
            List<BlogSpace> Bloglist = new List<BlogSpace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                Bloglist = dbcon.BlogSpaces.ToList();

            }
            dbcon.Dispose();
            return Bloglist;
        }

        public List<Hotel> GetAllHotel()
        {

            List<Hotel> Hotellist = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                Hotellist = dbcon.Hotels.ToList();

            }
            dbcon.Dispose();
            return Hotellist;
        }

        public List<Location> GetAllLocations()
        {
            List<Location> LocList = new List<Location>();
            using (dbcon = new TourismWebsiteDBEntities())
            {

                LocList = dbcon.Locations.ToList();



            }
            dbcon.Dispose();
            return LocList;
        }

        public List<TouristPlace> GetAllPlace()
        {
            List<TouristPlace> TPlaceList = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                TPlaceList = dbcon.TouristPlaces.ToList();

            }
            dbcon.Dispose();
            return TPlaceList;
        }

        public List<User> GetAllUsers()
        {
            List<User> UserList = new List<User>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                UserList = dbcon.Users.ToList();

            }
            dbcon.Dispose();
            return UserList;
        }

        public List<BlogSpace> GetBlogs(string title)
        {
            List<BlogSpace> BlogList = new List<BlogSpace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                BlogList = dbcon.BlogSpaces.Where(x => x.Title == title).ToList();


            }
            dbcon.Dispose();
            return BlogList;
        }

        public List<BlogSpace> GetBlogsByLocation(string location)
        {
            List<BlogSpace> BlogList = new List<BlogSpace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                BlogList = dbcon.BlogSpaces.Where(x => (string)x.LocationName == location).ToList();

            }
            dbcon.Dispose();
            return BlogList;
        }


        /*        public List<double> GetCoordinates(string location)
                {
                    List<double> coords = new List<double>();
                    using (dbcon = new TourismWebsiteDBEntities())
                    {
                        var req = dbcon.Locations.Where(x => x.LocationName == location).FirstOrDefault();
                        coords.Add(req.Latitude);
                        coords.Add(req.Longitude);

                    }
                    return coords;
                }

        */
        public Location GetCoordinates(string location)
        {
            Location coords = new Location();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                coords = dbcon.Locations.Where(x => x.LocationName == location).FirstOrDefault();


            }
            dbcon.Dispose();
            return coords;
        }

        public Hotel GetHotelPrice(int id)
        {
            Hotel HotelPrice = null;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelPrice = (Hotel)dbcon.Hotels.Where(x => x.Id == id).First();

            }
            dbcon.Dispose();
            return HotelPrice;

        }

        public List<Hotel> GetHotelsByLocation(int Locationid)
        {
            List<Hotel> HotelList = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelList = dbcon.Hotels.Where(x => (int)x.LocationId == Locationid).ToList();

            }
            dbcon.Dispose();
            return HotelList;
        }

        public List<Hotel> GetHotelsByName(string Name)
        {
            List<Hotel> HotelsListByName = new List<Hotel>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                HotelsListByName = dbcon.Hotels.Where(x => (string)x.HotelName == Name).ToList();

            }
            dbcon.Dispose();
            return HotelsListByName;
        }

        public List<TouristPlace> GetPlacesByLocation(int Locationid)
        {
            List<TouristPlace> PlacesListbyLocation = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesListbyLocation = dbcon.TouristPlaces.Where(x => (int)x.LocationId == Locationid).ToList();

            }
            dbcon.Dispose();
            return PlacesListbyLocation;
        }

        public List<TouristPlace> GetPlacesByName(string Name)
        {
            List<TouristPlace> PlacesListbyName = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesListbyName = dbcon.TouristPlaces.Where(x => (string)x.PlaceName == Name).ToList();

            }
            dbcon.Dispose();
            return PlacesListbyName;
        }

        public List<TouristPlace> GetPlacesByRating(int Rating)
        {
            List<TouristPlace> PlacesByRating = new List<TouristPlace>();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                PlacesByRating = dbcon.TouristPlaces.Where(x => x.Ratings == Rating).ToList();

            }
            dbcon.Dispose();
            return PlacesByRating;
        }

        public List<UserReview> GetUserReviews()
        {

            List<UserReview> UList = new List<UserReview>();

            return UList;
        }

        public bool InsertHotel(Hotel obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Hotels.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status; 
        }

        public async Task<bool> InsertLocation(Location obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Locations.Add(obj);
                int changes = await dbcon.SaveChangesAsync();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool InsertTPlace(TouristPlace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.TouristPlaces.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool RatingAPlace(UserReview Review)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.UserReviews.Add(Review);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool UpdateBlog(BlogSpace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.BlogSpaces.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public Hotel GetHotel(int id)
        {
            Hotel hotel = new Hotel();
            using (dbcon = new TourismWebsiteDBEntities())
            {
                 hotel = dbcon.Hotels.Find(id);
            }
            dbcon.Dispose();
            return hotel;
        }
        public bool UpdateHotel(Hotel obj)
        {
            bool status = false;
              using (dbcon = new TourismWebsiteDBEntities())
              {
                var getobj = dbcon.Hotels.Where(s => s.Id == obj.Id).First();
                if(obj.hotelImage != null)
                {
                    getobj.hotelImage = obj.hotelImage;
                }
                
                getobj.HotelName = obj.HotelName;
                getobj.Hoteltype = obj.Hoteltype;
                getobj.Price = obj.Price;
                int changes = dbcon.SaveChanges();


                if (changes > 0)
                {
                    status = true;
                }
                /*      dbcon.Entry(obj).State = EntityState.Modified;
                      if (dbcon.SaveChanges() > 0)
                          status = true;*/
            }
             
            
            return status;
        }

        public bool UpdateLocation(Location obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                dbcon.Locations.Add(obj);
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool UpdatePlace(TouristPlace obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var uobj = dbcon.TouristPlaces.Where(x => x.Id == obj.Id).First();
                uobj.PlaceName = obj.PlaceName;
                uobj.Ratings = obj.Ratings;

                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

        public bool UpdateUser(User obj)
        {
            bool status = false;
            using (dbcon = new TourismWebsiteDBEntities())
            {
                var uobj = dbcon.Users.Where(x => x.UserId == obj.UserId).First();
                uobj.UserName = obj.UserName;
                uobj.Isactive = obj.Isactive;
                uobj.ContactNumber = obj.ContactNumber;
                int changes = dbcon.SaveChanges();
                if (changes > 0)
                {
                    status = true;
                }
            }
            dbcon.Dispose();
            return status;
        }

    }
}
