using Product.Context;
using WebApplication1.Models;
using System.Collections.Specialized;

namespace WebApplication1
{
    public static class DbInitializer
    {
        static Random randObj = new Random(1);
        public static void Initialize(ProductContext db, int companyCount, int productionCount)
        {
            int activity = 500;
            db.Database.EnsureCreated();
            InitTableActivityTypes(db, activity);
            InitTableMeasurementUnits(db);
            InitTableOwnershipForms(db);
            int ProductReleasePlansCount = 1000;
            InitTableProductReleasePlans(db, companyCount, productionCount, ProductReleasePlansCount);

        }

        /// <summary>
        /// Генератор для таблицы activityTypes
        /// </summary>
        /// <param name="db"></param>
        public static void InitTableActivityTypes(ProductContext db, int activity)
        {
            if (!db.activityTypes.Any())
            {
                //виды деятельности
                string[] Name = { "type of activity1", "type of activity2", "type of activity3", "type of activity4", "type of activity5", "type of activity6"};
                
                for(int i = 0; i < activity; i += 2)
                {
                    string name = Name[randObj.Next(Name.Length)];
                    
                    db.Add(new ActivityTypes { Name = name});
                                    }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Генератор для таблицы Единицы измерения
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static int InitTableMeasurementUnits(ProductContext db)
        {
            int measurement = 0;
            if (!db.measurementUnits.Any())
            {
                string[] measurementUnit = { "Unit of measurement1", "Unit of measurement2", "Unit of measurement3", "Unit of measurement4", "Unit of measurement5", "Unit of measurement6"};
                measurement = measurementUnit.Length;
                for(int i = 0; i < measurement; i++)
                {
                    db.Add(new MeasurementUnits (measurementUnit[i]));
                }
                db.SaveChanges();
            }
            return measurement;
        }

        /// <summary>
        /// Генератор для таблицы Формы собственности
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static int InitTableOwnershipForms(ProductContext db)
        {
            int ownership = 0;
            if (!db.ownershipForms.Any())
            {
                string[] ownershipFormss = { "private property", "collective ownership"};
                ownership = ownershipFormss.Length;
                for(int i = 0; i < ownership; i++)
                {
                    db.Add(new OwnershipForms { Name = ownershipFormss[i] });
                }
                db.SaveChanges();
            }
            return ownership;
        }
        public static void InitTableProductReleasePlans(ProductContext db, int companyCount, int productionCount, int ProductReleasePlansCount)
        {
            if (!db.productReleasePlans.Any())
            {
                for (int i = 0; i < ProductReleasePlansCount; i++)
                {
                    int productionTypeId = randObj.Next(1, productionCount);
                    double plannedOutputVolume = randObj.Next(5, 230);
                    int companyId = randObj.Next(1, companyCount);
                    double actualOutputVolume = randObj.Next(5, 230);
                    int quarterInfo = randObj.Next(0, 18);
                    int yearInfo = randObj.Next(0, 18);
                    db.Add(new ProductReleasePlans(productionTypeId, companyId, yearInfo, quarterInfo, actualOutputVolume, plannedOutputVolume));
              
                }
                db.SaveChanges();
            }
        }

        internal static void Initialize(ProductContext dbContext, ProductContext companyCount, ProductContext productionCount)
        {
            throw new NotImplementedException();
        }
    }
}