using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProductService
    {
        public static ProductDTO AddProduct(ProductDTO c)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Product>(c);
            var data1 = DataAccessFactory.ProductData().Create(data);
            return mapper.Map<ProductDTO>(data1);
        }
        public static List<ProductDTO> ViewProduct()
        {
            var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }
        public static ProductDTO UpdateProduct(ProductDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Product>(u);
            var ret = DataAccessFactory.ProductData().Update(data);
            //if (ret != false)
            return mapper.Map<ProductDTO>(ret);
            //return false;
        }
        public static ProductDTO ViewProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            //var RET = mapper.Map<Product>(data);
            return mapper.Map<ProductDTO>(data);
            //return RET;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.ProductData().Delete(id);
            return res;
        }

    }
}
