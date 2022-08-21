using Data.Context;
using Data.Models;
using DataAccess.UniOfWork;

namespace Business
{
    public class UserBusiness
    {
        #region Members
        private static readonly Lazy<UserBusiness> instance = new(() => new UserBusiness());
        #endregion

        #region Properties
        public static UserBusiness Instance = instance.Value;
        #endregion

        #region Methods
        public ResultDataModel<List<UserModel>> GetAllUser()
        {
            try
            {
                using (UnitOfWork<ToDoContext> UnitOfWork = new())
                {
                    var list = UnitOfWork.GetRepository<UserModel>().GetAll(u => !u.IsDelete).ToList();
                    return new ResultDataModel<List<UserModel>>(200,list);
                }
            }
            catch(Exception ex)
            {
                return new ResultDataModel<List<UserModel>>(500);
            }
        }

        public ResultModel AddUser(UserModel user)
        {
            try
            {
                using(UnitOfWork<ToDoContext> UnitOfWork = new())
                {
                    user.Id = Guid.NewGuid();
                    user.CreationTime = DateTime.Now;
                    UnitOfWork.GetRepository<UserModel>().Add(user);
                    return new ResultModel(200);
                }
            }
            catch(Exception ex)
            {
                return new ResultModel(500,ex.Message);
            }
        }
        #endregion
    }
}
