using System;
using System.Collections.Generic;

namespace ProjectFanta.Services.Interfaces {

    public interface IOwnerRepo
    {
        IOwner GetByKey(string key);

        void Create(IOwner owner);
    } 

}