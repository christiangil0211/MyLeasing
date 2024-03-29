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

        public async Task<Contract> ToContractAsync(ContractViewModel model, bool isNew)
        {
            return new Contract
            {
                EndDate = model.EndDate.ToUniversalTime(),
                IsActive = model.IsActive,
                Lessee = await _dataContext.Lessees.FindAsync(model.LesseeId),
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                Property = await _dataContext.Properties.FindAsync(model.PropertyId),
                Remarks = model.Remarks,
                StartDate = model.StartDate.ToUniversalTime(),
                Id = isNew ? 0 : model.Id
            };
        }

        public ContractViewModel ToContractViewModel(Contract contract)
        {
            return new ContractViewModel
            {
                EndDate = contract.EndDateLocal,
                Id = contract.Id,
                IsActive = contract.IsActive,
                Lessee = contract.Lessee,
                Owner = contract.Owner,
                Price = contract.Price,
                Property = contract.Property,
                Remarks = contract.Remarks,
                StartDate = contract.StartDateLocal,
                LesseeId = contract.Lessee.Id,
                Lessees = _combosHelper.GetComboLessees(),
                OwnerId = contract.Owner.Id,
                PropertyId = contract.Property.Id
            };
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
