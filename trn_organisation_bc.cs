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
   public class trn_organisation_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisation_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisation_bc( IGxContext context )
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
         ReadRow013( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey013( ) ;
         standaloneModal( ) ;
         AddRow013( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
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

      protected void CONFIRM_010( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls013( ) ;
            }
            else
            {
               CheckExtendedTable013( ) ;
               if ( AnyError == 0 )
               {
                  ZM013( 17) ;
               }
               CloseExtendedTableCursors013( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         AV34successmsg = AV12WebSession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV34successmsg,  "success",  "",  "true",  ""));
            AV12WebSession.Remove(context.GetMessage( "NotificationMessage", ""));
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
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV36Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV37GXV1 = 1;
            while ( AV37GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV37GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationTypeId") == 0 )
               {
                  AV13Insert_OrganisationTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV37GXV1 = (int)(AV37GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM013( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z17OrganisationPhone = A17OrganisationPhone;
            Z251OrganisationAddressZipCode = A251OrganisationAddressZipCode;
            Z13OrganisationName = A13OrganisationName;
            Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
            Z16OrganisationEmail = A16OrganisationEmail;
            Z361OrganisationPhoneCode = A361OrganisationPhoneCode;
            Z362OrganisationPhoneNumber = A362OrganisationPhoneNumber;
            Z18OrganisationVATNumber = A18OrganisationVATNumber;
            Z303OrganisationAddressCountry = A303OrganisationAddressCountry;
            Z252OrganisationAddressCity = A252OrganisationAddressCity;
            Z304OrganisationAddressLine1 = A304OrganisationAddressLine1;
            Z305OrganisationAddressLine2 = A305OrganisationAddressLine2;
            Z19OrganisationTypeId = A19OrganisationTypeId;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
         if ( GX_JID == -16 )
         {
            Z11OrganisationId = A11OrganisationId;
            Z17OrganisationPhone = A17OrganisationPhone;
            Z251OrganisationAddressZipCode = A251OrganisationAddressZipCode;
            Z13OrganisationName = A13OrganisationName;
            Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
            Z16OrganisationEmail = A16OrganisationEmail;
            Z361OrganisationPhoneCode = A361OrganisationPhoneCode;
            Z362OrganisationPhoneNumber = A362OrganisationPhoneNumber;
            Z18OrganisationVATNumber = A18OrganisationVATNumber;
            Z506OrganisationLogo = A506OrganisationLogo;
            Z40000OrganisationLogo_GXI = A40000OrganisationLogo_GXI;
            Z303OrganisationAddressCountry = A303OrganisationAddressCountry;
            Z252OrganisationAddressCity = A252OrganisationAddressCity;
            Z304OrganisationAddressLine1 = A304OrganisationAddressLine1;
            Z305OrganisationAddressLine2 = A305OrganisationAddressLine2;
            Z19OrganisationTypeId = A19OrganisationTypeId;
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31VatPattern = context.GetMessage( context.GetMessage( "[A-Za-z]{2}\\d{9}[A-Za-z]\\d{2}", ""), "");
         AV36Pgmname = "Trn_Organisation_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load013( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A17OrganisationPhone = BC00015_A17OrganisationPhone[0];
            A251OrganisationAddressZipCode = BC00015_A251OrganisationAddressZipCode[0];
            A13OrganisationName = BC00015_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC00015_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC00015_A16OrganisationEmail[0];
            A361OrganisationPhoneCode = BC00015_A361OrganisationPhoneCode[0];
            A362OrganisationPhoneNumber = BC00015_A362OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC00015_A18OrganisationVATNumber[0];
            A40000OrganisationLogo_GXI = BC00015_A40000OrganisationLogo_GXI[0];
            A303OrganisationAddressCountry = BC00015_A303OrganisationAddressCountry[0];
            A252OrganisationAddressCity = BC00015_A252OrganisationAddressCity[0];
            A304OrganisationAddressLine1 = BC00015_A304OrganisationAddressLine1[0];
            A305OrganisationAddressLine2 = BC00015_A305OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC00015_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC00015_A19OrganisationTypeId[0];
            A506OrganisationLogo = BC00015_A506OrganisationLogo[0];
            ZM013( -16) ;
         }
         pr_default.close(3);
         OnLoadActions013( ) ;
      }

      protected void OnLoadActions013( )
      {
         GXt_boolean1 = AV35OrganisationHasOwnBrand;
         new prc_isorgnisationhasownbranding(context ).execute(  A11OrganisationId, out  GXt_boolean1) ;
         AV35OrganisationHasOwnBrand = GXt_boolean1;
         GXt_char2 = A17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  A361OrganisationPhoneCode,  A362OrganisationPhoneNumber, out  GXt_char2) ;
         A17OrganisationPhone = GXt_char2;
         A251OrganisationAddressZipCode = StringUtil.Upper( A251OrganisationAddressZipCode);
      }

      protected void CheckExtendedTable013( )
      {
         standaloneModal( ) ;
         GXt_boolean1 = AV35OrganisationHasOwnBrand;
         new prc_isorgnisationhasownbranding(context ).execute(  A11OrganisationId, out  GXt_boolean1) ;
         AV35OrganisationHasOwnBrand = GXt_boolean1;
         if ( ! ( GxRegex.IsMatch(A12OrganisationKvkNumber,"\\b\\d{8}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "KvK number should contain 8 digits", ""), context.GetMessage( "Organisation Kvk Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A12OrganisationKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KVK number must contain 8 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A16OrganisationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Organisation Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         GXt_char2 = A17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  A361OrganisationPhoneCode,  A362OrganisationPhoneNumber, out  GXt_char2) ;
         A17OrganisationPhone = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A362OrganisationPhoneNumber)) && ! GxRegex.IsMatch(A362OrganisationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A18OrganisationVATNumber) != 14 )
         {
            GX_msglist.addItem(context.GetMessage( "VAT number must contain 14 characters", ""), 1, "");
            AnyError = 1;
         }
         A251OrganisationAddressZipCode = StringUtil.Upper( A251OrganisationAddressZipCode);
         if ( ! GxRegex.IsMatch(A251OrganisationAddressZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A251OrganisationAddressZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisation Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONTYPEID");
            AnyError = 1;
         }
         A20OrganisationTypeName = BC00014_A20OrganisationTypeName[0];
         pr_default.close(2);
         if ( GxRegex.IsMatch(A18OrganisationVATNumber,AV31VatPattern) != true )
         {
            GX_msglist.addItem(context.GetMessage( "VAT number is incorrect", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors013( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey013( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM013( 16) ;
            RcdFound3 = 1;
            A11OrganisationId = BC00013_A11OrganisationId[0];
            n11OrganisationId = BC00013_n11OrganisationId[0];
            A17OrganisationPhone = BC00013_A17OrganisationPhone[0];
            A251OrganisationAddressZipCode = BC00013_A251OrganisationAddressZipCode[0];
            A13OrganisationName = BC00013_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC00013_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC00013_A16OrganisationEmail[0];
            A361OrganisationPhoneCode = BC00013_A361OrganisationPhoneCode[0];
            A362OrganisationPhoneNumber = BC00013_A362OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC00013_A18OrganisationVATNumber[0];
            A40000OrganisationLogo_GXI = BC00013_A40000OrganisationLogo_GXI[0];
            A303OrganisationAddressCountry = BC00013_A303OrganisationAddressCountry[0];
            A252OrganisationAddressCity = BC00013_A252OrganisationAddressCity[0];
            A304OrganisationAddressLine1 = BC00013_A304OrganisationAddressLine1[0];
            A305OrganisationAddressLine2 = BC00013_A305OrganisationAddressLine2[0];
            A19OrganisationTypeId = BC00013_A19OrganisationTypeId[0];
            A506OrganisationLogo = BC00013_A506OrganisationLogo[0];
            Z11OrganisationId = A11OrganisationId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load013( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey013( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey013( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey013( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency013( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z17OrganisationPhone, BC00012_A17OrganisationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z251OrganisationAddressZipCode, BC00012_A251OrganisationAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z13OrganisationName, BC00012_A13OrganisationName[0]) != 0 ) || ( StringUtil.StrCmp(Z12OrganisationKvkNumber, BC00012_A12OrganisationKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z16OrganisationEmail, BC00012_A16OrganisationEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z361OrganisationPhoneCode, BC00012_A361OrganisationPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z362OrganisationPhoneNumber, BC00012_A362OrganisationPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z18OrganisationVATNumber, BC00012_A18OrganisationVATNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z303OrganisationAddressCountry, BC00012_A303OrganisationAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z252OrganisationAddressCity, BC00012_A252OrganisationAddressCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z304OrganisationAddressLine1, BC00012_A304OrganisationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z305OrganisationAddressLine2, BC00012_A305OrganisationAddressLine2[0]) != 0 ) || ( Z19OrganisationTypeId != BC00012_A19OrganisationTypeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Organisation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM013( 0) ;
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {n11OrganisationId, A11OrganisationId, A17OrganisationPhone, A251OrganisationAddressZipCode, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A361OrganisationPhoneCode, A362OrganisationPhoneNumber, A18OrganisationVATNumber, A506OrganisationLogo, A40000OrganisationLogo_GXI, A303OrganisationAddressCountry, A252OrganisationAddressCity, A304OrganisationAddressLine1, A305OrganisationAddressLine2, A19OrganisationTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load013( ) ;
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void Update013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A17OrganisationPhone, A251OrganisationAddressZipCode, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A361OrganisationPhoneCode, A362OrganisationPhoneNumber, A18OrganisationVATNumber, A303OrganisationAddressCountry, A252OrganisationAddressCity, A304OrganisationAddressLine1, A305OrganisationAddressLine2, A19OrganisationTypeId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate013( ) ;
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
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void DeferredUpdate013( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A506OrganisationLogo, A40000OrganisationLogo_GXI, n11OrganisationId, A11OrganisationId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls013( ) ;
            AfterConfirm013( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete013( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {n11OrganisationId, A11OrganisationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel013( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls013( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV35OrganisationHasOwnBrand;
            new prc_isorgnisationhasownbranding(context ).execute(  A11OrganisationId, out  GXt_boolean1) ;
            AV35OrganisationHasOwnBrand = GXt_boolean1;
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A19OrganisationTypeId});
            A20OrganisationTypeName = BC000111_A20OrganisationTypeName[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "General Suppliers", "")+" ("+context.GetMessage( "SG_Organisation Supplier", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Audits", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000114 */
            pr_default.execute(12, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationSetting", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000115 */
            pr_default.execute(13, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000116 */
            pr_default.execute(14, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Managers", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel013( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete013( ) ;
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

      public void ScanKeyStart013( )
      {
         /* Scan By routine */
         /* Using cursor BC000117 */
         pr_default.execute(15, new Object[] {n11OrganisationId, A11OrganisationId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = BC000117_A11OrganisationId[0];
            n11OrganisationId = BC000117_n11OrganisationId[0];
            A17OrganisationPhone = BC000117_A17OrganisationPhone[0];
            A251OrganisationAddressZipCode = BC000117_A251OrganisationAddressZipCode[0];
            A13OrganisationName = BC000117_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC000117_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC000117_A16OrganisationEmail[0];
            A361OrganisationPhoneCode = BC000117_A361OrganisationPhoneCode[0];
            A362OrganisationPhoneNumber = BC000117_A362OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC000117_A18OrganisationVATNumber[0];
            A40000OrganisationLogo_GXI = BC000117_A40000OrganisationLogo_GXI[0];
            A303OrganisationAddressCountry = BC000117_A303OrganisationAddressCountry[0];
            A252OrganisationAddressCity = BC000117_A252OrganisationAddressCity[0];
            A304OrganisationAddressLine1 = BC000117_A304OrganisationAddressLine1[0];
            A305OrganisationAddressLine2 = BC000117_A305OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC000117_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC000117_A19OrganisationTypeId[0];
            A506OrganisationLogo = BC000117_A506OrganisationLogo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext013( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound3 = 0;
         ScanKeyLoad013( ) ;
      }

      protected void ScanKeyLoad013( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = BC000117_A11OrganisationId[0];
            n11OrganisationId = BC000117_n11OrganisationId[0];
            A17OrganisationPhone = BC000117_A17OrganisationPhone[0];
            A251OrganisationAddressZipCode = BC000117_A251OrganisationAddressZipCode[0];
            A13OrganisationName = BC000117_A13OrganisationName[0];
            A12OrganisationKvkNumber = BC000117_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = BC000117_A16OrganisationEmail[0];
            A361OrganisationPhoneCode = BC000117_A361OrganisationPhoneCode[0];
            A362OrganisationPhoneNumber = BC000117_A362OrganisationPhoneNumber[0];
            A18OrganisationVATNumber = BC000117_A18OrganisationVATNumber[0];
            A40000OrganisationLogo_GXI = BC000117_A40000OrganisationLogo_GXI[0];
            A303OrganisationAddressCountry = BC000117_A303OrganisationAddressCountry[0];
            A252OrganisationAddressCity = BC000117_A252OrganisationAddressCity[0];
            A304OrganisationAddressLine1 = BC000117_A304OrganisationAddressLine1[0];
            A305OrganisationAddressLine2 = BC000117_A305OrganisationAddressLine2[0];
            A20OrganisationTypeName = BC000117_A20OrganisationTypeName[0];
            A19OrganisationTypeId = BC000117_A19OrganisationTypeId[0];
            A506OrganisationLogo = BC000117_A506OrganisationLogo[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd013( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm013( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert013( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate013( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete013( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete013( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate013( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes013( )
      {
      }

      protected void send_integrity_lvl_hashes013( )
      {
      }

      protected void AddRow013( )
      {
         VarsToRow3( bcTrn_Organisation) ;
      }

      protected void ReadRow013( )
      {
         RowToVars3( bcTrn_Organisation, 1) ;
      }

      protected void InitializeNonKey013( )
      {
         A17OrganisationPhone = "";
         A251OrganisationAddressZipCode = "";
         AV35OrganisationHasOwnBrand = false;
         A13OrganisationName = "";
         A12OrganisationKvkNumber = "";
         A16OrganisationEmail = "";
         A361OrganisationPhoneCode = "";
         A362OrganisationPhoneNumber = "";
         A18OrganisationVATNumber = "";
         A506OrganisationLogo = "";
         A40000OrganisationLogo_GXI = "";
         A303OrganisationAddressCountry = "";
         A252OrganisationAddressCity = "";
         A304OrganisationAddressLine1 = "";
         A305OrganisationAddressLine2 = "";
         A19OrganisationTypeId = Guid.Empty;
         A20OrganisationTypeName = "";
         Z17OrganisationPhone = "";
         Z251OrganisationAddressZipCode = "";
         Z13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         Z361OrganisationPhoneCode = "";
         Z362OrganisationPhoneNumber = "";
         Z18OrganisationVATNumber = "";
         Z303OrganisationAddressCountry = "";
         Z252OrganisationAddressCity = "";
         Z304OrganisationAddressLine1 = "";
         Z305OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
      }

      protected void InitAll013( )
      {
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         InitializeNonKey013( ) ;
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

      public void VarsToRow3( SdtTrn_Organisation obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Organisationphone = A17OrganisationPhone;
         obj3.gxTpr_Organisationaddresszipcode = A251OrganisationAddressZipCode;
         obj3.gxTpr_Organisationname = A13OrganisationName;
         obj3.gxTpr_Organisationkvknumber = A12OrganisationKvkNumber;
         obj3.gxTpr_Organisationemail = A16OrganisationEmail;
         obj3.gxTpr_Organisationphonecode = A361OrganisationPhoneCode;
         obj3.gxTpr_Organisationphonenumber = A362OrganisationPhoneNumber;
         obj3.gxTpr_Organisationvatnumber = A18OrganisationVATNumber;
         obj3.gxTpr_Organisationlogo = A506OrganisationLogo;
         obj3.gxTpr_Organisationlogo_gxi = A40000OrganisationLogo_GXI;
         obj3.gxTpr_Organisationaddresscountry = A303OrganisationAddressCountry;
         obj3.gxTpr_Organisationaddresscity = A252OrganisationAddressCity;
         obj3.gxTpr_Organisationaddressline1 = A304OrganisationAddressLine1;
         obj3.gxTpr_Organisationaddressline2 = A305OrganisationAddressLine2;
         obj3.gxTpr_Organisationtypeid = A19OrganisationTypeId;
         obj3.gxTpr_Organisationtypename = A20OrganisationTypeName;
         obj3.gxTpr_Organisationid = A11OrganisationId;
         obj3.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj3.gxTpr_Organisationname_Z = Z13OrganisationName;
         obj3.gxTpr_Organisationkvknumber_Z = Z12OrganisationKvkNumber;
         obj3.gxTpr_Organisationemail_Z = Z16OrganisationEmail;
         obj3.gxTpr_Organisationphone_Z = Z17OrganisationPhone;
         obj3.gxTpr_Organisationphonecode_Z = Z361OrganisationPhoneCode;
         obj3.gxTpr_Organisationphonenumber_Z = Z362OrganisationPhoneNumber;
         obj3.gxTpr_Organisationvatnumber_Z = Z18OrganisationVATNumber;
         obj3.gxTpr_Organisationaddresscountry_Z = Z303OrganisationAddressCountry;
         obj3.gxTpr_Organisationaddresscity_Z = Z252OrganisationAddressCity;
         obj3.gxTpr_Organisationaddresszipcode_Z = Z251OrganisationAddressZipCode;
         obj3.gxTpr_Organisationaddressline1_Z = Z304OrganisationAddressLine1;
         obj3.gxTpr_Organisationaddressline2_Z = Z305OrganisationAddressLine2;
         obj3.gxTpr_Organisationtypeid_Z = Z19OrganisationTypeId;
         obj3.gxTpr_Organisationtypename_Z = Z20OrganisationTypeName;
         obj3.gxTpr_Organisationlogo_gxi_Z = Z40000OrganisationLogo_GXI;
         obj3.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtTrn_Organisation obj3 )
      {
         obj3.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars3( SdtTrn_Organisation obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A17OrganisationPhone = obj3.gxTpr_Organisationphone;
         A251OrganisationAddressZipCode = obj3.gxTpr_Organisationaddresszipcode;
         A13OrganisationName = obj3.gxTpr_Organisationname;
         A12OrganisationKvkNumber = obj3.gxTpr_Organisationkvknumber;
         A16OrganisationEmail = obj3.gxTpr_Organisationemail;
         A361OrganisationPhoneCode = obj3.gxTpr_Organisationphonecode;
         A362OrganisationPhoneNumber = obj3.gxTpr_Organisationphonenumber;
         A18OrganisationVATNumber = obj3.gxTpr_Organisationvatnumber;
         A506OrganisationLogo = obj3.gxTpr_Organisationlogo;
         A40000OrganisationLogo_GXI = obj3.gxTpr_Organisationlogo_gxi;
         A303OrganisationAddressCountry = obj3.gxTpr_Organisationaddresscountry;
         A252OrganisationAddressCity = obj3.gxTpr_Organisationaddresscity;
         A304OrganisationAddressLine1 = obj3.gxTpr_Organisationaddressline1;
         A305OrganisationAddressLine2 = obj3.gxTpr_Organisationaddressline2;
         A19OrganisationTypeId = obj3.gxTpr_Organisationtypeid;
         A20OrganisationTypeName = obj3.gxTpr_Organisationtypename;
         A11OrganisationId = obj3.gxTpr_Organisationid;
         n11OrganisationId = false;
         Z11OrganisationId = obj3.gxTpr_Organisationid_Z;
         Z13OrganisationName = obj3.gxTpr_Organisationname_Z;
         Z12OrganisationKvkNumber = obj3.gxTpr_Organisationkvknumber_Z;
         Z16OrganisationEmail = obj3.gxTpr_Organisationemail_Z;
         Z17OrganisationPhone = obj3.gxTpr_Organisationphone_Z;
         Z361OrganisationPhoneCode = obj3.gxTpr_Organisationphonecode_Z;
         Z362OrganisationPhoneNumber = obj3.gxTpr_Organisationphonenumber_Z;
         Z18OrganisationVATNumber = obj3.gxTpr_Organisationvatnumber_Z;
         Z303OrganisationAddressCountry = obj3.gxTpr_Organisationaddresscountry_Z;
         Z252OrganisationAddressCity = obj3.gxTpr_Organisationaddresscity_Z;
         Z251OrganisationAddressZipCode = obj3.gxTpr_Organisationaddresszipcode_Z;
         Z304OrganisationAddressLine1 = obj3.gxTpr_Organisationaddressline1_Z;
         Z305OrganisationAddressLine2 = obj3.gxTpr_Organisationaddressline2_Z;
         Z19OrganisationTypeId = obj3.gxTpr_Organisationtypeid_Z;
         Z20OrganisationTypeName = obj3.gxTpr_Organisationtypename_Z;
         Z40000OrganisationLogo_GXI = obj3.gxTpr_Organisationlogo_gxi_Z;
         n11OrganisationId = (bool)(Convert.ToBoolean(obj3.gxTpr_Organisationid_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11OrganisationId = (Guid)getParm(obj,0);
         n11OrganisationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey013( ) ;
         ScanKeyStart013( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11OrganisationId = A11OrganisationId;
         }
         ZM013( -16) ;
         OnLoadActions013( ) ;
         AddRow013( ) ;
         ScanKeyEnd013( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcTrn_Organisation, 0) ;
         ScanKeyStart013( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11OrganisationId = A11OrganisationId;
         }
         ZM013( -16) ;
         OnLoadActions013( ) ;
         AddRow013( ) ;
         ScanKeyEnd013( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey013( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert013( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A11OrganisationId != Z11OrganisationId )
               {
                  A11OrganisationId = Z11OrganisationId;
                  n11OrganisationId = false;
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
                  Update013( ) ;
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
                  if ( A11OrganisationId != Z11OrganisationId )
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
                        Insert013( ) ;
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
                        Insert013( ) ;
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
         RowToVars3( bcTrn_Organisation, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcTrn_Organisation) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcTrn_Organisation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert013( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcTrn_Organisation) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bcTrn_Organisation) ;
         }
         else
         {
            SdtTrn_Organisation auxBC = new SdtTrn_Organisation(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Organisation);
               auxBC.Save();
               bcTrn_Organisation.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars3( bcTrn_Organisation, 1) ;
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
         RowToVars3( bcTrn_Organisation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert013( ) ;
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
               VarsToRow3( bcTrn_Organisation) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bcTrn_Organisation) ;
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
         RowToVars3( bcTrn_Organisation, 0) ;
         GetKey013( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11OrganisationId != Z11OrganisationId )
            {
               A11OrganisationId = Z11OrganisationId;
               n11OrganisationId = false;
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
            if ( A11OrganisationId != Z11OrganisationId )
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
         context.RollbackDataStores("trn_organisation_bc",pr_default);
         VarsToRow3( bcTrn_Organisation) ;
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
         Gx_mode = bcTrn_Organisation.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Organisation.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Organisation )
         {
            bcTrn_Organisation = (SdtTrn_Organisation)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Organisation.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Organisation.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcTrn_Organisation) ;
            }
            else
            {
               RowToVars3( bcTrn_Organisation, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Organisation.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Organisation.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcTrn_Organisation, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Organisation Trn_Organisation_BC
      {
         get {
            return bcTrn_Organisation ;
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
            return "trn_organisation_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV34successmsg = "";
         AV12WebSession = context.GetSession();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV36Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationTypeId = Guid.Empty;
         Z17OrganisationPhone = "";
         A17OrganisationPhone = "";
         Z251OrganisationAddressZipCode = "";
         A251OrganisationAddressZipCode = "";
         Z13OrganisationName = "";
         A13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         A12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         A16OrganisationEmail = "";
         Z361OrganisationPhoneCode = "";
         A361OrganisationPhoneCode = "";
         Z362OrganisationPhoneNumber = "";
         A362OrganisationPhoneNumber = "";
         Z18OrganisationVATNumber = "";
         A18OrganisationVATNumber = "";
         Z303OrganisationAddressCountry = "";
         A303OrganisationAddressCountry = "";
         Z252OrganisationAddressCity = "";
         A252OrganisationAddressCity = "";
         Z304OrganisationAddressLine1 = "";
         A304OrganisationAddressLine1 = "";
         Z305OrganisationAddressLine2 = "";
         A305OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
         A19OrganisationTypeId = Guid.Empty;
         Z20OrganisationTypeName = "";
         A20OrganisationTypeName = "";
         Z506OrganisationLogo = "";
         A506OrganisationLogo = "";
         Z40000OrganisationLogo_GXI = "";
         A40000OrganisationLogo_GXI = "";
         AV31VatPattern = "";
         BC00015_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00015_n11OrganisationId = new bool[] {false} ;
         BC00015_A17OrganisationPhone = new string[] {""} ;
         BC00015_A251OrganisationAddressZipCode = new string[] {""} ;
         BC00015_A13OrganisationName = new string[] {""} ;
         BC00015_A12OrganisationKvkNumber = new string[] {""} ;
         BC00015_A16OrganisationEmail = new string[] {""} ;
         BC00015_A361OrganisationPhoneCode = new string[] {""} ;
         BC00015_A362OrganisationPhoneNumber = new string[] {""} ;
         BC00015_A18OrganisationVATNumber = new string[] {""} ;
         BC00015_A40000OrganisationLogo_GXI = new string[] {""} ;
         BC00015_A303OrganisationAddressCountry = new string[] {""} ;
         BC00015_A252OrganisationAddressCity = new string[] {""} ;
         BC00015_A304OrganisationAddressLine1 = new string[] {""} ;
         BC00015_A305OrganisationAddressLine2 = new string[] {""} ;
         BC00015_A20OrganisationTypeName = new string[] {""} ;
         BC00015_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00015_A506OrganisationLogo = new string[] {""} ;
         GXt_char2 = "";
         BC00014_A20OrganisationTypeName = new string[] {""} ;
         BC00016_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00016_n11OrganisationId = new bool[] {false} ;
         BC00013_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00013_n11OrganisationId = new bool[] {false} ;
         BC00013_A17OrganisationPhone = new string[] {""} ;
         BC00013_A251OrganisationAddressZipCode = new string[] {""} ;
         BC00013_A13OrganisationName = new string[] {""} ;
         BC00013_A12OrganisationKvkNumber = new string[] {""} ;
         BC00013_A16OrganisationEmail = new string[] {""} ;
         BC00013_A361OrganisationPhoneCode = new string[] {""} ;
         BC00013_A362OrganisationPhoneNumber = new string[] {""} ;
         BC00013_A18OrganisationVATNumber = new string[] {""} ;
         BC00013_A40000OrganisationLogo_GXI = new string[] {""} ;
         BC00013_A303OrganisationAddressCountry = new string[] {""} ;
         BC00013_A252OrganisationAddressCity = new string[] {""} ;
         BC00013_A304OrganisationAddressLine1 = new string[] {""} ;
         BC00013_A305OrganisationAddressLine2 = new string[] {""} ;
         BC00013_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00013_A506OrganisationLogo = new string[] {""} ;
         sMode3 = "";
         BC00012_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00012_n11OrganisationId = new bool[] {false} ;
         BC00012_A17OrganisationPhone = new string[] {""} ;
         BC00012_A251OrganisationAddressZipCode = new string[] {""} ;
         BC00012_A13OrganisationName = new string[] {""} ;
         BC00012_A12OrganisationKvkNumber = new string[] {""} ;
         BC00012_A16OrganisationEmail = new string[] {""} ;
         BC00012_A361OrganisationPhoneCode = new string[] {""} ;
         BC00012_A362OrganisationPhoneNumber = new string[] {""} ;
         BC00012_A18OrganisationVATNumber = new string[] {""} ;
         BC00012_A40000OrganisationLogo_GXI = new string[] {""} ;
         BC00012_A303OrganisationAddressCountry = new string[] {""} ;
         BC00012_A252OrganisationAddressCity = new string[] {""} ;
         BC00012_A304OrganisationAddressLine1 = new string[] {""} ;
         BC00012_A305OrganisationAddressLine2 = new string[] {""} ;
         BC00012_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00012_A506OrganisationLogo = new string[] {""} ;
         BC000111_A20OrganisationTypeName = new string[] {""} ;
         BC000112_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000113_A371AuditId = new Guid[] {Guid.Empty} ;
         BC000114_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000114_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000114_n11OrganisationId = new bool[] {false} ;
         BC000115_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC000115_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000115_n11OrganisationId = new bool[] {false} ;
         BC000116_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC000116_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000116_n11OrganisationId = new bool[] {false} ;
         BC000117_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000117_n11OrganisationId = new bool[] {false} ;
         BC000117_A17OrganisationPhone = new string[] {""} ;
         BC000117_A251OrganisationAddressZipCode = new string[] {""} ;
         BC000117_A13OrganisationName = new string[] {""} ;
         BC000117_A12OrganisationKvkNumber = new string[] {""} ;
         BC000117_A16OrganisationEmail = new string[] {""} ;
         BC000117_A361OrganisationPhoneCode = new string[] {""} ;
         BC000117_A362OrganisationPhoneNumber = new string[] {""} ;
         BC000117_A18OrganisationVATNumber = new string[] {""} ;
         BC000117_A40000OrganisationLogo_GXI = new string[] {""} ;
         BC000117_A303OrganisationAddressCountry = new string[] {""} ;
         BC000117_A252OrganisationAddressCity = new string[] {""} ;
         BC000117_A304OrganisationAddressLine1 = new string[] {""} ;
         BC000117_A305OrganisationAddressLine2 = new string[] {""} ;
         BC000117_A20OrganisationTypeName = new string[] {""} ;
         BC000117_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC000117_A506OrganisationLogo = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A11OrganisationId, BC00012_A17OrganisationPhone, BC00012_A251OrganisationAddressZipCode, BC00012_A13OrganisationName, BC00012_A12OrganisationKvkNumber, BC00012_A16OrganisationEmail, BC00012_A361OrganisationPhoneCode, BC00012_A362OrganisationPhoneNumber, BC00012_A18OrganisationVATNumber, BC00012_A40000OrganisationLogo_GXI,
               BC00012_A303OrganisationAddressCountry, BC00012_A252OrganisationAddressCity, BC00012_A304OrganisationAddressLine1, BC00012_A305OrganisationAddressLine2, BC00012_A19OrganisationTypeId, BC00012_A506OrganisationLogo
               }
               , new Object[] {
               BC00013_A11OrganisationId, BC00013_A17OrganisationPhone, BC00013_A251OrganisationAddressZipCode, BC00013_A13OrganisationName, BC00013_A12OrganisationKvkNumber, BC00013_A16OrganisationEmail, BC00013_A361OrganisationPhoneCode, BC00013_A362OrganisationPhoneNumber, BC00013_A18OrganisationVATNumber, BC00013_A40000OrganisationLogo_GXI,
               BC00013_A303OrganisationAddressCountry, BC00013_A252OrganisationAddressCity, BC00013_A304OrganisationAddressLine1, BC00013_A305OrganisationAddressLine2, BC00013_A19OrganisationTypeId, BC00013_A506OrganisationLogo
               }
               , new Object[] {
               BC00014_A20OrganisationTypeName
               }
               , new Object[] {
               BC00015_A11OrganisationId, BC00015_A17OrganisationPhone, BC00015_A251OrganisationAddressZipCode, BC00015_A13OrganisationName, BC00015_A12OrganisationKvkNumber, BC00015_A16OrganisationEmail, BC00015_A361OrganisationPhoneCode, BC00015_A362OrganisationPhoneNumber, BC00015_A18OrganisationVATNumber, BC00015_A40000OrganisationLogo_GXI,
               BC00015_A303OrganisationAddressCountry, BC00015_A252OrganisationAddressCity, BC00015_A304OrganisationAddressLine1, BC00015_A305OrganisationAddressLine2, BC00015_A20OrganisationTypeName, BC00015_A19OrganisationTypeId, BC00015_A506OrganisationLogo
               }
               , new Object[] {
               BC00016_A11OrganisationId
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
               BC000111_A20OrganisationTypeName
               }
               , new Object[] {
               BC000112_A42SupplierGenId
               }
               , new Object[] {
               BC000113_A371AuditId
               }
               , new Object[] {
               BC000114_A100OrganisationSettingid, BC000114_A11OrganisationId
               }
               , new Object[] {
               BC000115_A509OrganisationDynamicFormId, BC000115_A11OrganisationId
               }
               , new Object[] {
               BC000116_A21ManagerId, BC000116_A11OrganisationId
               }
               , new Object[] {
               BC000117_A11OrganisationId, BC000117_A17OrganisationPhone, BC000117_A251OrganisationAddressZipCode, BC000117_A13OrganisationName, BC000117_A12OrganisationKvkNumber, BC000117_A16OrganisationEmail, BC000117_A361OrganisationPhoneCode, BC000117_A362OrganisationPhoneNumber, BC000117_A18OrganisationVATNumber, BC000117_A40000OrganisationLogo_GXI,
               BC000117_A303OrganisationAddressCountry, BC000117_A252OrganisationAddressCity, BC000117_A304OrganisationAddressLine1, BC000117_A305OrganisationAddressLine2, BC000117_A20OrganisationTypeName, BC000117_A19OrganisationTypeId, BC000117_A506OrganisationLogo
               }
            }
         );
         AV36Pgmname = "Trn_Organisation_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound3 ;
      private int trnEnded ;
      private int AV37GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV36Pgmname ;
      private string Z17OrganisationPhone ;
      private string A17OrganisationPhone ;
      private string GXt_char2 ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool n11OrganisationId ;
      private bool AV35OrganisationHasOwnBrand ;
      private bool Gx_longc ;
      private bool GXt_boolean1 ;
      private string AV34successmsg ;
      private string Z251OrganisationAddressZipCode ;
      private string A251OrganisationAddressZipCode ;
      private string Z13OrganisationName ;
      private string A13OrganisationName ;
      private string Z12OrganisationKvkNumber ;
      private string A12OrganisationKvkNumber ;
      private string Z16OrganisationEmail ;
      private string A16OrganisationEmail ;
      private string Z361OrganisationPhoneCode ;
      private string A361OrganisationPhoneCode ;
      private string Z362OrganisationPhoneNumber ;
      private string A362OrganisationPhoneNumber ;
      private string Z18OrganisationVATNumber ;
      private string A18OrganisationVATNumber ;
      private string Z303OrganisationAddressCountry ;
      private string A303OrganisationAddressCountry ;
      private string Z252OrganisationAddressCity ;
      private string A252OrganisationAddressCity ;
      private string Z304OrganisationAddressLine1 ;
      private string A304OrganisationAddressLine1 ;
      private string Z305OrganisationAddressLine2 ;
      private string A305OrganisationAddressLine2 ;
      private string Z20OrganisationTypeName ;
      private string A20OrganisationTypeName ;
      private string Z40000OrganisationLogo_GXI ;
      private string A40000OrganisationLogo_GXI ;
      private string AV31VatPattern ;
      private string Z506OrganisationLogo ;
      private string A506OrganisationLogo ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV13Insert_OrganisationTypeId ;
      private Guid Z19OrganisationTypeId ;
      private Guid A19OrganisationTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00015_A11OrganisationId ;
      private bool[] BC00015_n11OrganisationId ;
      private string[] BC00015_A17OrganisationPhone ;
      private string[] BC00015_A251OrganisationAddressZipCode ;
      private string[] BC00015_A13OrganisationName ;
      private string[] BC00015_A12OrganisationKvkNumber ;
      private string[] BC00015_A16OrganisationEmail ;
      private string[] BC00015_A361OrganisationPhoneCode ;
      private string[] BC00015_A362OrganisationPhoneNumber ;
      private string[] BC00015_A18OrganisationVATNumber ;
      private string[] BC00015_A40000OrganisationLogo_GXI ;
      private string[] BC00015_A303OrganisationAddressCountry ;
      private string[] BC00015_A252OrganisationAddressCity ;
      private string[] BC00015_A304OrganisationAddressLine1 ;
      private string[] BC00015_A305OrganisationAddressLine2 ;
      private string[] BC00015_A20OrganisationTypeName ;
      private Guid[] BC00015_A19OrganisationTypeId ;
      private string[] BC00015_A506OrganisationLogo ;
      private string[] BC00014_A20OrganisationTypeName ;
      private Guid[] BC00016_A11OrganisationId ;
      private bool[] BC00016_n11OrganisationId ;
      private Guid[] BC00013_A11OrganisationId ;
      private bool[] BC00013_n11OrganisationId ;
      private string[] BC00013_A17OrganisationPhone ;
      private string[] BC00013_A251OrganisationAddressZipCode ;
      private string[] BC00013_A13OrganisationName ;
      private string[] BC00013_A12OrganisationKvkNumber ;
      private string[] BC00013_A16OrganisationEmail ;
      private string[] BC00013_A361OrganisationPhoneCode ;
      private string[] BC00013_A362OrganisationPhoneNumber ;
      private string[] BC00013_A18OrganisationVATNumber ;
      private string[] BC00013_A40000OrganisationLogo_GXI ;
      private string[] BC00013_A303OrganisationAddressCountry ;
      private string[] BC00013_A252OrganisationAddressCity ;
      private string[] BC00013_A304OrganisationAddressLine1 ;
      private string[] BC00013_A305OrganisationAddressLine2 ;
      private Guid[] BC00013_A19OrganisationTypeId ;
      private string[] BC00013_A506OrganisationLogo ;
      private Guid[] BC00012_A11OrganisationId ;
      private bool[] BC00012_n11OrganisationId ;
      private string[] BC00012_A17OrganisationPhone ;
      private string[] BC00012_A251OrganisationAddressZipCode ;
      private string[] BC00012_A13OrganisationName ;
      private string[] BC00012_A12OrganisationKvkNumber ;
      private string[] BC00012_A16OrganisationEmail ;
      private string[] BC00012_A361OrganisationPhoneCode ;
      private string[] BC00012_A362OrganisationPhoneNumber ;
      private string[] BC00012_A18OrganisationVATNumber ;
      private string[] BC00012_A40000OrganisationLogo_GXI ;
      private string[] BC00012_A303OrganisationAddressCountry ;
      private string[] BC00012_A252OrganisationAddressCity ;
      private string[] BC00012_A304OrganisationAddressLine1 ;
      private string[] BC00012_A305OrganisationAddressLine2 ;
      private Guid[] BC00012_A19OrganisationTypeId ;
      private string[] BC00012_A506OrganisationLogo ;
      private string[] BC000111_A20OrganisationTypeName ;
      private Guid[] BC000112_A42SupplierGenId ;
      private Guid[] BC000113_A371AuditId ;
      private Guid[] BC000114_A100OrganisationSettingid ;
      private Guid[] BC000114_A11OrganisationId ;
      private bool[] BC000114_n11OrganisationId ;
      private Guid[] BC000115_A509OrganisationDynamicFormId ;
      private Guid[] BC000115_A11OrganisationId ;
      private bool[] BC000115_n11OrganisationId ;
      private Guid[] BC000116_A21ManagerId ;
      private Guid[] BC000116_A11OrganisationId ;
      private bool[] BC000116_n11OrganisationId ;
      private Guid[] BC000117_A11OrganisationId ;
      private bool[] BC000117_n11OrganisationId ;
      private string[] BC000117_A17OrganisationPhone ;
      private string[] BC000117_A251OrganisationAddressZipCode ;
      private string[] BC000117_A13OrganisationName ;
      private string[] BC000117_A12OrganisationKvkNumber ;
      private string[] BC000117_A16OrganisationEmail ;
      private string[] BC000117_A361OrganisationPhoneCode ;
      private string[] BC000117_A362OrganisationPhoneNumber ;
      private string[] BC000117_A18OrganisationVATNumber ;
      private string[] BC000117_A40000OrganisationLogo_GXI ;
      private string[] BC000117_A303OrganisationAddressCountry ;
      private string[] BC000117_A252OrganisationAddressCity ;
      private string[] BC000117_A304OrganisationAddressLine1 ;
      private string[] BC000117_A305OrganisationAddressLine2 ;
      private string[] BC000117_A20OrganisationTypeName ;
      private Guid[] BC000117_A19OrganisationTypeId ;
      private string[] BC000117_A506OrganisationLogo ;
      private SdtTrn_Organisation bcTrn_Organisation ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisation_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisation_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisation_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00012;
       prmBC00012 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00013;
       prmBC00013 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00014;
       prmBC00014 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00015;
       prmBC00015 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00016;
       prmBC00016 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00017;
       prmBC00017 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationPhone",GXType.Char,20,0) ,
       new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("OrganisationName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("OrganisationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("OrganisationVATNumber",GXType.VarChar,14,0) ,
       new ParDef("OrganisationLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=9, Tbl="Trn_Organisation", Fld="OrganisationLogo"} ,
       new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00018;
       prmBC00018 = new Object[] {
       new ParDef("OrganisationPhone",GXType.Char,20,0) ,
       new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
       new ParDef("OrganisationName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationKvkNumber",GXType.VarChar,8,0) ,
       new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("OrganisationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("OrganisationVATNumber",GXType.VarChar,14,0) ,
       new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00019;
       prmBC00019 = new Object[] {
       new ParDef("OrganisationLogo",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Organisation", Fld="OrganisationLogo"} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000110;
       prmBC000110 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000111;
       prmBC000111 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000112;
       prmBC000112 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000113;
       prmBC000113 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000114;
       prmBC000114 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000115;
       prmBC000115 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000116;
       prmBC000116 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000117;
       prmBC000117 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00012", "SELECT OrganisationId, OrganisationPhone, OrganisationAddressZipCode, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationLogo_GXI, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId, OrganisationLogo FROM Trn_Organisation WHERE OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Organisation",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00013", "SELECT OrganisationId, OrganisationPhone, OrganisationAddressZipCode, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationLogo_GXI, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId, OrganisationLogo FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00014", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00015", "SELECT TM1.OrganisationId, TM1.OrganisationPhone, TM1.OrganisationAddressZipCode, TM1.OrganisationName, TM1.OrganisationKvkNumber, TM1.OrganisationEmail, TM1.OrganisationPhoneCode, TM1.OrganisationPhoneNumber, TM1.OrganisationVATNumber, TM1.OrganisationLogo_GXI, TM1.OrganisationAddressCountry, TM1.OrganisationAddressCity, TM1.OrganisationAddressLine1, TM1.OrganisationAddressLine2, T2.OrganisationTypeName, TM1.OrganisationTypeId, TM1.OrganisationLogo FROM (Trn_Organisation TM1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = TM1.OrganisationTypeId) WHERE TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00016", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00017", "SAVEPOINT gxupdate;INSERT INTO Trn_Organisation(OrganisationId, OrganisationPhone, OrganisationAddressZipCode, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationVATNumber, OrganisationLogo, OrganisationLogo_GXI, OrganisationAddressCountry, OrganisationAddressCity, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId) VALUES(:OrganisationId, :OrganisationPhone, :OrganisationAddressZipCode, :OrganisationName, :OrganisationKvkNumber, :OrganisationEmail, :OrganisationPhoneCode, :OrganisationPhoneNumber, :OrganisationVATNumber, :OrganisationLogo, :OrganisationLogo_GXI, :OrganisationAddressCountry, :OrganisationAddressCity, :OrganisationAddressLine1, :OrganisationAddressLine2, :OrganisationTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00017)
          ,new CursorDef("BC00018", "SAVEPOINT gxupdate;UPDATE Trn_Organisation SET OrganisationPhone=:OrganisationPhone, OrganisationAddressZipCode=:OrganisationAddressZipCode, OrganisationName=:OrganisationName, OrganisationKvkNumber=:OrganisationKvkNumber, OrganisationEmail=:OrganisationEmail, OrganisationPhoneCode=:OrganisationPhoneCode, OrganisationPhoneNumber=:OrganisationPhoneNumber, OrganisationVATNumber=:OrganisationVATNumber, OrganisationAddressCountry=:OrganisationAddressCountry, OrganisationAddressCity=:OrganisationAddressCity, OrganisationAddressLine1=:OrganisationAddressLine1, OrganisationAddressLine2=:OrganisationAddressLine2, OrganisationTypeId=:OrganisationTypeId  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00018)
          ,new CursorDef("BC00019", "SAVEPOINT gxupdate;UPDATE Trn_Organisation SET OrganisationLogo=:OrganisationLogo, OrganisationLogo_GXI=:OrganisationLogo_GXI  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00019)
          ,new CursorDef("BC000110", "SAVEPOINT gxupdate;DELETE FROM Trn_Organisation  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000110)
          ,new CursorDef("BC000111", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000112", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SG_OrganisationSupplierId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000113", "SELECT AuditId FROM Trn_Audit WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000114", "SELECT OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000115", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000115,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000116", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000116,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000117", "SELECT TM1.OrganisationId, TM1.OrganisationPhone, TM1.OrganisationAddressZipCode, TM1.OrganisationName, TM1.OrganisationKvkNumber, TM1.OrganisationEmail, TM1.OrganisationPhoneCode, TM1.OrganisationPhoneNumber, TM1.OrganisationVATNumber, TM1.OrganisationLogo_GXI, TM1.OrganisationAddressCountry, TM1.OrganisationAddressCity, TM1.OrganisationAddressLine1, TM1.OrganisationAddressLine2, T2.OrganisationTypeName, TM1.OrganisationTypeId, TM1.OrganisationLogo FROM (Trn_Organisation TM1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = TM1.OrganisationTypeId) WHERE TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000117,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(10));
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
             ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(10));
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
             ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(10));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((Guid[]) buf[15])[0] = rslt.getGuid(16);
             ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(10));
             return;
    }
 }

}

}
