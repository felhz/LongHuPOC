﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using LongHu.DataAccess;
using LongHu.Framework;
using LongHu.Framework.Utility;
using System.Linq.Expressions;
using System;
using My.FrameWork.Utilities;
using My.FrameWork.Utilities.Cache;

namespace LongHu.BusinessLogic
{
    public class OrgChartService
    {
        #region Save method
        /// <summary>
        ///  save Entity Method
        /// </summary>
        /// <param name="svarOrgChart"></param>
        public Decimal Add(ObjectModel.OrgChart svarOrgChart)
        {
		    svarOrgChart.IsActive = "1";
            var rmodel = new ConvertModel();
            var sOrgChart = rmodel.ReturnModel<OrgChart, ObjectModel.OrgChart>(svarOrgChart);
            var dao = new OrgChartRepository();
            var newItem=dao.Insert(sOrgChart);
			return newItem.Id;
        }

        #endregion

        #region Update method
        /// <summary>
        ///  Edit Entity Method
        /// </summary>
        /// <param name="evarOrgChart"></param>
        public void Update(ObjectModel.OrgChart evarOrgChart)
        {
            var rmodel = new ConvertModel();
            var eOrgChart = rmodel.ReturnModel<OrgChart, ObjectModel.OrgChart>(evarOrgChart);
            var dao = new OrgChartRepository();
            var dataOrgChart = dao.Query(s => s.Id == evarOrgChart.Id).FirstOrDefault();
            eOrgChart.CreatedOn =dataOrgChart.CreatedOn;
    		eOrgChart.CreatedByEmployeeId =dataOrgChart.CreatedByEmployeeId;
    		eOrgChart.ModifiedByEmployeeId =ConstantManager.GetCurrentUserId();
    		eOrgChart.ModifiedOn =DateTime.Now;
    		eOrgChart.IsActive =dataOrgChart.IsActive;
            dao.Update(eOrgChart, c => c.Id == eOrgChart.Id);

        }

        #endregion

        #region Remove method
        /// <summary>
        ///  Delete Entity Method
        /// </summary>
        /// <param name="dvarOrgChart"></param>    
        public void Remove(ObjectModel.OrgChart dvarOrgChart)
        {
            var dao = new OrgChartRepository();
            dao.Delete(s => s.Id == dvarOrgChart.Id);
        }

        #endregion

        #region Get Single
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelOrgChart"></param>
        /// <returns></returns>
        public ObjectModel.OrgChart GetOrgChartByID(ObjectModel.OrgChart modelOrgChart)
        {
            var rmodel = new ConvertModel();
            var dao = new OrgChartRepository();
            var dataOrgChart = dao.Query(s => s.Id == modelOrgChart.Id).FirstOrDefault();

            return rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(dataOrgChart);
        }

        #endregion

        #region Get Query
        /// <summary>
        ///  Get Entity List 
        /// </summary>
        /// <returns>List</returns>
        public IList<ObjectModel.OrgChart> FindAll()
        {
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.OrgChart>();
            var daOrgChart = new OrgChartRepository();
            foreach (var vartemp in daOrgChart.Query(c => c.IsActive=="1"))
            {
                var omOrgChart = rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(vartemp);
                list.Add(omOrgChart);
            }
            return list;
        }

        #endregion

        #region Get Page Query
        /// <summary>
        ///  Get Entity Page Query
        /// </summary>
        /// <returns>List</returns>
        public IList<ObjectModel.OrgChart> QueryByPage<TKey>(Expression<Func<ObjectModel.OrgChart, bool>> filter, Expression<Func<ObjectModel.OrgChart, TKey>> orderBy, int orderType, int pageSize, int pageIndex, out int recordsCount)
        {
		    var newFilter = ExpressionConverter<OrgChart>.Convert(filter);
            var newOrderBy = ExpressionConverter<OrgChart>.Convert(orderBy);
            var dao = new OrgChartRepository();
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.OrgChart>();
            var dataList= dao.QueryByPage(newFilter, newOrderBy, orderType, pageSize, pageIndex, out recordsCount);
            if (null == dataList) return null;
            foreach (var vartemp in dataList)
            {
                var omOrgChart = rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(vartemp);
                list.Add(omOrgChart);
            }
            return list;

        }
		private IList<ObjectModel.OrgChart> QueryData(Expression<Func<OrgChart, bool>> filter, Expression<Func<OrgChart, ObjectModel.OrgChart>> selector)
        {
             var newfilter = ExpressionConverter<OrgChart>.Convert(filter);
            var dao = new OrgChartRepository();
         
            var dataList = dao.Query(newfilter, p => new ObjectModel.OrgChart { 
            //write something
            }).ToList();
            return dataList;
        }
        public IList<ObjectModel.OrgChart> Query(Expression<Func<ObjectModel.OrgChart, bool>> filter)
        {
		    var newfilter = ExpressionConverter<OrgChart>.Convert(filter);
            var dao = new OrgChartRepository();
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.OrgChart>();
            var dataList = dao.Query(newfilter).ToList();
            if (null == dataList) return null;
            foreach (var vartemp in dataList)
            {
                var omOrgChart = rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(vartemp);
                list.Add(omOrgChart);
            }
            return list;
        }

		public IList<ObjectModel.OrgChart> QueryByPage(Expression<Func<ObjectModel.OrgChart, bool>> filter, string orderBy, int pageSize, int pageIndex, out int recordsCount)
        {         
            var newfilter = ExpressionConverter<OrgChart>.Convert(filter);
			var dao = new OrgChartRepository();
            var dataList = dao.QueryByPage(newfilter, orderBy, pageSize, pageIndex, out recordsCount).ToList();           
            if (null == dataList) return null;
            var list = new List<ObjectModel.OrgChart>();
            var rmodel = new ConvertModel();
            foreach (var vartemp in dataList)
            {
                var omOrgChart = rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(vartemp);
                list.Add(omOrgChart);
            }
            return list;

        }
		public IList<ObjectModel.OrgChart> GetOrgChartFromCache()
        {
            var key = "OrgChart_key";
			var query=CacheHelper.Get(key) as IList<ObjectModel.OrgChart>;
            if (null == query)
            {
                query = this.Query(q => q.IsActive=="1");
				DateTime ExpirationTime = DateTime.Now.AddMinutes(ConstantManager.CacheCurrentUserExpirationTime);
                CacheHelper.Insert(key, query, ExpirationTime);
            }
            return query;
        }
		public ObjectModel.OrgChart GetSingleOrDefault(Expression<Func<ObjectModel.OrgChart, bool>> filter, string orderBy)
        {
            var newfilter = ExpressionConverter<OrgChart>.Convert(filter);
            var dao = new OrgChartRepository();
            int recordCount = 0;
            var data = dao.QueryByPage(newfilter, orderBy, 1, 1, out recordCount).ToList().FirstOrDefault();
            if (null == data) return null;
            var list = new List<ObjectModel.OrgChart>();
            var rmodel = new ConvertModel();
            return rmodel.ReturnModel<ObjectModel.OrgChart, OrgChart>(data);

        }
        #endregion
    }
}



