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
            mens = 0,
            ladies = 1
        };

        public enum mainSubCategory
        {
            tshirts = 0,
            skinny = 1,
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

            if (category.Equals(mainCategory.mens.ToString()))
            {
                details.fieldName = "mainCategory";
                details.categoryId = Convert.ToInt32(mainCategory.mens);
                details.categoryTitle = "Mens";
            }
            else if (category.Equals(mainCategory.ladies.ToString()))
            {
                details.fieldName = "mainCategory";
                details.categoryId = Convert.ToInt32(mainCategory.ladies);
                details.categoryTitle = "Ladies";
            }
            else if (category.Equals(mainSubCategory.tshirts.ToString()))
            {
                details.fieldName = "mainSubCategory";
                details.categoryId = Convert.ToInt32(mainSubCategory.tshirts);
                details.categoryTitle = "T-Shirts";
            }
            else if (category.Equals(mainSubCategory.skinny.ToString()))
            {
                details.fieldName = "mainSubCategory";
                details.categoryId = Convert.ToInt32(mainSubCategory.skinny);
                details.categoryTitle = "Skinny Tops";
            }
            //else if (category.Equals(subCategory.apple.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.apple);
            //    details.categoryTitle = "Apple";
            //}
            //else if (category.Equals(subCategory.xiaomiSmartWatch.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.xiaomiSmartWatch);
            //    details.categoryTitle = "Xiaomi Smart Watches";
            //}
            //else if (category.Equals(subCategory.xiaomiFitnessTracker.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.xiaomiFitnessTracker);
            //    details.categoryTitle = "Xiaomi Fitness Trackers";
            //}
            //else if (category.Equals(subCategory.samsung.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.samsung);
            //    details.categoryTitle = "Samsung";
            //}
            //else if (category.Equals(subCategory.hotwheels.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.hotwheels);
            //    details.categoryTitle = "Hot Wheels";
            //}
            //else if (category.Equals(subCategory.carmodels.ToString()))
            //{
            //    details.fieldName = "subCategory";
            //    details.categoryId = Convert.ToInt32(subCategory.carmodels);
            //    details.categoryTitle = "Model Cars";
            //}

            return details;
        }
    }
}
