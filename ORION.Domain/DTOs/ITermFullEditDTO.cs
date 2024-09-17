using System;

namespace ORION.Domain.DTOs
{
    public interface ITermFullEditDto
    {
        int Id { get; set; }    
     
        bool IsDeleted { get;}

        string Role { get; }

        DateTime StartOfTerm { get;  }
        
        DateTime EndOfTerm { get; set; }
        
        int NumberOfTerms { get; set; }

        int BusinessOwnerId { get; set; }
    }
}