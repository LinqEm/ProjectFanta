using System;

namespace ProjectFanta.Services.Interfaces {

    public interface IOwner
    {
        Guid _id { get; set; }
        string PhoneNumber { get; set; }
        string AuthKey { get; set; }
    } 

}