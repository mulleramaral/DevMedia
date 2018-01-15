using System.ServiceModel;

namespace Servico
{
    [ServiceContract]
    public interface IOlaMundoService
    {
        [OperationContract]
        string OlaMundo();
    }
}
