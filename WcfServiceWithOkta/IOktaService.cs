using System.ServiceModel;

namespace WcfServiceWithOkta
{
    [ServiceContract]
    public interface IOktaService
    {
        [OperationContract]
        void DoWork();
    }
}
