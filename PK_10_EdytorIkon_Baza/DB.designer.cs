﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PK_10_EdytorIkon_Baza
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DatabaseIcon")]
	public partial class DBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPicture(Picture instance);
    partial void UpdatePicture(Picture instance);
    partial void DeletePicture(Picture instance);
    partial void InsertPixel(Pixel instance);
    partial void UpdatePixel(Pixel instance);
    partial void DeletePixel(Pixel instance);
    #endregion
		
		public DBDataContext() : 
				base(global::PK_10_EdytorIkon_Baza.Properties.Settings.Default.DatabaseIconConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Picture> Pictures
		{
			get
			{
				return this.GetTable<Picture>();
			}
		}
		
		public System.Data.Linq.Table<Pixel> Pixels
		{
			get
			{
				return this.GetTable<Pixel>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Picture")]
	public partial class Picture : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _Width;
		
		private int _Height;
		
		private EntitySet<Pixel> _Pixels;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnWidthChanging(int value);
    partial void OnWidthChanged();
    partial void OnHeightChanging(int value);
    partial void OnHeightChanged();
    #endregion
		
		public Picture()
		{
			this._Pixels = new EntitySet<Pixel>(new Action<Pixel>(this.attach_Pixels), new Action<Pixel>(this.detach_Pixels));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Width", DbType="Int NOT NULL")]
		public int Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				if ((this._Width != value))
				{
					this.OnWidthChanging(value);
					this.SendPropertyChanging();
					this._Width = value;
					this.SendPropertyChanged("Width");
					this.OnWidthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Int NOT NULL")]
		public int Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Pixel", Storage="_Pixels", ThisKey="Id", OtherKey="PictureId")]
		public EntitySet<Pixel> Pixels
		{
			get
			{
				return this._Pixels;
			}
			set
			{
				this._Pixels.Assign(value);
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
		
		private void attach_Pixels(Pixel entity)
		{
			this.SendPropertyChanging();
			entity.Picture = this;
		}
		
		private void detach_Pixels(Pixel entity)
		{
			this.SendPropertyChanging();
			entity.Picture = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pixel")]
	public partial class Pixel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _PosX;
		
		private int _PosY;
		
		private int _Color;
		
		private int _PictureId;
		
		private EntityRef<Picture> _Picture;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPosXChanging(int value);
    partial void OnPosXChanged();
    partial void OnPosYChanging(int value);
    partial void OnPosYChanged();
    partial void OnColorChanging(int value);
    partial void OnColorChanged();
    partial void OnPictureIdChanging(int value);
    partial void OnPictureIdChanged();
    #endregion
		
		public Pixel()
		{
			this._Picture = default(EntityRef<Picture>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PosX", DbType="Int NOT NULL")]
		public int PosX
		{
			get
			{
				return this._PosX;
			}
			set
			{
				if ((this._PosX != value))
				{
					this.OnPosXChanging(value);
					this.SendPropertyChanging();
					this._PosX = value;
					this.SendPropertyChanged("PosX");
					this.OnPosXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PosY", DbType="Int NOT NULL")]
		public int PosY
		{
			get
			{
				return this._PosY;
			}
			set
			{
				if ((this._PosY != value))
				{
					this.OnPosYChanging(value);
					this.SendPropertyChanging();
					this._PosY = value;
					this.SendPropertyChanged("PosY");
					this.OnPosYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="Int NOT NULL")]
		public int Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._Color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PictureId", DbType="Int NOT NULL")]
		public int PictureId
		{
			get
			{
				return this._PictureId;
			}
			set
			{
				if ((this._PictureId != value))
				{
					if (this._Picture.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPictureIdChanging(value);
					this.SendPropertyChanging();
					this._PictureId = value;
					this.SendPropertyChanged("PictureId");
					this.OnPictureIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Pixel", Storage="_Picture", ThisKey="PictureId", OtherKey="Id", IsForeignKey=true)]
		public Picture Picture
		{
			get
			{
				return this._Picture.Entity;
			}
			set
			{
				Picture previousValue = this._Picture.Entity;
				if (((previousValue != value) 
							|| (this._Picture.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Picture.Entity = null;
						previousValue.Pixels.Remove(this);
					}
					this._Picture.Entity = value;
					if ((value != null))
					{
						value.Pixels.Add(this);
						this._PictureId = value.Id;
					}
					else
					{
						this._PictureId = default(int);
					}
					this.SendPropertyChanged("Picture");
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
