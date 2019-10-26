using System.Collections.Generic;

namespace ProjectFanta.Services.Interfaces {

    public interface IGroup
    {
        string Key { get; set; }
        IList<IUser> Subscribers { get; set; }
        IUser Admin { get; set; }
    }

}