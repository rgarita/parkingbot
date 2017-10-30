using ParkingBotDataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBotDataAccess.Repositories
{
    interface IReservationsRepository
    {
        #region CRUD Spots
        /// <summary>
        /// Create a spot on the pool
        /// </summary>
        /// <param name="spotName">Name of the spot</param>
        /// <returns></returns>
        Spot CreateSpot(String spotName);
        /// <summary>
        /// Deletes an spot from the pool
        /// </summary>
        /// <param name="spotName">Spot Name</param>
        void DeleteSpot(String spotName);
        #endregion

        #region Users
        /// <summary>
        /// Registers an user on the App, Looking if already exists
        /// </summary>
        /// <param name="userId">User ID (Channel user ID)</param>
        /// <param name="DisplayName">Friendly Name</param>
        /// <returns></returns>
        User RegisterUser(string userId, string DisplayName);
        #endregion

        #region Reservations
        /// <summary>
        /// Returns a list of open spots
        /// </summary>
        /// <returns></returns>
        List<Spot> GetOpenSpots();
        /// <summary>
        /// Checks if a spot is available
        /// </summary>
        /// <param name="spotName">Spot Name</param>
        /// <returns></returns>
        bool IsSpotAvailable(string spotName);
        /// <summary>
        /// Reserves an spot for an specified time frame
        /// </summary>
        /// <param name="user">User entity</param>
        /// <param name="spotName">Spot name</param>
        /// <param name="startDate">Start date & time</param>
        /// <param name="endDate">End date & time</param>
        /// <returns></returns>
        Reservation ReserveSpot(User user, string spotName, DateTime startDate, DateTime endDate);
        /// <summary>
        /// Reserves an spot for the day
        /// </summary>
        /// <param name="user">User entity</param>
        /// <param name="spotName">Spot name</param>
        /// <returns></returns>
        Reservation ReserveSpot(User user, string spotName);
        #endregion

    }
}
