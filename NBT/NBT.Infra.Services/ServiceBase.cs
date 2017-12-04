using NBT.Core.Common;
using NBT.Core.Services;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services
{
    public class ServiceBase<T> : DisposableObject, IService<T> where T : class
    {
        private IRepository<T> _repository { get; }
        protected IUnitOfWork _unitOfWork { get; }
        public ServiceBase(
            IUnitOfWork unitOfWork,
            IRepository<T> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(T entity) => await this._repository.InsertAsync(entity);

        public async Task DeleteAsync(T entity) => await this._repository.DeleteAsync(entity);

        public async Task<T> GetByIdAsync(object id) => await this._repository.GetByIdAsync(id);

        public async Task UpdateAsync(T entity) => await this._repository.UpdateAsync(entity);

        protected override void DisposeCore()
        {
            _unitOfWork.Dispose();
        }
    }
}
