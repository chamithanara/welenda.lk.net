﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Welenda.lk.Models;
using static Welenda.lk.Models.AuthErrorCodes;
using static Welenda.lk.Models.ProductModel;
using Welenda.lk.External;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using static Welenda.lk.Models.ProductTypes;

namespace Welenda.lk.Database
{
    class ExecuteQueries
    {
        private SqlConnection getConnection()
        {
            var database = Connection.getDbInstance();
            return database.GetDBConnection();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ErrorCodes CreateUser(string email, string password, string name)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    if (!db.users.Where(u => u.email == email).Any())
                    {
                        var users = db.Set<user>();
                        users.Add(new user { email = email, password = password, name = name, uid = Guid.NewGuid().ToString() });

                        db.SaveChanges();
                        return ErrorCodes.success;
                    }
                    else
                    {
                        return ErrorCodes.emailExist;
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return ErrorCodes.exception;
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel LoginUser(string email, string password)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    if (!db.users.Where(u => u.email == email & u.password == password).Any())
                    {
                        return new ResultModel { errorCode = ErrorCodes.nouserinfo, result = null };
                    }
                    else
                    {
                        var user = db.users.Where(u => u.email == email && u.password == password).ToList();
                        return new ResultModel { errorCode = ErrorCodes.success, userResult = user };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetHotProducts()
        {
            try
            {
                lock (this)
                {
                    Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();

                    using (var db = new welendadbContext())
                    {
                        var L2EQuery = db.products.Where(s => s.ishotproduct == true).ToList();

                        foreach (var product in L2EQuery)
                        {
                            var data = new List<string>();
                            var id = product.id.ToString().Trim();

                            data.Add(product.title.Trim());
                            data.Add(product.imgurl.Trim());
                            data.Add(product.oldprice.Trim());
                            data.Add(product.newprice.Trim());

                            str.Add(id, data);
                        }
                    }
                        
                    if (str.Count != 0)
                    {
                        return new ResultModel { errorCode = ErrorCodes.success, hotProducts = str };
                    }
                }
            }
            catch (SqlException e)
            {
                var msg = e.Message;
                return new ResultModel { errorCode = ErrorCodes.exception };
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetElectronicsProducts()
        { 
            try
            {
                lock (this)
                {
                    Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();

                    using (var db = new welendadbContext())
                    {
                        var L2EQuery = db.products.Where(s => s.mainCategory == 0 && 
                                                              s.isinhomepage == true);

                        foreach (var product in L2EQuery)
                        {
                            var data = new List<string>();
                            var id = product.id.ToString().Trim();

                            data.Add(product.title.Trim());
                            data.Add(product.imgurl.Trim());
                            data.Add(product.oldprice.Trim());
                            data.Add(product.newprice.Trim());

                            str.Add(id, data);
                        }
                    }
                        
                    if (str.Count != 0)
                    {
                        return new ResultModel { errorCode = ErrorCodes.success, ElectornicsProducts = str };
                    }
                }
            }
            catch (SqlException e)
            {
                var msg = e.Message;
                return new ResultModel { errorCode = ErrorCodes.exception };
            }

            return new ResultModel { errorCode = ErrorCodes.success };            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetToyProducts()
        {
            try
            {
                lock (this)
                {
                    Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();

                    using (var db = new welendadbContext())
                    {
                        var L2EQuery = db.products.Where(s => s.mainCategory == 1 && 
                                                              s.isinhomepage == true);

                        foreach (var product in L2EQuery)
                        {
                            var data = new List<string>();
                            var id = product.id.ToString().Trim();

                            data.Add(product.title.Trim());
                            data.Add(product.imgurl.Trim());
                            data.Add(product.oldprice.Trim());
                            data.Add(product.newprice.Trim());

                            str.Add(id, data);
                        }
                    }

                    if (str.Count != 0)
                    {
                        return new ResultModel { errorCode = ErrorCodes.success, ToyProducts = str };
                    }
                }
            }
            catch (SqlException e)
            {
                var msg = e.Message;
                return new ResultModel { errorCode = ErrorCodes.exception };
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetProductDetails(string productId)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var productIdVal = Convert.ToInt32(productId);
                    var productDetail = db.productdetails.Where(p => p.productid == productIdVal).FirstOrDefault();
                    var prodInfo = db.productinfoes.Where(p => p.productid == productIdVal).ToList();

                    return new ResultModel { errorCode = ErrorCodes.success, productDetailResult = productDetail, productInfoResult = prodInfo };
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetProductSubDetails(string productId)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var productIdVal = Convert.ToInt32(productId);
                    var product = db.products.Where(p => p.id == productIdVal).FirstOrDefault();
                    return new ResultModel { errorCode = ErrorCodes.success, productResult = product };
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetProductsForCategory(string main, string sub)
        {
            try
            {
                var mainDetails = new CategoryDetails().GetDategoryDetails(main);
                var subDetails = new CategoryDetails().GetDategoryDetails(sub);
                var L2EQuery = new List<product>();

                using (var db = new welendadbContext())
                {
                    //if (catergoryDetails.fieldName.Equals("mainCategory"))
                    //{
                        L2EQuery = db.products.Where(s => s.mainCategory == mainDetails.categoryId && s.mainSubCategory == subDetails.categoryId).ToList();
                    //}
                    //else if (catergoryDetails.fieldName.Equals("mainSubCategory"))
                    //{
                    //    L2EQuery = db.products.Where(s => s.mainSubCategory == catergoryDetails.categoryId).ToList();
                    //}
                    //else if (catergoryDetails.fieldName.Equals("subCategory"))
                    //{
                    //    L2EQuery = db.products.Where(s => s.subCategory == catergoryDetails.categoryId).ToList();
                    //}

                    lock (this)
                    {
                        Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();

                        foreach (var product in L2EQuery)
                        {
                            var data = new List<string>();
                            var id = product.id.ToString().Trim();

                            data.Add(product.title.Trim());
                            data.Add(product.imgurl.Trim());
                            data.Add(product.oldprice.Trim());
                            data.Add(product.newprice.Trim());

                            str.Add(id, data);
                        }

                        string title = mainDetails.categoryTitle + "-" + subDetails.categoryTitle;
                        if (str.Count != 0)
                        {
                            return new ResultModel { errorCode = ErrorCodes.success, ElectornicsProducts = str, categoryTitle = title };
                        }
                        else
                        {
                            return new ResultModel { errorCode = ErrorCodes.success, categoryTitle = title };
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                var msg = e.Message;
                return new ResultModel { errorCode = ErrorCodes.exception };
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel ProductAddToCart(int prodId, int quantity, string userId, string name)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var user = db.users.Where(u => u.uid.Trim().Equals(userId.Trim()) &&
                                              u.name.Trim().Equals(name.Trim())).FirstOrDefault();

                    if (user != null && db.products.Any(p => p.id == prodId))
                    {
                        // check if the item already added by the user
                        if (!db.usertobaskets.Any(ub => ub.productId == prodId &&
                                                       ub.userId == user.id))
                        {
                            var userToBasket = db.Set<usertobasket>();
                            userToBasket.Add(new usertobasket { userId = user.id, productId = prodId, quantity = quantity });

                            db.SaveChanges();
                            return new ResultModel { errorCode = ErrorCodes.success };
                        }
                        else
                        {
                            return new ResultModel { errorCode = ErrorCodes.itemexists };
                        }
                    }
                    else
                    {
                        return new ResultModel { errorCode = ErrorCodes.error };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetCartItemCount(string userId, string name)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var user = db.users.Where(u => u.uid.Trim().Equals(userId.Trim()) &&
                                              u.name.Trim().Equals(name.Trim())).FirstOrDefault();

                    if (user != null)
                    {
                        var count = db.usertobaskets.Count(ub => ub.userId == user.id);
                        return new ResultModel { basketItemCount = count, errorCode = ErrorCodes.success };
                    }
                    else
                    {
                        return new ResultModel { errorCode = ErrorCodes.error };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel GetItemsFromCart(string userId)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var user = db.users.Where(u => u.uid.Trim().Equals(userId.Trim())).FirstOrDefault();

                    if (user != null)
                    {
                        var items = db.usertobaskets.Where(ub => ub.userId == user.id);
                        var productsList = new List<ProductToQuantity>();

                        foreach (var item in items)
                        {
                            var productToQuantityModel = new ProductToQuantity();
                            productToQuantityModel.product = item.product;
                            productToQuantityModel.quantity = item.quantity;

                            productsList.Add(productToQuantityModel);
                        }

                        return new ResultModel { cartProductList = productsList, errorCode = ErrorCodes.success };
                    }
                    else
                    {
                        return new ResultModel { errorCode = ErrorCodes.error };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public ResultModel RemoveItemFromBasket(string userId, int prodId)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var user = db.users.SingleOrDefault(u => u.uid.Trim().Equals(userId));
                    var userToBasket = db.usertobaskets.SingleOrDefault(u => u.userId == user.id && 
                                                                            u.productId == prodId);

                    if (user != null && userToBasket != null)
                    {
                        db.usertobaskets.Remove(userToBasket);
                        db.SaveChanges();

                        return new ResultModel { errorCode = ErrorCodes.success };
                    }
                    else
                    {
                        return new ResultModel { errorCode = ErrorCodes.error };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual ResultModel getProducts()
        {
            ResultModel result = new ResultModel();
            List<ProductModel> productModels = new List<ProductModel>();
            using (var db = new welendadbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var products = db.products.Include("productSubImages").ToList();

                    if (products == null)
                    {
                        return new ResultModel {errorCode = ErrorCodes.error };
                    }
                    else
                    {
                        foreach (product product in products)
                        {
                            var productModel = new ProductModel();

                            productModel.id = product.id;
                            productModel.title = product.title.Trim();
                            productModel.newprice = product.newprice.Trim();
                            productModel.imgUrl = product.imgurl.Trim();

                            productModels.Add(productModel);
                        }

                        return new ResultModel { productsList = productModels, errorCode = ErrorCodes.success };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual ResultModel getSubImages(int id)
        {
            using (var db = new welendadbContext())
            {
                try
                {
                    var productSubImages = db.productSubImages.Where(p => p.productId == id).Select(a => a.imageUrl).ToList();

                    if (productSubImages == null)
                    {
                        return new ResultModel { errorCode = ErrorCodes.error };
                    }
                    else
                    {
                        return new ResultModel { result = productSubImages, errorCode = ErrorCodes.success };
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
            }
        }

        public ResultModel saveOrder()
        {
            return new ResultModel { errorCode = ErrorCodes.exception, result = null };
        }
    }    
}
