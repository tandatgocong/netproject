﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MapGoogle.Databases
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WEBDEMO")]
	public partial class MapDemoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUSER(USER instance);
    partial void UpdateUSER(USER instance);
    partial void DeleteUSER(USER instance);
    partial void InsertLOCATION(LOCATION instance);
    partial void UpdateLOCATION(LOCATION instance);
    partial void DeleteLOCATION(LOCATION instance);
    #endregion
		
		public MapDemoDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MapDemoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDemoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDemoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDemoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<USER> USERs
		{
			get
			{
				return this.GetTable<USER>();
			}
		}
		
		public System.Data.Linq.Table<LOCATION> LOCATIONs
		{
			get
			{
				return this.GetTable<LOCATION>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.USERS")]
	public partial class USER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _USERNAME;
		
		private string _PASSWORD;
		
		private string _FULLNAME;
		
		private string _ROLEID;
		
		private System.Nullable<bool> _ENABLED;
		
		private System.Nullable<int> _CAP;
		
		private string _MAPHONG;
		
		private string _CREATEBY;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private string _MODIFYBY;
		
		private System.Nullable<System.DateTime> _MODIFYDATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUSERNAMEChanging(string value);
    partial void OnUSERNAMEChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    partial void OnFULLNAMEChanging(string value);
    partial void OnFULLNAMEChanged();
    partial void OnROLEIDChanging(string value);
    partial void OnROLEIDChanged();
    partial void OnENABLEDChanging(System.Nullable<bool> value);
    partial void OnENABLEDChanged();
    partial void OnCAPChanging(System.Nullable<int> value);
    partial void OnCAPChanged();
    partial void OnMAPHONGChanging(string value);
    partial void OnMAPHONGChanged();
    partial void OnCREATEBYChanging(string value);
    partial void OnCREATEBYChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    partial void OnMODIFYBYChanging(string value);
    partial void OnMODIFYBYChanged();
    partial void OnMODIFYDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnMODIFYDATEChanged();
    #endregion
		
		public USER()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USERNAME", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string USERNAME
		{
			get
			{
				return this._USERNAME;
			}
			set
			{
				if ((this._USERNAME != value))
				{
					this.OnUSERNAMEChanging(value);
					this.SendPropertyChanging();
					this._USERNAME = value;
					this.SendPropertyChanged("USERNAME");
					this.OnUSERNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(50)")]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULLNAME", DbType="NVarChar(50)")]
		public string FULLNAME
		{
			get
			{
				return this._FULLNAME;
			}
			set
			{
				if ((this._FULLNAME != value))
				{
					this.OnFULLNAMEChanging(value);
					this.SendPropertyChanging();
					this._FULLNAME = value;
					this.SendPropertyChanged("FULLNAME");
					this.OnFULLNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLEID", DbType="VarChar(5)")]
		public string ROLEID
		{
			get
			{
				return this._ROLEID;
			}
			set
			{
				if ((this._ROLEID != value))
				{
					this.OnROLEIDChanging(value);
					this.SendPropertyChanging();
					this._ROLEID = value;
					this.SendPropertyChanged("ROLEID");
					this.OnROLEIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ENABLED", DbType="Bit")]
		public System.Nullable<bool> ENABLED
		{
			get
			{
				return this._ENABLED;
			}
			set
			{
				if ((this._ENABLED != value))
				{
					this.OnENABLEDChanging(value);
					this.SendPropertyChanging();
					this._ENABLED = value;
					this.SendPropertyChanged("ENABLED");
					this.OnENABLEDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAP", DbType="Int")]
		public System.Nullable<int> CAP
		{
			get
			{
				return this._CAP;
			}
			set
			{
				if ((this._CAP != value))
				{
					this.OnCAPChanging(value);
					this.SendPropertyChanging();
					this._CAP = value;
					this.SendPropertyChanged("CAP");
					this.OnCAPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAPHONG", DbType="VarChar(20)")]
		public string MAPHONG
		{
			get
			{
				return this._MAPHONG;
			}
			set
			{
				if ((this._MAPHONG != value))
				{
					this.OnMAPHONGChanging(value);
					this.SendPropertyChanging();
					this._MAPHONG = value;
					this.SendPropertyChanged("MAPHONG");
					this.OnMAPHONGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEBY", DbType="VarChar(50)")]
		public string CREATEBY
		{
			get
			{
				return this._CREATEBY;
			}
			set
			{
				if ((this._CREATEBY != value))
				{
					this.OnCREATEBYChanging(value);
					this.SendPropertyChanging();
					this._CREATEBY = value;
					this.SendPropertyChanged("CREATEBY");
					this.OnCREATEBYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MODIFYBY", DbType="VarChar(50)")]
		public string MODIFYBY
		{
			get
			{
				return this._MODIFYBY;
			}
			set
			{
				if ((this._MODIFYBY != value))
				{
					this.OnMODIFYBYChanging(value);
					this.SendPropertyChanging();
					this._MODIFYBY = value;
					this.SendPropertyChanged("MODIFYBY");
					this.OnMODIFYBYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MODIFYDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> MODIFYDATE
		{
			get
			{
				return this._MODIFYDATE;
			}
			set
			{
				if ((this._MODIFYDATE != value))
				{
					this.OnMODIFYDATEChanging(value);
					this.SendPropertyChanging();
					this._MODIFYDATE = value;
					this.SendPropertyChanged("MODIFYDATE");
					this.OnMODIFYDATEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LOCATION")]
	public partial class LOCATION : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<double> _X;
		
		private System.Nullable<double> _Y;
		
		private System.Nullable<int> _MUC;
		
		private string _MACHINHANH;
		
		private string _TENCHINHANH;
		
		private string _ADDRESS;
		
		private string _LOAICHINHANH;
		
		private string _TRUNGBAY;
		
		private string _TANSO;
		
		private string _DIENTHOAI;
		
		private string _CHUCHINHANH;
		
		private string _IMG;
		
		private int _STT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnXChanging(System.Nullable<double> value);
    partial void OnXChanged();
    partial void OnYChanging(System.Nullable<double> value);
    partial void OnYChanged();
    partial void OnMUCChanging(System.Nullable<int> value);
    partial void OnMUCChanged();
    partial void OnMACHINHANHChanging(string value);
    partial void OnMACHINHANHChanged();
    partial void OnTENCHINHANHChanging(string value);
    partial void OnTENCHINHANHChanged();
    partial void OnADDRESSChanging(string value);
    partial void OnADDRESSChanged();
    partial void OnLOAICHINHANHChanging(string value);
    partial void OnLOAICHINHANHChanged();
    partial void OnTRUNGBAYChanging(string value);
    partial void OnTRUNGBAYChanged();
    partial void OnTANSOChanging(string value);
    partial void OnTANSOChanged();
    partial void OnDIENTHOAIChanging(string value);
    partial void OnDIENTHOAIChanged();
    partial void OnCHUCHINHANHChanging(string value);
    partial void OnCHUCHINHANHChanged();
    partial void OnIMGChanging(string value);
    partial void OnIMGChanged();
    partial void OnSTTChanging(int value);
    partial void OnSTTChanged();
    #endregion
		
		public LOCATION()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_X", DbType="Float")]
		public System.Nullable<double> X
		{
			get
			{
				return this._X;
			}
			set
			{
				if ((this._X != value))
				{
					this.OnXChanging(value);
					this.SendPropertyChanging();
					this._X = value;
					this.SendPropertyChanged("X");
					this.OnXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Y", DbType="Float")]
		public System.Nullable<double> Y
		{
			get
			{
				return this._Y;
			}
			set
			{
				if ((this._Y != value))
				{
					this.OnYChanging(value);
					this.SendPropertyChanging();
					this._Y = value;
					this.SendPropertyChanged("Y");
					this.OnYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MUC", DbType="Int")]
		public System.Nullable<int> MUC
		{
			get
			{
				return this._MUC;
			}
			set
			{
				if ((this._MUC != value))
				{
					this.OnMUCChanging(value);
					this.SendPropertyChanging();
					this._MUC = value;
					this.SendPropertyChanged("MUC");
					this.OnMUCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MACHINHANH", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string MACHINHANH
		{
			get
			{
				return this._MACHINHANH;
			}
			set
			{
				if ((this._MACHINHANH != value))
				{
					this.OnMACHINHANHChanging(value);
					this.SendPropertyChanging();
					this._MACHINHANH = value;
					this.SendPropertyChanged("MACHINHANH");
					this.OnMACHINHANHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENCHINHANH", DbType="NVarChar(250)")]
		public string TENCHINHANH
		{
			get
			{
				return this._TENCHINHANH;
			}
			set
			{
				if ((this._TENCHINHANH != value))
				{
					this.OnTENCHINHANHChanging(value);
					this.SendPropertyChanging();
					this._TENCHINHANH = value;
					this.SendPropertyChanged("TENCHINHANH");
					this.OnTENCHINHANHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDRESS", DbType="NVarChar(500)")]
		public string ADDRESS
		{
			get
			{
				return this._ADDRESS;
			}
			set
			{
				if ((this._ADDRESS != value))
				{
					this.OnADDRESSChanging(value);
					this.SendPropertyChanging();
					this._ADDRESS = value;
					this.SendPropertyChanged("ADDRESS");
					this.OnADDRESSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOAICHINHANH", DbType="NVarChar(500)")]
		public string LOAICHINHANH
		{
			get
			{
				return this._LOAICHINHANH;
			}
			set
			{
				if ((this._LOAICHINHANH != value))
				{
					this.OnLOAICHINHANHChanging(value);
					this.SendPropertyChanging();
					this._LOAICHINHANH = value;
					this.SendPropertyChanged("LOAICHINHANH");
					this.OnLOAICHINHANHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRUNGBAY", DbType="NVarChar(500)")]
		public string TRUNGBAY
		{
			get
			{
				return this._TRUNGBAY;
			}
			set
			{
				if ((this._TRUNGBAY != value))
				{
					this.OnTRUNGBAYChanging(value);
					this.SendPropertyChanging();
					this._TRUNGBAY = value;
					this.SendPropertyChanged("TRUNGBAY");
					this.OnTRUNGBAYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TANSO", DbType="NVarChar(500)")]
		public string TANSO
		{
			get
			{
				return this._TANSO;
			}
			set
			{
				if ((this._TANSO != value))
				{
					this.OnTANSOChanging(value);
					this.SendPropertyChanging();
					this._TANSO = value;
					this.SendPropertyChanged("TANSO");
					this.OnTANSOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIENTHOAI", DbType="NVarChar(500)")]
		public string DIENTHOAI
		{
			get
			{
				return this._DIENTHOAI;
			}
			set
			{
				if ((this._DIENTHOAI != value))
				{
					this.OnDIENTHOAIChanging(value);
					this.SendPropertyChanging();
					this._DIENTHOAI = value;
					this.SendPropertyChanged("DIENTHOAI");
					this.OnDIENTHOAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHUCHINHANH", DbType="NVarChar(500)")]
		public string CHUCHINHANH
		{
			get
			{
				return this._CHUCHINHANH;
			}
			set
			{
				if ((this._CHUCHINHANH != value))
				{
					this.OnCHUCHINHANHChanging(value);
					this.SendPropertyChanging();
					this._CHUCHINHANH = value;
					this.SendPropertyChanged("CHUCHINHANH");
					this.OnCHUCHINHANHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IMG", DbType="NVarChar(500)")]
		public string IMG
		{
			get
			{
				return this._IMG;
			}
			set
			{
				if ((this._IMG != value))
				{
					this.OnIMGChanging(value);
					this.SendPropertyChanging();
					this._IMG = value;
					this.SendPropertyChanged("IMG");
					this.OnIMGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STT", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int STT
		{
			get
			{
				return this._STT;
			}
			set
			{
				if ((this._STT != value))
				{
					this.OnSTTChanging(value);
					this.SendPropertyChanging();
					this._STT = value;
					this.SendPropertyChanged("STT");
					this.OnSTTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
