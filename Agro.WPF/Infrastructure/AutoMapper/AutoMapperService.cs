

using Agro.Interfaces;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class AutoMapperService<T>:IMapper<T>
{
    private readonly IMapper _baseMapper;

    public AutoMapperService(IMapper baseMapper)=>_baseMapper = baseMapper;

    public T? Map(object? source) => _baseMapper.Map<T>(source);
}

public class AutoMapperService<TIn, TOut> : IMapper<TIn, TOut>
{
    private readonly IMapper _baseMapper;

    public AutoMapperService(IMapper baseMapper) => _baseMapper = baseMapper;

    public TIn? Map(TOut? source) => _baseMapper.Map<TIn>(source);

    public TOut? Map(TIn? source) => _baseMapper.Map<TOut>(source);

    public TOut Map(TIn source, TOut destination) => _baseMapper.Map<TIn,TOut>(source, destination);
}