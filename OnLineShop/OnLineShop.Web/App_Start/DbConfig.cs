
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using OnLineShop.Data;
using OnLineShop.Data.Migrations;

namespace OnLineShop.Web.App_Start
{
    public class DbConfig
    {
        public static void Initilize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnLineShopDbContext, Configuration>());
            OnLineShopDbContext.Create().Database.Initialize(true);
        }

    }
}