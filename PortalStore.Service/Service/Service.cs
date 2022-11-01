using PortalStore.Core.IRepository;
using PortalStore.Core.IService;
using PortalStore.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.saveChanges();
        }

        public void AddRange(List<T> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.saveChanges();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _repository.Count(expression);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.saveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            _repository.DeleteRange(entities);
            _unitOfWork.saveChanges();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _repository.GetBy(expression).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.saveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            _repository.UpdateRange(entities);
            _unitOfWork.saveChanges();
        }
    }
}
