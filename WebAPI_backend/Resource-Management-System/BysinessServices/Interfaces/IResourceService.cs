﻿using BysinessServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BysinessServices.Interfaces
{
    public interface IResourceService : ICrud<ResourceModel>
    {
        Task<IEnumerable<ScheduleModel>> GetScheduleByResourceId();
        Task<IEnumerable<ScheduleModel>> GetScheduleByUserId();

        Task<IEnumerable<ResourceTypeModel>> GetAllResourceTypesAsync();
        Task AddResourceTypeAsync(ResourceTypeModel resourceTypeModel);
        Task UpdateResourceTypeAsync(ResourceTypeModel resourceTypeModel);
        Task RemoveResourceTypeAsync(int resourceTypeId);
    }
}