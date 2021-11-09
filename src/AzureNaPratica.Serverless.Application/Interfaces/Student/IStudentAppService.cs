using AzureNaPratica.Serverless.Application.Base.Interfaces.Service;
using AzureNaPratica.Serverless.Application.DataTransferObject.Student;

namespace AzureNaPratica.Serverless.Application.Interfaces.Student
{
    public interface IStudentAppService : IBaseAppService<StudentDto, string>
    {

    }
}
