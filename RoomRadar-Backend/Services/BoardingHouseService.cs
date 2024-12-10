using RoomRadar_Backend.DTO;
using RoomRadar_Backend.Models;
using RoomRadar_Backend.Repository.Interfaces;
using RoomRadar_Backend.Services.Interfaces;
using Newtonsoft.Json;

namespace RoomRadar_Backend.Services
{
    public class BoardingHouseService : IBoardingHouseService
    {
        private readonly IBoardingHouseRepository _boardingHouseRepository;

        public BoardingHouseService(IBoardingHouseRepository boardingHouseRepository)
        {
            _boardingHouseRepository = boardingHouseRepository;
        }
        public ApiResponseDTO GetAllBoardingHousesForViewing()
        {
            List<BoardingHouseForViewingDTO> boardingHousesForViewing = _boardingHouseRepository.GetAllBoardingHousesForViewing();

            return new ApiResponseDTO
            {
                Success = true,
                Type = "FetchSuccessful",
                Data = boardingHousesForViewing
            };
        }

        public ApiResponseDTO CreateBoardingHouseListing(BoardingHouseListingDTO boardingHouseDetails)
        {
            BoardingHouse newBoardingHouse = new BoardingHouse
            {
                PropertyName = boardingHouseDetails.PropertyName,
                PropertyType = boardingHouseDetails.PropertyType,
                RulesJson = JsonConvert.SerializeObject(boardingHouseDetails.RulesArray),
                NumOfBeds = boardingHouseDetails.NumOfBeds,
                NumOfBedrooms = boardingHouseDetails.NumOfBedrooms,
                MonthlyRate = boardingHouseDetails.MonthlyRate,
                LandLordId = boardingHouseDetails.LandLordId,
                Description = boardingHouseDetails.Description,
                AmenitiesJson = JsonConvert.SerializeObject(boardingHouseDetails.AmenitiesArray),
                AllowPets = boardingHouseDetails.AllowPets,
                AdditionalFeesJson = JsonConvert.SerializeObject(boardingHouseDetails.AdditionalFeesArray)
            };

            Location boardingHouseLatLng = new Location
            {
                Latitude = boardingHouseDetails.Latitude,
                Longitude = boardingHouseDetails.Longitude,
            };

            Address boardingHouseAddress = new Address
            {
                Street = boardingHouseDetails.Street,
                Barangay = boardingHouseDetails.Barangay,
                Municipality = boardingHouseDetails.Municipality,
                Province = boardingHouseDetails.Province,
                Country = boardingHouseDetails.Country,
                PostalCode = boardingHouseDetails.PostalCode
            };

            newBoardingHouse.Address = boardingHouseAddress;
            newBoardingHouse.Location = boardingHouseLatLng;
            _boardingHouseRepository.CreateBoardingHouseListing(newBoardingHouse);

            return new ApiResponseDTO
            {
                Success = true,
                Type = "ListingSuccessful",
                Data = newBoardingHouse
            };
        }

    }
}
