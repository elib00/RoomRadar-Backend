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

        public ApiResponseDTO AddBoardingHouseRating(CreateRatingDTO ratingDTO)
        {
            if (_boardingHouseRepository.UserAlreadyRatedBoardingHouse(ratingDTO.UserId, ratingDTO.BoardingHouseId))
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "UserAlreadyRated",
                    Data = null
                };
            }

            Rating newRating = new Rating
            {
                UserId = ratingDTO.UserId,
                BoardingHouseId = ratingDTO.BoardingHouseId,
                Star = ratingDTO.Star
            };

            _boardingHouseRepository.AddBoardingHouseRating(newRating);

            return new ApiResponseDTO
            {
                Success = true,
                Type = "RatingAdditionSuccessful",
                Data = new
                {
                    UserId = newRating.UserId,
                    BoardingHouseId = newRating.BoardingHouseId,
                    Star = newRating.Star
                }
            };
        }

        public ApiResponseDTO AddBoardingHouseFavorite(CreateFavoriteDTO favDTO)
        {
            if (_boardingHouseRepository.UserAlreadyFavoritedBoardingHouse(favDTO.UserId, favDTO.BoardingHouseId))
            {
                return new ApiResponseDTO
                {
                    Success = false,
                    Type = "UserAlreadyFavorited",
                    Data = null
                };
            }

            Favorite newFav = new Favorite
            {
                UserId = favDTO.UserId,
                BoardingHouseId = favDTO.BoardingHouseId
            };

            _boardingHouseRepository.AddBoardingHouseFavorite(newFav);

            return new ApiResponseDTO
            {
                Success = true,
                Type = "FavoriteAdditionSuccessful",
                Data = new
                {
                    UserId = favDTO.UserId,
                    BoardingHouseId = favDTO.BoardingHouseId
                }
            };
        }

        public ApiResponseDTO GetBoardingHouseDetails(int boardingHouseId)
        {
            BoardingHouse boardingHouse = _boardingHouseRepository.GetBoardingHouseDetails(boardingHouseId);

            return new ApiResponseDTO
            {
                Success = true, 
                Type = "BoardingHouseDetailsFetchSuccessful",
                Data = boardingHouse
            };
        }

        public ApiResponseDTO FilterListings(ListingFiltersDTO listingFiltersDTO)
        {
            List<BoardingHouseForViewingDTO> listings = _boardingHouseRepository.FilterListings(listingFiltersDTO);
            return new ApiResponseDTO
            {
                Success = true,
                Type = "FilterApplicationSuccessful",
                Data = listings
            }
        }


    }
}
