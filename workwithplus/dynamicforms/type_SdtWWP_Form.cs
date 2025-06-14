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
   [XmlRoot(ElementName = "WWP_Form" )]
   [XmlType(TypeName =  "WWP_Form" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtWWP_Form : GxSilentTrnSdt
   {
      public SdtWWP_Form( )
      {
      }

      public SdtWWP_Form( IGxContext context )
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

      public void Load( short AV206WWPFormId ,
                        short AV207WWPFormVersionNumber )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV206WWPFormId,(short)AV207WWPFormVersionNumber});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPFormId", typeof(short)}, new Object[]{"WWPFormVersionNumber", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WorkWithPlus\\DynamicForms\\WWP_Form");
         metadata.Set("BT", "WWP_Form");
         metadata.Set("PK", "[ \"WWPFormId\",\"WWPFormVersionNumber\" ]");
         metadata.Set("Levels", "[ \"Element\" ]");
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
         state.Add("gxTpr_Wwpformid_Z");
         state.Add("gxTpr_Wwpformversionnumber_Z");
         state.Add("gxTpr_Wwpformreferencename_Z");
         state.Add("gxTpr_Wwpformtitle_Z");
         state.Add("gxTpr_Wwpformdate_Z_Nullable");
         state.Add("gxTpr_Wwpformiswizard_Z");
         state.Add("gxTpr_Wwpformresume_Z");
         state.Add("gxTpr_Wwpforminstantiated_Z");
         state.Add("gxTpr_Wwpformlatestversionnumber_Z");
         state.Add("gxTpr_Wwpformtype_Z");
         state.Add("gxTpr_Wwpformsectionrefelements_Z");
         state.Add("gxTpr_Wwpformisfordynamicvalidations_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form sdt;
         sdt = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)(source);
         gxTv_SdtWWP_Form_Wwpformid = sdt.gxTv_SdtWWP_Form_Wwpformid ;
         gxTv_SdtWWP_Form_Wwpformversionnumber = sdt.gxTv_SdtWWP_Form_Wwpformversionnumber ;
         gxTv_SdtWWP_Form_Wwpformreferencename = sdt.gxTv_SdtWWP_Form_Wwpformreferencename ;
         gxTv_SdtWWP_Form_Wwpformtitle = sdt.gxTv_SdtWWP_Form_Wwpformtitle ;
         gxTv_SdtWWP_Form_Wwpformdate = sdt.gxTv_SdtWWP_Form_Wwpformdate ;
         gxTv_SdtWWP_Form_Wwpformiswizard = sdt.gxTv_SdtWWP_Form_Wwpformiswizard ;
         gxTv_SdtWWP_Form_Wwpformresume = sdt.gxTv_SdtWWP_Form_Wwpformresume ;
         gxTv_SdtWWP_Form_Wwpformresumemessage = sdt.gxTv_SdtWWP_Form_Wwpformresumemessage ;
         gxTv_SdtWWP_Form_Wwpformvalidations = sdt.gxTv_SdtWWP_Form_Wwpformvalidations ;
         gxTv_SdtWWP_Form_Wwpforminstantiated = sdt.gxTv_SdtWWP_Form_Wwpforminstantiated ;
         gxTv_SdtWWP_Form_Wwpformlatestversionnumber = sdt.gxTv_SdtWWP_Form_Wwpformlatestversionnumber ;
         gxTv_SdtWWP_Form_Wwpformtype = sdt.gxTv_SdtWWP_Form_Wwpformtype ;
         gxTv_SdtWWP_Form_Wwpformsectionrefelements = sdt.gxTv_SdtWWP_Form_Wwpformsectionrefelements ;
         gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations = sdt.gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations ;
         gxTv_SdtWWP_Form_Element = sdt.gxTv_SdtWWP_Form_Element ;
         gxTv_SdtWWP_Form_Mode = sdt.gxTv_SdtWWP_Form_Mode ;
         gxTv_SdtWWP_Form_Initialized = sdt.gxTv_SdtWWP_Form_Initialized ;
         gxTv_SdtWWP_Form_Wwpformid_Z = sdt.gxTv_SdtWWP_Form_Wwpformid_Z ;
         gxTv_SdtWWP_Form_Wwpformversionnumber_Z = sdt.gxTv_SdtWWP_Form_Wwpformversionnumber_Z ;
         gxTv_SdtWWP_Form_Wwpformreferencename_Z = sdt.gxTv_SdtWWP_Form_Wwpformreferencename_Z ;
         gxTv_SdtWWP_Form_Wwpformtitle_Z = sdt.gxTv_SdtWWP_Form_Wwpformtitle_Z ;
         gxTv_SdtWWP_Form_Wwpformdate_Z = sdt.gxTv_SdtWWP_Form_Wwpformdate_Z ;
         gxTv_SdtWWP_Form_Wwpformiswizard_Z = sdt.gxTv_SdtWWP_Form_Wwpformiswizard_Z ;
         gxTv_SdtWWP_Form_Wwpformresume_Z = sdt.gxTv_SdtWWP_Form_Wwpformresume_Z ;
         gxTv_SdtWWP_Form_Wwpforminstantiated_Z = sdt.gxTv_SdtWWP_Form_Wwpforminstantiated_Z ;
         gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z = sdt.gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z ;
         gxTv_SdtWWP_Form_Wwpformtype_Z = sdt.gxTv_SdtWWP_Form_Wwpformtype_Z ;
         gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z = sdt.gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z ;
         gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z = sdt.gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z ;
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
         AddObjectProperty("WWPFormId", gxTv_SdtWWP_Form_Wwpformid, false, includeNonInitialized);
         AddObjectProperty("WWPFormVersionNumber", gxTv_SdtWWP_Form_Wwpformversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormReferenceName", gxTv_SdtWWP_Form_Wwpformreferencename, false, includeNonInitialized);
         AddObjectProperty("WWPFormTitle", gxTv_SdtWWP_Form_Wwpformtitle, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_Form_Wwpformdate;
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
         AddObjectProperty("WWPFormDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsWizard", gxTv_SdtWWP_Form_Wwpformiswizard, false, includeNonInitialized);
         AddObjectProperty("WWPFormResume", gxTv_SdtWWP_Form_Wwpformresume, false, includeNonInitialized);
         AddObjectProperty("WWPFormResumeMessage", gxTv_SdtWWP_Form_Wwpformresumemessage, false, includeNonInitialized);
         AddObjectProperty("WWPFormValidations", gxTv_SdtWWP_Form_Wwpformvalidations, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstantiated", gxTv_SdtWWP_Form_Wwpforminstantiated, false, includeNonInitialized);
         AddObjectProperty("WWPFormLatestVersionNumber", gxTv_SdtWWP_Form_Wwpformlatestversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormType", gxTv_SdtWWP_Form_Wwpformtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormSectionRefElements", gxTv_SdtWWP_Form_Wwpformsectionrefelements, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsForDynamicValidations", gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations, false, includeNonInitialized);
         if ( gxTv_SdtWWP_Form_Element != null )
         {
            AddObjectProperty("Element", gxTv_SdtWWP_Form_Element, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWWP_Form_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_Form_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPFormId_Z", gxTv_SdtWWP_Form_Wwpformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormVersionNumber_Z", gxTv_SdtWWP_Form_Wwpformversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormReferenceName_Z", gxTv_SdtWWP_Form_Wwpformreferencename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormTitle_Z", gxTv_SdtWWP_Form_Wwpformtitle_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_Form_Wwpformdate_Z;
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
            AddObjectProperty("WWPFormDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsWizard_Z", gxTv_SdtWWP_Form_Wwpformiswizard_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormResume_Z", gxTv_SdtWWP_Form_Wwpformresume_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstantiated_Z", gxTv_SdtWWP_Form_Wwpforminstantiated_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormLatestVersionNumber_Z", gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormType_Z", gxTv_SdtWWP_Form_Wwpformtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormSectionRefElements_Z", gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsForDynamicValidations_Z", gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form sdt )
      {
         if ( sdt.IsDirty("WWPFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformid = sdt.gxTv_SdtWWP_Form_Wwpformid ;
         }
         if ( sdt.IsDirty("WWPFormVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformversionnumber = sdt.gxTv_SdtWWP_Form_Wwpformversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormReferenceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformreferencename = sdt.gxTv_SdtWWP_Form_Wwpformreferencename ;
         }
         if ( sdt.IsDirty("WWPFormTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtitle = sdt.gxTv_SdtWWP_Form_Wwpformtitle ;
         }
         if ( sdt.IsDirty("WWPFormDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformdate = sdt.gxTv_SdtWWP_Form_Wwpformdate ;
         }
         if ( sdt.IsDirty("WWPFormIsWizard") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformiswizard = sdt.gxTv_SdtWWP_Form_Wwpformiswizard ;
         }
         if ( sdt.IsDirty("WWPFormResume") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformresume = sdt.gxTv_SdtWWP_Form_Wwpformresume ;
         }
         if ( sdt.IsDirty("WWPFormResumeMessage") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformresumemessage = sdt.gxTv_SdtWWP_Form_Wwpformresumemessage ;
         }
         if ( sdt.IsDirty("WWPFormValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformvalidations = sdt.gxTv_SdtWWP_Form_Wwpformvalidations ;
         }
         if ( sdt.IsDirty("WWPFormInstantiated") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpforminstantiated = sdt.gxTv_SdtWWP_Form_Wwpforminstantiated ;
         }
         if ( sdt.IsDirty("WWPFormLatestVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformlatestversionnumber = sdt.gxTv_SdtWWP_Form_Wwpformlatestversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormType") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtype = sdt.gxTv_SdtWWP_Form_Wwpformtype ;
         }
         if ( sdt.IsDirty("WWPFormSectionRefElements") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformsectionrefelements = sdt.gxTv_SdtWWP_Form_Wwpformsectionrefelements ;
         }
         if ( sdt.IsDirty("WWPFormIsForDynamicValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations = sdt.gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations ;
         }
         if ( gxTv_SdtWWP_Form_Element != null )
         {
            GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> newCollectionElement = sdt.gxTpr_Element;
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element currItemElement;
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element newItemElement;
            short idx = 1;
            while ( idx <= newCollectionElement.Count )
            {
               newItemElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)newCollectionElement.Item(idx));
               currItemElement = gxTv_SdtWWP_Form_Element.GetByKey(newItemElement.gxTpr_Wwpformelementid);
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
                  gxTv_SdtWWP_Form_Element.Add(newItemElement, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPFormId" )]
      [  XmlElement( ElementName = "WWPFormId"   )]
      public short gxTpr_Wwpformid
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWWP_Form_Wwpformid != value )
            {
               gxTv_SdtWWP_Form_Mode = "INS";
               this.gxTv_SdtWWP_Form_Wwpformid_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z_SetNull( );
               if ( gxTv_SdtWWP_Form_Element != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> collectionElement = gxTv_SdtWWP_Form_Element;
                  GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element currItemElement;
                  short idx = 1;
                  while ( idx <= collectionElement.Count )
                  {
                     currItemElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)collectionElement.Item(idx));
                     currItemElement.gxTpr_Mode = "INS";
                     currItemElement.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtWWP_Form_Wwpformid = value;
            SetDirty("Wwpformid");
         }

      }

      [  SoapElement( ElementName = "WWPFormVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber"   )]
      public short gxTpr_Wwpformversionnumber
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformversionnumber ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWWP_Form_Wwpformversionnumber != value )
            {
               gxTv_SdtWWP_Form_Mode = "INS";
               this.gxTv_SdtWWP_Form_Wwpformid_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z_SetNull( );
               if ( gxTv_SdtWWP_Form_Element != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> collectionElement = gxTv_SdtWWP_Form_Element;
                  GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element currItemElement;
                  short idx = 1;
                  while ( idx <= collectionElement.Count )
                  {
                     currItemElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)collectionElement.Item(idx));
                     currItemElement.gxTpr_Mode = "INS";
                     currItemElement.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtWWP_Form_Wwpformversionnumber = value;
            SetDirty("Wwpformversionnumber");
         }

      }

      [  SoapElement( ElementName = "WWPFormReferenceName" )]
      [  XmlElement( ElementName = "WWPFormReferenceName"   )]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformreferencename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformreferencename = value;
            SetDirty("Wwpformreferencename");
         }

      }

      [  SoapElement( ElementName = "WWPFormTitle" )]
      [  XmlElement( ElementName = "WWPFormTitle"   )]
      public string gxTpr_Wwpformtitle
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtitle = value;
            SetDirty("Wwpformtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormDate" )]
      [  XmlElement( ElementName = "WWPFormDate"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Form_Wwpformdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Form_Wwpformdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Form_Wwpformdate = DateTime.MinValue;
            else
               gxTv_SdtWWP_Form_Wwpformdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformdate = value;
            SetDirty("Wwpformdate");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsWizard" )]
      [  XmlElement( ElementName = "WWPFormIsWizard"   )]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformiswizard ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformiswizard = value;
            SetDirty("Wwpformiswizard");
         }

      }

      [  SoapElement( ElementName = "WWPFormResume" )]
      [  XmlElement( ElementName = "WWPFormResume"   )]
      public short gxTpr_Wwpformresume
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformresume ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformresume = value;
            SetDirty("Wwpformresume");
         }

      }

      [  SoapElement( ElementName = "WWPFormResumeMessage" )]
      [  XmlElement( ElementName = "WWPFormResumeMessage"   )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformresumemessage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformresumemessage = value;
            SetDirty("Wwpformresumemessage");
         }

      }

      [  SoapElement( ElementName = "WWPFormValidations" )]
      [  XmlElement( ElementName = "WWPFormValidations"   )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformvalidations = value;
            SetDirty("Wwpformvalidations");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstantiated" )]
      [  XmlElement( ElementName = "WWPFormInstantiated"   )]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return gxTv_SdtWWP_Form_Wwpforminstantiated ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpforminstantiated = value;
            SetDirty("Wwpforminstantiated");
         }

      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber"   )]
      public short gxTpr_Wwpformlatestversionnumber
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformlatestversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformlatestversionnumber = value;
            SetDirty("Wwpformlatestversionnumber");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformlatestversionnumber_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformlatestversionnumber = 0;
         SetDirty("Wwpformlatestversionnumber");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformlatestversionnumber_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType" )]
      [  XmlElement( ElementName = "WWPFormType"   )]
      public short gxTpr_Wwpformtype
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtype = value;
            SetDirty("Wwpformtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements"   )]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformsectionrefelements ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformsectionrefelements = value;
            SetDirty("Wwpformsectionrefelements");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations = value;
            SetDirty("Wwpformisfordynamicvalidations");
         }

      }

      [  SoapElement( ElementName = "Element" )]
      [  XmlArray( ElementName = "Element"  )]
      [  XmlArrayItemAttribute( ElementName= "WWP_Form.Element"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> gxTpr_Element_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtWWP_Form_Element == null )
            {
               gxTv_SdtWWP_Form_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Comforta_version21");
            }
            return gxTv_SdtWWP_Form_Element ;
         }

         set {
            if ( gxTv_SdtWWP_Form_Element == null )
            {
               gxTv_SdtWWP_Form_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Comforta_version21");
            }
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Element = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> gxTpr_Element
      {
         get {
            if ( gxTv_SdtWWP_Form_Element == null )
            {
               gxTv_SdtWWP_Form_Element = new GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element>( context, "WWP_Form.Element", "Comforta_version21");
            }
            sdtIsNull = 0;
            return gxTv_SdtWWP_Form_Element ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Element = value;
            SetDirty("Element");
         }

      }

      public void gxTv_SdtWWP_Form_Element_SetNull( )
      {
         gxTv_SdtWWP_Form_Element = null;
         SetDirty("Element");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Element_IsNull( )
      {
         if ( gxTv_SdtWWP_Form_Element == null )
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
            return gxTv_SdtWWP_Form_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_Form_Mode_SetNull( )
      {
         gxTv_SdtWWP_Form_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_Form_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_Form_Initialized_SetNull( )
      {
         gxTv_SdtWWP_Form_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormId_Z" )]
      [  XmlElement( ElementName = "WWPFormId_Z"   )]
      public short gxTpr_Wwpformid_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformid_Z = value;
            SetDirty("Wwpformid_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformid_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformid_Z = 0;
         SetDirty("Wwpformid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber_Z"   )]
      public short gxTpr_Wwpformversionnumber_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformversionnumber_Z = value;
            SetDirty("Wwpformversionnumber_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformversionnumber_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformversionnumber_Z = 0;
         SetDirty("Wwpformversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormReferenceName_Z" )]
      [  XmlElement( ElementName = "WWPFormReferenceName_Z"   )]
      public string gxTpr_Wwpformreferencename_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformreferencename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformreferencename_Z = value;
            SetDirty("Wwpformreferencename_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformreferencename_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformreferencename_Z = "";
         SetDirty("Wwpformreferencename_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformreferencename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormTitle_Z" )]
      [  XmlElement( ElementName = "WWPFormTitle_Z"   )]
      public string gxTpr_Wwpformtitle_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtitle_Z = value;
            SetDirty("Wwpformtitle_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformtitle_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformtitle_Z = "";
         SetDirty("Wwpformtitle_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormDate_Z" )]
      [  XmlElement( ElementName = "WWPFormDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_Form_Wwpformdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_Form_Wwpformdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_Form_Wwpformdate_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_Form_Wwpformdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformdate_Z = value;
            SetDirty("Wwpformdate_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformdate_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpformdate_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsWizard_Z" )]
      [  XmlElement( ElementName = "WWPFormIsWizard_Z"   )]
      public bool gxTpr_Wwpformiswizard_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformiswizard_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformiswizard_Z = value;
            SetDirty("Wwpformiswizard_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformiswizard_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformiswizard_Z = false;
         SetDirty("Wwpformiswizard_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformiswizard_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormResume_Z" )]
      [  XmlElement( ElementName = "WWPFormResume_Z"   )]
      public short gxTpr_Wwpformresume_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformresume_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformresume_Z = value;
            SetDirty("Wwpformresume_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformresume_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformresume_Z = 0;
         SetDirty("Wwpformresume_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformresume_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstantiated_Z" )]
      [  XmlElement( ElementName = "WWPFormInstantiated_Z"   )]
      public bool gxTpr_Wwpforminstantiated_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpforminstantiated_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpforminstantiated_Z = value;
            SetDirty("Wwpforminstantiated_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpforminstantiated_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpforminstantiated_Z = false;
         SetDirty("Wwpforminstantiated_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpforminstantiated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber_Z"   )]
      public short gxTpr_Wwpformlatestversionnumber_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z = value;
            SetDirty("Wwpformlatestversionnumber_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z = 0;
         SetDirty("Wwpformlatestversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType_Z" )]
      [  XmlElement( ElementName = "WWPFormType_Z"   )]
      public short gxTpr_Wwpformtype_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformtype_Z = value;
            SetDirty("Wwpformtype_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformtype_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformtype_Z = 0;
         SetDirty("Wwpformtype_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements_Z" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements_Z"   )]
      public string gxTpr_Wwpformsectionrefelements_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z = value;
            SetDirty("Wwpformsectionrefelements_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z = "";
         SetDirty("Wwpformsectionrefelements_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations_Z" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations_Z"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations_Z
      {
         get {
            return gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z = value;
            SetDirty("Wwpformisfordynamicvalidations_Z");
         }

      }

      public void gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z_SetNull( )
      {
         gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z = false;
         SetDirty("Wwpformisfordynamicvalidations_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z_IsNull( )
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
         gxTv_SdtWWP_Form_Wwpformreferencename = "";
         gxTv_SdtWWP_Form_Wwpformtitle = "";
         gxTv_SdtWWP_Form_Wwpformdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Form_Wwpformresumemessage = "";
         gxTv_SdtWWP_Form_Wwpformvalidations = "";
         gxTv_SdtWWP_Form_Wwpformsectionrefelements = "";
         gxTv_SdtWWP_Form_Mode = "";
         gxTv_SdtWWP_Form_Wwpformreferencename_Z = "";
         gxTv_SdtWWP_Form_Wwpformtitle_Z = "";
         gxTv_SdtWWP_Form_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "workwithplus.dynamicforms.wwp_form", "GeneXus.Programs.workwithplus.dynamicforms.wwp_form_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtWWP_Form_Wwpformid ;
      private short sdtIsNull ;
      private short gxTv_SdtWWP_Form_Wwpformversionnumber ;
      private short gxTv_SdtWWP_Form_Wwpformresume ;
      private short gxTv_SdtWWP_Form_Wwpformlatestversionnumber ;
      private short gxTv_SdtWWP_Form_Wwpformtype ;
      private short gxTv_SdtWWP_Form_Initialized ;
      private short gxTv_SdtWWP_Form_Wwpformid_Z ;
      private short gxTv_SdtWWP_Form_Wwpformversionnumber_Z ;
      private short gxTv_SdtWWP_Form_Wwpformresume_Z ;
      private short gxTv_SdtWWP_Form_Wwpformlatestversionnumber_Z ;
      private short gxTv_SdtWWP_Form_Wwpformtype_Z ;
      private string gxTv_SdtWWP_Form_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_Form_Wwpformdate ;
      private DateTime gxTv_SdtWWP_Form_Wwpformdate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtWWP_Form_Wwpformiswizard ;
      private bool gxTv_SdtWWP_Form_Wwpforminstantiated ;
      private bool gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations ;
      private bool gxTv_SdtWWP_Form_Wwpformiswizard_Z ;
      private bool gxTv_SdtWWP_Form_Wwpforminstantiated_Z ;
      private bool gxTv_SdtWWP_Form_Wwpformisfordynamicvalidations_Z ;
      private string gxTv_SdtWWP_Form_Wwpformresumemessage ;
      private string gxTv_SdtWWP_Form_Wwpformvalidations ;
      private string gxTv_SdtWWP_Form_Wwpformreferencename ;
      private string gxTv_SdtWWP_Form_Wwpformtitle ;
      private string gxTv_SdtWWP_Form_Wwpformsectionrefelements ;
      private string gxTv_SdtWWP_Form_Wwpformreferencename_Z ;
      private string gxTv_SdtWWP_Form_Wwpformtitle_Z ;
      private string gxTv_SdtWWP_Form_Wwpformsectionrefelements_Z ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> gxTv_SdtWWP_Form_Element=null ;
   }

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_Form", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_Form_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form>
   {
      public SdtWWP_Form_RESTInterface( ) : base()
      {
      }

      public SdtWWP_Form_RESTInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormId" , Order = 0 )]
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

      [DataMember( Name = "WWPFormVersionNumber" , Order = 1 )]
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

      [DataMember( Name = "WWPFormReferenceName" , Order = 2 )]
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

      [DataMember( Name = "WWPFormTitle" , Order = 3 )]
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

      [DataMember( Name = "WWPFormDate" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wwpformdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpformdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpformdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPFormIsWizard" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return sdt.gxTpr_Wwpformiswizard ;
         }

         set {
            sdt.gxTpr_Wwpformiswizard = value;
         }

      }

      [DataMember( Name = "WWPFormResume" , Order = 6 )]
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

      [DataMember( Name = "WWPFormResumeMessage" , Order = 7 )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return sdt.gxTpr_Wwpformresumemessage ;
         }

         set {
            sdt.gxTpr_Wwpformresumemessage = value;
         }

      }

      [DataMember( Name = "WWPFormValidations" , Order = 8 )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return sdt.gxTpr_Wwpformvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformvalidations = value;
         }

      }

      [DataMember( Name = "WWPFormInstantiated" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return sdt.gxTpr_Wwpforminstantiated ;
         }

         set {
            sdt.gxTpr_Wwpforminstantiated = value;
         }

      }

      [DataMember( Name = "WWPFormLatestVersionNumber" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformlatestversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformlatestversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformlatestversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormType" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformtype
      {
         get {
            return sdt.gxTpr_Wwpformtype ;
         }

         set {
            sdt.gxTpr_Wwpformtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormSectionRefElements" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return sdt.gxTpr_Wwpformsectionrefelements ;
         }

         set {
            sdt.gxTpr_Wwpformsectionrefelements = value;
         }

      }

      [DataMember( Name = "WWPFormIsForDynamicValidations" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return sdt.gxTpr_Wwpformisfordynamicvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformisfordynamicvalidations = value;
         }

      }

      [DataMember( Name = "Element" , Order = 14 )]
      public GxGenericCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element_RESTInterface> gxTpr_Element
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element_RESTInterface>(sdt.gxTpr_Element) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Element);
         }

      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)Sdt ;
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
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
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

   [DataContract(Name = @"WorkWithPlus\DynamicForms\WWP_Form", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_Form_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form>
   {
      public SdtWWP_Form_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_Form_RESTLInterface( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormReferenceName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form sdt
      {
         get {
            return (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)Sdt ;
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
            sdt = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form() ;
         }
      }

   }

}
