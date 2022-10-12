using Dependency.Interface;

namespace Dependency.Service
{

    public class UserService : IScoped, ISingleton, ITransient
    {
        public UserService()
        {
            OperationId = Guid.NewGuid().ToString();
        }

        public string OperationId { get; }
    }
}
