﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using ConsultoriasService.Infrastructure.RefitInternalGenerated;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace ConsultoriasService.Infrastructure.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
namespace ConsultoriasService.Infrastructure.Requests
{
    using global::Refit;
    using global::System;
    using global::System.Net.Http;
    using global::System.Threading.Tasks;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIRefitNormas : IRefitNormas
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIRefitNormas(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<HttpResponseMessage> IRefitNormas.ObterNormasAsync(string authorization)
        {
            var arguments = new object[] { authorization };
            var func = requestBuilder.BuildRestResultFuncForMethod("ObterNormasAsync", new Type[] { typeof(string) });
            return (Task<HttpResponseMessage>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<HttpResponseMessage> IRefitNormas.ObterNormaPorIdAsync(string authorization, Guid id)
        {
            var arguments = new object[] { authorization, id };
            var func = requestBuilder.BuildRestResultFuncForMethod("ObterNormaPorIdAsync", new Type[] { typeof(string), typeof(Guid) });
            return (Task<HttpResponseMessage>)func(Client, arguments);
        }
    }
}

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.