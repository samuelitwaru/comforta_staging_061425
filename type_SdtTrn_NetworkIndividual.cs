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
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_NetworkIndividual" )]
   [XmlType(TypeName =  "Trn_NetworkIndividual" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_NetworkIndividual : GxSilentTrnSdt
   {
      public SdtTrn_NetworkIndividual( )
      {
      }

      public SdtTrn_NetworkIndividual( IGxContext context )
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

      public void Load( Guid AV74NetworkIndividualId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV74NetworkIndividualId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NetworkIndividualId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_NetworkIndividual");
         metadata.Set("BT", "Trn_NetworkIndividual");
         metadata.Set("PK", "[ \"NetworkIndividualId\" ]");
         metadata.Set("PKAssigned", "[ \"NetworkIndividualId\" ]");
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
         state.Add("gxTpr_Networkindividualid_Z");
         state.Add("gxTpr_Networkindividualbsnnumber_Z");
         state.Add("gxTpr_Networkindividualgivenname_Z");
         state.Add("gxTpr_Networkindividuallastname_Z");
         state.Add("gxTpr_Networkindividualemail_Z");
         state.Add("gxTpr_Networkindividualphone_Z");
         state.Add("gxTpr_Networkindividualhomephone_Z");
         state.Add("gxTpr_Networkindividualphonecode_Z");
         state.Add("gxTpr_Networkindividualhomephonecode_Z");
         state.Add("gxTpr_Networkindividualphonenumber_Z");
         state.Add("gxTpr_Networkindividualhomephonenumber_Z");
         state.Add("gxTpr_Networkindividualrelationship_Z");
         state.Add("gxTpr_Networkindividualgender_Z");
         state.Add("gxTpr_Networkindividualcountry_Z");
         state.Add("gxTpr_Networkindividualcity_Z");
         state.Add("gxTpr_Networkindividualzipcode_Z");
         state.Add("gxTpr_Networkindividualaddressline1_Z");
         state.Add("gxTpr_Networkindividualaddressline2_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_NetworkIndividual sdt;
         sdt = (SdtTrn_NetworkIndividual)(source);
         gxTv_SdtTrn_NetworkIndividual_Networkindividualid = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualid ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualemail = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualemail ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphone = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphone ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgender = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgender ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcity = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcity ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 ;
         gxTv_SdtTrn_NetworkIndividual_Mode = sdt.gxTv_SdtTrn_NetworkIndividual_Mode ;
         gxTv_SdtTrn_NetworkIndividual_Initialized = sdt.gxTv_SdtTrn_NetworkIndividual_Initialized ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z ;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z ;
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
         AddObjectProperty("NetworkIndividualId", gxTv_SdtTrn_NetworkIndividual_Networkindividualid, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualBsnNumber", gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualGivenName", gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualLastName", gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualEmail", gxTv_SdtTrn_NetworkIndividual_Networkindividualemail, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualPhone", gxTv_SdtTrn_NetworkIndividual_Networkindividualphone, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualHomePhone", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualPhoneCode", gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualHomePhoneCode", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualPhoneNumber", gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualHomePhoneNumber", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualRelationship", gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualGender", gxTv_SdtTrn_NetworkIndividual_Networkindividualgender, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualCountry", gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualCity", gxTv_SdtTrn_NetworkIndividual_Networkindividualcity, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualZipCode", gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualAddressLine1", gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1, false, includeNonInitialized);
         AddObjectProperty("NetworkIndividualAddressLine2", gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_NetworkIndividual_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_NetworkIndividual_Initialized, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualId_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualBsnNumber_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualGivenName_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualLastName_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualEmail_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualPhone_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualHomePhone_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualPhoneCode_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualHomePhoneCode_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualPhoneNumber_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualHomePhoneNumber_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualRelationship_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualGender_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualCountry_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualCity_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualZipCode_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualAddressLine1_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z, false, includeNonInitialized);
            AddObjectProperty("NetworkIndividualAddressLine2_Z", gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_NetworkIndividual sdt )
      {
         if ( sdt.IsDirty("NetworkIndividualId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualid = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualid ;
         }
         if ( sdt.IsDirty("NetworkIndividualBsnNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber ;
         }
         if ( sdt.IsDirty("NetworkIndividualGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname ;
         }
         if ( sdt.IsDirty("NetworkIndividualLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname ;
         }
         if ( sdt.IsDirty("NetworkIndividualEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualemail = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualemail ;
         }
         if ( sdt.IsDirty("NetworkIndividualPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphone = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphone ;
         }
         if ( sdt.IsDirty("NetworkIndividualHomePhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone ;
         }
         if ( sdt.IsDirty("NetworkIndividualPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode ;
         }
         if ( sdt.IsDirty("NetworkIndividualHomePhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode ;
         }
         if ( sdt.IsDirty("NetworkIndividualPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber ;
         }
         if ( sdt.IsDirty("NetworkIndividualHomePhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber ;
         }
         if ( sdt.IsDirty("NetworkIndividualRelationship") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship ;
         }
         if ( sdt.IsDirty("NetworkIndividualGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgender = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualgender ;
         }
         if ( sdt.IsDirty("NetworkIndividualCountry") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry ;
         }
         if ( sdt.IsDirty("NetworkIndividualCity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcity = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualcity ;
         }
         if ( sdt.IsDirty("NetworkIndividualZipCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode ;
         }
         if ( sdt.IsDirty("NetworkIndividualAddressLine1") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 ;
         }
         if ( sdt.IsDirty("NetworkIndividualAddressLine2") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 = sdt.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NetworkIndividualId" )]
      [  XmlElement( ElementName = "NetworkIndividualId"   )]
      public Guid gxTpr_Networkindividualid
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_NetworkIndividual_Networkindividualid != value )
            {
               gxTv_SdtTrn_NetworkIndividual_Mode = "INS";
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z_SetNull( );
               this.gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z_SetNull( );
            }
            gxTv_SdtTrn_NetworkIndividual_Networkindividualid = value;
            SetDirty("Networkindividualid");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualBsnNumber" )]
      [  XmlElement( ElementName = "NetworkIndividualBsnNumber"   )]
      public string gxTpr_Networkindividualbsnnumber
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber = value;
            SetDirty("Networkindividualbsnnumber");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualGivenName" )]
      [  XmlElement( ElementName = "NetworkIndividualGivenName"   )]
      public string gxTpr_Networkindividualgivenname
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname = value;
            SetDirty("Networkindividualgivenname");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualLastName" )]
      [  XmlElement( ElementName = "NetworkIndividualLastName"   )]
      public string gxTpr_Networkindividuallastname
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname = value;
            SetDirty("Networkindividuallastname");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualEmail" )]
      [  XmlElement( ElementName = "NetworkIndividualEmail"   )]
      public string gxTpr_Networkindividualemail
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualemail = value;
            SetDirty("Networkindividualemail");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualPhone" )]
      [  XmlElement( ElementName = "NetworkIndividualPhone"   )]
      public string gxTpr_Networkindividualphone
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphone = value;
            SetDirty("Networkindividualphone");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhone" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhone"   )]
      public string gxTpr_Networkindividualhomephone
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone = value;
            SetDirty("Networkindividualhomephone");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualPhoneCode" )]
      [  XmlElement( ElementName = "NetworkIndividualPhoneCode"   )]
      public string gxTpr_Networkindividualphonecode
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode = value;
            SetDirty("Networkindividualphonecode");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhoneCode" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhoneCode"   )]
      public string gxTpr_Networkindividualhomephonecode
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode = value;
            SetDirty("Networkindividualhomephonecode");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualPhoneNumber" )]
      [  XmlElement( ElementName = "NetworkIndividualPhoneNumber"   )]
      public string gxTpr_Networkindividualphonenumber
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber = value;
            SetDirty("Networkindividualphonenumber");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhoneNumber" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhoneNumber"   )]
      public string gxTpr_Networkindividualhomephonenumber
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber = value;
            SetDirty("Networkindividualhomephonenumber");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualRelationship" )]
      [  XmlElement( ElementName = "NetworkIndividualRelationship"   )]
      public string gxTpr_Networkindividualrelationship
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship = value;
            SetDirty("Networkindividualrelationship");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualGender" )]
      [  XmlElement( ElementName = "NetworkIndividualGender"   )]
      public string gxTpr_Networkindividualgender
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualgender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgender = value;
            SetDirty("Networkindividualgender");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualCountry" )]
      [  XmlElement( ElementName = "NetworkIndividualCountry"   )]
      public string gxTpr_Networkindividualcountry
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry = value;
            SetDirty("Networkindividualcountry");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualCity" )]
      [  XmlElement( ElementName = "NetworkIndividualCity"   )]
      public string gxTpr_Networkindividualcity
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualcity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcity = value;
            SetDirty("Networkindividualcity");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualZipCode" )]
      [  XmlElement( ElementName = "NetworkIndividualZipCode"   )]
      public string gxTpr_Networkindividualzipcode
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode = value;
            SetDirty("Networkindividualzipcode");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualAddressLine1" )]
      [  XmlElement( ElementName = "NetworkIndividualAddressLine1"   )]
      public string gxTpr_Networkindividualaddressline1
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 = value;
            SetDirty("Networkindividualaddressline1");
         }

      }

      [  SoapElement( ElementName = "NetworkIndividualAddressLine2" )]
      [  XmlElement( ElementName = "NetworkIndividualAddressLine2"   )]
      public string gxTpr_Networkindividualaddressline2
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 = value;
            SetDirty("Networkindividualaddressline2");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Mode_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Initialized_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualId_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualId_Z"   )]
      public Guid gxTpr_Networkindividualid_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z = value;
            SetDirty("Networkindividualid_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z = Guid.Empty;
         SetDirty("Networkindividualid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualBsnNumber_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualBsnNumber_Z"   )]
      public string gxTpr_Networkindividualbsnnumber_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z = value;
            SetDirty("Networkindividualbsnnumber_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z = "";
         SetDirty("Networkindividualbsnnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualGivenName_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualGivenName_Z"   )]
      public string gxTpr_Networkindividualgivenname_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z = value;
            SetDirty("Networkindividualgivenname_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z = "";
         SetDirty("Networkindividualgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualLastName_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualLastName_Z"   )]
      public string gxTpr_Networkindividuallastname_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z = value;
            SetDirty("Networkindividuallastname_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z = "";
         SetDirty("Networkindividuallastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualEmail_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualEmail_Z"   )]
      public string gxTpr_Networkindividualemail_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z = value;
            SetDirty("Networkindividualemail_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z = "";
         SetDirty("Networkindividualemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualPhone_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualPhone_Z"   )]
      public string gxTpr_Networkindividualphone_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z = value;
            SetDirty("Networkindividualphone_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z = "";
         SetDirty("Networkindividualphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhone_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhone_Z"   )]
      public string gxTpr_Networkindividualhomephone_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z = value;
            SetDirty("Networkindividualhomephone_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z = "";
         SetDirty("Networkindividualhomephone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualPhoneCode_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualPhoneCode_Z"   )]
      public string gxTpr_Networkindividualphonecode_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z = value;
            SetDirty("Networkindividualphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z = "";
         SetDirty("Networkindividualphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhoneCode_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhoneCode_Z"   )]
      public string gxTpr_Networkindividualhomephonecode_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z = value;
            SetDirty("Networkindividualhomephonecode_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z = "";
         SetDirty("Networkindividualhomephonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualPhoneNumber_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualPhoneNumber_Z"   )]
      public string gxTpr_Networkindividualphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z = value;
            SetDirty("Networkindividualphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z = "";
         SetDirty("Networkindividualphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualHomePhoneNumber_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualHomePhoneNumber_Z"   )]
      public string gxTpr_Networkindividualhomephonenumber_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z = value;
            SetDirty("Networkindividualhomephonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z = "";
         SetDirty("Networkindividualhomephonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualRelationship_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualRelationship_Z"   )]
      public string gxTpr_Networkindividualrelationship_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z = value;
            SetDirty("Networkindividualrelationship_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z = "";
         SetDirty("Networkindividualrelationship_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualGender_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualGender_Z"   )]
      public string gxTpr_Networkindividualgender_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z = value;
            SetDirty("Networkindividualgender_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z = "";
         SetDirty("Networkindividualgender_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualCountry_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualCountry_Z"   )]
      public string gxTpr_Networkindividualcountry_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z = value;
            SetDirty("Networkindividualcountry_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z = "";
         SetDirty("Networkindividualcountry_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualCity_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualCity_Z"   )]
      public string gxTpr_Networkindividualcity_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z = value;
            SetDirty("Networkindividualcity_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z = "";
         SetDirty("Networkindividualcity_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualZipCode_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualZipCode_Z"   )]
      public string gxTpr_Networkindividualzipcode_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z = value;
            SetDirty("Networkindividualzipcode_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z = "";
         SetDirty("Networkindividualzipcode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualAddressLine1_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualAddressLine1_Z"   )]
      public string gxTpr_Networkindividualaddressline1_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z = value;
            SetDirty("Networkindividualaddressline1_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z = "";
         SetDirty("Networkindividualaddressline1_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NetworkIndividualAddressLine2_Z" )]
      [  XmlElement( ElementName = "NetworkIndividualAddressLine2_Z"   )]
      public string gxTpr_Networkindividualaddressline2_Z
      {
         get {
            return gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z = value;
            SetDirty("Networkindividualaddressline2_Z");
         }

      }

      public void gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z_SetNull( )
      {
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z = "";
         SetDirty("Networkindividualaddressline2_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z_IsNull( )
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
         gxTv_SdtTrn_NetworkIndividual_Networkindividualid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualemail = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphone = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgender = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcity = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 = "";
         gxTv_SdtTrn_NetworkIndividual_Mode = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z = Guid.Empty;
         gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z = "";
         gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_networkindividual", "GeneXus.Programs.trn_networkindividual_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_NetworkIndividual_Initialized ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphone ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone ;
      private string gxTv_SdtTrn_NetworkIndividual_Mode ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphone_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephone_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualemail ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualgender ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualcity ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1 ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2 ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualbsnnumber_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualgivenname_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividuallastname_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualemail_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphonecode_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonecode_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualphonenumber_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualhomephonenumber_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualrelationship_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualgender_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualcountry_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualcity_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualzipcode_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline1_Z ;
      private string gxTv_SdtTrn_NetworkIndividual_Networkindividualaddressline2_Z ;
      private Guid gxTv_SdtTrn_NetworkIndividual_Networkindividualid ;
      private Guid gxTv_SdtTrn_NetworkIndividual_Networkindividualid_Z ;
   }

   [DataContract(Name = @"Trn_NetworkIndividual", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_NetworkIndividual_RESTInterface : GxGenericCollectionItem<SdtTrn_NetworkIndividual>
   {
      public SdtTrn_NetworkIndividual_RESTInterface( ) : base()
      {
      }

      public SdtTrn_NetworkIndividual_RESTInterface( SdtTrn_NetworkIndividual psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NetworkIndividualId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Networkindividualid
      {
         get {
            return sdt.gxTpr_Networkindividualid ;
         }

         set {
            sdt.gxTpr_Networkindividualid = value;
         }

      }

      [DataMember( Name = "NetworkIndividualBsnNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualbsnnumber
      {
         get {
            return sdt.gxTpr_Networkindividualbsnnumber ;
         }

         set {
            sdt.gxTpr_Networkindividualbsnnumber = value;
         }

      }

      [DataMember( Name = "NetworkIndividualGivenName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualgivenname
      {
         get {
            return sdt.gxTpr_Networkindividualgivenname ;
         }

         set {
            sdt.gxTpr_Networkindividualgivenname = value;
         }

      }

      [DataMember( Name = "NetworkIndividualLastName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Networkindividuallastname
      {
         get {
            return sdt.gxTpr_Networkindividuallastname ;
         }

         set {
            sdt.gxTpr_Networkindividuallastname = value;
         }

      }

      [DataMember( Name = "NetworkIndividualEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualemail
      {
         get {
            return sdt.gxTpr_Networkindividualemail ;
         }

         set {
            sdt.gxTpr_Networkindividualemail = value;
         }

      }

      [DataMember( Name = "NetworkIndividualPhone" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Networkindividualphone) ;
         }

         set {
            sdt.gxTpr_Networkindividualphone = value;
         }

      }

      [DataMember( Name = "NetworkIndividualHomePhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualhomephone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Networkindividualhomephone) ;
         }

         set {
            sdt.gxTpr_Networkindividualhomephone = value;
         }

      }

      [DataMember( Name = "NetworkIndividualPhoneCode" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualphonecode
      {
         get {
            return sdt.gxTpr_Networkindividualphonecode ;
         }

         set {
            sdt.gxTpr_Networkindividualphonecode = value;
         }

      }

      [DataMember( Name = "NetworkIndividualHomePhoneCode" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualhomephonecode
      {
         get {
            return sdt.gxTpr_Networkindividualhomephonecode ;
         }

         set {
            sdt.gxTpr_Networkindividualhomephonecode = value;
         }

      }

      [DataMember( Name = "NetworkIndividualPhoneNumber" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualphonenumber
      {
         get {
            return sdt.gxTpr_Networkindividualphonenumber ;
         }

         set {
            sdt.gxTpr_Networkindividualphonenumber = value;
         }

      }

      [DataMember( Name = "NetworkIndividualHomePhoneNumber" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualhomephonenumber
      {
         get {
            return sdt.gxTpr_Networkindividualhomephonenumber ;
         }

         set {
            sdt.gxTpr_Networkindividualhomephonenumber = value;
         }

      }

      [DataMember( Name = "NetworkIndividualRelationship" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualrelationship
      {
         get {
            return sdt.gxTpr_Networkindividualrelationship ;
         }

         set {
            sdt.gxTpr_Networkindividualrelationship = value;
         }

      }

      [DataMember( Name = "NetworkIndividualGender" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualgender
      {
         get {
            return sdt.gxTpr_Networkindividualgender ;
         }

         set {
            sdt.gxTpr_Networkindividualgender = value;
         }

      }

      [DataMember( Name = "NetworkIndividualCountry" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualcountry
      {
         get {
            return sdt.gxTpr_Networkindividualcountry ;
         }

         set {
            sdt.gxTpr_Networkindividualcountry = value;
         }

      }

      [DataMember( Name = "NetworkIndividualCity" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualcity
      {
         get {
            return sdt.gxTpr_Networkindividualcity ;
         }

         set {
            sdt.gxTpr_Networkindividualcity = value;
         }

      }

      [DataMember( Name = "NetworkIndividualZipCode" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualzipcode
      {
         get {
            return sdt.gxTpr_Networkindividualzipcode ;
         }

         set {
            sdt.gxTpr_Networkindividualzipcode = value;
         }

      }

      [DataMember( Name = "NetworkIndividualAddressLine1" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualaddressline1
      {
         get {
            return sdt.gxTpr_Networkindividualaddressline1 ;
         }

         set {
            sdt.gxTpr_Networkindividualaddressline1 = value;
         }

      }

      [DataMember( Name = "NetworkIndividualAddressLine2" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualaddressline2
      {
         get {
            return sdt.gxTpr_Networkindividualaddressline2 ;
         }

         set {
            sdt.gxTpr_Networkindividualaddressline2 = value;
         }

      }

      public SdtTrn_NetworkIndividual sdt
      {
         get {
            return (SdtTrn_NetworkIndividual)Sdt ;
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
            sdt = new SdtTrn_NetworkIndividual() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 18 )]
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

   [DataContract(Name = @"Trn_NetworkIndividual", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_NetworkIndividual_RESTLInterface : GxGenericCollectionItem<SdtTrn_NetworkIndividual>
   {
      public SdtTrn_NetworkIndividual_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_NetworkIndividual_RESTLInterface( SdtTrn_NetworkIndividual psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NetworkIndividualBsnNumber" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Networkindividualbsnnumber
      {
         get {
            return sdt.gxTpr_Networkindividualbsnnumber ;
         }

         set {
            sdt.gxTpr_Networkindividualbsnnumber = value;
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

      public SdtTrn_NetworkIndividual sdt
      {
         get {
            return (SdtTrn_NetworkIndividual)Sdt ;
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
            sdt = new SdtTrn_NetworkIndividual() ;
         }
      }

   }

}
