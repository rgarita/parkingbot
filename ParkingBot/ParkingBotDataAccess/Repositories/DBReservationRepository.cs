using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingBotDataAccess.DataModel;

namespace ParkingBotDataAccess.Repositories
{
    public class DBReservationRepository : IReservationsRepository
    {
        public ParkingBotEntities Entities { get; set; }
        public DBReservationRepository()
        {
            this.Entities = new ParkingBotEntities();
        }
        public Spot CreateSpot(string spotName)
        {
            Spot spot = Entities.Spots.Where(s => s.Name == spotName).FirstOrDefault(null);
            if(spot==null)
            {
                Spot newSpot = new Spot();
                newSpot.Name = spotName;
                newSpot.Active = true;
                spot = Entities.Spots.Add(newSpot);
            }
            Entities.SaveChanges();
            return spot;
        }

        public void DeleteSpot(string spotName)
        {
            Spot spot = Entities.Spots.Where(s => s.Name == spotName).FirstOrDefault(null);
            if (spot != null)
            {
                Entities.Spots.Remove(spot);
                Entities.SaveChanges();
            }
        }

        public List<Spot> GetOpenSpots()
        {
            throw new NotImplementedException();
        }

        public bool IsSpotAvailable(string spotName)
        {
            throw new NotImplementedException();
        }

        public User RegisterUser(string userId, string DisplayName)
        {
            User user = Entities.Users.Where(u => u.UserId == userId).FirstOrDefault(null);
            if (user == null)
            {
                User newUser = new User();
                newUser.UserId = userId;
                newUser.DisplayName = DisplayName;
                user = Entities.Users.Add(newUser);
            }
            return user;
        }

        public Reservation ReserveSpot(User user, string spotName, DateTime startDate, DateTime endDate)
        {
            Spot spot = Entities.Spots.Where(s => s.Name == spotName).FirstOrDefault(null);
            if (spot != null)
            {
                List<Reservation> results = Entities.Reservations.Where(r => r.Spot == spot && startDate < r.EndDate && endDate > r.StartDate).ToList();
                if (results.Count != 0)
                {
                    Reservation newReservation = new Reservation();
                    newReservation.User = user;
                    newReservation.Spot = spot;
                    newReservation.StartDate = startDate;
                    newReservation.EndDate = endDate;
                    return Entities.Reservations.Add(newReservation);
                }
                else
                {
                    throw new ReservationException("Already Reserved Spot");
                }
            }
            else
            {
                throw new ReservationException("Invalid Spot");
            }
        }

        public Reservation ReserveSpot(User user, string spotName)
        {
            return this.ReserveSpot(user, spotName, DateTime.Now, DateTime.Today.AddHours(23));
        }
    }
}
