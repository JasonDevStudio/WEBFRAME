using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace System.Data
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// Created by：cz，2014-5-21，DataTable转换成IList（类型中的属性名需和字段名一致）
        /// </summary>
        /// <typeparam name="T">类 型</typeparam>
        /// <param name="dt">DataTable 本身</param>
        /// <returns>返回 IList</returns>
        public static IList<T> ToList<T>(this DataTable dt) where T : class,new()
        {
            IList<T> result = new List<T>();

            List<PropertyInfo> listOfPropertyInfos = new List<PropertyInfo>();
            Type t = typeof(T);

            //获得T的所有的Public属性，并找出T属性和DataTable的列名称相同的属性(PropertyInfo)，加入到属性列表
            Array.ForEach<PropertyInfo>(t.GetProperties(), p =>
            {
                if (dt.Columns.IndexOf(p.Name) != -1)
                {
                    listOfPropertyInfos.Add(p);
                }
            }
            );
            foreach (DataRow row in dt.Rows)
            {
                T temp = new T();
                listOfPropertyInfos.ForEach(p =>
                {
                    if (row[p.Name] != DBNull.Value)
                    {
                        p.SetValue(temp, row[p.Name], null);
                    }
                }
                );
                result.Add(temp);
            }
            return result;
        }

    }
}
