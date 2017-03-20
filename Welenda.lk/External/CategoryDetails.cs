using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welenda.lk.Models;

namespace Welenda.lk.External
{
    class CategoryDetails
    {
        public enum mainCategory
        {
            electronics = 0,
            toys = 1
        };

        public enum mainSubCategory
        {
            smartwatches = 0,
            Fitnesstrackers = 1,
        };

        public enum subCategory
        {
            apple = 0,
            xiaomiSmartWatch = 1,
            xiaomiFitnessTracker = 2,
            samsung = 3,
            hotwheels = 4,
            carmodels = 5
        };

        public CategoryModel GetDategoryDetails(string category)
        {
            var details = new CategoryModel();

            if (category.Equals(mainCategory.electronics.ToString()))
            {
                details.fieldName = "mainCategory";
                details.categoryId = Convert.ToInt32(mainCategory.electronics);
                details.categoryTitle = "Electornics";
            }
            else if (category.Equals(mainCategory.toys.ToString()))
            {
                details.fieldName = "mainCategory";
                details.categoryId = Convert.ToInt32(mainCategory.toys);
                details.categoryTitle = "Toys";
            }
            else if (category.Equals(mainSubCategory.smartwatches.ToString()))
            {
                details.fieldName = "mainSubCategory";
                details.categoryId = Convert.ToInt32(mainSubCategory.smartwatches);
                details.categoryTitle = "Smart Watches";
            }
            else if (category.Equals(mainSubCategory.Fitnesstrackers.ToString()))
            {
                details.fieldName = "mainSubCategory";
                details.categoryId = Convert.ToInt32(mainSubCategory.Fitnesstrackers);
                details.categoryTitle = "Fitness Trackers";
            }
            else if (category.Equals(subCategory.apple.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.apple);
                details.categoryTitle = "Apple";
            }
            else if (category.Equals(subCategory.xiaomiSmartWatch.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.xiaomiSmartWatch);
                details.categoryTitle = "Xiaomi Smart Watches";
            }
            else if (category.Equals(subCategory.xiaomiFitnessTracker.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.xiaomiFitnessTracker);
                details.categoryTitle = "Xiaomi Fitness Trackers";
            }
            else if (category.Equals(subCategory.samsung.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.samsung);
                details.categoryTitle = "Samsung";
            }
            else if (category.Equals(subCategory.hotwheels.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.hotwheels);
                details.categoryTitle = "Hot Wheels";
            }
            else if (category.Equals(subCategory.carmodels.ToString()))
            {
                details.fieldName = "subCategory";
                details.categoryId = Convert.ToInt32(subCategory.carmodels);
                details.categoryTitle = "Model Cars";
            }

            return details;
        }
    }
}
