
using System.Collections.Generic;
using System.Linq;
using XinYiAPI.DataAccess.Base;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Eneities;

namespace XinYiAPI.Services
{
    public class MapTemplateService : IMapTemplateDao
    {
        public AlanContext AlanContext;
        public MapTemplateService(AlanContext alanContext)
        {
            this.AlanContext = alanContext;
        }

        public bool CreateMapTemplate(MapTemplate MapTemplate)
        {
            AlanContext.mapTemplates.Add(MapTemplate);
            return AlanContext.SaveChanges() > 0;
        }

        public bool DeleteMapTemplate(MapTemplate mapTemplate)
        {
            AlanContext.mapTemplates.Remove(mapTemplate);
            return AlanContext.SaveChanges() > 0;  
        }
        public bool DeleteMapTemplate(string id)
        {
            var mapTemplate = AlanContext.mapTemplates.Find(id);
            AlanContext.mapTemplates.Remove(mapTemplate);
            return AlanContext.SaveChanges() > 0;
        }

        public MapTemplate GetMapTemplateById(string id)
        {
            return AlanContext.mapTemplates.Find(id);
        }

        public IList<MapTemplate> GetMaptemplates()
        {
           return  AlanContext.mapTemplates.ToList();
        }

        public bool UpdateMapTemplate(MapTemplate MapTemplate)
        {
            AlanContext.mapTemplates.Update(MapTemplate);
            return AlanContext.SaveChanges() > 0;
        }
    }
}
