using CG.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        int UpdatesModule(UpdateModule request);
    }
}
