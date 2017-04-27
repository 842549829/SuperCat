
namespace Qunau.SuperCat
{
    /// <summary>
    /// 前序航班信息爬取精灵
    /// </summary>
    [System.ServiceModel.ServiceContract]
    public interface ICat
    {
        /// <summary>
        /// 根据航班号查询前序航班信息
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationContract]
        string QueryBeforeFlight(string flight);
    }
}
