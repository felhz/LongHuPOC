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
    public class ProjectStructureService
    {
        #region Save method
        /// <summary>
        ///  save Entity Method
        /// </summary>
        /// <param name="svarProjectStructure"></param>
        public Decimal Add(ObjectModel.ProjectStructure svarProjectStructure)
        {
		    svarProjectStructure.IsActive = "1";
            var rmodel = new ConvertModel();
            var sProjectStructure = rmodel.ReturnModel<ProjectStructure, ObjectModel.ProjectStructure>(svarProjectStructure);
            var dao = new ProjectStructureRepository();
            var newItem=dao.Insert(sProjectStructure);
			return newItem.Id;
        }

        #endregion

        #region Update method
        /// <summary>
        ///  Edit Entity Method
        /// </summary>
        /// <param name="evarProjectStructure"></param>
        public void Update(ObjectModel.ProjectStructure evarProjectStructure)
        {
            var rmodel = new ConvertModel();
            var eProjectStructure = rmodel.ReturnModel<ProjectStructure, ObjectModel.ProjectStructure>(evarProjectStructure);
            var dao = new ProjectStructureRepository();
            var dataProjectStructure = dao.Query(s => s.Id == evarProjectStructure.Id).FirstOrDefault();
            //eProjectStructure.CreatedOn =dataProjectStructure.CreatedOn;
            //eProjectStructure.CreatedByEmployeeId =dataProjectStructure.CreatedByEmployeeId;
            //eProjectStructure.ModifiedByEmployeeId =ConstantManager.GetCurrentUserId();
            //eProjectStructure.ModifiedOn =DateTime.Now;
    		eProjectStructure.IsActive =dataProjectStructure.IsActive;
            dao.Update(eProjectStructure, c => c.Id == eProjectStructure.Id);

        }

        #endregion

        #region Remove method
        /// <summary>
        ///  Delete Entity Method
        /// </summary>
        /// <param name="dvarProjectStructure"></param>    
        public void Remove(ObjectModel.ProjectStructure dvarProjectStructure)
        {
            var dao = new ProjectStructureRepository();
            dao.Delete(s => s.Id == dvarProjectStructure.Id);
        }

        #endregion

        #region Get Single
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelProjectStructure"></param>
        /// <returns></returns>
        public ObjectModel.ProjectStructure GetProjectStructureByID(ObjectModel.ProjectStructure modelProjectStructure)
        {
            var rmodel = new ConvertModel();
            var dao = new ProjectStructureRepository();
            var dataProjectStructure = dao.Query(s => s.Id == modelProjectStructure.Id).FirstOrDefault();

            return rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(dataProjectStructure);
        }

        #endregion

        #region Get Query
        /// <summary>
        ///  Get Entity List 
        /// </summary>
        /// <returns>List</returns>
        public IList<ObjectModel.ProjectStructure> FindAll()
        {
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.ProjectStructure>();
            var daProjectStructure = new ProjectStructureRepository();
            foreach (var vartemp in daProjectStructure.Query(c => c.IsActive == "1"))
            {
                var omProjectStructure = rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(vartemp);
                list.Add(omProjectStructure);
            }
            return list;
        }

        #endregion

        #region Get Page Query
        /// <summary>
        ///  Get Entity Page Query
        /// </summary>
        /// <returns>List</returns>
        public IList<ObjectModel.ProjectStructure> QueryByPage<TKey>(Expression<Func<ObjectModel.ProjectStructure, bool>> filter, Expression<Func<ObjectModel.ProjectStructure, TKey>> orderBy, int orderType, int pageSize, int pageIndex, out int recordsCount)
        {
		    var newFilter = ExpressionConverter<ProjectStructure>.Convert(filter);
            var newOrderBy = ExpressionConverter<ProjectStructure>.Convert(orderBy);
            var dao = new ProjectStructureRepository();
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.ProjectStructure>();
            var dataList= dao.QueryByPage(newFilter, newOrderBy, orderType, pageSize, pageIndex, out recordsCount);
            if (null == dataList) return null;
            foreach (var vartemp in dataList)
            {
                var omProjectStructure = rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(vartemp);
                list.Add(omProjectStructure);
            }
            return list;

        }
		private IList<ObjectModel.ProjectStructure> QueryData(Expression<Func<ProjectStructure, bool>> filter, Expression<Func<ProjectStructure, ObjectModel.ProjectStructure>> selector)
        {
             var newfilter = ExpressionConverter<ProjectStructure>.Convert(filter);
            var dao = new ProjectStructureRepository();
         
            var dataList = dao.Query(newfilter, p => new ObjectModel.ProjectStructure { 
            //write something
            }).ToList();
            return dataList;
        }
        public IList<ObjectModel.ProjectStructure> Query(Expression<Func<ObjectModel.ProjectStructure, bool>> filter)
        {
		    var newfilter = ExpressionConverter<ProjectStructure>.Convert(filter);
            var dao = new ProjectStructureRepository();
            var rmodel = new ConvertModel();
            var list = new List<ObjectModel.ProjectStructure>();
            var dataList = dao.Query(newfilter).ToList();
            if (null == dataList) return null;
            foreach (var vartemp in dataList)
            {
                var omProjectStructure = rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(vartemp);
                list.Add(omProjectStructure);
            }
            return list;
        }

		public IList<ObjectModel.ProjectStructure> QueryByPage(Expression<Func<ObjectModel.ProjectStructure, bool>> filter, string orderBy, int pageSize, int pageIndex, out int recordsCount)
        {         
            var newfilter = ExpressionConverter<ProjectStructure>.Convert(filter);
			var dao = new ProjectStructureRepository();
            var dataList = dao.QueryByPage(newfilter, orderBy, pageSize, pageIndex, out recordsCount).ToList();           
            if (null == dataList) return null;
            var list = new List<ObjectModel.ProjectStructure>();
            var rmodel = new ConvertModel();
            foreach (var vartemp in dataList)
            {
                var omProjectStructure = rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(vartemp);
                list.Add(omProjectStructure);
            }
            return list;

        }
		public IList<ObjectModel.ProjectStructure> GetProjectStructureFromCache()
        {
            var key = "ProjectStructure_key";
			var query=CacheHelper.Get(key) as IList<ObjectModel.ProjectStructure>;
            if (null == query)
            {
                query = this.Query(q => q.IsActive=="1");
				DateTime ExpirationTime = DateTime.Now.AddMinutes(ConstantManager.CacheCurrentUserExpirationTime);
                CacheHelper.Insert(key, query, ExpirationTime);
            }
            return query;
        }
		public ObjectModel.ProjectStructure GetSingleOrDefault(Expression<Func<ObjectModel.ProjectStructure, bool>> filter, string orderBy)
        {
            var newfilter = ExpressionConverter<ProjectStructure>.Convert(filter);
            var dao = new ProjectStructureRepository();
            int recordCount = 0;
            var data = dao.QueryByPage(newfilter, orderBy, 1, 1, out recordCount).ToList().FirstOrDefault();
            if (null == data) return null;
            var list = new List<ObjectModel.ProjectStructure>();
            var rmodel = new ConvertModel();
            return rmodel.ReturnModel<ObjectModel.ProjectStructure, ProjectStructure>(data);

        }
        #endregion
    }
}



