using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface IMapTemplateDao
    {
        IList<MapTemplate> GetMaptemplates();
        MapTemplate GetMapTemplateById(string id);
        bool CreateMapTemplate(MapTemplate MapTemplate);
        bool UpdateMapTemplate(MapTemplate MapTemplate);
        bool DeleteMapTemplate(MapTemplate id);
    }
}
