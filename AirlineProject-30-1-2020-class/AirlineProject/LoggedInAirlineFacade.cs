using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            //what if it's in the air?
            //what if landing date is earlier than departure date?
            //need to remove tickets as well
            LoginHelper.CheckToken<AirlineCompany>(token);
            POCOValidator.FlightValidator(flight, true);
            if (_flightDAO.Get(flight.ID) == null)
                throw new FlightNotFoundException($"failed to cancel flight! there is no flight with id [{flight.ID}]");
            if (flight.AirlineCompanyId != token.User.ID)
                throw new InaccessibleFlightException($"failed to cancel flight! you do not own flight [{flight}]");
            //need to add functions to to remove Poco lists
            //if customer is deleted then flight's vacancy is increased

            // to delete a poco ==> you need to delete those
            //airlineCompany ==> flights
            //country ==> airlineCompanies, flights
            //customer ==> tickets
            //flight ==> tickets
            //ticket ==> none
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            throw new NotImplementedException();
        }

        public void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
