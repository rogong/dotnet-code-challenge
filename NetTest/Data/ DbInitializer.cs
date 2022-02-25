using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTest.Entities;

namespace NetTest.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if (context.CarOwnerInfos.Any()) return;

            var CarOwnerInfos = new List<CarOwnerInfo>
            {
                new CarOwnerInfo
                {

                   FirstName = "Oluseyi",
                   LastName = "Ayinde",
                   Address =  "112, church street,",
                   State = "Lagos",
                   Lga = "Ikeja",
                   VehicleMaker = "Toyota",
                   VehicleModel = "Camry 2010",
                   PurchaseReceiptUrl = "/images/CarOwnerInfos/sb-ang1.png",
                   VehicleDocUrl = "/images/CarOwnerInfos/sb-ang1.png",

                },
                new CarOwnerInfo
                {

                   FirstName = "Dave",
                   LastName = "John",
                   Address =  "112, church street,",
                   State = "Lagos",
                   Lga = "Ikeja",
                   VehicleMaker = "Toyota",
                   VehicleModel = "Camry 2010",
                   PurchaseReceiptUrl = "/images/CarOwnerInfos/sb-ang1.png",
                   VehicleDocUrl = "/images/CarOwnerInfos/sb-ang1.png",

                },

            };

            foreach (var CarOwnerInfo in CarOwnerInfos)
            {
                context.CarOwnerInfos.Add(CarOwnerInfo);
            }

            context.SaveChanges();

        }
    }
}
