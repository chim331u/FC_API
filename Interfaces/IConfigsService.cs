using fc_minimalApi.Contracts.Configs;

namespace fc_minimalApi.Interfaces;

public interface IConfigsService
{
    Task<IEnumerable<ConfigsDto>> GetConfigList();
    Task<ConfigsDto> GetConfig(int id);
    Task<string> GetConfigValue(string key);
    Task<ConfigsDto> UpdateConfig(int id, ConfigsDto config);
    Task<ConfigsDto> AddConfig(ConfigsDto config);
    Task<bool> DeleteConfig(int id);
}