using System;
using AutoMapper;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Map
{
    public interface IMapperService : IService
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts);
    }
}
