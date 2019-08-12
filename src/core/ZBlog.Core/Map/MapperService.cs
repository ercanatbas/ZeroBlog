using AutoMapper;
using System;

namespace ZBlog.Core.Map
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source) => _mapper.Map<TDestination>(source);
        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts) => _mapper.Map<TDestination>(source, opts);

        public TDestination Map<TSource, TDestination>(TSource source) => _mapper.Map<TSource, TDestination>(source);
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => _mapper.Map(source, destination);
        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts) => _mapper.Map(source, opts);
    }
}
