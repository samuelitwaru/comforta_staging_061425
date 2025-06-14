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
   public class trn_suppliergen_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_suppliergen_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergen_bc( IGxContext context )
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
         ReadRow069( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey069( ) ;
         standaloneModal( ) ;
         AddRow069( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z42SupplierGenId = A42SupplierGenId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               if ( AnyError == 0 )
               {
                  ZM069( 29) ;
                  ZM069( 30) ;
                  ZM069( 31) ;
               }
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV43Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV44GXV1 = 1;
            while ( AV44GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV44GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierGenTypeId") == 0 )
               {
                  AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_OrganisationSupplierId") == 0 )
               {
                  AV34Insert_SG_OrganisationSupplierId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_LocationSupplierOrganisationId") == 0 )
               {
                  AV35Insert_SG_LocationSupplierOrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SG_LocationSupplierLocationId") == 0 )
               {
                  AV36Insert_SG_LocationSupplierLocationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV44GXV1 = (int)(AV44GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
         GXt_guid1 = AV39SG_LocationSupplierLocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV39SG_LocationSupplierLocationId = GXt_guid1;
         if ( (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            A603SG_LocationSupplierLocationId = Guid.Empty;
            n603SG_LocationSupplierLocationId = false;
            n603SG_LocationSupplierLocationId = true;
         }
         if ( ! (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            GXt_guid1 = AV38SG_LocationSupplierOrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV38SG_LocationSupplierOrganisationId = GXt_guid1;
            if ( (Guid.Empty==AV38SG_LocationSupplierOrganisationId) )
            {
               A602SG_LocationSupplierOrganisatio = Guid.Empty;
               n602SG_LocationSupplierOrganisatio = false;
               n602SG_LocationSupplierOrganisatio = true;
            }
         }
         if ( (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            GXt_guid1 = AV40SG_OrganisationSupplierId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            AV40SG_OrganisationSupplierId = GXt_guid1;
            if ( (Guid.Empty==AV40SG_OrganisationSupplierId) )
            {
               A601SG_OrganisationSupplierId = Guid.Empty;
               n601SG_OrganisationSupplierId = false;
               n601SG_OrganisationSupplierId = true;
            }
         }
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV12WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "General Supplier Inserted successfully", ""));
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z607SupplierGenLandlineNumber = A607SupplierGenLandlineNumber;
            Z259SupplierGenAddressZipCode = A259SupplierGenAddressZipCode;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z309SupplierGenAddressCountry = A309SupplierGenAddressCountry;
            Z260SupplierGenAddressCity = A260SupplierGenAddressCity;
            Z310SupplierGenAddressLine1 = A310SupplierGenAddressLine1;
            Z311SupplierGenAddressLine2 = A311SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z353SupplierGenPhoneCode = A353SupplierGenPhoneCode;
            Z354SupplierGenPhoneNumber = A354SupplierGenPhoneNumber;
            Z605SupplierGenLandlineCode = A605SupplierGenLandlineCode;
            Z606SupplierGenLandlineSubNumber = A606SupplierGenLandlineSubNumber;
            Z501SupplierGenEmail = A501SupplierGenEmail;
            Z428SupplierGenWebsite = A428SupplierGenWebsite;
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            Z601SG_OrganisationSupplierId = A601SG_OrganisationSupplierId;
            Z602SG_LocationSupplierOrganisatio = A602SG_LocationSupplierOrganisatio;
            Z603SG_LocationSupplierLocationId = A603SG_LocationSupplierLocationId;
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -28 )
         {
            Z42SupplierGenId = A42SupplierGenId;
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z607SupplierGenLandlineNumber = A607SupplierGenLandlineNumber;
            Z259SupplierGenAddressZipCode = A259SupplierGenAddressZipCode;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z309SupplierGenAddressCountry = A309SupplierGenAddressCountry;
            Z260SupplierGenAddressCity = A260SupplierGenAddressCity;
            Z310SupplierGenAddressLine1 = A310SupplierGenAddressLine1;
            Z311SupplierGenAddressLine2 = A311SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z353SupplierGenPhoneCode = A353SupplierGenPhoneCode;
            Z354SupplierGenPhoneNumber = A354SupplierGenPhoneNumber;
            Z605SupplierGenLandlineCode = A605SupplierGenLandlineCode;
            Z606SupplierGenLandlineSubNumber = A606SupplierGenLandlineSubNumber;
            Z501SupplierGenEmail = A501SupplierGenEmail;
            Z428SupplierGenWebsite = A428SupplierGenWebsite;
            Z604SupplierGenDescription = A604SupplierGenDescription;
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            Z601SG_OrganisationSupplierId = A601SG_OrganisationSupplierId;
            Z602SG_LocationSupplierOrganisatio = A602SG_LocationSupplierOrganisatio;
            Z603SG_LocationSupplierLocationId = A603SG_LocationSupplierLocationId;
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV43Pgmname = "Trn_SupplierGen_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) )
         {
            A42SupplierGenId = Guid.NewGuid( );
            n42SupplierGenId = false;
         }
         if ( IsIns( )  && ! (Guid.Empty==AV40SG_OrganisationSupplierId) )
         {
            A601SG_OrganisationSupplierId = AV40SG_OrganisationSupplierId;
            n601SG_OrganisationSupplierId = false;
         }
         if ( IsIns( )  && ! (Guid.Empty==AV38SG_LocationSupplierOrganisationId) )
         {
            A602SG_LocationSupplierOrganisatio = AV38SG_LocationSupplierOrganisationId;
            n602SG_LocationSupplierOrganisatio = false;
         }
         if ( IsIns( )  && ! (Guid.Empty==AV39SG_LocationSupplierLocationId) )
         {
            A603SG_LocationSupplierLocationId = AV39SG_LocationSupplierLocationId;
            n603SG_LocationSupplierLocationId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load069( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
            A48SupplierGenContactPhone = BC00067_A48SupplierGenContactPhone[0];
            A607SupplierGenLandlineNumber = BC00067_A607SupplierGenLandlineNumber[0];
            A259SupplierGenAddressZipCode = BC00067_A259SupplierGenAddressZipCode[0];
            A43SupplierGenKvkNumber = BC00067_A43SupplierGenKvkNumber[0];
            A254SupplierGenTypeName = BC00067_A254SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC00067_A44SupplierGenCompanyName[0];
            A309SupplierGenAddressCountry = BC00067_A309SupplierGenAddressCountry[0];
            A260SupplierGenAddressCity = BC00067_A260SupplierGenAddressCity[0];
            A310SupplierGenAddressLine1 = BC00067_A310SupplierGenAddressLine1[0];
            A311SupplierGenAddressLine2 = BC00067_A311SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC00067_A47SupplierGenContactName[0];
            A353SupplierGenPhoneCode = BC00067_A353SupplierGenPhoneCode[0];
            A354SupplierGenPhoneNumber = BC00067_A354SupplierGenPhoneNumber[0];
            A605SupplierGenLandlineCode = BC00067_A605SupplierGenLandlineCode[0];
            A606SupplierGenLandlineSubNumber = BC00067_A606SupplierGenLandlineSubNumber[0];
            A501SupplierGenEmail = BC00067_A501SupplierGenEmail[0];
            A428SupplierGenWebsite = BC00067_A428SupplierGenWebsite[0];
            A604SupplierGenDescription = BC00067_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = BC00067_A253SupplierGenTypeId[0];
            A601SG_OrganisationSupplierId = BC00067_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = BC00067_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = BC00067_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = BC00067_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = BC00067_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = BC00067_n603SG_LocationSupplierLocationId[0];
            ZM069( -28) ;
         }
         pr_default.close(5);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         A259SupplierGenAddressZipCode = StringUtil.Upper( A259SupplierGenAddressZipCode);
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
      }

      protected void CheckExtendedTable069( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A43SupplierGenKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43SupplierGenKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen KvK Number", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A43SupplierGenKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KvK number should contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Supplier Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
         }
         A254SupplierGenTypeName = BC00064_A254SupplierGenTypeName[0];
         pr_default.close(2);
         if ( (Guid.Empty==A253SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Category", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Company Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A309SupplierGenAddressCountry)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Address Country", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A260SupplierGenAddressCity)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         A259SupplierGenAddressZipCode = StringUtil.Upper( A259SupplierGenAddressZipCode);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A259SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! GxRegex.IsMatch(A259SupplierGenAddressZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A259SupplierGenAddressZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A310SupplierGenAddressLine1)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line1", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         GXt_char2 = A48SupplierGenContactPhone;
         new prc_concatenateintlphone(context ).execute(  A353SupplierGenPhoneCode,  A354SupplierGenPhoneNumber, out  GXt_char2) ;
         A48SupplierGenContactPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A354SupplierGenPhoneNumber)) && ! GxRegex.IsMatch(A354SupplierGenPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "");
            AnyError = 1;
         }
         GXt_char2 = A607SupplierGenLandlineNumber;
         new prc_concatenateintlphone(context ).execute(  A605SupplierGenLandlineCode,  A606SupplierGenLandlineSubNumber, out  GXt_char2) ;
         A607SupplierGenLandlineNumber = GXt_char2;
         if ( ! ( GxRegex.IsMatch(A501SupplierGenEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! GxRegex.IsMatch(A428SupplierGenWebsite,context.GetMessage( "(?:https?://|www\\.)[^\\s/$.?#].[^\\s]*", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A428SupplierGenWebsite)) )
         {
            GX_msglist.addItem(context.GetMessage( "Invalid website format", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A601SG_OrganisationSupplierId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Organisation Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONSUPPLIERID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A603SG_LocationSupplierLocationId) || (Guid.Empty==A602SG_LocationSupplierOrganisatio) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Supplier", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_LOCATIONSUPPLIERORGANISATIO");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey069( )
      {
         /* Using cursor BC00068 */
         pr_default.execute(6, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 28) ;
            RcdFound9 = 1;
            A42SupplierGenId = BC00063_A42SupplierGenId[0];
            n42SupplierGenId = BC00063_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC00063_A48SupplierGenContactPhone[0];
            A607SupplierGenLandlineNumber = BC00063_A607SupplierGenLandlineNumber[0];
            A259SupplierGenAddressZipCode = BC00063_A259SupplierGenAddressZipCode[0];
            A43SupplierGenKvkNumber = BC00063_A43SupplierGenKvkNumber[0];
            A44SupplierGenCompanyName = BC00063_A44SupplierGenCompanyName[0];
            A309SupplierGenAddressCountry = BC00063_A309SupplierGenAddressCountry[0];
            A260SupplierGenAddressCity = BC00063_A260SupplierGenAddressCity[0];
            A310SupplierGenAddressLine1 = BC00063_A310SupplierGenAddressLine1[0];
            A311SupplierGenAddressLine2 = BC00063_A311SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC00063_A47SupplierGenContactName[0];
            A353SupplierGenPhoneCode = BC00063_A353SupplierGenPhoneCode[0];
            A354SupplierGenPhoneNumber = BC00063_A354SupplierGenPhoneNumber[0];
            A605SupplierGenLandlineCode = BC00063_A605SupplierGenLandlineCode[0];
            A606SupplierGenLandlineSubNumber = BC00063_A606SupplierGenLandlineSubNumber[0];
            A501SupplierGenEmail = BC00063_A501SupplierGenEmail[0];
            A428SupplierGenWebsite = BC00063_A428SupplierGenWebsite[0];
            A604SupplierGenDescription = BC00063_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = BC00063_A253SupplierGenTypeId[0];
            A601SG_OrganisationSupplierId = BC00063_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = BC00063_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = BC00063_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = BC00063_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = BC00063_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = BC00063_n603SG_LocationSupplierLocationId[0];
            Z42SupplierGenId = A42SupplierGenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z48SupplierGenContactPhone, BC00062_A48SupplierGenContactPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z607SupplierGenLandlineNumber, BC00062_A607SupplierGenLandlineNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z259SupplierGenAddressZipCode, BC00062_A259SupplierGenAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, BC00062_A43SupplierGenKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44SupplierGenCompanyName, BC00062_A44SupplierGenCompanyName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z309SupplierGenAddressCountry, BC00062_A309SupplierGenAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z260SupplierGenAddressCity, BC00062_A260SupplierGenAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z310SupplierGenAddressLine1, BC00062_A310SupplierGenAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z311SupplierGenAddressLine2, BC00062_A311SupplierGenAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierGenContactName, BC00062_A47SupplierGenContactName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z353SupplierGenPhoneCode, BC00062_A353SupplierGenPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z354SupplierGenPhoneNumber, BC00062_A354SupplierGenPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z605SupplierGenLandlineCode, BC00062_A605SupplierGenLandlineCode[0]) != 0 ) || ( StringUtil.StrCmp(Z606SupplierGenLandlineSubNumber, BC00062_A606SupplierGenLandlineSubNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z501SupplierGenEmail, BC00062_A501SupplierGenEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z428SupplierGenWebsite, BC00062_A428SupplierGenWebsite[0]) != 0 ) || ( Z253SupplierGenTypeId != BC00062_A253SupplierGenTypeId[0] ) || ( Z601SG_OrganisationSupplierId != BC00062_A601SG_OrganisationSupplierId[0] ) || ( Z602SG_LocationSupplierOrganisatio != BC00062_A602SG_LocationSupplierOrganisatio[0] ) || ( Z603SG_LocationSupplierLocationId != BC00062_A603SG_LocationSupplierLocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00069 */
                     pr_default.execute(7, new Object[] {n42SupplierGenId, A42SupplierGenId, A48SupplierGenContactPhone, A607SupplierGenLandlineNumber, A259SupplierGenAddressZipCode, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A309SupplierGenAddressCountry, A260SupplierGenAddressCity, A310SupplierGenAddressLine1, A311SupplierGenAddressLine2, A47SupplierGenContactName, A353SupplierGenPhoneCode, A354SupplierGenPhoneNumber, A605SupplierGenLandlineCode, A606SupplierGenLandlineSubNumber, A501SupplierGenEmail, A428SupplierGenWebsite, A604SupplierGenDescription, A253SupplierGenTypeId, n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio, n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(7) == 1) )
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000610 */
                     pr_default.execute(8, new Object[] {A48SupplierGenContactPhone, A607SupplierGenLandlineNumber, A259SupplierGenAddressZipCode, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A309SupplierGenAddressCountry, A260SupplierGenAddressCity, A310SupplierGenAddressLine1, A311SupplierGenAddressLine2, A47SupplierGenContactName, A353SupplierGenPhoneCode, A354SupplierGenPhoneNumber, A605SupplierGenLandlineCode, A606SupplierGenLandlineSubNumber, A501SupplierGenEmail, A428SupplierGenWebsite, A604SupplierGenDescription, A253SupplierGenTypeId, n601SG_OrganisationSupplierId, A601SG_OrganisationSupplierId, n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio, n603SG_LocationSupplierLocationId, A603SG_LocationSupplierLocationId, n42SupplierGenId, A42SupplierGenId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
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
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000611 */
                  pr_default.execute(9, new Object[] {n42SupplierGenId, A42SupplierGenId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel069( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000612 */
            pr_default.execute(10, new Object[] {A253SupplierGenTypeId});
            A254SupplierGenTypeName = BC000612_A254SupplierGenTypeName[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000614 */
            pr_default.execute(12, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
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

      public void ScanKeyStart069( )
      {
         /* Scan By routine */
         /* Using cursor BC000615 */
         pr_default.execute(13, new Object[] {n42SupplierGenId, A42SupplierGenId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = BC000615_A42SupplierGenId[0];
            n42SupplierGenId = BC000615_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC000615_A48SupplierGenContactPhone[0];
            A607SupplierGenLandlineNumber = BC000615_A607SupplierGenLandlineNumber[0];
            A259SupplierGenAddressZipCode = BC000615_A259SupplierGenAddressZipCode[0];
            A43SupplierGenKvkNumber = BC000615_A43SupplierGenKvkNumber[0];
            A254SupplierGenTypeName = BC000615_A254SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC000615_A44SupplierGenCompanyName[0];
            A309SupplierGenAddressCountry = BC000615_A309SupplierGenAddressCountry[0];
            A260SupplierGenAddressCity = BC000615_A260SupplierGenAddressCity[0];
            A310SupplierGenAddressLine1 = BC000615_A310SupplierGenAddressLine1[0];
            A311SupplierGenAddressLine2 = BC000615_A311SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC000615_A47SupplierGenContactName[0];
            A353SupplierGenPhoneCode = BC000615_A353SupplierGenPhoneCode[0];
            A354SupplierGenPhoneNumber = BC000615_A354SupplierGenPhoneNumber[0];
            A605SupplierGenLandlineCode = BC000615_A605SupplierGenLandlineCode[0];
            A606SupplierGenLandlineSubNumber = BC000615_A606SupplierGenLandlineSubNumber[0];
            A501SupplierGenEmail = BC000615_A501SupplierGenEmail[0];
            A428SupplierGenWebsite = BC000615_A428SupplierGenWebsite[0];
            A604SupplierGenDescription = BC000615_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = BC000615_A253SupplierGenTypeId[0];
            A601SG_OrganisationSupplierId = BC000615_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = BC000615_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = BC000615_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = BC000615_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = BC000615_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = BC000615_n603SG_LocationSupplierLocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         ScanKeyLoad069( ) ;
      }

      protected void ScanKeyLoad069( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = BC000615_A42SupplierGenId[0];
            n42SupplierGenId = BC000615_n42SupplierGenId[0];
            A48SupplierGenContactPhone = BC000615_A48SupplierGenContactPhone[0];
            A607SupplierGenLandlineNumber = BC000615_A607SupplierGenLandlineNumber[0];
            A259SupplierGenAddressZipCode = BC000615_A259SupplierGenAddressZipCode[0];
            A43SupplierGenKvkNumber = BC000615_A43SupplierGenKvkNumber[0];
            A254SupplierGenTypeName = BC000615_A254SupplierGenTypeName[0];
            A44SupplierGenCompanyName = BC000615_A44SupplierGenCompanyName[0];
            A309SupplierGenAddressCountry = BC000615_A309SupplierGenAddressCountry[0];
            A260SupplierGenAddressCity = BC000615_A260SupplierGenAddressCity[0];
            A310SupplierGenAddressLine1 = BC000615_A310SupplierGenAddressLine1[0];
            A311SupplierGenAddressLine2 = BC000615_A311SupplierGenAddressLine2[0];
            A47SupplierGenContactName = BC000615_A47SupplierGenContactName[0];
            A353SupplierGenPhoneCode = BC000615_A353SupplierGenPhoneCode[0];
            A354SupplierGenPhoneNumber = BC000615_A354SupplierGenPhoneNumber[0];
            A605SupplierGenLandlineCode = BC000615_A605SupplierGenLandlineCode[0];
            A606SupplierGenLandlineSubNumber = BC000615_A606SupplierGenLandlineSubNumber[0];
            A501SupplierGenEmail = BC000615_A501SupplierGenEmail[0];
            A428SupplierGenWebsite = BC000615_A428SupplierGenWebsite[0];
            A604SupplierGenDescription = BC000615_A604SupplierGenDescription[0];
            A253SupplierGenTypeId = BC000615_A253SupplierGenTypeId[0];
            A601SG_OrganisationSupplierId = BC000615_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = BC000615_n601SG_OrganisationSupplierId[0];
            A602SG_LocationSupplierOrganisatio = BC000615_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = BC000615_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = BC000615_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = BC000615_n603SG_LocationSupplierLocationId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd069( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void AddRow069( )
      {
         VarsToRow9( bcTrn_SupplierGen) ;
      }

      protected void ReadRow069( )
      {
         RowToVars9( bcTrn_SupplierGen, 1) ;
      }

      protected void InitializeNonKey069( )
      {
         A48SupplierGenContactPhone = "";
         A607SupplierGenLandlineNumber = "";
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         n602SG_LocationSupplierOrganisatio = false;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         n603SG_LocationSupplierLocationId = false;
         A601SG_OrganisationSupplierId = Guid.Empty;
         n601SG_OrganisationSupplierId = false;
         A259SupplierGenAddressZipCode = "";
         A43SupplierGenKvkNumber = "";
         A253SupplierGenTypeId = Guid.Empty;
         A254SupplierGenTypeName = "";
         A44SupplierGenCompanyName = "";
         A309SupplierGenAddressCountry = "";
         A260SupplierGenAddressCity = "";
         A310SupplierGenAddressLine1 = "";
         A311SupplierGenAddressLine2 = "";
         A47SupplierGenContactName = "";
         A353SupplierGenPhoneCode = "";
         A354SupplierGenPhoneNumber = "";
         A605SupplierGenLandlineCode = "";
         A606SupplierGenLandlineSubNumber = "";
         A501SupplierGenEmail = "";
         A428SupplierGenWebsite = "";
         A604SupplierGenDescription = "";
         Z48SupplierGenContactPhone = "";
         Z607SupplierGenLandlineNumber = "";
         Z259SupplierGenAddressZipCode = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z309SupplierGenAddressCountry = "";
         Z260SupplierGenAddressCity = "";
         Z310SupplierGenAddressLine1 = "";
         Z311SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z353SupplierGenPhoneCode = "";
         Z354SupplierGenPhoneNumber = "";
         Z605SupplierGenLandlineCode = "";
         Z606SupplierGenLandlineSubNumber = "";
         Z501SupplierGenEmail = "";
         Z428SupplierGenWebsite = "";
         Z253SupplierGenTypeId = Guid.Empty;
         Z601SG_OrganisationSupplierId = Guid.Empty;
         Z602SG_LocationSupplierOrganisatio = Guid.Empty;
         Z603SG_LocationSupplierLocationId = Guid.Empty;
      }

      protected void InitAll069( )
      {
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A601SG_OrganisationSupplierId = i601SG_OrganisationSupplierId;
         n601SG_OrganisationSupplierId = false;
         A602SG_LocationSupplierOrganisatio = i602SG_LocationSupplierOrganisatio;
         n602SG_LocationSupplierOrganisatio = false;
         A603SG_LocationSupplierLocationId = i603SG_LocationSupplierLocationId;
         n603SG_LocationSupplierLocationId = false;
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

      public void VarsToRow9( SdtTrn_SupplierGen obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Suppliergencontactphone = A48SupplierGenContactPhone;
         obj9.gxTpr_Suppliergenlandlinenumber = A607SupplierGenLandlineNumber;
         obj9.gxTpr_Sg_locationsupplierorganisationid = A602SG_LocationSupplierOrganisatio;
         obj9.gxTpr_Sg_locationsupplierlocationid = A603SG_LocationSupplierLocationId;
         obj9.gxTpr_Sg_organisationsupplierid = A601SG_OrganisationSupplierId;
         obj9.gxTpr_Suppliergenaddresszipcode = A259SupplierGenAddressZipCode;
         obj9.gxTpr_Suppliergenkvknumber = A43SupplierGenKvkNumber;
         obj9.gxTpr_Suppliergentypeid = A253SupplierGenTypeId;
         obj9.gxTpr_Suppliergentypename = A254SupplierGenTypeName;
         obj9.gxTpr_Suppliergencompanyname = A44SupplierGenCompanyName;
         obj9.gxTpr_Suppliergenaddresscountry = A309SupplierGenAddressCountry;
         obj9.gxTpr_Suppliergenaddresscity = A260SupplierGenAddressCity;
         obj9.gxTpr_Suppliergenaddressline1 = A310SupplierGenAddressLine1;
         obj9.gxTpr_Suppliergenaddressline2 = A311SupplierGenAddressLine2;
         obj9.gxTpr_Suppliergencontactname = A47SupplierGenContactName;
         obj9.gxTpr_Suppliergenphonecode = A353SupplierGenPhoneCode;
         obj9.gxTpr_Suppliergenphonenumber = A354SupplierGenPhoneNumber;
         obj9.gxTpr_Suppliergenlandlinecode = A605SupplierGenLandlineCode;
         obj9.gxTpr_Suppliergenlandlinesubnumber = A606SupplierGenLandlineSubNumber;
         obj9.gxTpr_Suppliergenemail = A501SupplierGenEmail;
         obj9.gxTpr_Suppliergenwebsite = A428SupplierGenWebsite;
         obj9.gxTpr_Suppliergendescription = A604SupplierGenDescription;
         obj9.gxTpr_Suppliergenid = A42SupplierGenId;
         obj9.gxTpr_Suppliergenid_Z = Z42SupplierGenId;
         obj9.gxTpr_Suppliergenkvknumber_Z = Z43SupplierGenKvkNumber;
         obj9.gxTpr_Suppliergentypeid_Z = Z253SupplierGenTypeId;
         obj9.gxTpr_Suppliergentypename_Z = Z254SupplierGenTypeName;
         obj9.gxTpr_Suppliergencompanyname_Z = Z44SupplierGenCompanyName;
         obj9.gxTpr_Suppliergenaddresscountry_Z = Z309SupplierGenAddressCountry;
         obj9.gxTpr_Suppliergenaddresscity_Z = Z260SupplierGenAddressCity;
         obj9.gxTpr_Suppliergenaddresszipcode_Z = Z259SupplierGenAddressZipCode;
         obj9.gxTpr_Suppliergenaddressline1_Z = Z310SupplierGenAddressLine1;
         obj9.gxTpr_Suppliergenaddressline2_Z = Z311SupplierGenAddressLine2;
         obj9.gxTpr_Suppliergencontactname_Z = Z47SupplierGenContactName;
         obj9.gxTpr_Suppliergencontactphone_Z = Z48SupplierGenContactPhone;
         obj9.gxTpr_Suppliergenphonecode_Z = Z353SupplierGenPhoneCode;
         obj9.gxTpr_Suppliergenphonenumber_Z = Z354SupplierGenPhoneNumber;
         obj9.gxTpr_Suppliergenlandlinecode_Z = Z605SupplierGenLandlineCode;
         obj9.gxTpr_Suppliergenlandlinesubnumber_Z = Z606SupplierGenLandlineSubNumber;
         obj9.gxTpr_Suppliergenlandlinenumber_Z = Z607SupplierGenLandlineNumber;
         obj9.gxTpr_Suppliergenemail_Z = Z501SupplierGenEmail;
         obj9.gxTpr_Suppliergenwebsite_Z = Z428SupplierGenWebsite;
         obj9.gxTpr_Sg_organisationsupplierid_Z = Z601SG_OrganisationSupplierId;
         obj9.gxTpr_Sg_locationsupplierorganisationid_Z = Z602SG_LocationSupplierOrganisatio;
         obj9.gxTpr_Sg_locationsupplierlocationid_Z = Z603SG_LocationSupplierLocationId;
         obj9.gxTpr_Suppliergenid_N = (short)(Convert.ToInt16(n42SupplierGenId));
         obj9.gxTpr_Sg_organisationsupplierid_N = (short)(Convert.ToInt16(n601SG_OrganisationSupplierId));
         obj9.gxTpr_Sg_locationsupplierorganisationid_N = (short)(Convert.ToInt16(n602SG_LocationSupplierOrganisatio));
         obj9.gxTpr_Sg_locationsupplierlocationid_N = (short)(Convert.ToInt16(n603SG_LocationSupplierLocationId));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtTrn_SupplierGen obj9 )
      {
         obj9.gxTpr_Suppliergenid = A42SupplierGenId;
         return  ;
      }

      public void RowToVars9( SdtTrn_SupplierGen obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A48SupplierGenContactPhone = obj9.gxTpr_Suppliergencontactphone;
         A607SupplierGenLandlineNumber = obj9.gxTpr_Suppliergenlandlinenumber;
         A602SG_LocationSupplierOrganisatio = obj9.gxTpr_Sg_locationsupplierorganisationid;
         n602SG_LocationSupplierOrganisatio = false;
         A603SG_LocationSupplierLocationId = obj9.gxTpr_Sg_locationsupplierlocationid;
         n603SG_LocationSupplierLocationId = false;
         A601SG_OrganisationSupplierId = obj9.gxTpr_Sg_organisationsupplierid;
         n601SG_OrganisationSupplierId = false;
         A259SupplierGenAddressZipCode = obj9.gxTpr_Suppliergenaddresszipcode;
         A43SupplierGenKvkNumber = obj9.gxTpr_Suppliergenkvknumber;
         A253SupplierGenTypeId = obj9.gxTpr_Suppliergentypeid;
         A254SupplierGenTypeName = obj9.gxTpr_Suppliergentypename;
         A44SupplierGenCompanyName = obj9.gxTpr_Suppliergencompanyname;
         A309SupplierGenAddressCountry = obj9.gxTpr_Suppliergenaddresscountry;
         A260SupplierGenAddressCity = obj9.gxTpr_Suppliergenaddresscity;
         A310SupplierGenAddressLine1 = obj9.gxTpr_Suppliergenaddressline1;
         A311SupplierGenAddressLine2 = obj9.gxTpr_Suppliergenaddressline2;
         A47SupplierGenContactName = obj9.gxTpr_Suppliergencontactname;
         A353SupplierGenPhoneCode = obj9.gxTpr_Suppliergenphonecode;
         A354SupplierGenPhoneNumber = obj9.gxTpr_Suppliergenphonenumber;
         A605SupplierGenLandlineCode = obj9.gxTpr_Suppliergenlandlinecode;
         A606SupplierGenLandlineSubNumber = obj9.gxTpr_Suppliergenlandlinesubnumber;
         A501SupplierGenEmail = obj9.gxTpr_Suppliergenemail;
         A428SupplierGenWebsite = obj9.gxTpr_Suppliergenwebsite;
         A604SupplierGenDescription = obj9.gxTpr_Suppliergendescription;
         A42SupplierGenId = obj9.gxTpr_Suppliergenid;
         n42SupplierGenId = false;
         Z42SupplierGenId = obj9.gxTpr_Suppliergenid_Z;
         Z43SupplierGenKvkNumber = obj9.gxTpr_Suppliergenkvknumber_Z;
         Z253SupplierGenTypeId = obj9.gxTpr_Suppliergentypeid_Z;
         Z254SupplierGenTypeName = obj9.gxTpr_Suppliergentypename_Z;
         Z44SupplierGenCompanyName = obj9.gxTpr_Suppliergencompanyname_Z;
         Z309SupplierGenAddressCountry = obj9.gxTpr_Suppliergenaddresscountry_Z;
         Z260SupplierGenAddressCity = obj9.gxTpr_Suppliergenaddresscity_Z;
         Z259SupplierGenAddressZipCode = obj9.gxTpr_Suppliergenaddresszipcode_Z;
         Z310SupplierGenAddressLine1 = obj9.gxTpr_Suppliergenaddressline1_Z;
         Z311SupplierGenAddressLine2 = obj9.gxTpr_Suppliergenaddressline2_Z;
         Z47SupplierGenContactName = obj9.gxTpr_Suppliergencontactname_Z;
         Z48SupplierGenContactPhone = obj9.gxTpr_Suppliergencontactphone_Z;
         Z353SupplierGenPhoneCode = obj9.gxTpr_Suppliergenphonecode_Z;
         Z354SupplierGenPhoneNumber = obj9.gxTpr_Suppliergenphonenumber_Z;
         Z605SupplierGenLandlineCode = obj9.gxTpr_Suppliergenlandlinecode_Z;
         Z606SupplierGenLandlineSubNumber = obj9.gxTpr_Suppliergenlandlinesubnumber_Z;
         Z607SupplierGenLandlineNumber = obj9.gxTpr_Suppliergenlandlinenumber_Z;
         Z501SupplierGenEmail = obj9.gxTpr_Suppliergenemail_Z;
         Z428SupplierGenWebsite = obj9.gxTpr_Suppliergenwebsite_Z;
         Z601SG_OrganisationSupplierId = obj9.gxTpr_Sg_organisationsupplierid_Z;
         Z602SG_LocationSupplierOrganisatio = obj9.gxTpr_Sg_locationsupplierorganisationid_Z;
         Z603SG_LocationSupplierLocationId = obj9.gxTpr_Sg_locationsupplierlocationid_Z;
         n42SupplierGenId = (bool)(Convert.ToBoolean(obj9.gxTpr_Suppliergenid_N));
         n601SG_OrganisationSupplierId = (bool)(Convert.ToBoolean(obj9.gxTpr_Sg_organisationsupplierid_N));
         n602SG_LocationSupplierOrganisatio = (bool)(Convert.ToBoolean(obj9.gxTpr_Sg_locationsupplierorganisationid_N));
         n603SG_LocationSupplierLocationId = (bool)(Convert.ToBoolean(obj9.gxTpr_Sg_locationsupplierlocationid_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A42SupplierGenId = (Guid)getParm(obj,0);
         n42SupplierGenId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey069( ) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM069( -28) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcTrn_SupplierGen, 0) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM069( -28) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert069( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  A42SupplierGenId = Z42SupplierGenId;
                  n42SupplierGenId = false;
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
                  Update069( ) ;
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
                  if ( A42SupplierGenId != Z42SupplierGenId )
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
                        Insert069( ) ;
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
                        Insert069( ) ;
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcTrn_SupplierGen) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcTrn_SupplierGen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert069( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcTrn_SupplierGen) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcTrn_SupplierGen) ;
         }
         else
         {
            SdtTrn_SupplierGen auxBC = new SdtTrn_SupplierGen(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A42SupplierGenId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierGen);
               auxBC.Save();
               bcTrn_SupplierGen.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
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
         RowToVars9( bcTrn_SupplierGen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert069( ) ;
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
               VarsToRow9( bcTrn_SupplierGen) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcTrn_SupplierGen) ;
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
         RowToVars9( bcTrn_SupplierGen, 0) ;
         GetKey069( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A42SupplierGenId != Z42SupplierGenId )
            {
               A42SupplierGenId = Z42SupplierGenId;
               n42SupplierGenId = false;
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
            if ( A42SupplierGenId != Z42SupplierGenId )
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
         context.RollbackDataStores("trn_suppliergen_bc",pr_default);
         VarsToRow9( bcTrn_SupplierGen) ;
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
         Gx_mode = bcTrn_SupplierGen.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierGen.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierGen )
         {
            bcTrn_SupplierGen = (SdtTrn_SupplierGen)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierGen.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGen.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcTrn_SupplierGen) ;
            }
            else
            {
               RowToVars9( bcTrn_SupplierGen, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierGen.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGen.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcTrn_SupplierGen, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierGen Trn_SupplierGen_BC
      {
         get {
            return bcTrn_SupplierGen ;
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
            return "trn_suppliergen_Execute" ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z42SupplierGenId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV43Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_SupplierGenTypeId = Guid.Empty;
         AV34Insert_SG_OrganisationSupplierId = Guid.Empty;
         AV35Insert_SG_LocationSupplierOrganisationId = Guid.Empty;
         AV36Insert_SG_LocationSupplierLocationId = Guid.Empty;
         AV39SG_LocationSupplierLocationId = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         AV38SG_LocationSupplierOrganisationId = Guid.Empty;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         AV40SG_OrganisationSupplierId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         A601SG_OrganisationSupplierId = Guid.Empty;
         Z48SupplierGenContactPhone = "";
         A48SupplierGenContactPhone = "";
         Z607SupplierGenLandlineNumber = "";
         A607SupplierGenLandlineNumber = "";
         Z259SupplierGenAddressZipCode = "";
         A259SupplierGenAddressZipCode = "";
         Z43SupplierGenKvkNumber = "";
         A43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         A44SupplierGenCompanyName = "";
         Z309SupplierGenAddressCountry = "";
         A309SupplierGenAddressCountry = "";
         Z260SupplierGenAddressCity = "";
         A260SupplierGenAddressCity = "";
         Z310SupplierGenAddressLine1 = "";
         A310SupplierGenAddressLine1 = "";
         Z311SupplierGenAddressLine2 = "";
         A311SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         A47SupplierGenContactName = "";
         Z353SupplierGenPhoneCode = "";
         A353SupplierGenPhoneCode = "";
         Z354SupplierGenPhoneNumber = "";
         A354SupplierGenPhoneNumber = "";
         Z605SupplierGenLandlineCode = "";
         A605SupplierGenLandlineCode = "";
         Z606SupplierGenLandlineSubNumber = "";
         A606SupplierGenLandlineSubNumber = "";
         Z501SupplierGenEmail = "";
         A501SupplierGenEmail = "";
         Z428SupplierGenWebsite = "";
         A428SupplierGenWebsite = "";
         Z253SupplierGenTypeId = Guid.Empty;
         A253SupplierGenTypeId = Guid.Empty;
         Z601SG_OrganisationSupplierId = Guid.Empty;
         Z602SG_LocationSupplierOrganisatio = Guid.Empty;
         Z603SG_LocationSupplierLocationId = Guid.Empty;
         Z254SupplierGenTypeName = "";
         A254SupplierGenTypeName = "";
         Z604SupplierGenDescription = "";
         A604SupplierGenDescription = "";
         BC00067_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00067_n42SupplierGenId = new bool[] {false} ;
         BC00067_A48SupplierGenContactPhone = new string[] {""} ;
         BC00067_A607SupplierGenLandlineNumber = new string[] {""} ;
         BC00067_A259SupplierGenAddressZipCode = new string[] {""} ;
         BC00067_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00067_A254SupplierGenTypeName = new string[] {""} ;
         BC00067_A44SupplierGenCompanyName = new string[] {""} ;
         BC00067_A309SupplierGenAddressCountry = new string[] {""} ;
         BC00067_A260SupplierGenAddressCity = new string[] {""} ;
         BC00067_A310SupplierGenAddressLine1 = new string[] {""} ;
         BC00067_A311SupplierGenAddressLine2 = new string[] {""} ;
         BC00067_A47SupplierGenContactName = new string[] {""} ;
         BC00067_A353SupplierGenPhoneCode = new string[] {""} ;
         BC00067_A354SupplierGenPhoneNumber = new string[] {""} ;
         BC00067_A605SupplierGenLandlineCode = new string[] {""} ;
         BC00067_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         BC00067_A501SupplierGenEmail = new string[] {""} ;
         BC00067_A428SupplierGenWebsite = new string[] {""} ;
         BC00067_A604SupplierGenDescription = new string[] {""} ;
         BC00067_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00067_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         BC00067_n601SG_OrganisationSupplierId = new bool[] {false} ;
         BC00067_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         BC00067_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         BC00067_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         BC00067_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         BC00064_A254SupplierGenTypeName = new string[] {""} ;
         GXt_char2 = "";
         BC00065_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         BC00065_n601SG_OrganisationSupplierId = new bool[] {false} ;
         BC00066_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         BC00066_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         BC00068_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00068_n42SupplierGenId = new bool[] {false} ;
         BC00063_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00063_n42SupplierGenId = new bool[] {false} ;
         BC00063_A48SupplierGenContactPhone = new string[] {""} ;
         BC00063_A607SupplierGenLandlineNumber = new string[] {""} ;
         BC00063_A259SupplierGenAddressZipCode = new string[] {""} ;
         BC00063_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00063_A44SupplierGenCompanyName = new string[] {""} ;
         BC00063_A309SupplierGenAddressCountry = new string[] {""} ;
         BC00063_A260SupplierGenAddressCity = new string[] {""} ;
         BC00063_A310SupplierGenAddressLine1 = new string[] {""} ;
         BC00063_A311SupplierGenAddressLine2 = new string[] {""} ;
         BC00063_A47SupplierGenContactName = new string[] {""} ;
         BC00063_A353SupplierGenPhoneCode = new string[] {""} ;
         BC00063_A354SupplierGenPhoneNumber = new string[] {""} ;
         BC00063_A605SupplierGenLandlineCode = new string[] {""} ;
         BC00063_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         BC00063_A501SupplierGenEmail = new string[] {""} ;
         BC00063_A428SupplierGenWebsite = new string[] {""} ;
         BC00063_A604SupplierGenDescription = new string[] {""} ;
         BC00063_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00063_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         BC00063_n601SG_OrganisationSupplierId = new bool[] {false} ;
         BC00063_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         BC00063_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         BC00063_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         BC00063_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         sMode9 = "";
         BC00062_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00062_n42SupplierGenId = new bool[] {false} ;
         BC00062_A48SupplierGenContactPhone = new string[] {""} ;
         BC00062_A607SupplierGenLandlineNumber = new string[] {""} ;
         BC00062_A259SupplierGenAddressZipCode = new string[] {""} ;
         BC00062_A43SupplierGenKvkNumber = new string[] {""} ;
         BC00062_A44SupplierGenCompanyName = new string[] {""} ;
         BC00062_A309SupplierGenAddressCountry = new string[] {""} ;
         BC00062_A260SupplierGenAddressCity = new string[] {""} ;
         BC00062_A310SupplierGenAddressLine1 = new string[] {""} ;
         BC00062_A311SupplierGenAddressLine2 = new string[] {""} ;
         BC00062_A47SupplierGenContactName = new string[] {""} ;
         BC00062_A353SupplierGenPhoneCode = new string[] {""} ;
         BC00062_A354SupplierGenPhoneNumber = new string[] {""} ;
         BC00062_A605SupplierGenLandlineCode = new string[] {""} ;
         BC00062_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         BC00062_A501SupplierGenEmail = new string[] {""} ;
         BC00062_A428SupplierGenWebsite = new string[] {""} ;
         BC00062_A604SupplierGenDescription = new string[] {""} ;
         BC00062_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC00062_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         BC00062_n601SG_OrganisationSupplierId = new bool[] {false} ;
         BC00062_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         BC00062_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         BC00062_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         BC00062_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         BC000612_A254SupplierGenTypeName = new string[] {""} ;
         BC000613_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000613_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000613_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000614_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC000614_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000614_n42SupplierGenId = new bool[] {false} ;
         BC000615_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000615_n42SupplierGenId = new bool[] {false} ;
         BC000615_A48SupplierGenContactPhone = new string[] {""} ;
         BC000615_A607SupplierGenLandlineNumber = new string[] {""} ;
         BC000615_A259SupplierGenAddressZipCode = new string[] {""} ;
         BC000615_A43SupplierGenKvkNumber = new string[] {""} ;
         BC000615_A254SupplierGenTypeName = new string[] {""} ;
         BC000615_A44SupplierGenCompanyName = new string[] {""} ;
         BC000615_A309SupplierGenAddressCountry = new string[] {""} ;
         BC000615_A260SupplierGenAddressCity = new string[] {""} ;
         BC000615_A310SupplierGenAddressLine1 = new string[] {""} ;
         BC000615_A311SupplierGenAddressLine2 = new string[] {""} ;
         BC000615_A47SupplierGenContactName = new string[] {""} ;
         BC000615_A353SupplierGenPhoneCode = new string[] {""} ;
         BC000615_A354SupplierGenPhoneNumber = new string[] {""} ;
         BC000615_A605SupplierGenLandlineCode = new string[] {""} ;
         BC000615_A606SupplierGenLandlineSubNumber = new string[] {""} ;
         BC000615_A501SupplierGenEmail = new string[] {""} ;
         BC000615_A428SupplierGenWebsite = new string[] {""} ;
         BC000615_A604SupplierGenDescription = new string[] {""} ;
         BC000615_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000615_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         BC000615_n601SG_OrganisationSupplierId = new bool[] {false} ;
         BC000615_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         BC000615_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         BC000615_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         BC000615_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         i601SG_OrganisationSupplierId = Guid.Empty;
         i602SG_LocationSupplierOrganisatio = Guid.Empty;
         i603SG_LocationSupplierLocationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A42SupplierGenId, BC00062_A48SupplierGenContactPhone, BC00062_A607SupplierGenLandlineNumber, BC00062_A259SupplierGenAddressZipCode, BC00062_A43SupplierGenKvkNumber, BC00062_A44SupplierGenCompanyName, BC00062_A309SupplierGenAddressCountry, BC00062_A260SupplierGenAddressCity, BC00062_A310SupplierGenAddressLine1, BC00062_A311SupplierGenAddressLine2,
               BC00062_A47SupplierGenContactName, BC00062_A353SupplierGenPhoneCode, BC00062_A354SupplierGenPhoneNumber, BC00062_A605SupplierGenLandlineCode, BC00062_A606SupplierGenLandlineSubNumber, BC00062_A501SupplierGenEmail, BC00062_A428SupplierGenWebsite, BC00062_A604SupplierGenDescription, BC00062_A253SupplierGenTypeId, BC00062_A601SG_OrganisationSupplierId,
               BC00062_n601SG_OrganisationSupplierId, BC00062_A602SG_LocationSupplierOrganisatio, BC00062_n602SG_LocationSupplierOrganisatio, BC00062_A603SG_LocationSupplierLocationId, BC00062_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               BC00063_A42SupplierGenId, BC00063_A48SupplierGenContactPhone, BC00063_A607SupplierGenLandlineNumber, BC00063_A259SupplierGenAddressZipCode, BC00063_A43SupplierGenKvkNumber, BC00063_A44SupplierGenCompanyName, BC00063_A309SupplierGenAddressCountry, BC00063_A260SupplierGenAddressCity, BC00063_A310SupplierGenAddressLine1, BC00063_A311SupplierGenAddressLine2,
               BC00063_A47SupplierGenContactName, BC00063_A353SupplierGenPhoneCode, BC00063_A354SupplierGenPhoneNumber, BC00063_A605SupplierGenLandlineCode, BC00063_A606SupplierGenLandlineSubNumber, BC00063_A501SupplierGenEmail, BC00063_A428SupplierGenWebsite, BC00063_A604SupplierGenDescription, BC00063_A253SupplierGenTypeId, BC00063_A601SG_OrganisationSupplierId,
               BC00063_n601SG_OrganisationSupplierId, BC00063_A602SG_LocationSupplierOrganisatio, BC00063_n602SG_LocationSupplierOrganisatio, BC00063_A603SG_LocationSupplierLocationId, BC00063_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               BC00064_A254SupplierGenTypeName
               }
               , new Object[] {
               BC00065_A601SG_OrganisationSupplierId
               }
               , new Object[] {
               BC00066_A603SG_LocationSupplierLocationId
               }
               , new Object[] {
               BC00067_A42SupplierGenId, BC00067_A48SupplierGenContactPhone, BC00067_A607SupplierGenLandlineNumber, BC00067_A259SupplierGenAddressZipCode, BC00067_A43SupplierGenKvkNumber, BC00067_A254SupplierGenTypeName, BC00067_A44SupplierGenCompanyName, BC00067_A309SupplierGenAddressCountry, BC00067_A260SupplierGenAddressCity, BC00067_A310SupplierGenAddressLine1,
               BC00067_A311SupplierGenAddressLine2, BC00067_A47SupplierGenContactName, BC00067_A353SupplierGenPhoneCode, BC00067_A354SupplierGenPhoneNumber, BC00067_A605SupplierGenLandlineCode, BC00067_A606SupplierGenLandlineSubNumber, BC00067_A501SupplierGenEmail, BC00067_A428SupplierGenWebsite, BC00067_A604SupplierGenDescription, BC00067_A253SupplierGenTypeId,
               BC00067_A601SG_OrganisationSupplierId, BC00067_n601SG_OrganisationSupplierId, BC00067_A602SG_LocationSupplierOrganisatio, BC00067_n602SG_LocationSupplierOrganisatio, BC00067_A603SG_LocationSupplierLocationId, BC00067_n603SG_LocationSupplierLocationId
               }
               , new Object[] {
               BC00068_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000612_A254SupplierGenTypeName
               }
               , new Object[] {
               BC000613_A58ProductServiceId, BC000613_A29LocationId, BC000613_A11OrganisationId
               }
               , new Object[] {
               BC000614_A616SupplierDynamicFormId, BC000614_A42SupplierGenId
               }
               , new Object[] {
               BC000615_A42SupplierGenId, BC000615_A48SupplierGenContactPhone, BC000615_A607SupplierGenLandlineNumber, BC000615_A259SupplierGenAddressZipCode, BC000615_A43SupplierGenKvkNumber, BC000615_A254SupplierGenTypeName, BC000615_A44SupplierGenCompanyName, BC000615_A309SupplierGenAddressCountry, BC000615_A260SupplierGenAddressCity, BC000615_A310SupplierGenAddressLine1,
               BC000615_A311SupplierGenAddressLine2, BC000615_A47SupplierGenContactName, BC000615_A353SupplierGenPhoneCode, BC000615_A354SupplierGenPhoneNumber, BC000615_A605SupplierGenLandlineCode, BC000615_A606SupplierGenLandlineSubNumber, BC000615_A501SupplierGenEmail, BC000615_A428SupplierGenWebsite, BC000615_A604SupplierGenDescription, BC000615_A253SupplierGenTypeId,
               BC000615_A601SG_OrganisationSupplierId, BC000615_n601SG_OrganisationSupplierId, BC000615_A602SG_LocationSupplierOrganisatio, BC000615_n602SG_LocationSupplierOrganisatio, BC000615_A603SG_LocationSupplierLocationId, BC000615_n603SG_LocationSupplierLocationId
               }
            }
         );
         Z42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AV43Pgmname = "Trn_SupplierGen_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private int trnEnded ;
      private int AV44GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV43Pgmname ;
      private string Z48SupplierGenContactPhone ;
      private string A48SupplierGenContactPhone ;
      private string GXt_char2 ;
      private string sMode9 ;
      private bool returnInSub ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n601SG_OrganisationSupplierId ;
      private bool n42SupplierGenId ;
      private bool Gx_longc ;
      private string Z604SupplierGenDescription ;
      private string A604SupplierGenDescription ;
      private string Z607SupplierGenLandlineNumber ;
      private string A607SupplierGenLandlineNumber ;
      private string Z259SupplierGenAddressZipCode ;
      private string A259SupplierGenAddressZipCode ;
      private string Z43SupplierGenKvkNumber ;
      private string A43SupplierGenKvkNumber ;
      private string Z44SupplierGenCompanyName ;
      private string A44SupplierGenCompanyName ;
      private string Z309SupplierGenAddressCountry ;
      private string A309SupplierGenAddressCountry ;
      private string Z260SupplierGenAddressCity ;
      private string A260SupplierGenAddressCity ;
      private string Z310SupplierGenAddressLine1 ;
      private string A310SupplierGenAddressLine1 ;
      private string Z311SupplierGenAddressLine2 ;
      private string A311SupplierGenAddressLine2 ;
      private string Z47SupplierGenContactName ;
      private string A47SupplierGenContactName ;
      private string Z353SupplierGenPhoneCode ;
      private string A353SupplierGenPhoneCode ;
      private string Z354SupplierGenPhoneNumber ;
      private string A354SupplierGenPhoneNumber ;
      private string Z605SupplierGenLandlineCode ;
      private string A605SupplierGenLandlineCode ;
      private string Z606SupplierGenLandlineSubNumber ;
      private string A606SupplierGenLandlineSubNumber ;
      private string Z501SupplierGenEmail ;
      private string A501SupplierGenEmail ;
      private string Z428SupplierGenWebsite ;
      private string A428SupplierGenWebsite ;
      private string Z254SupplierGenTypeName ;
      private string A254SupplierGenTypeName ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid AV13Insert_SupplierGenTypeId ;
      private Guid AV34Insert_SG_OrganisationSupplierId ;
      private Guid AV35Insert_SG_LocationSupplierOrganisationId ;
      private Guid AV36Insert_SG_LocationSupplierLocationId ;
      private Guid AV39SG_LocationSupplierLocationId ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid AV38SG_LocationSupplierOrganisationId ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid AV40SG_OrganisationSupplierId ;
      private Guid GXt_guid1 ;
      private Guid A601SG_OrganisationSupplierId ;
      private Guid Z253SupplierGenTypeId ;
      private Guid A253SupplierGenTypeId ;
      private Guid Z601SG_OrganisationSupplierId ;
      private Guid Z602SG_LocationSupplierOrganisatio ;
      private Guid Z603SG_LocationSupplierLocationId ;
      private Guid i601SG_OrganisationSupplierId ;
      private Guid i602SG_LocationSupplierOrganisatio ;
      private Guid i603SG_LocationSupplierLocationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00067_A42SupplierGenId ;
      private bool[] BC00067_n42SupplierGenId ;
      private string[] BC00067_A48SupplierGenContactPhone ;
      private string[] BC00067_A607SupplierGenLandlineNumber ;
      private string[] BC00067_A259SupplierGenAddressZipCode ;
      private string[] BC00067_A43SupplierGenKvkNumber ;
      private string[] BC00067_A254SupplierGenTypeName ;
      private string[] BC00067_A44SupplierGenCompanyName ;
      private string[] BC00067_A309SupplierGenAddressCountry ;
      private string[] BC00067_A260SupplierGenAddressCity ;
      private string[] BC00067_A310SupplierGenAddressLine1 ;
      private string[] BC00067_A311SupplierGenAddressLine2 ;
      private string[] BC00067_A47SupplierGenContactName ;
      private string[] BC00067_A353SupplierGenPhoneCode ;
      private string[] BC00067_A354SupplierGenPhoneNumber ;
      private string[] BC00067_A605SupplierGenLandlineCode ;
      private string[] BC00067_A606SupplierGenLandlineSubNumber ;
      private string[] BC00067_A501SupplierGenEmail ;
      private string[] BC00067_A428SupplierGenWebsite ;
      private string[] BC00067_A604SupplierGenDescription ;
      private Guid[] BC00067_A253SupplierGenTypeId ;
      private Guid[] BC00067_A601SG_OrganisationSupplierId ;
      private bool[] BC00067_n601SG_OrganisationSupplierId ;
      private Guid[] BC00067_A602SG_LocationSupplierOrganisatio ;
      private bool[] BC00067_n602SG_LocationSupplierOrganisatio ;
      private Guid[] BC00067_A603SG_LocationSupplierLocationId ;
      private bool[] BC00067_n603SG_LocationSupplierLocationId ;
      private string[] BC00064_A254SupplierGenTypeName ;
      private Guid[] BC00065_A601SG_OrganisationSupplierId ;
      private bool[] BC00065_n601SG_OrganisationSupplierId ;
      private Guid[] BC00066_A603SG_LocationSupplierLocationId ;
      private bool[] BC00066_n603SG_LocationSupplierLocationId ;
      private Guid[] BC00068_A42SupplierGenId ;
      private bool[] BC00068_n42SupplierGenId ;
      private Guid[] BC00063_A42SupplierGenId ;
      private bool[] BC00063_n42SupplierGenId ;
      private string[] BC00063_A48SupplierGenContactPhone ;
      private string[] BC00063_A607SupplierGenLandlineNumber ;
      private string[] BC00063_A259SupplierGenAddressZipCode ;
      private string[] BC00063_A43SupplierGenKvkNumber ;
      private string[] BC00063_A44SupplierGenCompanyName ;
      private string[] BC00063_A309SupplierGenAddressCountry ;
      private string[] BC00063_A260SupplierGenAddressCity ;
      private string[] BC00063_A310SupplierGenAddressLine1 ;
      private string[] BC00063_A311SupplierGenAddressLine2 ;
      private string[] BC00063_A47SupplierGenContactName ;
      private string[] BC00063_A353SupplierGenPhoneCode ;
      private string[] BC00063_A354SupplierGenPhoneNumber ;
      private string[] BC00063_A605SupplierGenLandlineCode ;
      private string[] BC00063_A606SupplierGenLandlineSubNumber ;
      private string[] BC00063_A501SupplierGenEmail ;
      private string[] BC00063_A428SupplierGenWebsite ;
      private string[] BC00063_A604SupplierGenDescription ;
      private Guid[] BC00063_A253SupplierGenTypeId ;
      private Guid[] BC00063_A601SG_OrganisationSupplierId ;
      private bool[] BC00063_n601SG_OrganisationSupplierId ;
      private Guid[] BC00063_A602SG_LocationSupplierOrganisatio ;
      private bool[] BC00063_n602SG_LocationSupplierOrganisatio ;
      private Guid[] BC00063_A603SG_LocationSupplierLocationId ;
      private bool[] BC00063_n603SG_LocationSupplierLocationId ;
      private Guid[] BC00062_A42SupplierGenId ;
      private bool[] BC00062_n42SupplierGenId ;
      private string[] BC00062_A48SupplierGenContactPhone ;
      private string[] BC00062_A607SupplierGenLandlineNumber ;
      private string[] BC00062_A259SupplierGenAddressZipCode ;
      private string[] BC00062_A43SupplierGenKvkNumber ;
      private string[] BC00062_A44SupplierGenCompanyName ;
      private string[] BC00062_A309SupplierGenAddressCountry ;
      private string[] BC00062_A260SupplierGenAddressCity ;
      private string[] BC00062_A310SupplierGenAddressLine1 ;
      private string[] BC00062_A311SupplierGenAddressLine2 ;
      private string[] BC00062_A47SupplierGenContactName ;
      private string[] BC00062_A353SupplierGenPhoneCode ;
      private string[] BC00062_A354SupplierGenPhoneNumber ;
      private string[] BC00062_A605SupplierGenLandlineCode ;
      private string[] BC00062_A606SupplierGenLandlineSubNumber ;
      private string[] BC00062_A501SupplierGenEmail ;
      private string[] BC00062_A428SupplierGenWebsite ;
      private string[] BC00062_A604SupplierGenDescription ;
      private Guid[] BC00062_A253SupplierGenTypeId ;
      private Guid[] BC00062_A601SG_OrganisationSupplierId ;
      private bool[] BC00062_n601SG_OrganisationSupplierId ;
      private Guid[] BC00062_A602SG_LocationSupplierOrganisatio ;
      private bool[] BC00062_n602SG_LocationSupplierOrganisatio ;
      private Guid[] BC00062_A603SG_LocationSupplierLocationId ;
      private bool[] BC00062_n603SG_LocationSupplierLocationId ;
      private string[] BC000612_A254SupplierGenTypeName ;
      private Guid[] BC000613_A58ProductServiceId ;
      private Guid[] BC000613_A29LocationId ;
      private Guid[] BC000613_A11OrganisationId ;
      private Guid[] BC000614_A616SupplierDynamicFormId ;
      private Guid[] BC000614_A42SupplierGenId ;
      private bool[] BC000614_n42SupplierGenId ;
      private Guid[] BC000615_A42SupplierGenId ;
      private bool[] BC000615_n42SupplierGenId ;
      private string[] BC000615_A48SupplierGenContactPhone ;
      private string[] BC000615_A607SupplierGenLandlineNumber ;
      private string[] BC000615_A259SupplierGenAddressZipCode ;
      private string[] BC000615_A43SupplierGenKvkNumber ;
      private string[] BC000615_A254SupplierGenTypeName ;
      private string[] BC000615_A44SupplierGenCompanyName ;
      private string[] BC000615_A309SupplierGenAddressCountry ;
      private string[] BC000615_A260SupplierGenAddressCity ;
      private string[] BC000615_A310SupplierGenAddressLine1 ;
      private string[] BC000615_A311SupplierGenAddressLine2 ;
      private string[] BC000615_A47SupplierGenContactName ;
      private string[] BC000615_A353SupplierGenPhoneCode ;
      private string[] BC000615_A354SupplierGenPhoneNumber ;
      private string[] BC000615_A605SupplierGenLandlineCode ;
      private string[] BC000615_A606SupplierGenLandlineSubNumber ;
      private string[] BC000615_A501SupplierGenEmail ;
      private string[] BC000615_A428SupplierGenWebsite ;
      private string[] BC000615_A604SupplierGenDescription ;
      private Guid[] BC000615_A253SupplierGenTypeId ;
      private Guid[] BC000615_A601SG_OrganisationSupplierId ;
      private bool[] BC000615_n601SG_OrganisationSupplierId ;
      private Guid[] BC000615_A602SG_LocationSupplierOrganisatio ;
      private bool[] BC000615_n602SG_LocationSupplierOrganisatio ;
      private Guid[] BC000615_A603SG_LocationSupplierLocationId ;
      private bool[] BC000615_n603SG_LocationSupplierLocationId ;
      private SdtTrn_SupplierGen bcTrn_SupplierGen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergen_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergen_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergen_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00062;
       prmBC00062 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00063;
       prmBC00063 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00064;
       prmBC00064 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00065;
       prmBC00065 = new Object[] {
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00066;
       prmBC00066 = new Object[] {
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00067;
       prmBC00067 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00068;
       prmBC00068 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00069;
       prmBC00069 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenLandlineNumber",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenLandlineCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenLandlineSubNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,150,0) ,
       new ParDef("SupplierGenDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000610;
       prmBC000610 = new Object[] {
       new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
       new ParDef("SupplierGenLandlineNumber",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenLandlineCode",GXType.VarChar,40,0) ,
       new ParDef("SupplierGenLandlineSubNumber",GXType.VarChar,9,0) ,
       new ParDef("SupplierGenEmail",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenWebsite",GXType.VarChar,150,0) ,
       new ParDef("SupplierGenDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationSupplierId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SG_LocationSupplierLocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000611;
       prmBC000611 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000612;
       prmBC000612 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000613;
       prmBC000613 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000614;
       prmBC000614 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000615;
       prmBC000615 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00062", "SELECT SupplierGenId, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenLandlineCode, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierGen",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00063", "SELECT SupplierGenId, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenLandlineCode, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00064", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00065", "SELECT OrganisationId AS SG_OrganisationSupplierId FROM Trn_Organisation WHERE OrganisationId = :SG_OrganisationSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00066", "SELECT LocationId AS SG_LocationSupplierLocationId FROM Trn_Location WHERE LocationId = :SG_LocationSupplierLocationId AND OrganisationId = :SG_LocationSupplierOrganisatio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00067", "SELECT TM1.SupplierGenId, TM1.SupplierGenContactPhone, TM1.SupplierGenLandlineNumber, TM1.SupplierGenAddressZipCode, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCountry, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneCode, TM1.SupplierGenPhoneNumber, TM1.SupplierGenLandlineCode, TM1.SupplierGenLandlineSubNumber, TM1.SupplierGenEmail, TM1.SupplierGenWebsite, TM1.SupplierGenDescription, TM1.SupplierGenTypeId, TM1.SG_OrganisationSupplierId AS SG_OrganisationSupplierId, TM1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, TM1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00068", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00069", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGen(SupplierGenId, SupplierGenContactPhone, SupplierGenLandlineNumber, SupplierGenAddressZipCode, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCountry, SupplierGenAddressCity, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenPhoneCode, SupplierGenPhoneNumber, SupplierGenLandlineCode, SupplierGenLandlineSubNumber, SupplierGenEmail, SupplierGenWebsite, SupplierGenDescription, SupplierGenTypeId, SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId) VALUES(:SupplierGenId, :SupplierGenContactPhone, :SupplierGenLandlineNumber, :SupplierGenAddressZipCode, :SupplierGenKvkNumber, :SupplierGenCompanyName, :SupplierGenAddressCountry, :SupplierGenAddressCity, :SupplierGenAddressLine1, :SupplierGenAddressLine2, :SupplierGenContactName, :SupplierGenPhoneCode, :SupplierGenPhoneNumber, :SupplierGenLandlineCode, :SupplierGenLandlineSubNumber, :SupplierGenEmail, :SupplierGenWebsite, :SupplierGenDescription, :SupplierGenTypeId, :SG_OrganisationSupplierId, :SG_LocationSupplierOrganisatio, :SG_LocationSupplierLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00069)
          ,new CursorDef("BC000610", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGen SET SupplierGenContactPhone=:SupplierGenContactPhone, SupplierGenLandlineNumber=:SupplierGenLandlineNumber, SupplierGenAddressZipCode=:SupplierGenAddressZipCode, SupplierGenKvkNumber=:SupplierGenKvkNumber, SupplierGenCompanyName=:SupplierGenCompanyName, SupplierGenAddressCountry=:SupplierGenAddressCountry, SupplierGenAddressCity=:SupplierGenAddressCity, SupplierGenAddressLine1=:SupplierGenAddressLine1, SupplierGenAddressLine2=:SupplierGenAddressLine2, SupplierGenContactName=:SupplierGenContactName, SupplierGenPhoneCode=:SupplierGenPhoneCode, SupplierGenPhoneNumber=:SupplierGenPhoneNumber, SupplierGenLandlineCode=:SupplierGenLandlineCode, SupplierGenLandlineSubNumber=:SupplierGenLandlineSubNumber, SupplierGenEmail=:SupplierGenEmail, SupplierGenWebsite=:SupplierGenWebsite, SupplierGenDescription=:SupplierGenDescription, SupplierGenTypeId=:SupplierGenTypeId, SG_OrganisationSupplierId=:SG_OrganisationSupplierId, SG_LocationSupplierOrganisatio=:SG_LocationSupplierOrganisatio, SG_LocationSupplierLocationId=:SG_LocationSupplierLocationId  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000610)
          ,new CursorDef("BC000611", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000611)
          ,new CursorDef("BC000612", "SELECT SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000613", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000614", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000614,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000615", "SELECT TM1.SupplierGenId, TM1.SupplierGenContactPhone, TM1.SupplierGenLandlineNumber, TM1.SupplierGenAddressZipCode, TM1.SupplierGenKvkNumber, T2.SupplierGenTypeName, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCountry, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenPhoneCode, TM1.SupplierGenPhoneNumber, TM1.SupplierGenLandlineCode, TM1.SupplierGenLandlineSubNumber, TM1.SupplierGenEmail, TM1.SupplierGenWebsite, TM1.SupplierGenDescription, TM1.SupplierGenTypeId, TM1.SG_OrganisationSupplierId AS SG_OrganisationSupplierId, TM1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, TM1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId FROM (Trn_SupplierGen TM1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = TM1.SupplierGenTypeId) WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000615,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getLongVarchar(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getLongVarchar(18);
             ((Guid[]) buf[18])[0] = rslt.getGuid(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((Guid[]) buf[21])[0] = rslt.getGuid(21);
             ((bool[]) buf[22])[0] = rslt.wasNull(21);
             ((Guid[]) buf[23])[0] = rslt.getGuid(22);
             ((bool[]) buf[24])[0] = rslt.wasNull(22);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((bool[]) buf[21])[0] = rslt.wasNull(21);
             ((Guid[]) buf[22])[0] = rslt.getGuid(22);
             ((bool[]) buf[23])[0] = rslt.wasNull(22);
             ((Guid[]) buf[24])[0] = rslt.getGuid(23);
             ((bool[]) buf[25])[0] = rslt.wasNull(23);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((bool[]) buf[21])[0] = rslt.wasNull(21);
             ((Guid[]) buf[22])[0] = rslt.getGuid(22);
             ((bool[]) buf[23])[0] = rslt.wasNull(22);
             ((Guid[]) buf[24])[0] = rslt.getGuid(23);
             ((bool[]) buf[25])[0] = rslt.wasNull(23);
             return;
    }
 }

}

}
