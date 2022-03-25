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

        public void CreateFoodMap(MapContent model)
        {
            ValidateModelColumns(model);
            using (ContextModel contextModel = new ContextModel())
            {
                model.ID = Guid.NewGuid();
                model.CreateUser = new Guid("AA3F53D9-D8B4-4963-9AD1-100DD0C02ADB");
                model.CreateDate = DateTime.Now;
                contextModel.MapContents.Add(model);
                contextModel.SaveChanges();
            }
        }
        public void EditFoodMap(MapContent model)
        {
            ValidateModelColumns(model);
            using (ContextModel contextModel = new ContextModel())
            {
                var entity =
                     (from item in contextModel.MapContents
                      where item.ID == model.ID
                      select item).FirstOrDefault();
                if (entity == null)
                    throw new NullReferenceException("Data doesn't exist: " + model.ID);
                entity.Title = model.Title;
                entity.Body = model.Body;
                entity.CoverImage = model.CoverImage;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;
                entity.IsEnable = model.IsEnable;
                entity.UpdateUser = new Guid("AA3F53D9-D8B4-4963-9AD1-100DD0C02ADB");
                entity.UpdateDate = DateTime.Now;
                contextModel.SaveChanges();
            }
        }
        public void DeleteFoodMap(Guid id)
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var entity =
                     (from item in contextModel.MapContents
                      where item.ID == id
                      select item).FirstOrDefault();
                if (entity != null)
                {
                    contextModel.MapContents.Remove(entity);
                    contextModel.SaveChanges();
                }
            }
        }


        private static void ValidateModelColumns(MapContent model)
        {
            if (model == null)
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(model.Title) ||
                string.IsNullOrEmpty(model.Body))
                throw new ArgumentException("Title, Body is Requeired.");

            if (model.Latitude > 90 ||
                model.Latitude < -90)
                throw new ArgumentException("Latitude must between -90 to 90.");
        }
        #endregion
    }

}