using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsultoriasService.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("ConsultoriasService.Api"),
                Assembly.Load("ConsultoriasService.Application"),
                Assembly.Load("ConsultoriasService.Domain"),
                Assembly.Load("ConsultoriasService.Domain.Core"),
                Assembly.Load("ConsultoriasService.Infrastructure"),
                Assembly.Load("ConsultoriasService.CrossCutting")
            };
        }
    }
}
