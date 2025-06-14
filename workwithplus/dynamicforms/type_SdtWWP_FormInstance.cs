using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   [XmlRoot(ElementName = "WWP_FormInstance" )]
   [XmlType(TypeName =  "WWP_FormInstance" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtWWP_FormInstance : GxSilentTrnSdt
   {
      public SdtWWP_FormInstance( )
      {
      }

      public SdtWWP_FormInstance( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV214WWPFormInstanceId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV214WWPFormInstanceId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPFormInstanceId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WorkWithPlus\\DynamicForms\\WWP_FormInstance");
         metadata.Set("BT", "WWP_FormInstance");
         metadata.Set("PK", "[ \"WWPFormInstanceId\" ]");
         metadata.Set("PKAssigned", "[ \"WWPFormInstanceId\" ]");
         metadata.Set("Levels", "[ \"Element\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WWPFormId\",\"WWPFormVersionNumber\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPUserExtendedId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpforminstanceid_Z");
         state.Add("gxTpr_Wwpforminstancedate_Z_Nullable");
         state.Add("gxTpr_Wwpformid_Z");
         state.Add("gxTpr_Wwpformreferencename_Z");
         state.Add("gxTpr_Wwpformversionnumber_Z");
         state.Add("gxTpr_Wwpformtitle_Z");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedfullname_Z");
         state.Add("gxTpr_Wwpformresume_Z");
         state.Add("gxTpr_Wwpforminstancerecordkey_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance sdt;
         sdt = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)(source);
         gxTv_SdtWWP_FormInstance_Wwpforminstanceid = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstanceid ;
         gxTv_SdtWWP_FormInstance_Wwpforminstancedate = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancedate ;
         gxTv_SdtWWP_FormInstance_Wwpformid = sdt.gxTv_SdtWWP_FormInstance_Wwpformid ;
         gxTv_SdtWWP_FormInstance_Wwpformreferencename = sdt.gxTv_SdtWWP_FormInstance_Wwpformreferencename ;
         gxTv_SdtWWP_FormInstance_Wwpformversionnumber = sdt.gxTv_SdtWWP_FormInstance_Wwpformversionnumber ;
         gxTv_SdtWWP_FormInstance_Wwpformtitle = sdt.gxTv_SdtWWP_FormInstance_Wwpformtitle ;
         gxTv_SdtWWP_FormInstance_Wwpuserextendedid = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedid ;
         gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname ;
         gxTv_SdtWWP_FormInstance_Wwpformresume = sdt.gxTv_SdtWWP_FormInstance_Wwpformresume ;
         gxTv_SdtWWP_FormInstance_Wwpformvalidations = sdt.gxTv_SdtWWP_FormInstance_Wwpformvalidations ;
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey ;
         gxTv_SdtWWP_FormInstance_Element = sdt.gxTv_SdtWWP_FormInstance_Element ;
         gxTv_SdtWWP_FormInstance_Mode = sdt.gxTv_SdtWWP_FormInstance_Mode ;
         gxTv_SdtWWP_FormInstance_Initialized = sdt.gxTv_SdtWWP_FormInstance_Initialized ;
         gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z ;
         gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z ;
         gxTv_SdtWWP_FormInstance_Wwpformid_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpformid_Z ;
         gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z ;
         gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z ;
         gxTv_SdtWWP_FormInstance_Wwpformtitle_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpformtitle_Z ;
         gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z ;
         gxTv_SdtWWP_FormInstance_Wwpformresume_Z = sdt.gxTv_SdtWWP_FormInstance_Wwpformresume_Z ;
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("WWPFormInstanceId", gxTv_SdtWWP_FormInstance_Wwpforminstanceid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_FormInstance_Wwpforminstancedate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WWPFormInstanceDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormId", gxTv_SdtWWP_FormInstance_Wwpformid, false, includeNonInitialized);
         AddObjectProperty("WWPFormReferenceName", gxTv_SdtWWP_FormInstance_Wwpformreferencename, false, includeNonInitialized);
         AddObjectProperty("WWPFormVersionNumber", gxTv_SdtWWP_FormInstance_Wwpformversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormTitle", gxTv_SdtWWP_FormInstance_Wwpformtitle, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_FormInstance_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedFullName", gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname, false, includeNonInitialized);
         AddObjectProperty("WWPFormResume", gxTv_SdtWWP_FormInstance_Wwpformresume, false, includeNonInitialized);
         AddObjectProperty("WWPFormValidations", gxTv_SdtWWP_FormInstance_Wwpformvalidations, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceRecordKey", gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstanceRecordKey_N", gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N, false, includeNonInitialized);
         if ( gxTv_SdtWWP_FormInstance_Element != null )
         {
            AddObjectProperty("Element", gxTv_SdtWWP_FormInstance_Element, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_FormInstance_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_FormInstance_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceId_Z", gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WWPFormInstanceDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPFormId_Z", gxTv_SdtWWP_FormInstance_Wwpformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormReferenceName_Z", gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormVersionNumber_Z", gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormTitle_Z", gxTv_SdtWWP_FormInstance_Wwpformtitle_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedFullName_Z", gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormResume_Z", gxTv_SdtWWP_FormInstance_Wwpformresume_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstanceRecordKey_N", gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance sdt )
      {
         if ( sdt.IsDirty("WWPFormInstanceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstanceid = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstanceid ;
         }
         if ( sdt.IsDirty("WWPFormInstanceDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancedate = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancedate ;
         }
         if ( sdt.IsDirty("WWPFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformid = sdt.gxTv_SdtWWP_FormInstance_Wwpformid ;
         }
         if ( sdt.IsDirty("WWPFormReferenceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformreferencename = sdt.gxTv_SdtWWP_FormInstance_Wwpformreferencename ;
         }
         if ( sdt.IsDirty("WWPFormVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformversionnumber = sdt.gxTv_SdtWWP_FormInstance_Wwpformversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformtitle = sdt.gxTv_SdtWWP_FormInstance_Wwpformtitle ;
         }
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedid = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedid ;
         }
         if ( sdt.IsDirty("WWPUserExtendedFullName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname ;
         }
         if ( sdt.IsDirty("WWPFormResume") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformresume = sdt.gxTv_SdtWWP_FormInstance_Wwpformresume ;
         }
         if ( sdt.IsDirty("WWPFormValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformvalidations = sdt.gxTv_SdtWWP_FormInstance_Wwpformvalidations ;
         }
         if ( sdt.IsDirty("WWPFormInstanceRecordKey") )
         {
            gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = (short)(sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey = sdt.gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey ;
         }
         if ( gxTv_SdtWWP_FormInstance_Element != null )
         {
            GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element> newCollectionElement = sdt.gxTpr_Element;
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element currItemElement;
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element newItemElement;
            short idx = 1;
            while ( idx <= newCollectionElement.Count )
            {
               newItemElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)newCollectionElement.Item(idx));
               currItemElement = gxTv_SdtWWP_FormInstance_Element.GetByKey(newItemElement.gxTpr_Wwpformelementid, newItemElement.gxTpr_Wwpforminstanceelementid);
               if ( StringUtil.StrCmp(currItemElement.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemElement.UpdateDirties(newItemElement);
                  if ( StringUtil.StrCmp(newItemElement.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemElement.gxTpr_Mode = "DLT";
                  }
                  currItemElement.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtWWP_FormInstance_Element.Add(newItemElement, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceId" )]
      [  XmlElement( ElementName = "WWPFormInstanceId"   )]
      public int gxTpr_Wwpforminstanceid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstanceid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWWP_FormInstance_Wwpforminstanceid != value )
            {
               gxTv_SdtWWP_FormInstance_Mode = "INS";
               this.gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpformid_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z_SetNull( );
               this.gxTv_SdtWWP_FormInstance_Wwpformresume_Z_SetNull( );
               if ( gxTv_SdtWWP_FormInstance_Element != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element> collectionElement = gxTv_SdtWWP_FormInstance_Element;
                  GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element currItemElement;
                  short idx = 1;
                  while ( idx <= collectionElement.Count )
                  {
                     currItemElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)collectionElement.Item(idx));
                     currItemElement.gxTpr_Mode = "INS";
                     currItemElement.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtWWP_FormInstance_Wwpforminstanceid = value;
            SetDirty("Wwpforminstanceid");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceDate" )]
      [  XmlElement( ElementName = "WWPFormInstanceDate"  , IsNullable=true )]
      public string gxTpr_Wwpforminstancedate_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Wwpforminstancedate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_FormInstance_Wwpforminstancedate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_FormInstance_Wwpforminstancedate = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Wwpforminstancedate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstancedate
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstancedate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancedate = value;
            SetDirty("Wwpforminstancedate");
         }

      }

      [  SoapElement( ElementName = "WWPFormId" )]
      [  XmlElement( ElementName = "WWPFormId"   )]
      public short gxTpr_Wwpformid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformid = value;
            SetDirty("Wwpformid");
         }

      }

      [  SoapElement( ElementName = "WWPFormReferenceName" )]
      [  XmlElement( ElementName = "WWPFormReferenceName"   )]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformreferencename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformreferencename = value;
            SetDirty("Wwpformreferencename");
         }

      }

      [  SoapElement( ElementName = "WWPFormVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber"   )]
      public short gxTpr_Wwpformversionnumber
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformversionnumber = value;
            SetDirty("Wwpformversionnumber");
         }

      }

      [  SoapElement( ElementName = "WWPFormTitle" )]
      [  XmlElement( ElementName = "WWPFormTitle"   )]
      public string gxTpr_Wwpformtitle
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformtitle = value;
            SetDirty("Wwpformtitle");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpuserextendedid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName"   )]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname = value;
            SetDirty("Wwpuserextendedfullname");
         }

      }

      [  SoapElement( ElementName = "WWPFormResume" )]
      [  XmlElement( ElementName = "WWPFormResume"   )]
      public short gxTpr_Wwpformresume
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformresume ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformresume = value;
            SetDirty("Wwpformresume");
         }

      }

      [  SoapElement( ElementName = "WWPFormValidations" )]
      [  XmlElement( ElementName = "WWPFormValidations"   )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformvalidations = value;
            SetDirty("Wwpformvalidations");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstanceRecordKey" )]
      [  XmlElement( ElementName = "WWPFormInstanceRecordKey"   )]
      public string gxTpr_Wwpforminstancerecordkey
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey ;
         }

         set {
            gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey = value;
            SetDirty("Wwpforminstancerecordkey");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = 1;
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey = "";
         SetDirty("Wwpforminstancerecordkey");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_IsNull( )
      {
         return (gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N==1) ;
      }

      [  SoapElement( ElementName = "Element" )]
      [  XmlArray( ElementName = "Element"  )]
      [  XmlArrayItemAttribute( ElementName= "WWP_FormInstance.Element"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element> gxTpr_Element_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element == null )
            {
               gxTv_SdtWWP_FormInstance_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element>( context, "WWP_FormInstance.Element", "Comforta_version21");
            }
            return gxTv_SdtWWP_FormInstance_Element ;
         }

         set {
            if ( gxTv_SdtWWP_FormInstance_Element == null )
            {
               gxTv_SdtWWP_FormInstance_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element>( context, "WWP_FormInstance.Element", "Comforta_version21");
            }
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element> gxTpr_Element
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Element == null )
            {
               gxTv_SdtWWP_FormInstance_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element>( context, "WWP_FormInstance.Element", "Comforta_version21");
            }
            sdtIsNull = 0;
            return gxTv_SdtWWP_FormInstance_Element ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Element = value;
            SetDirty("Element");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Element_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Element = null;
         SetDirty("Element");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Element_IsNull( )
      {
         if ( gxTv_SdtWWP_FormInstance_Element == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_FormInstance_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Mode_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_FormInstance_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Initialized_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceId_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceId_Z"   )]
      public int gxTpr_Wwpforminstanceid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z = value;
            SetDirty("Wwpforminstanceid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z = 0;
         SetDirty("Wwpforminstanceid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceDate_Z" )]
      [  XmlElement( ElementName = "WWPFormInstanceDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpforminstancedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpforminstancedate_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = value;
            SetDirty("Wwpforminstancedate_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpforminstancedate_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormId_Z" )]
      [  XmlElement( ElementName = "WWPFormId_Z"   )]
      public short gxTpr_Wwpformid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformid_Z = value;
            SetDirty("Wwpformid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpformid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpformid_Z = 0;
         SetDirty("Wwpformid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormReferenceName_Z" )]
      [  XmlElement( ElementName = "WWPFormReferenceName_Z"   )]
      public string gxTpr_Wwpformreferencename_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z = value;
            SetDirty("Wwpformreferencename_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z = "";
         SetDirty("Wwpformreferencename_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber_Z"   )]
      public short gxTpr_Wwpformversionnumber_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z = value;
            SetDirty("Wwpformversionnumber_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z = 0;
         SetDirty("Wwpformversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormTitle_Z" )]
      [  XmlElement( ElementName = "WWPFormTitle_Z"   )]
      public string gxTpr_Wwpformtitle_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformtitle_Z = value;
            SetDirty("Wwpformtitle_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpformtitle_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpformtitle_Z = "";
         SetDirty("Wwpformtitle_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpformtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z = "";
         SetDirty("Wwpuserextendedid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName_Z"   )]
      public string gxTpr_Wwpuserextendedfullname_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z = value;
            SetDirty("Wwpuserextendedfullname_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z = "";
         SetDirty("Wwpuserextendedfullname_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormResume_Z" )]
      [  XmlElement( ElementName = "WWPFormResume_Z"   )]
      public short gxTpr_Wwpformresume_Z
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpformresume_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpformresume_Z = value;
            SetDirty("Wwpformresume_Z");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpformresume_Z_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpformresume_Z = 0;
         SetDirty("Wwpformresume_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpformresume_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstanceRecordKey_N" )]
      [  XmlElement( ElementName = "WWPFormInstanceRecordKey_N"   )]
      public short gxTpr_Wwpforminstancerecordkey_N
      {
         get {
            return gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = value;
            SetDirty("Wwpforminstancerecordkey_N");
         }

      }

      public void gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N_SetNull( )
      {
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N = 0;
         SetDirty("Wwpforminstancerecordkey_N");
         return  ;
      }

      public bool gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtWWP_FormInstance_Wwpforminstancedate = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_FormInstance_Wwpformreferencename = "";
         gxTv_SdtWWP_FormInstance_Wwpformtitle = "";
         gxTv_SdtWWP_FormInstance_Wwpuserextendedid = "";
         gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname = "";
         gxTv_SdtWWP_FormInstance_Wwpformvalidations = "";
         gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey = "";
         gxTv_SdtWWP_FormInstance_Mode = "";
         gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z = "";
         gxTv_SdtWWP_FormInstance_Wwpformtitle_Z = "";
         gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z = "";
         gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "workwithplus.dynamicforms.wwp_forminstance", "GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtWWP_FormInstance_Wwpformid ;
      private short gxTv_SdtWWP_FormInstance_Wwpformversionnumber ;
      private short gxTv_SdtWWP_FormInstance_Wwpformresume ;
      private short gxTv_SdtWWP_FormInstance_Initialized ;
      private short gxTv_SdtWWP_FormInstance_Wwpformid_Z ;
      private short gxTv_SdtWWP_FormInstance_Wwpformversionnumber_Z ;
      private short gxTv_SdtWWP_FormInstance_Wwpformresume_Z ;
      private short gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey_N ;
      private int gxTv_SdtWWP_FormInstance_Wwpforminstanceid ;
      private int gxTv_SdtWWP_FormInstance_Wwpforminstanceid_Z ;
      private string gxTv_SdtWWP_FormInstance_Wwpuserextendedid ;
      private string gxTv_SdtWWP_FormInstance_Mode ;
      private string gxTv_SdtWWP_FormInstance_Wwpuserextendedid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_FormInstance_Wwpforminstancedate ;
      private DateTime gxTv_SdtWWP_FormInstance_Wwpforminstancedate_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtWWP_FormInstance_Wwpformvalidations ;
      private string gxTv_SdtWWP_FormInstance_Wwpforminstancerecordkey ;
      private string gxTv_SdtWWP_FormInstance_Wwpformreferencename ;
      private string gxTv_SdtWWP_FormInstance_Wwpformtitle ;
      private string gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname ;
      private string gxTv_SdtWWP_FormInstance_Wwpformreferencename_Z ;
      private string gxTv_SdtWWP_FormInstance_Wwpformtitle_Z ;
      private string gxTv_SdtWWP_FormInstance_Wwpuserextendedfullname_Z ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element> gxTv_SdtWWP_FormInstance_Element=null ;
   }

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_FormInstance", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_FormInstance_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance>
   {
      public SdtWWP_FormInstance_RESTInterface( ) : base()
      {
      }

      public SdtWWP_FormInstance_RESTInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormInstanceId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Wwpforminstanceid
      {
         get {
            return sdt.gxTpr_Wwpforminstanceid ;
         }

         set {
            sdt.gxTpr_Wwpforminstanceid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormInstanceDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Wwpforminstancedate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpforminstancedate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpforminstancedate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPFormId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformid
      {
         get {
            return sdt.gxTpr_Wwpformid ;
         }

         set {
            sdt.gxTpr_Wwpformid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormReferenceName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return sdt.gxTpr_Wwpformreferencename ;
         }

         set {
            sdt.gxTpr_Wwpformreferencename = value;
         }

      }

      [DataMember( Name = "WWPFormVersionNumber" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormTitle" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpformtitle
      {
         get {
            return sdt.gxTpr_Wwpformtitle ;
         }

         set {
            sdt.gxTpr_Wwpformtitle = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedid) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedid = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedFullName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return sdt.gxTpr_Wwpuserextendedfullname ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedfullname = value;
         }

      }

      [DataMember( Name = "WWPFormResume" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformresume
      {
         get {
            return sdt.gxTpr_Wwpformresume ;
         }

         set {
            sdt.gxTpr_Wwpformresume = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormValidations" , Order = 9 )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return sdt.gxTpr_Wwpformvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformvalidations = value;
         }

      }

      [DataMember( Name = "WWPFormInstanceRecordKey" , Order = 10 )]
      public string gxTpr_Wwpforminstancerecordkey
      {
         get {
            return sdt.gxTpr_Wwpforminstancerecordkey ;
         }

         set {
            sdt.gxTpr_Wwpforminstancerecordkey = value;
         }

      }

      [DataMember( Name = "Element" , Order = 11 )]
      public GxGenericCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element_RESTInterface> gxTpr_Element
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element_RESTInterface>(sdt.gxTpr_Element) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Element);
         }

      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 12 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_FormInstance", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_FormInstance_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance>
   {
      public SdtWWP_FormInstance_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_FormInstance_RESTLInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormInstanceDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpforminstancedate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpforminstancedate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpforminstancedate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance() ;
         }
      }

   }

}
