using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TWYLisans.Infrastructure
{
    public static class TypeConversion
    {
        //Model ve entityler için tip dönüştürme methodu - Reflection işlemi
        public static TResult Conversion<T,TResult>(T model) where TResult : class , new()
        { 
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p =>
            {
                PropertyInfo property = typeof(TResult).GetProperty(p.Name);
                property.SetValue(result, p.GetValue(model));
            });
            return result;
        }
          
    }
}
