/*
				   File: type_SdtSDT_NotificationGroup_SDT_NotificationGroupItem
			Description: SDT_NotificationGroup
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
	[XmlRoot(ElementName="SDT_NotificationGroupItem")]
	[XmlType(TypeName="SDT_NotificationGroupItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_NotificationGroup_SDT_NotificationGroupItem : GxUserType
	{
		public SdtSDT_NotificationGroup_SDT_NotificationGroupItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationiconclass = "";

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationtitle = "";

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdescription = "";

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationlink = "";

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Parentlinkid = "";

		}

		public SdtSDT_NotificationGroup_SDT_NotificationGroupItem(IGxContext context)
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
			AddObjectProperty("NotificationId", gxTpr_Notificationid, false);


			AddObjectProperty("NotificationIconClass", gxTpr_Notificationiconclass, false);


			AddObjectProperty("NotificationTitle", gxTpr_Notificationtitle, false);


			AddObjectProperty("NotificationDescription", gxTpr_Notificationdescription, false);


			datetime_STZ = gxTpr_Notificationdatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NotificationDatetime", sDateCnv, false);



			AddObjectProperty("NotificationLink", gxTpr_Notificationlink, false);


			AddObjectProperty("isParent", gxTpr_Isparent, false);


			AddObjectProperty("ParentLinkId", gxTpr_Parentlinkid, false);


			AddObjectProperty("NumberOfChildNotifications", gxTpr_Numberofchildnotifications, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotificationId")]
		[XmlElement(ElementName="NotificationId")]
		public int gxTpr_Notificationid
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationid; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationid = value;
				SetDirty("Notificationid");
			}
		}




		[SoapElement(ElementName="NotificationIconClass")]
		[XmlElement(ElementName="NotificationIconClass")]
		public string gxTpr_Notificationiconclass
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationiconclass; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationiconclass = value;
				SetDirty("Notificationiconclass");
			}
		}




		[SoapElement(ElementName="NotificationTitle")]
		[XmlElement(ElementName="NotificationTitle")]
		public string gxTpr_Notificationtitle
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationtitle; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationtitle = value;
				SetDirty("Notificationtitle");
			}
		}




		[SoapElement(ElementName="NotificationDescription")]
		[XmlElement(ElementName="NotificationDescription")]
		public string gxTpr_Notificationdescription
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdescription; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdescription = value;
				SetDirty("Notificationdescription");
			}
		}



		[SoapElement(ElementName="NotificationDatetime")]
		[XmlElement(ElementName="NotificationDatetime" , IsNullable=true)]
		public string gxTpr_Notificationdatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime).value ;
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Notificationdatetime
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime = value;
				SetDirty("Notificationdatetime");
			}
		}



		[SoapElement(ElementName="NotificationLink")]
		[XmlElement(ElementName="NotificationLink")]
		public string gxTpr_Notificationlink
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationlink; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationlink = value;
				SetDirty("Notificationlink");
			}
		}




		[SoapElement(ElementName="isParent")]
		[XmlElement(ElementName="isParent")]
		public bool gxTpr_Isparent
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Isparent; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Isparent = value;
				SetDirty("Isparent");
			}
		}




		[SoapElement(ElementName="ParentLinkId")]
		[XmlElement(ElementName="ParentLinkId")]
		public string gxTpr_Parentlinkid
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Parentlinkid; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Parentlinkid = value;
				SetDirty("Parentlinkid");
			}
		}




		[SoapElement(ElementName="NumberOfChildNotifications")]
		[XmlElement(ElementName="NumberOfChildNotifications")]
		public short gxTpr_Numberofchildnotifications
		{
			get {
				return gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Numberofchildnotifications; 
			}
			set {
				gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Numberofchildnotifications = value;
				SetDirty("Numberofchildnotifications");
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
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationiconclass = "";
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationtitle = "";
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdescription = "";
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationlink = "";

			gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Parentlinkid = "";

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected int gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationid;
		 

		protected string gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationiconclass;
		 

		protected string gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationtitle;
		 

		protected string gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdescription;
		 

		protected DateTime gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationdatetime;
		 

		protected string gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Notificationlink;
		 

		protected bool gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Isparent;
		 

		protected string gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Parentlinkid;
		 

		protected short gxTv_SdtSDT_NotificationGroup_SDT_NotificationGroupItem_Numberofchildnotifications;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_NotificationGroupItem", Namespace="Comforta_version2")]
	public class SdtSDT_NotificationGroup_SDT_NotificationGroupItem_RESTInterface : GxGenericCollectionItem<SdtSDT_NotificationGroup_SDT_NotificationGroupItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NotificationGroup_SDT_NotificationGroupItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NotificationGroup_SDT_NotificationGroupItem_RESTInterface( SdtSDT_NotificationGroup_SDT_NotificationGroupItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NotificationId", Order=0)]
		public int gxTpr_Notificationid
		{
			get { 
				return sdt.gxTpr_Notificationid;

			}
			set { 
				sdt.gxTpr_Notificationid = value;
			}
		}

		[DataMember(Name="NotificationIconClass", Order=1)]
		public  string gxTpr_Notificationiconclass
		{
			get { 
				return sdt.gxTpr_Notificationiconclass;

			}
			set { 
				 sdt.gxTpr_Notificationiconclass = value;
			}
		}

		[DataMember(Name="NotificationTitle", Order=2)]
		public  string gxTpr_Notificationtitle
		{
			get { 
				return sdt.gxTpr_Notificationtitle;

			}
			set { 
				 sdt.gxTpr_Notificationtitle = value;
			}
		}

		[DataMember(Name="NotificationDescription", Order=3)]
		public  string gxTpr_Notificationdescription
		{
			get { 
				return sdt.gxTpr_Notificationdescription;

			}
			set { 
				 sdt.gxTpr_Notificationdescription = value;
			}
		}

		[DataMember(Name="NotificationDatetime", Order=4)]
		public  string gxTpr_Notificationdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Notificationdatetime,context);

			}
			set { 
				sdt.gxTpr_Notificationdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="NotificationLink", Order=5)]
		public  string gxTpr_Notificationlink
		{
			get { 
				return sdt.gxTpr_Notificationlink;

			}
			set { 
				 sdt.gxTpr_Notificationlink = value;
			}
		}

		[DataMember(Name="isParent", Order=6)]
		public bool gxTpr_Isparent
		{
			get { 
				return sdt.gxTpr_Isparent;

			}
			set { 
				sdt.gxTpr_Isparent = value;
			}
		}

		[DataMember(Name="ParentLinkId", Order=7)]
		public  string gxTpr_Parentlinkid
		{
			get { 
				return sdt.gxTpr_Parentlinkid;

			}
			set { 
				 sdt.gxTpr_Parentlinkid = value;
			}
		}

		[DataMember(Name="NumberOfChildNotifications", Order=8)]
		public short gxTpr_Numberofchildnotifications
		{
			get { 
				return sdt.gxTpr_Numberofchildnotifications;

			}
			set { 
				sdt.gxTpr_Numberofchildnotifications = value;
			}
		}


		#endregion

		public SdtSDT_NotificationGroup_SDT_NotificationGroupItem sdt
		{
			get { 
				return (SdtSDT_NotificationGroup_SDT_NotificationGroupItem)Sdt;
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
				sdt = new SdtSDT_NotificationGroup_SDT_NotificationGroupItem() ;
			}
		}
	}
	#endregion
}