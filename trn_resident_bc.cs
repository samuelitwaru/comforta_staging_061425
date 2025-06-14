using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_resident_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_resident_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_resident_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0964( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0964( ) ;
         standaloneModal( ) ;
         AddRow0964( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z62ResidentId = A62ResidentId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate0964( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0964( ) ;
            }
            else
            {
               CheckExtendedTable0964( ) ;
               if ( AnyError == 0 )
               {
                  ZM0964( 39) ;
                  ZM0964( 40) ;
                  ZM0964( 41) ;
                  ZM0964( 42) ;
               }
               CloseExtendedTableCursors0964( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV63Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV64GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV15Insert_ResidentTypeId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MedicalIndicationId") == 0 )
               {
                  AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ResidentPackageId") == 0 )
               {
                  AV51Insert_ResidentPackageId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               AV64GXV1 = (int)(AV64GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38ComboResidentCountry)) )
         {
            AV38ComboResidentCountry = "Netherlands";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ComboResidentPhoneCode)) )
         {
            AV39ComboResidentPhoneCode = AV40defaultCountryPhoneCode;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44ComboResidentHomePhoneCode)) )
         {
            AV44ComboResidentHomePhoneCode = AV40defaultCountryPhoneCode;
         }
      }

      protected void E11092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV63Pgmname) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
            new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV63Pgmname) ;
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM0964( short GX_JID )
      {
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
            Z430ResidentHomePhone = A430ResidentHomePhone;
            Z314ResidentZipCode = A314ResidentZipCode;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z312ResidentCountry = A312ResidentCountry;
            Z313ResidentCity = A313ResidentCity;
            Z315ResidentAddressLine1 = A315ResidentAddressLine1;
            Z316ResidentAddressLine2 = A316ResidentAddressLine2;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z347ResidentPhoneCode = A347ResidentPhoneCode;
            Z348ResidentPhoneNumber = A348ResidentPhoneNumber;
            Z431ResidentHomePhoneCode = A431ResidentHomePhoneCode;
            Z432ResidentHomePhoneNumber = A432ResidentHomePhoneNumber;
            Z599ResidentLanguage = A599ResidentLanguage;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z527ResidentPackageId = A527ResidentPackageId;
         }
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 40 ) || ( GX_JID == 0 ) )
         {
            Z97ResidentTypeName = A97ResidentTypeName;
         }
         if ( ( GX_JID == 41 ) || ( GX_JID == 0 ) )
         {
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            Z531ResidentPackageName = A531ResidentPackageName;
            Z529SG_OrganisationId = A529SG_OrganisationId;
            Z528SG_LocationId = A528SG_LocationId;
         }
         if ( GX_JID == -38 )
         {
            Z62ResidentId = A62ResidentId;
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
            Z430ResidentHomePhone = A430ResidentHomePhone;
            Z314ResidentZipCode = A314ResidentZipCode;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z312ResidentCountry = A312ResidentCountry;
            Z313ResidentCity = A313ResidentCity;
            Z315ResidentAddressLine1 = A315ResidentAddressLine1;
            Z316ResidentAddressLine2 = A316ResidentAddressLine2;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z347ResidentPhoneCode = A347ResidentPhoneCode;
            Z348ResidentPhoneNumber = A348ResidentPhoneNumber;
            Z431ResidentHomePhoneCode = A431ResidentHomePhoneCode;
            Z432ResidentHomePhoneNumber = A432ResidentHomePhoneNumber;
            Z445ResidentImage = A445ResidentImage;
            Z40000ResidentImage_GXI = A40000ResidentImage_GXI;
            Z599ResidentLanguage = A599ResidentLanguage;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z527ResidentPackageId = A527ResidentPackageId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
            Z531ResidentPackageName = A531ResidentPackageName;
            Z529SG_OrganisationId = A529SG_OrganisationId;
            Z528SG_LocationId = A528SG_LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_guid1 = A29LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
            A29LocationId = GXt_guid1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_guid1 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            A11OrganisationId = GXt_guid1;
         }
         AV63Pgmname = "Trn_Resident_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) )
         {
            A62ResidentId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0964( )
      {
         /* Using cursor BC00098 */
         pr_default.execute(6, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound64 = 1;
            A66ResidentInitials = BC00098_A66ResidentInitials[0];
            A70ResidentPhone = BC00098_A70ResidentPhone[0];
            A430ResidentHomePhone = BC00098_A430ResidentHomePhone[0];
            A314ResidentZipCode = BC00098_A314ResidentZipCode[0];
            A72ResidentSalutation = BC00098_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC00098_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC00098_A64ResidentGivenName[0];
            A65ResidentLastName = BC00098_A65ResidentLastName[0];
            A67ResidentEmail = BC00098_A67ResidentEmail[0];
            A68ResidentGender = BC00098_A68ResidentGender[0];
            A312ResidentCountry = BC00098_A312ResidentCountry[0];
            A313ResidentCity = BC00098_A313ResidentCity[0];
            A315ResidentAddressLine1 = BC00098_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC00098_A316ResidentAddressLine2[0];
            A73ResidentBirthDate = BC00098_A73ResidentBirthDate[0];
            A71ResidentGUID = BC00098_A71ResidentGUID[0];
            A97ResidentTypeName = BC00098_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC00098_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC00098_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC00098_A348ResidentPhoneNumber[0];
            A431ResidentHomePhoneCode = BC00098_A431ResidentHomePhoneCode[0];
            A432ResidentHomePhoneNumber = BC00098_A432ResidentHomePhoneNumber[0];
            A40000ResidentImage_GXI = BC00098_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = BC00098_n40000ResidentImage_GXI[0];
            A599ResidentLanguage = BC00098_A599ResidentLanguage[0];
            A531ResidentPackageName = BC00098_A531ResidentPackageName[0];
            A96ResidentTypeId = BC00098_A96ResidentTypeId[0];
            n96ResidentTypeId = BC00098_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC00098_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC00098_n98MedicalIndicationId[0];
            A527ResidentPackageId = BC00098_A527ResidentPackageId[0];
            n527ResidentPackageId = BC00098_n527ResidentPackageId[0];
            A529SG_OrganisationId = BC00098_A529SG_OrganisationId[0];
            A528SG_LocationId = BC00098_A528SG_LocationId[0];
            A445ResidentImage = BC00098_A445ResidentImage[0];
            n445ResidentImage = BC00098_n445ResidentImage[0];
            ZM0964( -38) ;
         }
         pr_default.close(6);
         OnLoadActions0964( ) ;
      }

      protected void OnLoadActions0964( )
      {
         A314ResidentZipCode = StringUtil.Upper( A314ResidentZipCode);
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A347ResidentPhoneCode,  A348ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         GXt_char2 = A430ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A431ResidentHomePhoneCode,  A432ResidentHomePhoneNumber, out  GXt_char2) ;
         A430ResidentHomePhone = GXt_char2;
      }

      protected void CheckExtendedTable0964( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A72ResidentSalutation, "Mr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Mrs") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Dr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Miss") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Salutation", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A63ResidentBsnNumber)) && ( StringUtil.Len( A63ResidentBsnNumber) != 9 ) )
         {
            GX_msglist.addItem(context.GetMessage( "BSN number contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Given Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         new prc_getnameinitials(context ).execute(  A64ResidentGivenName,  A65ResidentLastName, out  A66ResidentInitials) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Last Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A67ResidentEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A68ResidentGender, "Male") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Female") == 0 ) || ( StringUtil.StrCmp(A68ResidentGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         A314ResidentZipCode = StringUtil.Upper( A314ResidentZipCode);
         if ( ! GxRegex.IsMatch(A314ResidentZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A314ResidentZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = BC00095_A97ResidentTypeName[0];
         pr_default.close(3);
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = BC00096_A99MedicalIndicationName[0];
         pr_default.close(4);
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A347ResidentPhoneCode,  A348ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A348ResidentPhoneNumber)) && ! GxRegex.IsMatch(A348ResidentPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         GXt_char2 = A430ResidentHomePhone;
         new prc_concatenateintlphone(context ).execute(  A431ResidentHomePhoneCode,  A432ResidentHomePhoneNumber, out  GXt_char2) ;
         A430ResidentHomePhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A432ResidentHomePhoneNumber)) && ! GxRegex.IsMatch(A432ResidentHomePhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00097 */
         pr_default.execute(5, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A527ResidentPackageId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ResidentPackage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTPACKAGEID");
               AnyError = 1;
            }
         }
         A531ResidentPackageName = BC00097_A531ResidentPackageName[0];
         A529SG_OrganisationId = BC00097_A529SG_OrganisationId[0];
         A528SG_LocationId = BC00097_A528SG_LocationId[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0964( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0964( )
      {
         /* Using cursor BC00099 */
         pr_default.execute(7, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0964( 38) ;
            RcdFound64 = 1;
            A62ResidentId = BC00093_A62ResidentId[0];
            A66ResidentInitials = BC00093_A66ResidentInitials[0];
            A70ResidentPhone = BC00093_A70ResidentPhone[0];
            A430ResidentHomePhone = BC00093_A430ResidentHomePhone[0];
            A314ResidentZipCode = BC00093_A314ResidentZipCode[0];
            A72ResidentSalutation = BC00093_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC00093_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC00093_A64ResidentGivenName[0];
            A65ResidentLastName = BC00093_A65ResidentLastName[0];
            A67ResidentEmail = BC00093_A67ResidentEmail[0];
            A68ResidentGender = BC00093_A68ResidentGender[0];
            A312ResidentCountry = BC00093_A312ResidentCountry[0];
            A313ResidentCity = BC00093_A313ResidentCity[0];
            A315ResidentAddressLine1 = BC00093_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC00093_A316ResidentAddressLine2[0];
            A73ResidentBirthDate = BC00093_A73ResidentBirthDate[0];
            A71ResidentGUID = BC00093_A71ResidentGUID[0];
            A347ResidentPhoneCode = BC00093_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC00093_A348ResidentPhoneNumber[0];
            A431ResidentHomePhoneCode = BC00093_A431ResidentHomePhoneCode[0];
            A432ResidentHomePhoneNumber = BC00093_A432ResidentHomePhoneNumber[0];
            A40000ResidentImage_GXI = BC00093_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = BC00093_n40000ResidentImage_GXI[0];
            A599ResidentLanguage = BC00093_A599ResidentLanguage[0];
            A29LocationId = BC00093_A29LocationId[0];
            A11OrganisationId = BC00093_A11OrganisationId[0];
            A96ResidentTypeId = BC00093_A96ResidentTypeId[0];
            n96ResidentTypeId = BC00093_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC00093_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC00093_n98MedicalIndicationId[0];
            A527ResidentPackageId = BC00093_A527ResidentPackageId[0];
            n527ResidentPackageId = BC00093_n527ResidentPackageId[0];
            A445ResidentImage = BC00093_A445ResidentImage[0];
            n445ResidentImage = BC00093_n445ResidentImage[0];
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0964( ) ;
            if ( AnyError == 1 )
            {
               RcdFound64 = 0;
               InitializeNonKey0964( ) ;
            }
            Gx_mode = sMode64;
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey0964( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode64;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0964( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0964( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z66ResidentInitials, BC00092_A66ResidentInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z70ResidentPhone, BC00092_A70ResidentPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z430ResidentHomePhone, BC00092_A430ResidentHomePhone[0]) != 0 ) || ( StringUtil.StrCmp(Z314ResidentZipCode, BC00092_A314ResidentZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z72ResidentSalutation, BC00092_A72ResidentSalutation[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z63ResidentBsnNumber, BC00092_A63ResidentBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z64ResidentGivenName, BC00092_A64ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z65ResidentLastName, BC00092_A65ResidentLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z67ResidentEmail, BC00092_A67ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z68ResidentGender, BC00092_A68ResidentGender[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z312ResidentCountry, BC00092_A312ResidentCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z313ResidentCity, BC00092_A313ResidentCity[0]) != 0 ) || ( StringUtil.StrCmp(Z315ResidentAddressLine1, BC00092_A315ResidentAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z316ResidentAddressLine2, BC00092_A316ResidentAddressLine2[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( BC00092_A73ResidentBirthDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z71ResidentGUID, BC00092_A71ResidentGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z347ResidentPhoneCode, BC00092_A347ResidentPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z348ResidentPhoneNumber, BC00092_A348ResidentPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z431ResidentHomePhoneCode, BC00092_A431ResidentHomePhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z432ResidentHomePhoneNumber, BC00092_A432ResidentHomePhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z599ResidentLanguage, BC00092_A599ResidentLanguage[0]) != 0 ) || ( Z96ResidentTypeId != BC00092_A96ResidentTypeId[0] ) || ( Z98MedicalIndicationId != BC00092_A98MedicalIndicationId[0] ) || ( Z527ResidentPackageId != BC00092_A527ResidentPackageId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Resident"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0964( )
      {
         BeforeValidate0964( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0964( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0964( 0) ;
            CheckOptimisticConcurrency0964( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0964( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0964( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000910 */
                     pr_default.execute(8, new Object[] {A62ResidentId, A66ResidentInitials, A70ResidentPhone, A430ResidentHomePhone, A314ResidentZipCode, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A315ResidentAddressLine1, A316ResidentAddressLine2, A73ResidentBirthDate, A71ResidentGUID, A347ResidentPhoneCode, A348ResidentPhoneNumber, A431ResidentHomePhoneCode, A432ResidentHomePhoneNumber, n445ResidentImage, A445ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A599ResidentLanguage, A29LocationId, A11OrganisationId, n96ResidentTypeId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId, n527ResidentPackageId, A527ResidentPackageId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0964( ) ;
            }
            EndLevel0964( ) ;
         }
         CloseExtendedTableCursors0964( ) ;
      }

      protected void Update0964( )
      {
         BeforeValidate0964( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0964( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0964( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0964( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0964( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000911 */
                     pr_default.execute(9, new Object[] {A66ResidentInitials, A70ResidentPhone, A430ResidentHomePhone, A314ResidentZipCode, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A312ResidentCountry, A313ResidentCity, A315ResidentAddressLine1, A316ResidentAddressLine2, A73ResidentBirthDate, A71ResidentGUID, A347ResidentPhoneCode, A348ResidentPhoneNumber, A431ResidentHomePhoneCode, A432ResidentHomePhoneNumber, A599ResidentLanguage, n96ResidentTypeId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId, n527ResidentPackageId, A527ResidentPackageId, A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0964( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0964( ) ;
         }
         CloseExtendedTableCursors0964( ) ;
      }

      protected void DeferredUpdate0964( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000912 */
            pr_default.execute(10, new Object[] {n445ResidentImage, A445ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0964( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0964( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0964( ) ;
            AfterConfirm0964( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0964( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000913 */
                  pr_default.execute(11, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0964( ) ;
         Gx_mode = sMode64;
      }

      protected void OnDeleteControls0964( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000914 */
            pr_default.execute(12, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            A97ResidentTypeName = BC000914_A97ResidentTypeName[0];
            pr_default.close(12);
            /* Using cursor BC000915 */
            pr_default.execute(13, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = BC000915_A99MedicalIndicationName[0];
            pr_default.close(13);
            /* Using cursor BC000916 */
            pr_default.execute(14, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            A531ResidentPackageName = BC000916_A531ResidentPackageName[0];
            A529SG_OrganisationId = BC000916_A529SG_OrganisationId[0];
            A528SG_LocationId = BC000916_A528SG_LocationId[0];
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000917 */
            pr_default.execute(15, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Memo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel0964( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0964( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0964( )
      {
         /* Scan By routine */
         /* Using cursor BC000918 */
         pr_default.execute(16, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound64 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound64 = 1;
            A62ResidentId = BC000918_A62ResidentId[0];
            A66ResidentInitials = BC000918_A66ResidentInitials[0];
            A70ResidentPhone = BC000918_A70ResidentPhone[0];
            A430ResidentHomePhone = BC000918_A430ResidentHomePhone[0];
            A314ResidentZipCode = BC000918_A314ResidentZipCode[0];
            A72ResidentSalutation = BC000918_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC000918_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC000918_A64ResidentGivenName[0];
            A65ResidentLastName = BC000918_A65ResidentLastName[0];
            A67ResidentEmail = BC000918_A67ResidentEmail[0];
            A68ResidentGender = BC000918_A68ResidentGender[0];
            A312ResidentCountry = BC000918_A312ResidentCountry[0];
            A313ResidentCity = BC000918_A313ResidentCity[0];
            A315ResidentAddressLine1 = BC000918_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC000918_A316ResidentAddressLine2[0];
            A73ResidentBirthDate = BC000918_A73ResidentBirthDate[0];
            A71ResidentGUID = BC000918_A71ResidentGUID[0];
            A97ResidentTypeName = BC000918_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC000918_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC000918_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC000918_A348ResidentPhoneNumber[0];
            A431ResidentHomePhoneCode = BC000918_A431ResidentHomePhoneCode[0];
            A432ResidentHomePhoneNumber = BC000918_A432ResidentHomePhoneNumber[0];
            A40000ResidentImage_GXI = BC000918_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = BC000918_n40000ResidentImage_GXI[0];
            A599ResidentLanguage = BC000918_A599ResidentLanguage[0];
            A531ResidentPackageName = BC000918_A531ResidentPackageName[0];
            A29LocationId = BC000918_A29LocationId[0];
            A11OrganisationId = BC000918_A11OrganisationId[0];
            A96ResidentTypeId = BC000918_A96ResidentTypeId[0];
            n96ResidentTypeId = BC000918_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC000918_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000918_n98MedicalIndicationId[0];
            A527ResidentPackageId = BC000918_A527ResidentPackageId[0];
            n527ResidentPackageId = BC000918_n527ResidentPackageId[0];
            A529SG_OrganisationId = BC000918_A529SG_OrganisationId[0];
            A528SG_LocationId = BC000918_A528SG_LocationId[0];
            A445ResidentImage = BC000918_A445ResidentImage[0];
            n445ResidentImage = BC000918_n445ResidentImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0964( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound64 = 0;
         ScanKeyLoad0964( ) ;
      }

      protected void ScanKeyLoad0964( )
      {
         sMode64 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound64 = 1;
            A62ResidentId = BC000918_A62ResidentId[0];
            A66ResidentInitials = BC000918_A66ResidentInitials[0];
            A70ResidentPhone = BC000918_A70ResidentPhone[0];
            A430ResidentHomePhone = BC000918_A430ResidentHomePhone[0];
            A314ResidentZipCode = BC000918_A314ResidentZipCode[0];
            A72ResidentSalutation = BC000918_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC000918_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC000918_A64ResidentGivenName[0];
            A65ResidentLastName = BC000918_A65ResidentLastName[0];
            A67ResidentEmail = BC000918_A67ResidentEmail[0];
            A68ResidentGender = BC000918_A68ResidentGender[0];
            A312ResidentCountry = BC000918_A312ResidentCountry[0];
            A313ResidentCity = BC000918_A313ResidentCity[0];
            A315ResidentAddressLine1 = BC000918_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC000918_A316ResidentAddressLine2[0];
            A73ResidentBirthDate = BC000918_A73ResidentBirthDate[0];
            A71ResidentGUID = BC000918_A71ResidentGUID[0];
            A97ResidentTypeName = BC000918_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC000918_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC000918_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC000918_A348ResidentPhoneNumber[0];
            A431ResidentHomePhoneCode = BC000918_A431ResidentHomePhoneCode[0];
            A432ResidentHomePhoneNumber = BC000918_A432ResidentHomePhoneNumber[0];
            A40000ResidentImage_GXI = BC000918_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = BC000918_n40000ResidentImage_GXI[0];
            A599ResidentLanguage = BC000918_A599ResidentLanguage[0];
            A531ResidentPackageName = BC000918_A531ResidentPackageName[0];
            A29LocationId = BC000918_A29LocationId[0];
            A11OrganisationId = BC000918_A11OrganisationId[0];
            A96ResidentTypeId = BC000918_A96ResidentTypeId[0];
            n96ResidentTypeId = BC000918_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC000918_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000918_n98MedicalIndicationId[0];
            A527ResidentPackageId = BC000918_A527ResidentPackageId[0];
            n527ResidentPackageId = BC000918_n527ResidentPackageId[0];
            A529SG_OrganisationId = BC000918_A529SG_OrganisationId[0];
            A528SG_LocationId = BC000918_A528SG_LocationId[0];
            A445ResidentImage = BC000918_A445ResidentImage[0];
            n445ResidentImage = BC000918_n445ResidentImage[0];
         }
         Gx_mode = sMode64;
      }

      protected void ScanKeyEnd0964( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0964( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0964( )
      {
         /* Before Insert Rules */
         AV36GAMErrorResponse = "";
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", ref  A71ResidentGUID, ref  AV36GAMErrorResponse) ;
         }
         if ( IsIns( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV36GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeUpdate0964( )
      {
         /* Before Update Rules */
         AV36GAMErrorResponse = "";
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  A431ResidentHomePhoneCode,  A432ResidentHomePhoneNumber,  A445ResidentImage,  false,  "Resident", out  AV36GAMErrorResponse) ;
         }
         if ( IsUpd( )  && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36GAMErrorResponse)) )
         {
            GX_msglist.addItem(AV36GAMErrorResponse, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeDelete0964( )
      {
         /* Before Delete Rules */
         AV36GAMErrorResponse = "";
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeComplete0964( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_resident(context ).execute(  "N", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0964( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0964( )
      {
      }

      protected void send_integrity_lvl_hashes0964( )
      {
      }

      protected void AddRow0964( )
      {
         VarsToRow64( bcTrn_Resident) ;
      }

      protected void ReadRow0964( )
      {
         RowToVars64( bcTrn_Resident, 1) ;
      }

      protected void InitializeNonKey0964( )
      {
         AV42AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         AV36GAMErrorResponse = "";
         A66ResidentInitials = "";
         A70ResidentPhone = "";
         A430ResidentHomePhone = "";
         A314ResidentZipCode = "";
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A71ResidentGUID = "";
         A96ResidentTypeId = Guid.Empty;
         n96ResidentTypeId = false;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = "";
         A347ResidentPhoneCode = "";
         A348ResidentPhoneNumber = "";
         A431ResidentHomePhoneCode = "";
         A432ResidentHomePhoneNumber = "";
         A445ResidentImage = "";
         n445ResidentImage = false;
         A40000ResidentImage_GXI = "";
         n40000ResidentImage_GXI = false;
         A599ResidentLanguage = "";
         A527ResidentPackageId = Guid.Empty;
         n527ResidentPackageId = false;
         A531ResidentPackageName = "";
         A528SG_LocationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
         Z430ResidentHomePhone = "";
         Z314ResidentZipCode = "";
         Z72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         Z65ResidentLastName = "";
         Z67ResidentEmail = "";
         Z68ResidentGender = "";
         Z312ResidentCountry = "";
         Z313ResidentCity = "";
         Z315ResidentAddressLine1 = "";
         Z316ResidentAddressLine2 = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         Z347ResidentPhoneCode = "";
         Z348ResidentPhoneNumber = "";
         Z431ResidentHomePhoneCode = "";
         Z432ResidentHomePhoneNumber = "";
         Z599ResidentLanguage = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         Z527ResidentPackageId = Guid.Empty;
      }

      protected void InitAll0964( )
      {
         A62ResidentId = Guid.NewGuid( );
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         InitializeNonKey0964( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow64( SdtTrn_Resident obj64 )
      {
         obj64.gxTpr_Mode = Gx_mode;
         obj64.gxTpr_Residentinitials = A66ResidentInitials;
         obj64.gxTpr_Residentphone = A70ResidentPhone;
         obj64.gxTpr_Residenthomephone = A430ResidentHomePhone;
         obj64.gxTpr_Residentzipcode = A314ResidentZipCode;
         obj64.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj64.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
         obj64.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj64.gxTpr_Residentlastname = A65ResidentLastName;
         obj64.gxTpr_Residentemail = A67ResidentEmail;
         obj64.gxTpr_Residentgender = A68ResidentGender;
         obj64.gxTpr_Residentcountry = A312ResidentCountry;
         obj64.gxTpr_Residentcity = A313ResidentCity;
         obj64.gxTpr_Residentaddressline1 = A315ResidentAddressLine1;
         obj64.gxTpr_Residentaddressline2 = A316ResidentAddressLine2;
         obj64.gxTpr_Residentbirthdate = A73ResidentBirthDate;
         obj64.gxTpr_Residentguid = A71ResidentGUID;
         obj64.gxTpr_Residenttypeid = A96ResidentTypeId;
         obj64.gxTpr_Residenttypename = A97ResidentTypeName;
         obj64.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         obj64.gxTpr_Medicalindicationname = A99MedicalIndicationName;
         obj64.gxTpr_Residentphonecode = A347ResidentPhoneCode;
         obj64.gxTpr_Residentphonenumber = A348ResidentPhoneNumber;
         obj64.gxTpr_Residenthomephonecode = A431ResidentHomePhoneCode;
         obj64.gxTpr_Residenthomephonenumber = A432ResidentHomePhoneNumber;
         obj64.gxTpr_Residentimage = A445ResidentImage;
         obj64.gxTpr_Residentimage_gxi = A40000ResidentImage_GXI;
         obj64.gxTpr_Residentlanguage = A599ResidentLanguage;
         obj64.gxTpr_Residentpackageid = A527ResidentPackageId;
         obj64.gxTpr_Residentpackagename = A531ResidentPackageName;
         obj64.gxTpr_Sg_locationid = A528SG_LocationId;
         obj64.gxTpr_Sg_organisationid = A529SG_OrganisationId;
         obj64.gxTpr_Residentid = A62ResidentId;
         obj64.gxTpr_Locationid = A29LocationId;
         obj64.gxTpr_Organisationid = A11OrganisationId;
         obj64.gxTpr_Residentid_Z = Z62ResidentId;
         obj64.gxTpr_Locationid_Z = Z29LocationId;
         obj64.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj64.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj64.gxTpr_Residentbsnnumber_Z = Z63ResidentBsnNumber;
         obj64.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj64.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj64.gxTpr_Residentinitials_Z = Z66ResidentInitials;
         obj64.gxTpr_Residentemail_Z = Z67ResidentEmail;
         obj64.gxTpr_Residentgender_Z = Z68ResidentGender;
         obj64.gxTpr_Residentcountry_Z = Z312ResidentCountry;
         obj64.gxTpr_Residentcity_Z = Z313ResidentCity;
         obj64.gxTpr_Residentzipcode_Z = Z314ResidentZipCode;
         obj64.gxTpr_Residentaddressline1_Z = Z315ResidentAddressLine1;
         obj64.gxTpr_Residentaddressline2_Z = Z316ResidentAddressLine2;
         obj64.gxTpr_Residentphone_Z = Z70ResidentPhone;
         obj64.gxTpr_Residenthomephone_Z = Z430ResidentHomePhone;
         obj64.gxTpr_Residentbirthdate_Z = Z73ResidentBirthDate;
         obj64.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj64.gxTpr_Residenttypeid_Z = Z96ResidentTypeId;
         obj64.gxTpr_Residenttypename_Z = Z97ResidentTypeName;
         obj64.gxTpr_Medicalindicationid_Z = Z98MedicalIndicationId;
         obj64.gxTpr_Medicalindicationname_Z = Z99MedicalIndicationName;
         obj64.gxTpr_Residentphonecode_Z = Z347ResidentPhoneCode;
         obj64.gxTpr_Residentphonenumber_Z = Z348ResidentPhoneNumber;
         obj64.gxTpr_Residenthomephonecode_Z = Z431ResidentHomePhoneCode;
         obj64.gxTpr_Residenthomephonenumber_Z = Z432ResidentHomePhoneNumber;
         obj64.gxTpr_Residentlanguage_Z = Z599ResidentLanguage;
         obj64.gxTpr_Residentpackageid_Z = Z527ResidentPackageId;
         obj64.gxTpr_Residentpackagename_Z = Z531ResidentPackageName;
         obj64.gxTpr_Sg_locationid_Z = Z528SG_LocationId;
         obj64.gxTpr_Sg_organisationid_Z = Z529SG_OrganisationId;
         obj64.gxTpr_Residentimage_gxi_Z = Z40000ResidentImage_GXI;
         obj64.gxTpr_Residenttypeid_N = (short)(Convert.ToInt16(n96ResidentTypeId));
         obj64.gxTpr_Medicalindicationid_N = (short)(Convert.ToInt16(n98MedicalIndicationId));
         obj64.gxTpr_Residentimage_N = (short)(Convert.ToInt16(n445ResidentImage));
         obj64.gxTpr_Residentpackageid_N = (short)(Convert.ToInt16(n527ResidentPackageId));
         obj64.gxTpr_Residentimage_gxi_N = (short)(Convert.ToInt16(n40000ResidentImage_GXI));
         obj64.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow64( SdtTrn_Resident obj64 )
      {
         obj64.gxTpr_Residentid = A62ResidentId;
         obj64.gxTpr_Locationid = A29LocationId;
         obj64.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars64( SdtTrn_Resident obj64 ,
                               int forceLoad )
      {
         Gx_mode = obj64.gxTpr_Mode;
         A66ResidentInitials = obj64.gxTpr_Residentinitials;
         A70ResidentPhone = obj64.gxTpr_Residentphone;
         A430ResidentHomePhone = obj64.gxTpr_Residenthomephone;
         A314ResidentZipCode = obj64.gxTpr_Residentzipcode;
         A72ResidentSalutation = obj64.gxTpr_Residentsalutation;
         A63ResidentBsnNumber = obj64.gxTpr_Residentbsnnumber;
         A64ResidentGivenName = obj64.gxTpr_Residentgivenname;
         A65ResidentLastName = obj64.gxTpr_Residentlastname;
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A67ResidentEmail = obj64.gxTpr_Residentemail;
         }
         A68ResidentGender = obj64.gxTpr_Residentgender;
         A312ResidentCountry = obj64.gxTpr_Residentcountry;
         A313ResidentCity = obj64.gxTpr_Residentcity;
         A315ResidentAddressLine1 = obj64.gxTpr_Residentaddressline1;
         A316ResidentAddressLine2 = obj64.gxTpr_Residentaddressline2;
         A73ResidentBirthDate = obj64.gxTpr_Residentbirthdate;
         A71ResidentGUID = obj64.gxTpr_Residentguid;
         A96ResidentTypeId = obj64.gxTpr_Residenttypeid;
         n96ResidentTypeId = false;
         A97ResidentTypeName = obj64.gxTpr_Residenttypename;
         A98MedicalIndicationId = obj64.gxTpr_Medicalindicationid;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = obj64.gxTpr_Medicalindicationname;
         A347ResidentPhoneCode = obj64.gxTpr_Residentphonecode;
         A348ResidentPhoneNumber = obj64.gxTpr_Residentphonenumber;
         A431ResidentHomePhoneCode = obj64.gxTpr_Residenthomephonecode;
         A432ResidentHomePhoneNumber = obj64.gxTpr_Residenthomephonenumber;
         A445ResidentImage = obj64.gxTpr_Residentimage;
         n445ResidentImage = false;
         A40000ResidentImage_GXI = obj64.gxTpr_Residentimage_gxi;
         n40000ResidentImage_GXI = false;
         A599ResidentLanguage = obj64.gxTpr_Residentlanguage;
         A527ResidentPackageId = obj64.gxTpr_Residentpackageid;
         n527ResidentPackageId = false;
         A531ResidentPackageName = obj64.gxTpr_Residentpackagename;
         A528SG_LocationId = obj64.gxTpr_Sg_locationid;
         A529SG_OrganisationId = obj64.gxTpr_Sg_organisationid;
         A62ResidentId = obj64.gxTpr_Residentid;
         A29LocationId = obj64.gxTpr_Locationid;
         A11OrganisationId = obj64.gxTpr_Organisationid;
         Z62ResidentId = obj64.gxTpr_Residentid_Z;
         Z29LocationId = obj64.gxTpr_Locationid_Z;
         Z11OrganisationId = obj64.gxTpr_Organisationid_Z;
         Z72ResidentSalutation = obj64.gxTpr_Residentsalutation_Z;
         Z63ResidentBsnNumber = obj64.gxTpr_Residentbsnnumber_Z;
         Z64ResidentGivenName = obj64.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj64.gxTpr_Residentlastname_Z;
         Z66ResidentInitials = obj64.gxTpr_Residentinitials_Z;
         Z67ResidentEmail = obj64.gxTpr_Residentemail_Z;
         Z68ResidentGender = obj64.gxTpr_Residentgender_Z;
         Z312ResidentCountry = obj64.gxTpr_Residentcountry_Z;
         Z313ResidentCity = obj64.gxTpr_Residentcity_Z;
         Z314ResidentZipCode = obj64.gxTpr_Residentzipcode_Z;
         Z315ResidentAddressLine1 = obj64.gxTpr_Residentaddressline1_Z;
         Z316ResidentAddressLine2 = obj64.gxTpr_Residentaddressline2_Z;
         Z70ResidentPhone = obj64.gxTpr_Residentphone_Z;
         Z430ResidentHomePhone = obj64.gxTpr_Residenthomephone_Z;
         Z73ResidentBirthDate = obj64.gxTpr_Residentbirthdate_Z;
         Z71ResidentGUID = obj64.gxTpr_Residentguid_Z;
         Z96ResidentTypeId = obj64.gxTpr_Residenttypeid_Z;
         Z97ResidentTypeName = obj64.gxTpr_Residenttypename_Z;
         Z98MedicalIndicationId = obj64.gxTpr_Medicalindicationid_Z;
         Z99MedicalIndicationName = obj64.gxTpr_Medicalindicationname_Z;
         Z347ResidentPhoneCode = obj64.gxTpr_Residentphonecode_Z;
         Z348ResidentPhoneNumber = obj64.gxTpr_Residentphonenumber_Z;
         Z431ResidentHomePhoneCode = obj64.gxTpr_Residenthomephonecode_Z;
         Z432ResidentHomePhoneNumber = obj64.gxTpr_Residenthomephonenumber_Z;
         Z599ResidentLanguage = obj64.gxTpr_Residentlanguage_Z;
         Z527ResidentPackageId = obj64.gxTpr_Residentpackageid_Z;
         Z531ResidentPackageName = obj64.gxTpr_Residentpackagename_Z;
         Z528SG_LocationId = obj64.gxTpr_Sg_locationid_Z;
         Z529SG_OrganisationId = obj64.gxTpr_Sg_organisationid_Z;
         Z40000ResidentImage_GXI = obj64.gxTpr_Residentimage_gxi_Z;
         n96ResidentTypeId = (bool)(Convert.ToBoolean(obj64.gxTpr_Residenttypeid_N));
         n98MedicalIndicationId = (bool)(Convert.ToBoolean(obj64.gxTpr_Medicalindicationid_N));
         n445ResidentImage = (bool)(Convert.ToBoolean(obj64.gxTpr_Residentimage_N));
         n527ResidentPackageId = (bool)(Convert.ToBoolean(obj64.gxTpr_Residentpackageid_N));
         n40000ResidentImage_GXI = (bool)(Convert.ToBoolean(obj64.gxTpr_Residentimage_gxi_N));
         Gx_mode = obj64.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A62ResidentId = (Guid)getParm(obj,0);
         A29LocationId = (Guid)getParm(obj,1);
         A11OrganisationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0964( ) ;
         ScanKeyStart0964( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000919 */
            pr_default.execute(17, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(17) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(17);
         }
         else
         {
            Gx_mode = "UPD";
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0964( -38) ;
         OnLoadActions0964( ) ;
         AddRow0964( ) ;
         ScanKeyEnd0964( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars64( bcTrn_Resident, 0) ;
         ScanKeyStart0964( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000919 */
            pr_default.execute(17, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(17) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(17);
         }
         else
         {
            Gx_mode = "UPD";
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0964( -38) ;
         OnLoadActions0964( ) ;
         AddRow0964( ) ;
         ScanKeyEnd0964( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0964( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0964( ) ;
         }
         else
         {
            if ( RcdFound64 == 1 )
            {
               if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A62ResidentId = Z62ResidentId;
                  A29LocationId = Z29LocationId;
                  A11OrganisationId = Z11OrganisationId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0964( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0964( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0964( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcTrn_Resident, 1) ;
         SaveImpl( ) ;
         VarsToRow64( bcTrn_Resident) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcTrn_Resident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0964( ) ;
         AfterTrn( ) ;
         VarsToRow64( bcTrn_Resident) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow64( bcTrn_Resident) ;
         }
         else
         {
            SdtTrn_Resident auxBC = new SdtTrn_Resident(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A62ResidentId, A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Resident);
               auxBC.Save();
               bcTrn_Resident.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcTrn_Resident, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcTrn_Resident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0964( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow64( bcTrn_Resident) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow64( bcTrn_Resident) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcTrn_Resident, 0) ;
         GetKey0964( ) ;
         if ( RcdFound64 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A62ResidentId = Z62ResidentId;
               A29LocationId = Z29LocationId;
               A11OrganisationId = Z11OrganisationId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_resident_bc",pr_default);
         VarsToRow64( bcTrn_Resident) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_Resident.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Resident.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Resident )
         {
            bcTrn_Resident = (SdtTrn_Resident)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Resident.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Resident.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow64( bcTrn_Resident) ;
            }
            else
            {
               RowToVars64( bcTrn_Resident, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Resident.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Resident.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars64( bcTrn_Resident, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Resident Trn_Resident_BC
      {
         get {
            return bcTrn_Resident ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_resident_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV63Pgmname = "";
         AV17TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV15Insert_ResidentTypeId = Guid.Empty;
         AV16Insert_MedicalIndicationId = Guid.Empty;
         AV51Insert_ResidentPackageId = Guid.Empty;
         AV38ComboResidentCountry = "";
         AV39ComboResidentPhoneCode = "";
         AV40defaultCountryPhoneCode = "";
         AV44ComboResidentHomePhoneCode = "";
         AV42AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         Z66ResidentInitials = "";
         A66ResidentInitials = "";
         Z70ResidentPhone = "";
         A70ResidentPhone = "";
         Z430ResidentHomePhone = "";
         A430ResidentHomePhone = "";
         Z314ResidentZipCode = "";
         A314ResidentZipCode = "";
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         A63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z67ResidentEmail = "";
         A67ResidentEmail = "";
         Z68ResidentGender = "";
         A68ResidentGender = "";
         Z312ResidentCountry = "";
         A312ResidentCountry = "";
         Z313ResidentCity = "";
         A313ResidentCity = "";
         Z315ResidentAddressLine1 = "";
         A315ResidentAddressLine1 = "";
         Z316ResidentAddressLine2 = "";
         A316ResidentAddressLine2 = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         A73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z347ResidentPhoneCode = "";
         A347ResidentPhoneCode = "";
         Z348ResidentPhoneNumber = "";
         A348ResidentPhoneNumber = "";
         Z431ResidentHomePhoneCode = "";
         A431ResidentHomePhoneCode = "";
         Z432ResidentHomePhoneNumber = "";
         A432ResidentHomePhoneNumber = "";
         Z599ResidentLanguage = "";
         A599ResidentLanguage = "";
         Z96ResidentTypeId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         Z527ResidentPackageId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         Z97ResidentTypeName = "";
         A97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         A99MedicalIndicationName = "";
         Z531ResidentPackageName = "";
         A531ResidentPackageName = "";
         Z529SG_OrganisationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         Z528SG_LocationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         Z445ResidentImage = "";
         A445ResidentImage = "";
         Z40000ResidentImage_GXI = "";
         A40000ResidentImage_GXI = "";
         GXt_guid1 = Guid.Empty;
         BC00098_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00098_A66ResidentInitials = new string[] {""} ;
         BC00098_A70ResidentPhone = new string[] {""} ;
         BC00098_A430ResidentHomePhone = new string[] {""} ;
         BC00098_A314ResidentZipCode = new string[] {""} ;
         BC00098_A72ResidentSalutation = new string[] {""} ;
         BC00098_A63ResidentBsnNumber = new string[] {""} ;
         BC00098_A64ResidentGivenName = new string[] {""} ;
         BC00098_A65ResidentLastName = new string[] {""} ;
         BC00098_A67ResidentEmail = new string[] {""} ;
         BC00098_A68ResidentGender = new string[] {""} ;
         BC00098_A312ResidentCountry = new string[] {""} ;
         BC00098_A313ResidentCity = new string[] {""} ;
         BC00098_A315ResidentAddressLine1 = new string[] {""} ;
         BC00098_A316ResidentAddressLine2 = new string[] {""} ;
         BC00098_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC00098_A71ResidentGUID = new string[] {""} ;
         BC00098_A97ResidentTypeName = new string[] {""} ;
         BC00098_A99MedicalIndicationName = new string[] {""} ;
         BC00098_A347ResidentPhoneCode = new string[] {""} ;
         BC00098_A348ResidentPhoneNumber = new string[] {""} ;
         BC00098_A431ResidentHomePhoneCode = new string[] {""} ;
         BC00098_A432ResidentHomePhoneNumber = new string[] {""} ;
         BC00098_A40000ResidentImage_GXI = new string[] {""} ;
         BC00098_n40000ResidentImage_GXI = new bool[] {false} ;
         BC00098_A599ResidentLanguage = new string[] {""} ;
         BC00098_A531ResidentPackageName = new string[] {""} ;
         BC00098_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00098_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00098_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC00098_n96ResidentTypeId = new bool[] {false} ;
         BC00098_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC00098_n98MedicalIndicationId = new bool[] {false} ;
         BC00098_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC00098_n527ResidentPackageId = new bool[] {false} ;
         BC00098_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC00098_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC00098_A445ResidentImage = new string[] {""} ;
         BC00098_n445ResidentImage = new bool[] {false} ;
         BC00094_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00095_A97ResidentTypeName = new string[] {""} ;
         BC00096_A99MedicalIndicationName = new string[] {""} ;
         GXt_char2 = "";
         BC00097_A531ResidentPackageName = new string[] {""} ;
         BC00097_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC00097_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC00099_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00099_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00099_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00093_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00093_A66ResidentInitials = new string[] {""} ;
         BC00093_A70ResidentPhone = new string[] {""} ;
         BC00093_A430ResidentHomePhone = new string[] {""} ;
         BC00093_A314ResidentZipCode = new string[] {""} ;
         BC00093_A72ResidentSalutation = new string[] {""} ;
         BC00093_A63ResidentBsnNumber = new string[] {""} ;
         BC00093_A64ResidentGivenName = new string[] {""} ;
         BC00093_A65ResidentLastName = new string[] {""} ;
         BC00093_A67ResidentEmail = new string[] {""} ;
         BC00093_A68ResidentGender = new string[] {""} ;
         BC00093_A312ResidentCountry = new string[] {""} ;
         BC00093_A313ResidentCity = new string[] {""} ;
         BC00093_A315ResidentAddressLine1 = new string[] {""} ;
         BC00093_A316ResidentAddressLine2 = new string[] {""} ;
         BC00093_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC00093_A71ResidentGUID = new string[] {""} ;
         BC00093_A347ResidentPhoneCode = new string[] {""} ;
         BC00093_A348ResidentPhoneNumber = new string[] {""} ;
         BC00093_A431ResidentHomePhoneCode = new string[] {""} ;
         BC00093_A432ResidentHomePhoneNumber = new string[] {""} ;
         BC00093_A40000ResidentImage_GXI = new string[] {""} ;
         BC00093_n40000ResidentImage_GXI = new bool[] {false} ;
         BC00093_A599ResidentLanguage = new string[] {""} ;
         BC00093_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00093_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00093_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC00093_n96ResidentTypeId = new bool[] {false} ;
         BC00093_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC00093_n98MedicalIndicationId = new bool[] {false} ;
         BC00093_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC00093_n527ResidentPackageId = new bool[] {false} ;
         BC00093_A445ResidentImage = new string[] {""} ;
         BC00093_n445ResidentImage = new bool[] {false} ;
         sMode64 = "";
         BC00092_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC00092_A66ResidentInitials = new string[] {""} ;
         BC00092_A70ResidentPhone = new string[] {""} ;
         BC00092_A430ResidentHomePhone = new string[] {""} ;
         BC00092_A314ResidentZipCode = new string[] {""} ;
         BC00092_A72ResidentSalutation = new string[] {""} ;
         BC00092_A63ResidentBsnNumber = new string[] {""} ;
         BC00092_A64ResidentGivenName = new string[] {""} ;
         BC00092_A65ResidentLastName = new string[] {""} ;
         BC00092_A67ResidentEmail = new string[] {""} ;
         BC00092_A68ResidentGender = new string[] {""} ;
         BC00092_A312ResidentCountry = new string[] {""} ;
         BC00092_A313ResidentCity = new string[] {""} ;
         BC00092_A315ResidentAddressLine1 = new string[] {""} ;
         BC00092_A316ResidentAddressLine2 = new string[] {""} ;
         BC00092_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC00092_A71ResidentGUID = new string[] {""} ;
         BC00092_A347ResidentPhoneCode = new string[] {""} ;
         BC00092_A348ResidentPhoneNumber = new string[] {""} ;
         BC00092_A431ResidentHomePhoneCode = new string[] {""} ;
         BC00092_A432ResidentHomePhoneNumber = new string[] {""} ;
         BC00092_A40000ResidentImage_GXI = new string[] {""} ;
         BC00092_n40000ResidentImage_GXI = new bool[] {false} ;
         BC00092_A599ResidentLanguage = new string[] {""} ;
         BC00092_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00092_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00092_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC00092_n96ResidentTypeId = new bool[] {false} ;
         BC00092_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC00092_n98MedicalIndicationId = new bool[] {false} ;
         BC00092_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC00092_n527ResidentPackageId = new bool[] {false} ;
         BC00092_A445ResidentImage = new string[] {""} ;
         BC00092_n445ResidentImage = new bool[] {false} ;
         BC000914_A97ResidentTypeName = new string[] {""} ;
         BC000915_A99MedicalIndicationName = new string[] {""} ;
         BC000916_A531ResidentPackageName = new string[] {""} ;
         BC000916_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC000916_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC000917_A549MemoId = new Guid[] {Guid.Empty} ;
         BC000918_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000918_A66ResidentInitials = new string[] {""} ;
         BC000918_A70ResidentPhone = new string[] {""} ;
         BC000918_A430ResidentHomePhone = new string[] {""} ;
         BC000918_A314ResidentZipCode = new string[] {""} ;
         BC000918_A72ResidentSalutation = new string[] {""} ;
         BC000918_A63ResidentBsnNumber = new string[] {""} ;
         BC000918_A64ResidentGivenName = new string[] {""} ;
         BC000918_A65ResidentLastName = new string[] {""} ;
         BC000918_A67ResidentEmail = new string[] {""} ;
         BC000918_A68ResidentGender = new string[] {""} ;
         BC000918_A312ResidentCountry = new string[] {""} ;
         BC000918_A313ResidentCity = new string[] {""} ;
         BC000918_A315ResidentAddressLine1 = new string[] {""} ;
         BC000918_A316ResidentAddressLine2 = new string[] {""} ;
         BC000918_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC000918_A71ResidentGUID = new string[] {""} ;
         BC000918_A97ResidentTypeName = new string[] {""} ;
         BC000918_A99MedicalIndicationName = new string[] {""} ;
         BC000918_A347ResidentPhoneCode = new string[] {""} ;
         BC000918_A348ResidentPhoneNumber = new string[] {""} ;
         BC000918_A431ResidentHomePhoneCode = new string[] {""} ;
         BC000918_A432ResidentHomePhoneNumber = new string[] {""} ;
         BC000918_A40000ResidentImage_GXI = new string[] {""} ;
         BC000918_n40000ResidentImage_GXI = new bool[] {false} ;
         BC000918_A599ResidentLanguage = new string[] {""} ;
         BC000918_A531ResidentPackageName = new string[] {""} ;
         BC000918_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000918_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000918_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000918_n96ResidentTypeId = new bool[] {false} ;
         BC000918_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000918_n98MedicalIndicationId = new bool[] {false} ;
         BC000918_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC000918_n527ResidentPackageId = new bool[] {false} ;
         BC000918_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC000918_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC000918_A445ResidentImage = new string[] {""} ;
         BC000918_n445ResidentImage = new bool[] {false} ;
         AV36GAMErrorResponse = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000919_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_resident_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A62ResidentId, BC00092_A66ResidentInitials, BC00092_A70ResidentPhone, BC00092_A430ResidentHomePhone, BC00092_A314ResidentZipCode, BC00092_A72ResidentSalutation, BC00092_A63ResidentBsnNumber, BC00092_A64ResidentGivenName, BC00092_A65ResidentLastName, BC00092_A67ResidentEmail,
               BC00092_A68ResidentGender, BC00092_A312ResidentCountry, BC00092_A313ResidentCity, BC00092_A315ResidentAddressLine1, BC00092_A316ResidentAddressLine2, BC00092_A73ResidentBirthDate, BC00092_A71ResidentGUID, BC00092_A347ResidentPhoneCode, BC00092_A348ResidentPhoneNumber, BC00092_A431ResidentHomePhoneCode,
               BC00092_A432ResidentHomePhoneNumber, BC00092_A40000ResidentImage_GXI, BC00092_n40000ResidentImage_GXI, BC00092_A599ResidentLanguage, BC00092_A29LocationId, BC00092_A11OrganisationId, BC00092_A96ResidentTypeId, BC00092_n96ResidentTypeId, BC00092_A98MedicalIndicationId, BC00092_n98MedicalIndicationId,
               BC00092_A527ResidentPackageId, BC00092_n527ResidentPackageId, BC00092_A445ResidentImage, BC00092_n445ResidentImage
               }
               , new Object[] {
               BC00093_A62ResidentId, BC00093_A66ResidentInitials, BC00093_A70ResidentPhone, BC00093_A430ResidentHomePhone, BC00093_A314ResidentZipCode, BC00093_A72ResidentSalutation, BC00093_A63ResidentBsnNumber, BC00093_A64ResidentGivenName, BC00093_A65ResidentLastName, BC00093_A67ResidentEmail,
               BC00093_A68ResidentGender, BC00093_A312ResidentCountry, BC00093_A313ResidentCity, BC00093_A315ResidentAddressLine1, BC00093_A316ResidentAddressLine2, BC00093_A73ResidentBirthDate, BC00093_A71ResidentGUID, BC00093_A347ResidentPhoneCode, BC00093_A348ResidentPhoneNumber, BC00093_A431ResidentHomePhoneCode,
               BC00093_A432ResidentHomePhoneNumber, BC00093_A40000ResidentImage_GXI, BC00093_n40000ResidentImage_GXI, BC00093_A599ResidentLanguage, BC00093_A29LocationId, BC00093_A11OrganisationId, BC00093_A96ResidentTypeId, BC00093_n96ResidentTypeId, BC00093_A98MedicalIndicationId, BC00093_n98MedicalIndicationId,
               BC00093_A527ResidentPackageId, BC00093_n527ResidentPackageId, BC00093_A445ResidentImage, BC00093_n445ResidentImage
               }
               , new Object[] {
               BC00094_A29LocationId
               }
               , new Object[] {
               BC00095_A97ResidentTypeName
               }
               , new Object[] {
               BC00096_A99MedicalIndicationName
               }
               , new Object[] {
               BC00097_A531ResidentPackageName, BC00097_A529SG_OrganisationId, BC00097_A528SG_LocationId
               }
               , new Object[] {
               BC00098_A62ResidentId, BC00098_A66ResidentInitials, BC00098_A70ResidentPhone, BC00098_A430ResidentHomePhone, BC00098_A314ResidentZipCode, BC00098_A72ResidentSalutation, BC00098_A63ResidentBsnNumber, BC00098_A64ResidentGivenName, BC00098_A65ResidentLastName, BC00098_A67ResidentEmail,
               BC00098_A68ResidentGender, BC00098_A312ResidentCountry, BC00098_A313ResidentCity, BC00098_A315ResidentAddressLine1, BC00098_A316ResidentAddressLine2, BC00098_A73ResidentBirthDate, BC00098_A71ResidentGUID, BC00098_A97ResidentTypeName, BC00098_A99MedicalIndicationName, BC00098_A347ResidentPhoneCode,
               BC00098_A348ResidentPhoneNumber, BC00098_A431ResidentHomePhoneCode, BC00098_A432ResidentHomePhoneNumber, BC00098_A40000ResidentImage_GXI, BC00098_n40000ResidentImage_GXI, BC00098_A599ResidentLanguage, BC00098_A531ResidentPackageName, BC00098_A29LocationId, BC00098_A11OrganisationId, BC00098_A96ResidentTypeId,
               BC00098_n96ResidentTypeId, BC00098_A98MedicalIndicationId, BC00098_n98MedicalIndicationId, BC00098_A527ResidentPackageId, BC00098_n527ResidentPackageId, BC00098_A529SG_OrganisationId, BC00098_A528SG_LocationId, BC00098_A445ResidentImage, BC00098_n445ResidentImage
               }
               , new Object[] {
               BC00099_A62ResidentId, BC00099_A29LocationId, BC00099_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000914_A97ResidentTypeName
               }
               , new Object[] {
               BC000915_A99MedicalIndicationName
               }
               , new Object[] {
               BC000916_A531ResidentPackageName, BC000916_A529SG_OrganisationId, BC000916_A528SG_LocationId
               }
               , new Object[] {
               BC000917_A549MemoId
               }
               , new Object[] {
               BC000918_A62ResidentId, BC000918_A66ResidentInitials, BC000918_A70ResidentPhone, BC000918_A430ResidentHomePhone, BC000918_A314ResidentZipCode, BC000918_A72ResidentSalutation, BC000918_A63ResidentBsnNumber, BC000918_A64ResidentGivenName, BC000918_A65ResidentLastName, BC000918_A67ResidentEmail,
               BC000918_A68ResidentGender, BC000918_A312ResidentCountry, BC000918_A313ResidentCity, BC000918_A315ResidentAddressLine1, BC000918_A316ResidentAddressLine2, BC000918_A73ResidentBirthDate, BC000918_A71ResidentGUID, BC000918_A97ResidentTypeName, BC000918_A99MedicalIndicationName, BC000918_A347ResidentPhoneCode,
               BC000918_A348ResidentPhoneNumber, BC000918_A431ResidentHomePhoneCode, BC000918_A432ResidentHomePhoneNumber, BC000918_A40000ResidentImage_GXI, BC000918_n40000ResidentImage_GXI, BC000918_A599ResidentLanguage, BC000918_A531ResidentPackageName, BC000918_A29LocationId, BC000918_A11OrganisationId, BC000918_A96ResidentTypeId,
               BC000918_n96ResidentTypeId, BC000918_A98MedicalIndicationId, BC000918_n98MedicalIndicationId, BC000918_A527ResidentPackageId, BC000918_n527ResidentPackageId, BC000918_A529SG_OrganisationId, BC000918_A528SG_LocationId, BC000918_A445ResidentImage, BC000918_n445ResidentImage
               }
               , new Object[] {
               BC000919_A29LocationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         AV63Pgmname = "Trn_Resident_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12092 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound64 ;
      private int trnEnded ;
      private int AV64GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV63Pgmname ;
      private string Z66ResidentInitials ;
      private string A66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string A70ResidentPhone ;
      private string Z430ResidentHomePhone ;
      private string A430ResidentHomePhone ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string Z599ResidentLanguage ;
      private string A599ResidentLanguage ;
      private string GXt_char2 ;
      private string sMode64 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool returnInSub ;
      private bool n40000ResidentImage_GXI ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private bool n527ResidentPackageId ;
      private bool n445ResidentImage ;
      private bool Gx_longc ;
      private string AV36GAMErrorResponse ;
      private string AV38ComboResidentCountry ;
      private string AV39ComboResidentPhoneCode ;
      private string AV40defaultCountryPhoneCode ;
      private string AV44ComboResidentHomePhoneCode ;
      private string Z314ResidentZipCode ;
      private string A314ResidentZipCode ;
      private string Z63ResidentBsnNumber ;
      private string A63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string A64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string A65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string A67ResidentEmail ;
      private string Z68ResidentGender ;
      private string A68ResidentGender ;
      private string Z312ResidentCountry ;
      private string A312ResidentCountry ;
      private string Z313ResidentCity ;
      private string A313ResidentCity ;
      private string Z315ResidentAddressLine1 ;
      private string A315ResidentAddressLine1 ;
      private string Z316ResidentAddressLine2 ;
      private string A316ResidentAddressLine2 ;
      private string Z71ResidentGUID ;
      private string A71ResidentGUID ;
      private string Z347ResidentPhoneCode ;
      private string A347ResidentPhoneCode ;
      private string Z348ResidentPhoneNumber ;
      private string A348ResidentPhoneNumber ;
      private string Z431ResidentHomePhoneCode ;
      private string A431ResidentHomePhoneCode ;
      private string Z432ResidentHomePhoneNumber ;
      private string A432ResidentHomePhoneNumber ;
      private string Z97ResidentTypeName ;
      private string A97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string A99MedicalIndicationName ;
      private string Z531ResidentPackageName ;
      private string A531ResidentPackageName ;
      private string Z40000ResidentImage_GXI ;
      private string A40000ResidentImage_GXI ;
      private string Z445ResidentImage ;
      private string A445ResidentImage ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV15Insert_ResidentTypeId ;
      private Guid AV16Insert_MedicalIndicationId ;
      private Guid AV51Insert_ResidentPackageId ;
      private Guid Z96ResidentTypeId ;
      private Guid A96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid A98MedicalIndicationId ;
      private Guid Z527ResidentPackageId ;
      private Guid A527ResidentPackageId ;
      private Guid Z529SG_OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid Z528SG_LocationId ;
      private Guid A528SG_LocationId ;
      private Guid GXt_guid1 ;
      private IGxSession AV14WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV13TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV42AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00098_A62ResidentId ;
      private string[] BC00098_A66ResidentInitials ;
      private string[] BC00098_A70ResidentPhone ;
      private string[] BC00098_A430ResidentHomePhone ;
      private string[] BC00098_A314ResidentZipCode ;
      private string[] BC00098_A72ResidentSalutation ;
      private string[] BC00098_A63ResidentBsnNumber ;
      private string[] BC00098_A64ResidentGivenName ;
      private string[] BC00098_A65ResidentLastName ;
      private string[] BC00098_A67ResidentEmail ;
      private string[] BC00098_A68ResidentGender ;
      private string[] BC00098_A312ResidentCountry ;
      private string[] BC00098_A313ResidentCity ;
      private string[] BC00098_A315ResidentAddressLine1 ;
      private string[] BC00098_A316ResidentAddressLine2 ;
      private DateTime[] BC00098_A73ResidentBirthDate ;
      private string[] BC00098_A71ResidentGUID ;
      private string[] BC00098_A97ResidentTypeName ;
      private string[] BC00098_A99MedicalIndicationName ;
      private string[] BC00098_A347ResidentPhoneCode ;
      private string[] BC00098_A348ResidentPhoneNumber ;
      private string[] BC00098_A431ResidentHomePhoneCode ;
      private string[] BC00098_A432ResidentHomePhoneNumber ;
      private string[] BC00098_A40000ResidentImage_GXI ;
      private bool[] BC00098_n40000ResidentImage_GXI ;
      private string[] BC00098_A599ResidentLanguage ;
      private string[] BC00098_A531ResidentPackageName ;
      private Guid[] BC00098_A29LocationId ;
      private Guid[] BC00098_A11OrganisationId ;
      private Guid[] BC00098_A96ResidentTypeId ;
      private bool[] BC00098_n96ResidentTypeId ;
      private Guid[] BC00098_A98MedicalIndicationId ;
      private bool[] BC00098_n98MedicalIndicationId ;
      private Guid[] BC00098_A527ResidentPackageId ;
      private bool[] BC00098_n527ResidentPackageId ;
      private Guid[] BC00098_A529SG_OrganisationId ;
      private Guid[] BC00098_A528SG_LocationId ;
      private string[] BC00098_A445ResidentImage ;
      private bool[] BC00098_n445ResidentImage ;
      private Guid[] BC00094_A29LocationId ;
      private string[] BC00095_A97ResidentTypeName ;
      private string[] BC00096_A99MedicalIndicationName ;
      private string[] BC00097_A531ResidentPackageName ;
      private Guid[] BC00097_A529SG_OrganisationId ;
      private Guid[] BC00097_A528SG_LocationId ;
      private Guid[] BC00099_A62ResidentId ;
      private Guid[] BC00099_A29LocationId ;
      private Guid[] BC00099_A11OrganisationId ;
      private Guid[] BC00093_A62ResidentId ;
      private string[] BC00093_A66ResidentInitials ;
      private string[] BC00093_A70ResidentPhone ;
      private string[] BC00093_A430ResidentHomePhone ;
      private string[] BC00093_A314ResidentZipCode ;
      private string[] BC00093_A72ResidentSalutation ;
      private string[] BC00093_A63ResidentBsnNumber ;
      private string[] BC00093_A64ResidentGivenName ;
      private string[] BC00093_A65ResidentLastName ;
      private string[] BC00093_A67ResidentEmail ;
      private string[] BC00093_A68ResidentGender ;
      private string[] BC00093_A312ResidentCountry ;
      private string[] BC00093_A313ResidentCity ;
      private string[] BC00093_A315ResidentAddressLine1 ;
      private string[] BC00093_A316ResidentAddressLine2 ;
      private DateTime[] BC00093_A73ResidentBirthDate ;
      private string[] BC00093_A71ResidentGUID ;
      private string[] BC00093_A347ResidentPhoneCode ;
      private string[] BC00093_A348ResidentPhoneNumber ;
      private string[] BC00093_A431ResidentHomePhoneCode ;
      private string[] BC00093_A432ResidentHomePhoneNumber ;
      private string[] BC00093_A40000ResidentImage_GXI ;
      private bool[] BC00093_n40000ResidentImage_GXI ;
      private string[] BC00093_A599ResidentLanguage ;
      private Guid[] BC00093_A29LocationId ;
      private Guid[] BC00093_A11OrganisationId ;
      private Guid[] BC00093_A96ResidentTypeId ;
      private bool[] BC00093_n96ResidentTypeId ;
      private Guid[] BC00093_A98MedicalIndicationId ;
      private bool[] BC00093_n98MedicalIndicationId ;
      private Guid[] BC00093_A527ResidentPackageId ;
      private bool[] BC00093_n527ResidentPackageId ;
      private string[] BC00093_A445ResidentImage ;
      private bool[] BC00093_n445ResidentImage ;
      private Guid[] BC00092_A62ResidentId ;
      private string[] BC00092_A66ResidentInitials ;
      private string[] BC00092_A70ResidentPhone ;
      private string[] BC00092_A430ResidentHomePhone ;
      private string[] BC00092_A314ResidentZipCode ;
      private string[] BC00092_A72ResidentSalutation ;
      private string[] BC00092_A63ResidentBsnNumber ;
      private string[] BC00092_A64ResidentGivenName ;
      private string[] BC00092_A65ResidentLastName ;
      private string[] BC00092_A67ResidentEmail ;
      private string[] BC00092_A68ResidentGender ;
      private string[] BC00092_A312ResidentCountry ;
      private string[] BC00092_A313ResidentCity ;
      private string[] BC00092_A315ResidentAddressLine1 ;
      private string[] BC00092_A316ResidentAddressLine2 ;
      private DateTime[] BC00092_A73ResidentBirthDate ;
      private string[] BC00092_A71ResidentGUID ;
      private string[] BC00092_A347ResidentPhoneCode ;
      private string[] BC00092_A348ResidentPhoneNumber ;
      private string[] BC00092_A431ResidentHomePhoneCode ;
      private string[] BC00092_A432ResidentHomePhoneNumber ;
      private string[] BC00092_A40000ResidentImage_GXI ;
      private bool[] BC00092_n40000ResidentImage_GXI ;
      private string[] BC00092_A599ResidentLanguage ;
      private Guid[] BC00092_A29LocationId ;
      private Guid[] BC00092_A11OrganisationId ;
      private Guid[] BC00092_A96ResidentTypeId ;
      private bool[] BC00092_n96ResidentTypeId ;
      private Guid[] BC00092_A98MedicalIndicationId ;
      private bool[] BC00092_n98MedicalIndicationId ;
      private Guid[] BC00092_A527ResidentPackageId ;
      private bool[] BC00092_n527ResidentPackageId ;
      private string[] BC00092_A445ResidentImage ;
      private bool[] BC00092_n445ResidentImage ;
      private string[] BC000914_A97ResidentTypeName ;
      private string[] BC000915_A99MedicalIndicationName ;
      private string[] BC000916_A531ResidentPackageName ;
      private Guid[] BC000916_A529SG_OrganisationId ;
      private Guid[] BC000916_A528SG_LocationId ;
      private Guid[] BC000917_A549MemoId ;
      private Guid[] BC000918_A62ResidentId ;
      private string[] BC000918_A66ResidentInitials ;
      private string[] BC000918_A70ResidentPhone ;
      private string[] BC000918_A430ResidentHomePhone ;
      private string[] BC000918_A314ResidentZipCode ;
      private string[] BC000918_A72ResidentSalutation ;
      private string[] BC000918_A63ResidentBsnNumber ;
      private string[] BC000918_A64ResidentGivenName ;
      private string[] BC000918_A65ResidentLastName ;
      private string[] BC000918_A67ResidentEmail ;
      private string[] BC000918_A68ResidentGender ;
      private string[] BC000918_A312ResidentCountry ;
      private string[] BC000918_A313ResidentCity ;
      private string[] BC000918_A315ResidentAddressLine1 ;
      private string[] BC000918_A316ResidentAddressLine2 ;
      private DateTime[] BC000918_A73ResidentBirthDate ;
      private string[] BC000918_A71ResidentGUID ;
      private string[] BC000918_A97ResidentTypeName ;
      private string[] BC000918_A99MedicalIndicationName ;
      private string[] BC000918_A347ResidentPhoneCode ;
      private string[] BC000918_A348ResidentPhoneNumber ;
      private string[] BC000918_A431ResidentHomePhoneCode ;
      private string[] BC000918_A432ResidentHomePhoneNumber ;
      private string[] BC000918_A40000ResidentImage_GXI ;
      private bool[] BC000918_n40000ResidentImage_GXI ;
      private string[] BC000918_A599ResidentLanguage ;
      private string[] BC000918_A531ResidentPackageName ;
      private Guid[] BC000918_A29LocationId ;
      private Guid[] BC000918_A11OrganisationId ;
      private Guid[] BC000918_A96ResidentTypeId ;
      private bool[] BC000918_n96ResidentTypeId ;
      private Guid[] BC000918_A98MedicalIndicationId ;
      private bool[] BC000918_n98MedicalIndicationId ;
      private Guid[] BC000918_A527ResidentPackageId ;
      private bool[] BC000918_n527ResidentPackageId ;
      private Guid[] BC000918_A529SG_OrganisationId ;
      private Guid[] BC000918_A528SG_LocationId ;
      private string[] BC000918_A445ResidentImage ;
      private bool[] BC000918_n445ResidentImage ;
      private SdtTrn_Resident bcTrn_Resident ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000919_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_resident_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_resident_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_resident_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00092;
       prmBC00092 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00093;
       prmBC00093 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00094;
       prmBC00094 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00095;
       prmBC00095 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00096;
       prmBC00096 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00097;
       prmBC00097 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00098;
       prmBC00098 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00099;
       prmBC00099 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000910;
       prmBC000910 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=21, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentLanguage",GXType.Char,20,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000911;
       prmBC000911 = new Object[] {
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentZipCode",GXType.VarChar,100,0) ,
       new ParDef("ResidentSalutation",GXType.Char,20,0) ,
       new ParDef("ResidentBsnNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentGivenName",GXType.VarChar,100,0) ,
       new ParDef("ResidentLastName",GXType.VarChar,100,0) ,
       new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
       new ParDef("ResidentGender",GXType.VarChar,40,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentCity",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("ResidentAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentLanguage",GXType.Char,20,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000912;
       prmBC000912 = new Object[] {
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000913;
       prmBC000913 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000914;
       prmBC000914 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000915;
       prmBC000915 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000916;
       prmBC000916 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000917;
       prmBC000917 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000918;
       prmBC000918 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000919;
       prmBC000919 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00092", "SELECT ResidentId, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentZipCode, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, ResidentImage_GXI, ResidentLanguage, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId, ResidentPackageId, ResidentImage FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00093", "SELECT ResidentId, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentZipCode, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, ResidentImage_GXI, ResidentLanguage, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId, ResidentPackageId, ResidentImage FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00094", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00095", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00096", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00097", "SELECT ResidentPackageName, SG_OrganisationId, SG_LocationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00097,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00098", "SELECT TM1.ResidentId, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentHomePhone, TM1.ResidentZipCode, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCountry, TM1.ResidentCity, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentBirthDate, TM1.ResidentGUID, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneCode, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneCode, TM1.ResidentHomePhoneNumber, TM1.ResidentImage_GXI, TM1.ResidentLanguage, T4.ResidentPackageName, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId, TM1.ResidentPackageId, T4.SG_OrganisationId, T4.SG_LocationId, TM1.ResidentImage FROM (((Trn_Resident TM1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) LEFT JOIN Trn_ResidentPackage T4 ON T4.ResidentPackageId = TM1.ResidentPackageId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00099", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000910", "SAVEPOINT gxupdate;INSERT INTO Trn_Resident(ResidentId, ResidentInitials, ResidentPhone, ResidentHomePhone, ResidentZipCode, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentAddressLine1, ResidentAddressLine2, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentHomePhoneCode, ResidentHomePhoneNumber, ResidentImage, ResidentImage_GXI, ResidentLanguage, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId, ResidentPackageId) VALUES(:ResidentId, :ResidentInitials, :ResidentPhone, :ResidentHomePhone, :ResidentZipCode, :ResidentSalutation, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentCountry, :ResidentCity, :ResidentAddressLine1, :ResidentAddressLine2, :ResidentBirthDate, :ResidentGUID, :ResidentPhoneCode, :ResidentPhoneNumber, :ResidentHomePhoneCode, :ResidentHomePhoneNumber, :ResidentImage, :ResidentImage_GXI, :ResidentLanguage, :LocationId, :OrganisationId, :ResidentTypeId, :MedicalIndicationId, :ResidentPackageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000910)
          ,new CursorDef("BC000911", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentInitials=:ResidentInitials, ResidentPhone=:ResidentPhone, ResidentHomePhone=:ResidentHomePhone, ResidentZipCode=:ResidentZipCode, ResidentSalutation=:ResidentSalutation, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentCountry=:ResidentCountry, ResidentCity=:ResidentCity, ResidentAddressLine1=:ResidentAddressLine1, ResidentAddressLine2=:ResidentAddressLine2, ResidentBirthDate=:ResidentBirthDate, ResidentGUID=:ResidentGUID, ResidentPhoneCode=:ResidentPhoneCode, ResidentPhoneNumber=:ResidentPhoneNumber, ResidentHomePhoneCode=:ResidentHomePhoneCode, ResidentHomePhoneNumber=:ResidentHomePhoneNumber, ResidentLanguage=:ResidentLanguage, ResidentTypeId=:ResidentTypeId, MedicalIndicationId=:MedicalIndicationId, ResidentPackageId=:ResidentPackageId  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000911)
          ,new CursorDef("BC000912", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentImage=:ResidentImage, ResidentImage_GXI=:ResidentImage_GXI  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000912)
          ,new CursorDef("BC000913", "SAVEPOINT gxupdate;DELETE FROM Trn_Resident  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000913)
          ,new CursorDef("BC000914", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000914,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000915", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000915,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000916", "SELECT ResidentPackageName, SG_OrganisationId, SG_LocationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000916,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000917", "SELECT MemoId FROM Trn_Memo WHERE ResidentId = :ResidentId AND SG_LocationId = :LocationId AND SG_OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000917,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000918", "SELECT TM1.ResidentId, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentHomePhone, TM1.ResidentZipCode, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCountry, TM1.ResidentCity, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentBirthDate, TM1.ResidentGUID, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneCode, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneCode, TM1.ResidentHomePhoneNumber, TM1.ResidentImage_GXI, TM1.ResidentLanguage, T4.ResidentPackageName, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId, TM1.ResidentPackageId, T4.SG_OrganisationId, T4.SG_LocationId, TM1.ResidentImage FROM (((Trn_Resident TM1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) LEFT JOIN Trn_ResidentPackage T4 ON T4.ResidentPackageId = TM1.ResidentPackageId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000918,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000919", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000919,1, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[22])[0] = rslt.wasNull(22);
             ((string[]) buf[23])[0] = rslt.getString(23, 20);
             ((Guid[]) buf[24])[0] = rslt.getGuid(24);
             ((Guid[]) buf[25])[0] = rslt.getGuid(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((bool[]) buf[27])[0] = rslt.wasNull(26);
             ((Guid[]) buf[28])[0] = rslt.getGuid(27);
             ((bool[]) buf[29])[0] = rslt.wasNull(27);
             ((Guid[]) buf[30])[0] = rslt.getGuid(28);
             ((bool[]) buf[31])[0] = rslt.wasNull(28);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(22));
             ((bool[]) buf[33])[0] = rslt.wasNull(29);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[22])[0] = rslt.wasNull(22);
             ((string[]) buf[23])[0] = rslt.getString(23, 20);
             ((Guid[]) buf[24])[0] = rslt.getGuid(24);
             ((Guid[]) buf[25])[0] = rslt.getGuid(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((bool[]) buf[27])[0] = rslt.wasNull(26);
             ((Guid[]) buf[28])[0] = rslt.getGuid(27);
             ((bool[]) buf[29])[0] = rslt.wasNull(27);
             ((Guid[]) buf[30])[0] = rslt.getGuid(28);
             ((bool[]) buf[31])[0] = rslt.wasNull(28);
             ((string[]) buf[32])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(22));
             ((bool[]) buf[33])[0] = rslt.wasNull(29);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((string[]) buf[23])[0] = rslt.getMultimediaUri(24);
             ((bool[]) buf[24])[0] = rslt.wasNull(24);
             ((string[]) buf[25])[0] = rslt.getString(25, 20);
             ((string[]) buf[26])[0] = rslt.getVarchar(26);
             ((Guid[]) buf[27])[0] = rslt.getGuid(27);
             ((Guid[]) buf[28])[0] = rslt.getGuid(28);
             ((Guid[]) buf[29])[0] = rslt.getGuid(29);
             ((bool[]) buf[30])[0] = rslt.wasNull(29);
             ((Guid[]) buf[31])[0] = rslt.getGuid(30);
             ((bool[]) buf[32])[0] = rslt.wasNull(30);
             ((Guid[]) buf[33])[0] = rslt.getGuid(31);
             ((bool[]) buf[34])[0] = rslt.wasNull(31);
             ((Guid[]) buf[35])[0] = rslt.getGuid(32);
             ((Guid[]) buf[36])[0] = rslt.getGuid(33);
             ((string[]) buf[37])[0] = rslt.getMultimediaFile(34, rslt.getVarchar(24));
             ((bool[]) buf[38])[0] = rslt.wasNull(34);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((string[]) buf[23])[0] = rslt.getMultimediaUri(24);
             ((bool[]) buf[24])[0] = rslt.wasNull(24);
             ((string[]) buf[25])[0] = rslt.getString(25, 20);
             ((string[]) buf[26])[0] = rslt.getVarchar(26);
             ((Guid[]) buf[27])[0] = rslt.getGuid(27);
             ((Guid[]) buf[28])[0] = rslt.getGuid(28);
             ((Guid[]) buf[29])[0] = rslt.getGuid(29);
             ((bool[]) buf[30])[0] = rslt.wasNull(29);
             ((Guid[]) buf[31])[0] = rslt.getGuid(30);
             ((bool[]) buf[32])[0] = rslt.wasNull(30);
             ((Guid[]) buf[33])[0] = rslt.getGuid(31);
             ((bool[]) buf[34])[0] = rslt.wasNull(31);
             ((Guid[]) buf[35])[0] = rslt.getGuid(32);
             ((Guid[]) buf[36])[0] = rslt.getGuid(33);
             ((string[]) buf[37])[0] = rslt.getMultimediaFile(34, rslt.getVarchar(24));
             ((bool[]) buf[38])[0] = rslt.wasNull(34);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
