/*
				   File: type_SdtSDT_PageChildren
			Description: SDT_PageChildren
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_PageChildren")]
	[XmlType(TypeName="SDT_PageChildren" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_PageChildren : GxUserType
	{
		public SdtSDT_PageChildren( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageChildren_Name = "";

		}

		public SdtSDT_PageChildren(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public Guid gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_PageChildren_Id; 
			}
			set {
				gxTv_SdtSDT_PageChildren_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDT_PageChildren_Name; 
			}
			set {
				gxTv_SdtSDT_PageChildren_Name = value;
				SetDirty("Name");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_PageChildren_Name = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_PageChildren_Id;
		 

		protected string gxTv_SdtSDT_PageChildren_Name;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PageChildren", Namespace="Comforta_version21")]
	public class SdtSDT_PageChildren_RESTInterface : GxGenericCollectionItem<SdtSDT_PageChildren>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageChildren_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageChildren_RESTInterface( SdtSDT_PageChildren psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public Guid gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}


		#endregion

		public SdtSDT_PageChildren sdt
		{
			get { 
				return (SdtSDT_PageChildren)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_PageChildren() ;
			}
		}
	}
	#endregion
}