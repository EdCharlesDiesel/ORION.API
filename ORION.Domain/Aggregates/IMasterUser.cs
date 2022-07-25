using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface IMasterUser: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IMasterUser o);

        string Province { get; }

        string Occupation { get; set; }        
        
        bool IsBusinessOwner { get; set; }
           
        byte[] Picture { get;}      

        string EmailAddress { get; set; }   
    }

    
}
