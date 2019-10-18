﻿using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }
        public async Task<Property> ToPropertyAsync(PropertyViewModel model, bool isNew)
        {
            return new Property
            {
                Address = model.Address,
                Contracts = isNew ? new List<Contract>() : model.Contracts,
                HasParkingLot = model.HasParkingLot,
                Id = isNew ? 0 : model.Id,
                IsAvailable = model.IsAvailable,
                Neighborhood = model.Neighborhood,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PropertyImages = isNew ? new List<PropertyImage>() : model.PropertyImages,
                PropertyType = await _dataContext.PropertyTypes.FindAsync(model.PropertyTypeId),
                Remarks = model.Remarks,
                Rooms = model.Rooms,
                SquareMeters = model.SquareMeters,
                Stratum = model.Stratum,
                Price = model.Price
            };
        }

        public PropertyViewModel ToPropertyViewModel(Property properties)
        {
            return new PropertyViewModel
            {
                Address = properties.Address,
                Contracts = properties.Contracts,
                HasParkingLot = properties.HasParkingLot,
                Id = properties.Id,
                IsAvailable = properties.IsAvailable,
                Neighborhood = properties.Neighborhood,
                Owner = properties.Owner,
                PropertyImages = properties.PropertyImages,
                PropertyType = properties.PropertyType,
                Remarks = properties.Remarks,
                Rooms = properties.Rooms,
                SquareMeters = properties.SquareMeters,
                Stratum = properties.Stratum,
                Price = properties.Price,
                OwnerId = properties.Owner.Id,
                PropertyTypeId = properties.PropertyType.Id,
                PropertyTypes = _combosHelper.GetComboPropertyTypes()
            };
        }
    }
}
