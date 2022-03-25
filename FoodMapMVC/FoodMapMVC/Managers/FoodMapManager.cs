using FoodMapMVC.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMapMVC.Managers
{
    public class FoodMapManager
    {
        public List<MapContent> GetMapList()
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query = contextModel.MapContents.Where(obj => obj.IsEnable);
                var result = query.ToList();
                return result;
            }
        }
        public MapContent GetMap(Guid id)
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query =
                    from item in contextModel.MapContents
                    where item.ID == id && item.IsEnable
                    select item;
                var result = query.FirstOrDefault();
                return result;
            }
        }

        #region Admin
        public List<MapContent> GetAdminMapList()
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query = contextModel.MapContents;
                var result = query.ToList();
                return result;
            }
        }
        public MapContent GetAdminMap(Guid id)
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query =
                    from item in contextModel.MapContents
                    where item.ID == id
                    select item;
                var result = query.FirstOrDefault();
                return result;
            }
        }
        #endregion
    }

}