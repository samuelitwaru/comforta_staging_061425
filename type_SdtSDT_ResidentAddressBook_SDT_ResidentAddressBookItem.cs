/*
				   File: type_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem
			Description: SDT_ResidentAddressBook
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
	[XmlRoot(ElementName="SDT_ResidentAddressBookItem")]
	[XmlType(TypeName="SDT_ResidentAddressBookItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem : GxUserType
	{
		public SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentgivenname = "";

			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentlastname = "";

			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentfullname = "";

		}

		public SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem(IGxContext context)
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
			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentFullName", gxTpr_Residentfullname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentid; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Locationid; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Organisationid; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentgivenname; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentlastname; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentFullName")]
		[XmlElement(ElementName="ResidentFullName")]
		public string gxTpr_Residentfullname
		{
			get {
				return gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentfullname; 
			}
			set {
				gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentfullname = value;
				SetDirty("Residentfullname");
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
			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentgivenname = "";
			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentlastname = "";
			gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentfullname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentid;
		 

		protected Guid gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Locationid;
		 

		protected Guid gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Organisationid;
		 

		protected string gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentgivenname;
		 

		protected string gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentlastname;
		 

		protected string gxTv_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_Residentfullname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ResidentAddressBookItem", Namespace="Comforta_version2")]
	public class SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem_RESTInterface( SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentId", Order=0)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="LocationId", Order=1)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=2)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=3)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=4)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentFullName", Order=5)]
		public  string gxTpr_Residentfullname
		{
			get { 
				return sdt.gxTpr_Residentfullname;

			}
			set { 
				 sdt.gxTpr_Residentfullname = value;
			}
		}


		#endregion

		public SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem sdt
		{
			get { 
				return (SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem)Sdt;
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
				sdt = new SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem() ;
			}
		}
	}
	#endregion
}