using Transport.Models.Enumerations;

namespace Transport.Core.Interfaces;

public interface IDataSourceService
{
    T Get<T>(DataSourceType type);
}
