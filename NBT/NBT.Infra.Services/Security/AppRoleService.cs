﻿using NBT.Core.Domain.Identity;
using NBT.Core.Services.ApplicationServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Security;
using NBT.Core.Common.Exceptions;

namespace NBT.Infra.Services.Security
{
    public class AppRoleService : ServiceBase<AppRole>, IAppRoleService
    {
        IAppRoleRepository _appRoleRepo;
        IAppRoleGroupRepository _appRoleGroupRepo;
        public AppRoleService(IUnitOfWork unitOfWork
            , IAppRoleRepository appRoleRepo
            , IAppRoleGroupRepository appRoleGroupRepo) : base(unitOfWork, appRoleRepo)
        {
            _appRoleRepo = appRoleRepo;
            _appRoleGroupRepo = appRoleGroupRepo;
        }

        public bool AddRolesToGroup(IEnumerable<AppRoleGroup> roleGroups, int groupId)
        {
            var modelAppRoleGroup = _appRoleGroupRepo.TableNoTracking.Where(x=>x.GroupId == groupId);
            _appRoleGroupRepo.DeleteAsync(modelAppRoleGroup);
            //_appRoleGroupRepo.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _appRoleGroupRepo.Insert(roleGroup);
            }
            return true;
        }

        public void Delete(string id)
        {
            var modelAppRole = _appRoleRepo.TableNoTracking.Where(x => x.Id == id);
            _appRoleRepo.DeleteAsync(modelAppRole);
            //_appRoleRepository.DeleteMulti(x => x.Id == id);
        }

        public IEnumerable<AppRole> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _appRoleRepo.TableNoTracking;
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<AppRole> GetAll()
        {
            return _appRoleRepo.TableNoTracking.ToList();
        }

        public AppRole GetDetail(string id)
        {
            return _appRoleRepo.TableNoTracking.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AppRole> GetListRoleByGroupId(int groupId)
        {
            return _appRoleRepo.GetListRoleByGroupId(groupId);
        }

        public AppRole Insert(AppRole appRole)
        {
            if (_appRoleRepo.CheckContains(x => x.Name == appRole.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepo.Insert(appRole);
        }

        public void Update(AppRole AppRole)
        {
            if (_appRoleRepo.CheckContains(x => x.Description == AppRole.Description && x.Id != AppRole.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            _appRoleRepo.Update(AppRole);
        }
    }
}
