using AutoMapper;
using Data.Context;
using Data.Models;
using DataAccess.UniOfWork;

namespace Business
{
    public class ToDoBusiness
    {
        #region Members
        private readonly IMapper mapper;
        private static readonly Lazy<ToDoBusiness> instance = new(() => new ToDoBusiness());
        #endregion

        #region Properties
        public static ToDoBusiness Instance = instance.Value;
        #endregion

        #region Constructor
        //public ToDoBusiness(IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}
        #endregion

        #region Methods

        public ResultDataModel<List<ToDoModel>> GetAllTodo()
        {
            try
            {
                using (UnitOfWork<ToDoContext> uow = new())
                {
                    var list = uow.GetRepository<ToDoModel>().GetAll(t => !t.IsDeleted).ToList();
                    return new ResultDataModel<List<ToDoModel>>(200, list);
                }
            }
            catch (Exception ex)
            {
                return new ResultDataModel<List<ToDoModel>>(500);
            }
        }
        #endregion
    }
}
