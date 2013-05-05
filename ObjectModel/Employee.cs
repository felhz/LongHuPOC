﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using LongHu.Framework.Resources;

namespace LongHu.ObjectModel
{
    [Serializable]
    public class Employee
    {
        #region Primitive Properties
  
        [Key]
        public virtual Decimal Id
        {
            get;
            set;
        }   
			 public virtual string  UserName
			{
				get;
				set;
			} 
			 public virtual string  Email
			{
				get;
				set;
			} 
			 public virtual string  ContactPhone1
			{
				get;
				set;
			} 
           public virtual DateTime  CreatedOn
			{
				get;
				set;
			} 
           public virtual Decimal  CreatedByEmployeeId
			{
				get;
				set;
			} 
           public virtual DateTime  ModifiedOn
			{
				get;
				set;
			} 
           public virtual Decimal  ModifiedByEmployeeId
			{
				get;
				set;
			} 
			 public virtual string  LoginName
			{
				get;
				set;
			} 
			 public virtual string  Password
			{
				get;
				set;
			}
             public virtual string IsActive
			{
				get;
				set;
			} 
           public virtual Decimal?  DepartmentId
			{
				get;
				set;
			} 
        public EActionOperationType ActionOperationType { get; set; }

        #endregion
    
        #region Navigation Properties
        public virtual Department  Department
        {
            get;
            set;
        }   
    
              
        public IList<EmployeeOrgChart> EmployeeOrgChartList
        {
            get ;
            set ;
        }
              
        public IList<ProjectPlan> ProjectPlanList
        {
            get ;
            set ;
        }
              
      
              
        public IList<ProjectPlanCollection> ProjectPlanCollectionList
        {
            get ;
            set ;
        }
              
      

        #endregion
    }
	[Serializable]
    public class EmployeeSearch:BaseSearchModel
    {
      public  Decimal?  DepartmentId
        {
            get;
            set;
        }   
	}
}
