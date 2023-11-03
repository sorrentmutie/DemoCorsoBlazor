namespace DemoCorsoBlazor.Core.ReqRes;

public interface IReqResData
{
    Task<ReqResData?> PostSomeData(ReqResData data);
    Task<List<User>?> GetSomeData();
    void CancelRequest();
}

