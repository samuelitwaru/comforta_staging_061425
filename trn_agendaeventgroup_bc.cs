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
   public class trn_agendaeventgroup_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_agendaeventgroup_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendaeventgroup_bc( IGxContext context )
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
         ReadRow1C83( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1C83( ) ;
         standaloneModal( ) ;
         AddRow1C83( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z268AgendaCalendarId = A268AgendaCalendarId;
               Z62ResidentId = A62ResidentId;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C83( ) ;
            }
            else
            {
               CheckExtendedTable1C83( ) ;
               if ( AnyError == 0 )
               {
                  ZM1C83( 5) ;
                  ZM1C83( 6) ;
                  ZM1C83( 7) ;
                  ZM1C83( 8) ;
               }
               CloseExtendedTableCursors1C83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1C83( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z442AgendaEventGroupRSVP = A442AgendaEventGroupRSVP;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z66ResidentInitials = A66ResidentInitials;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z312ResidentCountry = A312ResidentCountry;
            Z313ResidentCity = A313ResidentCity;
            Z314ResidentZipCode = A314ResidentZipCode;
            Z315ResidentAddressLine1 = A315ResidentAddressLine1;
            Z316ResidentAddressLine2 = A316ResidentAddressLine2;
            Z70ResidentPhone = A70ResidentPhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z347ResidentPhoneCode = A347ResidentPhoneCode;
            Z348ResidentPhoneNumber = A348ResidentPhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z97ResidentTypeName = A97ResidentTypeName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
         if ( GX_JID == -4 )
         {
            Z442AgendaEventGroupRSVP = A442AgendaEventGroupRSVP;
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z63ResidentBsnNumber = A63ResidentBsnNumber;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z66ResidentInitials = A66ResidentInitials;
            Z67ResidentEmail = A67ResidentEmail;
            Z68ResidentGender = A68ResidentGender;
            Z312ResidentCountry = A312ResidentCountry;
            Z313ResidentCity = A313ResidentCity;
            Z314ResidentZipCode = A314ResidentZipCode;
            Z315ResidentAddressLine1 = A315ResidentAddressLine1;
            Z316ResidentAddressLine2 = A316ResidentAddressLine2;
            Z70ResidentPhone = A70ResidentPhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z71ResidentGUID = A71ResidentGUID;
            Z347ResidentPhoneCode = A347ResidentPhoneCode;
            Z348ResidentPhoneNumber = A348ResidentPhoneNumber;
            Z96ResidentTypeId = A96ResidentTypeId;
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z97ResidentTypeName = A97ResidentTypeName;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load1C83( )
      {
         /* Using cursor BC001C8 */
         pr_default.execute(6, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = BC001C8_A442AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001C8_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C8_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C8_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C8_A65ResidentLastName[0];
            A66ResidentInitials = BC001C8_A66ResidentInitials[0];
            A67ResidentEmail = BC001C8_A67ResidentEmail[0];
            A68ResidentGender = BC001C8_A68ResidentGender[0];
            A312ResidentCountry = BC001C8_A312ResidentCountry[0];
            A313ResidentCity = BC001C8_A313ResidentCity[0];
            A314ResidentZipCode = BC001C8_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C8_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C8_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C8_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C8_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C8_A71ResidentGUID[0];
            A97ResidentTypeName = BC001C8_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001C8_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC001C8_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C8_A348ResidentPhoneNumber[0];
            A29LocationId = BC001C8_A29LocationId[0];
            A11OrganisationId = BC001C8_A11OrganisationId[0];
            A96ResidentTypeId = BC001C8_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C8_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C8_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C8_n98MedicalIndicationId[0];
            ZM1C83( -4) ;
         }
         pr_default.close(6);
         OnLoadActions1C83( ) ;
      }

      protected void OnLoadActions1C83( )
      {
      }

      protected void CheckExtendedTable1C83( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001C4 */
         pr_default.execute(2, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
         }
         A29LocationId = BC001C4_A29LocationId[0];
         A11OrganisationId = BC001C4_A11OrganisationId[0];
         pr_default.close(2);
         /* Using cursor BC001C5 */
         pr_default.execute(3, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         A72ResidentSalutation = BC001C5_A72ResidentSalutation[0];
         A63ResidentBsnNumber = BC001C5_A63ResidentBsnNumber[0];
         A64ResidentGivenName = BC001C5_A64ResidentGivenName[0];
         A65ResidentLastName = BC001C5_A65ResidentLastName[0];
         A66ResidentInitials = BC001C5_A66ResidentInitials[0];
         A67ResidentEmail = BC001C5_A67ResidentEmail[0];
         A68ResidentGender = BC001C5_A68ResidentGender[0];
         A312ResidentCountry = BC001C5_A312ResidentCountry[0];
         A313ResidentCity = BC001C5_A313ResidentCity[0];
         A314ResidentZipCode = BC001C5_A314ResidentZipCode[0];
         A315ResidentAddressLine1 = BC001C5_A315ResidentAddressLine1[0];
         A316ResidentAddressLine2 = BC001C5_A316ResidentAddressLine2[0];
         A70ResidentPhone = BC001C5_A70ResidentPhone[0];
         A73ResidentBirthDate = BC001C5_A73ResidentBirthDate[0];
         A71ResidentGUID = BC001C5_A71ResidentGUID[0];
         A347ResidentPhoneCode = BC001C5_A347ResidentPhoneCode[0];
         A348ResidentPhoneNumber = BC001C5_A348ResidentPhoneNumber[0];
         A96ResidentTypeId = BC001C5_A96ResidentTypeId[0];
         n96ResidentTypeId = BC001C5_n96ResidentTypeId[0];
         A98MedicalIndicationId = BC001C5_A98MedicalIndicationId[0];
         n98MedicalIndicationId = BC001C5_n98MedicalIndicationId[0];
         pr_default.close(3);
         /* Using cursor BC001C6 */
         pr_default.execute(4, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
               AnyError = 1;
            }
         }
         A97ResidentTypeName = BC001C6_A97ResidentTypeName[0];
         pr_default.close(4);
         /* Using cursor BC001C7 */
         pr_default.execute(5, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
            }
         }
         A99MedicalIndicationName = BC001C7_A99MedicalIndicationName[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1C83( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C83( )
      {
         /* Using cursor BC001C9 */
         pr_default.execute(7, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001C3 */
         pr_default.execute(1, new Object[] {A268AgendaCalendarId, A62ResidentId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C83( 4) ;
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = BC001C3_A442AgendaEventGroupRSVP[0];
            A268AgendaCalendarId = BC001C3_A268AgendaCalendarId[0];
            A62ResidentId = BC001C3_A62ResidentId[0];
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1C83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey1C83( ) ;
            }
            Gx_mode = sMode83;
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey1C83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode83;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C83( ) ;
         if ( RcdFound83 == 0 )
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
         CONFIRM_1C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1C83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001C2 */
            pr_default.execute(0, new Object[] {A268AgendaCalendarId, A62ResidentId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z442AgendaEventGroupRSVP != BC001C2_A442AgendaEventGroupRSVP[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaEventGroup"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C83( )
      {
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C83( 0) ;
            CheckOptimisticConcurrency1C83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C10 */
                     pr_default.execute(8, new Object[] {A442AgendaEventGroupRSVP, A268AgendaCalendarId, A62ResidentId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
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
               Load1C83( ) ;
            }
            EndLevel1C83( ) ;
         }
         CloseExtendedTableCursors1C83( ) ;
      }

      protected void Update1C83( )
      {
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C11 */
                     pr_default.execute(9, new Object[] {A442AgendaEventGroupRSVP, A268AgendaCalendarId, A62ResidentId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaEventGroup"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C83( ) ;
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
            EndLevel1C83( ) ;
         }
         CloseExtendedTableCursors1C83( ) ;
      }

      protected void DeferredUpdate1C83( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1C83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C83( ) ;
            AfterConfirm1C83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001C12 */
                  pr_default.execute(10, new Object[] {A268AgendaCalendarId, A62ResidentId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaEventGroup");
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1C83( ) ;
         Gx_mode = sMode83;
      }

      protected void OnDeleteControls1C83( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001C13 */
            pr_default.execute(11, new Object[] {A268AgendaCalendarId});
            A29LocationId = BC001C13_A29LocationId[0];
            A11OrganisationId = BC001C13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001C14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            A72ResidentSalutation = BC001C14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C14_A65ResidentLastName[0];
            A66ResidentInitials = BC001C14_A66ResidentInitials[0];
            A67ResidentEmail = BC001C14_A67ResidentEmail[0];
            A68ResidentGender = BC001C14_A68ResidentGender[0];
            A312ResidentCountry = BC001C14_A312ResidentCountry[0];
            A313ResidentCity = BC001C14_A313ResidentCity[0];
            A314ResidentZipCode = BC001C14_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C14_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C14_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C14_A71ResidentGUID[0];
            A347ResidentPhoneCode = BC001C14_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C14_A348ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001C14_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C14_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001C15 */
            pr_default.execute(13, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            A97ResidentTypeName = BC001C15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001C16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = BC001C16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel1C83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C83( ) ;
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

      public void ScanKeyStart1C83( )
      {
         /* Using cursor BC001C17 */
         pr_default.execute(15, new Object[] {A268AgendaCalendarId, A62ResidentId});
         RcdFound83 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = BC001C17_A442AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001C17_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C17_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C17_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C17_A65ResidentLastName[0];
            A66ResidentInitials = BC001C17_A66ResidentInitials[0];
            A67ResidentEmail = BC001C17_A67ResidentEmail[0];
            A68ResidentGender = BC001C17_A68ResidentGender[0];
            A312ResidentCountry = BC001C17_A312ResidentCountry[0];
            A313ResidentCity = BC001C17_A313ResidentCity[0];
            A314ResidentZipCode = BC001C17_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C17_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C17_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C17_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C17_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C17_A71ResidentGUID[0];
            A97ResidentTypeName = BC001C17_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001C17_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC001C17_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C17_A348ResidentPhoneNumber[0];
            A268AgendaCalendarId = BC001C17_A268AgendaCalendarId[0];
            A29LocationId = BC001C17_A29LocationId[0];
            A11OrganisationId = BC001C17_A11OrganisationId[0];
            A62ResidentId = BC001C17_A62ResidentId[0];
            A96ResidentTypeId = BC001C17_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C17_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C17_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C17_n98MedicalIndicationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1C83( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound83 = 0;
         ScanKeyLoad1C83( ) ;
      }

      protected void ScanKeyLoad1C83( )
      {
         sMode83 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound83 = 1;
            A442AgendaEventGroupRSVP = BC001C17_A442AgendaEventGroupRSVP[0];
            A72ResidentSalutation = BC001C17_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C17_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C17_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C17_A65ResidentLastName[0];
            A66ResidentInitials = BC001C17_A66ResidentInitials[0];
            A67ResidentEmail = BC001C17_A67ResidentEmail[0];
            A68ResidentGender = BC001C17_A68ResidentGender[0];
            A312ResidentCountry = BC001C17_A312ResidentCountry[0];
            A313ResidentCity = BC001C17_A313ResidentCity[0];
            A314ResidentZipCode = BC001C17_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C17_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C17_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C17_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C17_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C17_A71ResidentGUID[0];
            A97ResidentTypeName = BC001C17_A97ResidentTypeName[0];
            A99MedicalIndicationName = BC001C17_A99MedicalIndicationName[0];
            A347ResidentPhoneCode = BC001C17_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C17_A348ResidentPhoneNumber[0];
            A268AgendaCalendarId = BC001C17_A268AgendaCalendarId[0];
            A29LocationId = BC001C17_A29LocationId[0];
            A11OrganisationId = BC001C17_A11OrganisationId[0];
            A62ResidentId = BC001C17_A62ResidentId[0];
            A96ResidentTypeId = BC001C17_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C17_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C17_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C17_n98MedicalIndicationId[0];
         }
         Gx_mode = sMode83;
      }

      protected void ScanKeyEnd1C83( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1C83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C83( )
      {
      }

      protected void send_integrity_lvl_hashes1C83( )
      {
      }

      protected void AddRow1C83( )
      {
         VarsToRow83( bcTrn_AgendaEventGroup) ;
      }

      protected void ReadRow1C83( )
      {
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
      }

      protected void InitializeNonKey1C83( )
      {
         A442AgendaEventGroupRSVP = false;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A314ResidentZipCode = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A70ResidentPhone = "";
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
         Z442AgendaEventGroupRSVP = false;
      }

      protected void InitAll1C83( )
      {
         A268AgendaCalendarId = Guid.Empty;
         A62ResidentId = Guid.NewGuid( );
         InitializeNonKey1C83( ) ;
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

      public void VarsToRow83( SdtTrn_AgendaEventGroup obj83 )
      {
         obj83.gxTpr_Mode = Gx_mode;
         obj83.gxTpr_Agendaeventgrouprsvp = A442AgendaEventGroupRSVP;
         obj83.gxTpr_Locationid = A29LocationId;
         obj83.gxTpr_Organisationid = A11OrganisationId;
         obj83.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj83.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
         obj83.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj83.gxTpr_Residentlastname = A65ResidentLastName;
         obj83.gxTpr_Residentinitials = A66ResidentInitials;
         obj83.gxTpr_Residentemail = A67ResidentEmail;
         obj83.gxTpr_Residentgender = A68ResidentGender;
         obj83.gxTpr_Residentcountry = A312ResidentCountry;
         obj83.gxTpr_Residentcity = A313ResidentCity;
         obj83.gxTpr_Residentzipcode = A314ResidentZipCode;
         obj83.gxTpr_Residentaddressline1 = A315ResidentAddressLine1;
         obj83.gxTpr_Residentaddressline2 = A316ResidentAddressLine2;
         obj83.gxTpr_Residentphone = A70ResidentPhone;
         obj83.gxTpr_Residentbirthdate = A73ResidentBirthDate;
         obj83.gxTpr_Residentguid = A71ResidentGUID;
         obj83.gxTpr_Residenttypeid = A96ResidentTypeId;
         obj83.gxTpr_Residenttypename = A97ResidentTypeName;
         obj83.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         obj83.gxTpr_Medicalindicationname = A99MedicalIndicationName;
         obj83.gxTpr_Residentphonecode = A347ResidentPhoneCode;
         obj83.gxTpr_Residentphonenumber = A348ResidentPhoneNumber;
         obj83.gxTpr_Agendacalendarid = A268AgendaCalendarId;
         obj83.gxTpr_Residentid = A62ResidentId;
         obj83.gxTpr_Agendacalendarid_Z = Z268AgendaCalendarId;
         obj83.gxTpr_Residentid_Z = Z62ResidentId;
         obj83.gxTpr_Agendaeventgrouprsvp_Z = Z442AgendaEventGroupRSVP;
         obj83.gxTpr_Locationid_Z = Z29LocationId;
         obj83.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj83.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj83.gxTpr_Residentbsnnumber_Z = Z63ResidentBsnNumber;
         obj83.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj83.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj83.gxTpr_Residentinitials_Z = Z66ResidentInitials;
         obj83.gxTpr_Residentemail_Z = Z67ResidentEmail;
         obj83.gxTpr_Residentgender_Z = Z68ResidentGender;
         obj83.gxTpr_Residentcountry_Z = Z312ResidentCountry;
         obj83.gxTpr_Residentcity_Z = Z313ResidentCity;
         obj83.gxTpr_Residentzipcode_Z = Z314ResidentZipCode;
         obj83.gxTpr_Residentaddressline1_Z = Z315ResidentAddressLine1;
         obj83.gxTpr_Residentaddressline2_Z = Z316ResidentAddressLine2;
         obj83.gxTpr_Residentphone_Z = Z70ResidentPhone;
         obj83.gxTpr_Residentbirthdate_Z = Z73ResidentBirthDate;
         obj83.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj83.gxTpr_Residenttypeid_Z = Z96ResidentTypeId;
         obj83.gxTpr_Residenttypename_Z = Z97ResidentTypeName;
         obj83.gxTpr_Medicalindicationid_Z = Z98MedicalIndicationId;
         obj83.gxTpr_Medicalindicationname_Z = Z99MedicalIndicationName;
         obj83.gxTpr_Residentphonecode_Z = Z347ResidentPhoneCode;
         obj83.gxTpr_Residentphonenumber_Z = Z348ResidentPhoneNumber;
         obj83.gxTpr_Residenttypeid_N = (short)(Convert.ToInt16(n96ResidentTypeId));
         obj83.gxTpr_Medicalindicationid_N = (short)(Convert.ToInt16(n98MedicalIndicationId));
         obj83.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow83( SdtTrn_AgendaEventGroup obj83 )
      {
         obj83.gxTpr_Agendacalendarid = A268AgendaCalendarId;
         obj83.gxTpr_Residentid = A62ResidentId;
         return  ;
      }

      public void RowToVars83( SdtTrn_AgendaEventGroup obj83 ,
                               int forceLoad )
      {
         Gx_mode = obj83.gxTpr_Mode;
         A442AgendaEventGroupRSVP = obj83.gxTpr_Agendaeventgrouprsvp;
         A29LocationId = obj83.gxTpr_Locationid;
         A11OrganisationId = obj83.gxTpr_Organisationid;
         A72ResidentSalutation = obj83.gxTpr_Residentsalutation;
         A63ResidentBsnNumber = obj83.gxTpr_Residentbsnnumber;
         A64ResidentGivenName = obj83.gxTpr_Residentgivenname;
         A65ResidentLastName = obj83.gxTpr_Residentlastname;
         A66ResidentInitials = obj83.gxTpr_Residentinitials;
         A67ResidentEmail = obj83.gxTpr_Residentemail;
         A68ResidentGender = obj83.gxTpr_Residentgender;
         A312ResidentCountry = obj83.gxTpr_Residentcountry;
         A313ResidentCity = obj83.gxTpr_Residentcity;
         A314ResidentZipCode = obj83.gxTpr_Residentzipcode;
         A315ResidentAddressLine1 = obj83.gxTpr_Residentaddressline1;
         A316ResidentAddressLine2 = obj83.gxTpr_Residentaddressline2;
         A70ResidentPhone = obj83.gxTpr_Residentphone;
         A73ResidentBirthDate = obj83.gxTpr_Residentbirthdate;
         A71ResidentGUID = obj83.gxTpr_Residentguid;
         A96ResidentTypeId = obj83.gxTpr_Residenttypeid;
         n96ResidentTypeId = false;
         A97ResidentTypeName = obj83.gxTpr_Residenttypename;
         A98MedicalIndicationId = obj83.gxTpr_Medicalindicationid;
         n98MedicalIndicationId = false;
         A99MedicalIndicationName = obj83.gxTpr_Medicalindicationname;
         A347ResidentPhoneCode = obj83.gxTpr_Residentphonecode;
         A348ResidentPhoneNumber = obj83.gxTpr_Residentphonenumber;
         A268AgendaCalendarId = obj83.gxTpr_Agendacalendarid;
         A62ResidentId = obj83.gxTpr_Residentid;
         Z268AgendaCalendarId = obj83.gxTpr_Agendacalendarid_Z;
         Z62ResidentId = obj83.gxTpr_Residentid_Z;
         Z442AgendaEventGroupRSVP = obj83.gxTpr_Agendaeventgrouprsvp_Z;
         Z29LocationId = obj83.gxTpr_Locationid_Z;
         Z11OrganisationId = obj83.gxTpr_Organisationid_Z;
         Z72ResidentSalutation = obj83.gxTpr_Residentsalutation_Z;
         Z63ResidentBsnNumber = obj83.gxTpr_Residentbsnnumber_Z;
         Z64ResidentGivenName = obj83.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj83.gxTpr_Residentlastname_Z;
         Z66ResidentInitials = obj83.gxTpr_Residentinitials_Z;
         Z67ResidentEmail = obj83.gxTpr_Residentemail_Z;
         Z68ResidentGender = obj83.gxTpr_Residentgender_Z;
         Z312ResidentCountry = obj83.gxTpr_Residentcountry_Z;
         Z313ResidentCity = obj83.gxTpr_Residentcity_Z;
         Z314ResidentZipCode = obj83.gxTpr_Residentzipcode_Z;
         Z315ResidentAddressLine1 = obj83.gxTpr_Residentaddressline1_Z;
         Z316ResidentAddressLine2 = obj83.gxTpr_Residentaddressline2_Z;
         Z70ResidentPhone = obj83.gxTpr_Residentphone_Z;
         Z73ResidentBirthDate = obj83.gxTpr_Residentbirthdate_Z;
         Z71ResidentGUID = obj83.gxTpr_Residentguid_Z;
         Z96ResidentTypeId = obj83.gxTpr_Residenttypeid_Z;
         Z97ResidentTypeName = obj83.gxTpr_Residenttypename_Z;
         Z98MedicalIndicationId = obj83.gxTpr_Medicalindicationid_Z;
         Z99MedicalIndicationName = obj83.gxTpr_Medicalindicationname_Z;
         Z347ResidentPhoneCode = obj83.gxTpr_Residentphonecode_Z;
         Z348ResidentPhoneNumber = obj83.gxTpr_Residentphonenumber_Z;
         n96ResidentTypeId = (bool)(Convert.ToBoolean(obj83.gxTpr_Residenttypeid_N));
         n98MedicalIndicationId = (bool)(Convert.ToBoolean(obj83.gxTpr_Medicalindicationid_N));
         Gx_mode = obj83.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A268AgendaCalendarId = (Guid)getParm(obj,0);
         A62ResidentId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1C83( ) ;
         ScanKeyStart1C83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001C13 */
            pr_default.execute(11, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
               AnyError = 1;
            }
            A29LocationId = BC001C13_A29LocationId[0];
            A11OrganisationId = BC001C13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001C14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            A72ResidentSalutation = BC001C14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C14_A65ResidentLastName[0];
            A66ResidentInitials = BC001C14_A66ResidentInitials[0];
            A67ResidentEmail = BC001C14_A67ResidentEmail[0];
            A68ResidentGender = BC001C14_A68ResidentGender[0];
            A312ResidentCountry = BC001C14_A312ResidentCountry[0];
            A313ResidentCity = BC001C14_A313ResidentCity[0];
            A314ResidentZipCode = BC001C14_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C14_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C14_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C14_A71ResidentGUID[0];
            A347ResidentPhoneCode = BC001C14_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C14_A348ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001C14_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C14_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001C15 */
            pr_default.execute(13, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            if ( (pr_default.getStatus(13) == 101) )
            {
               if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
                  AnyError = 1;
               }
            }
            A97ResidentTypeName = BC001C15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001C16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(14) == 101) )
            {
               if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
                  AnyError = 1;
               }
            }
            A99MedicalIndicationName = BC001C16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
         else
         {
            Gx_mode = "UPD";
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
         }
         ZM1C83( -4) ;
         OnLoadActions1C83( ) ;
         AddRow1C83( ) ;
         ScanKeyEnd1C83( ) ;
         if ( RcdFound83 == 0 )
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
         RowToVars83( bcTrn_AgendaEventGroup, 0) ;
         ScanKeyStart1C83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001C13 */
            pr_default.execute(11, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Agenda/Calendar", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AGENDACALENDARID");
               AnyError = 1;
            }
            A29LocationId = BC001C13_A29LocationId[0];
            A11OrganisationId = BC001C13_A11OrganisationId[0];
            pr_default.close(11);
            /* Using cursor BC001C14 */
            pr_default.execute(12, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            A72ResidentSalutation = BC001C14_A72ResidentSalutation[0];
            A63ResidentBsnNumber = BC001C14_A63ResidentBsnNumber[0];
            A64ResidentGivenName = BC001C14_A64ResidentGivenName[0];
            A65ResidentLastName = BC001C14_A65ResidentLastName[0];
            A66ResidentInitials = BC001C14_A66ResidentInitials[0];
            A67ResidentEmail = BC001C14_A67ResidentEmail[0];
            A68ResidentGender = BC001C14_A68ResidentGender[0];
            A312ResidentCountry = BC001C14_A312ResidentCountry[0];
            A313ResidentCity = BC001C14_A313ResidentCity[0];
            A314ResidentZipCode = BC001C14_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = BC001C14_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = BC001C14_A316ResidentAddressLine2[0];
            A70ResidentPhone = BC001C14_A70ResidentPhone[0];
            A73ResidentBirthDate = BC001C14_A73ResidentBirthDate[0];
            A71ResidentGUID = BC001C14_A71ResidentGUID[0];
            A347ResidentPhoneCode = BC001C14_A347ResidentPhoneCode[0];
            A348ResidentPhoneNumber = BC001C14_A348ResidentPhoneNumber[0];
            A96ResidentTypeId = BC001C14_A96ResidentTypeId[0];
            n96ResidentTypeId = BC001C14_n96ResidentTypeId[0];
            A98MedicalIndicationId = BC001C14_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC001C14_n98MedicalIndicationId[0];
            pr_default.close(12);
            /* Using cursor BC001C15 */
            pr_default.execute(13, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            if ( (pr_default.getStatus(13) == 101) )
            {
               if ( ! ( (Guid.Empty==A96ResidentTypeId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Types", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
                  AnyError = 1;
               }
            }
            A97ResidentTypeName = BC001C15_A97ResidentTypeName[0];
            pr_default.close(13);
            /* Using cursor BC001C16 */
            pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(14) == 101) )
            {
               if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medical Indications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
                  AnyError = 1;
               }
            }
            A99MedicalIndicationName = BC001C16_A99MedicalIndicationName[0];
            pr_default.close(14);
         }
         else
         {
            Gx_mode = "UPD";
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z62ResidentId = A62ResidentId;
         }
         ZM1C83( -4) ;
         OnLoadActions1C83( ) ;
         AddRow1C83( ) ;
         ScanKeyEnd1C83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1C83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1C83( ) ;
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
               {
                  A268AgendaCalendarId = Z268AgendaCalendarId;
                  A62ResidentId = Z62ResidentId;
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
                  Update1C83( ) ;
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
                  if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
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
                        Insert1C83( ) ;
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
                        Insert1C83( ) ;
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
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
         SaveImpl( ) ;
         VarsToRow83( bcTrn_AgendaEventGroup) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C83( ) ;
         AfterTrn( ) ;
         VarsToRow83( bcTrn_AgendaEventGroup) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow83( bcTrn_AgendaEventGroup) ;
         }
         else
         {
            SdtTrn_AgendaEventGroup auxBC = new SdtTrn_AgendaEventGroup(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A268AgendaCalendarId, A62ResidentId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AgendaEventGroup);
               auxBC.Save();
               bcTrn_AgendaEventGroup.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
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
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C83( ) ;
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
               VarsToRow83( bcTrn_AgendaEventGroup) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow83( bcTrn_AgendaEventGroup) ;
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
         RowToVars83( bcTrn_AgendaEventGroup, 0) ;
         GetKey1C83( ) ;
         if ( RcdFound83 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
            {
               A268AgendaCalendarId = Z268AgendaCalendarId;
               A62ResidentId = Z62ResidentId;
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
            if ( ( A268AgendaCalendarId != Z268AgendaCalendarId ) || ( A62ResidentId != Z62ResidentId ) )
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
         context.RollbackDataStores("trn_agendaeventgroup_bc",pr_default);
         VarsToRow83( bcTrn_AgendaEventGroup) ;
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
         Gx_mode = bcTrn_AgendaEventGroup.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AgendaEventGroup.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AgendaEventGroup )
         {
            bcTrn_AgendaEventGroup = (SdtTrn_AgendaEventGroup)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AgendaEventGroup.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaEventGroup.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow83( bcTrn_AgendaEventGroup) ;
            }
            else
            {
               RowToVars83( bcTrn_AgendaEventGroup, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AgendaEventGroup.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaEventGroup.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars83( bcTrn_AgendaEventGroup, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AgendaEventGroup Trn_AgendaEventGroup_BC
      {
         get {
            return bcTrn_AgendaEventGroup ;
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
            return "trn_agendaeventgroup_Execute" ;
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
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z268AgendaCalendarId = Guid.Empty;
         A268AgendaCalendarId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z63ResidentBsnNumber = "";
         A63ResidentBsnNumber = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z66ResidentInitials = "";
         A66ResidentInitials = "";
         Z67ResidentEmail = "";
         A67ResidentEmail = "";
         Z68ResidentGender = "";
         A68ResidentGender = "";
         Z312ResidentCountry = "";
         A312ResidentCountry = "";
         Z313ResidentCity = "";
         A313ResidentCity = "";
         Z314ResidentZipCode = "";
         A314ResidentZipCode = "";
         Z315ResidentAddressLine1 = "";
         A315ResidentAddressLine1 = "";
         Z316ResidentAddressLine2 = "";
         A316ResidentAddressLine2 = "";
         Z70ResidentPhone = "";
         A70ResidentPhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         A73ResidentBirthDate = DateTime.MinValue;
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z347ResidentPhoneCode = "";
         A347ResidentPhoneCode = "";
         Z348ResidentPhoneNumber = "";
         A348ResidentPhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         Z97ResidentTypeName = "";
         A97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         A99MedicalIndicationName = "";
         BC001C8_A442AgendaEventGroupRSVP = new bool[] {false} ;
         BC001C8_A72ResidentSalutation = new string[] {""} ;
         BC001C8_A63ResidentBsnNumber = new string[] {""} ;
         BC001C8_A64ResidentGivenName = new string[] {""} ;
         BC001C8_A65ResidentLastName = new string[] {""} ;
         BC001C8_A66ResidentInitials = new string[] {""} ;
         BC001C8_A67ResidentEmail = new string[] {""} ;
         BC001C8_A68ResidentGender = new string[] {""} ;
         BC001C8_A312ResidentCountry = new string[] {""} ;
         BC001C8_A313ResidentCity = new string[] {""} ;
         BC001C8_A314ResidentZipCode = new string[] {""} ;
         BC001C8_A315ResidentAddressLine1 = new string[] {""} ;
         BC001C8_A316ResidentAddressLine2 = new string[] {""} ;
         BC001C8_A70ResidentPhone = new string[] {""} ;
         BC001C8_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001C8_A71ResidentGUID = new string[] {""} ;
         BC001C8_A97ResidentTypeName = new string[] {""} ;
         BC001C8_A99MedicalIndicationName = new string[] {""} ;
         BC001C8_A347ResidentPhoneCode = new string[] {""} ;
         BC001C8_A348ResidentPhoneNumber = new string[] {""} ;
         BC001C8_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001C8_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C8_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001C8_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001C8_n96ResidentTypeId = new bool[] {false} ;
         BC001C8_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001C8_n98MedicalIndicationId = new bool[] {false} ;
         BC001C4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C5_A72ResidentSalutation = new string[] {""} ;
         BC001C5_A63ResidentBsnNumber = new string[] {""} ;
         BC001C5_A64ResidentGivenName = new string[] {""} ;
         BC001C5_A65ResidentLastName = new string[] {""} ;
         BC001C5_A66ResidentInitials = new string[] {""} ;
         BC001C5_A67ResidentEmail = new string[] {""} ;
         BC001C5_A68ResidentGender = new string[] {""} ;
         BC001C5_A312ResidentCountry = new string[] {""} ;
         BC001C5_A313ResidentCity = new string[] {""} ;
         BC001C5_A314ResidentZipCode = new string[] {""} ;
         BC001C5_A315ResidentAddressLine1 = new string[] {""} ;
         BC001C5_A316ResidentAddressLine2 = new string[] {""} ;
         BC001C5_A70ResidentPhone = new string[] {""} ;
         BC001C5_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001C5_A71ResidentGUID = new string[] {""} ;
         BC001C5_A347ResidentPhoneCode = new string[] {""} ;
         BC001C5_A348ResidentPhoneNumber = new string[] {""} ;
         BC001C5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001C5_n96ResidentTypeId = new bool[] {false} ;
         BC001C5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001C5_n98MedicalIndicationId = new bool[] {false} ;
         BC001C6_A97ResidentTypeName = new string[] {""} ;
         BC001C7_A99MedicalIndicationName = new string[] {""} ;
         BC001C9_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001C9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001C3_A442AgendaEventGroupRSVP = new bool[] {false} ;
         BC001C3_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001C3_A62ResidentId = new Guid[] {Guid.Empty} ;
         sMode83 = "";
         BC001C2_A442AgendaEventGroupRSVP = new bool[] {false} ;
         BC001C2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001C2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001C13_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C14_A72ResidentSalutation = new string[] {""} ;
         BC001C14_A63ResidentBsnNumber = new string[] {""} ;
         BC001C14_A64ResidentGivenName = new string[] {""} ;
         BC001C14_A65ResidentLastName = new string[] {""} ;
         BC001C14_A66ResidentInitials = new string[] {""} ;
         BC001C14_A67ResidentEmail = new string[] {""} ;
         BC001C14_A68ResidentGender = new string[] {""} ;
         BC001C14_A312ResidentCountry = new string[] {""} ;
         BC001C14_A313ResidentCity = new string[] {""} ;
         BC001C14_A314ResidentZipCode = new string[] {""} ;
         BC001C14_A315ResidentAddressLine1 = new string[] {""} ;
         BC001C14_A316ResidentAddressLine2 = new string[] {""} ;
         BC001C14_A70ResidentPhone = new string[] {""} ;
         BC001C14_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001C14_A71ResidentGUID = new string[] {""} ;
         BC001C14_A347ResidentPhoneCode = new string[] {""} ;
         BC001C14_A348ResidentPhoneNumber = new string[] {""} ;
         BC001C14_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001C14_n96ResidentTypeId = new bool[] {false} ;
         BC001C14_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001C14_n98MedicalIndicationId = new bool[] {false} ;
         BC001C15_A97ResidentTypeName = new string[] {""} ;
         BC001C16_A99MedicalIndicationName = new string[] {""} ;
         BC001C17_A442AgendaEventGroupRSVP = new bool[] {false} ;
         BC001C17_A72ResidentSalutation = new string[] {""} ;
         BC001C17_A63ResidentBsnNumber = new string[] {""} ;
         BC001C17_A64ResidentGivenName = new string[] {""} ;
         BC001C17_A65ResidentLastName = new string[] {""} ;
         BC001C17_A66ResidentInitials = new string[] {""} ;
         BC001C17_A67ResidentEmail = new string[] {""} ;
         BC001C17_A68ResidentGender = new string[] {""} ;
         BC001C17_A312ResidentCountry = new string[] {""} ;
         BC001C17_A313ResidentCity = new string[] {""} ;
         BC001C17_A314ResidentZipCode = new string[] {""} ;
         BC001C17_A315ResidentAddressLine1 = new string[] {""} ;
         BC001C17_A316ResidentAddressLine2 = new string[] {""} ;
         BC001C17_A70ResidentPhone = new string[] {""} ;
         BC001C17_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         BC001C17_A71ResidentGUID = new string[] {""} ;
         BC001C17_A97ResidentTypeName = new string[] {""} ;
         BC001C17_A99MedicalIndicationName = new string[] {""} ;
         BC001C17_A347ResidentPhoneCode = new string[] {""} ;
         BC001C17_A348ResidentPhoneNumber = new string[] {""} ;
         BC001C17_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC001C17_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001C17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001C17_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001C17_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC001C17_n96ResidentTypeId = new bool[] {false} ;
         BC001C17_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC001C17_n98MedicalIndicationId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendaeventgroup_bc__default(),
            new Object[][] {
                new Object[] {
               BC001C2_A442AgendaEventGroupRSVP, BC001C2_A268AgendaCalendarId, BC001C2_A62ResidentId
               }
               , new Object[] {
               BC001C3_A442AgendaEventGroupRSVP, BC001C3_A268AgendaCalendarId, BC001C3_A62ResidentId
               }
               , new Object[] {
               BC001C4_A29LocationId, BC001C4_A11OrganisationId
               }
               , new Object[] {
               BC001C5_A72ResidentSalutation, BC001C5_A63ResidentBsnNumber, BC001C5_A64ResidentGivenName, BC001C5_A65ResidentLastName, BC001C5_A66ResidentInitials, BC001C5_A67ResidentEmail, BC001C5_A68ResidentGender, BC001C5_A312ResidentCountry, BC001C5_A313ResidentCity, BC001C5_A314ResidentZipCode,
               BC001C5_A315ResidentAddressLine1, BC001C5_A316ResidentAddressLine2, BC001C5_A70ResidentPhone, BC001C5_A73ResidentBirthDate, BC001C5_A71ResidentGUID, BC001C5_A347ResidentPhoneCode, BC001C5_A348ResidentPhoneNumber, BC001C5_A96ResidentTypeId, BC001C5_n96ResidentTypeId, BC001C5_A98MedicalIndicationId,
               BC001C5_n98MedicalIndicationId
               }
               , new Object[] {
               BC001C6_A97ResidentTypeName
               }
               , new Object[] {
               BC001C7_A99MedicalIndicationName
               }
               , new Object[] {
               BC001C8_A442AgendaEventGroupRSVP, BC001C8_A72ResidentSalutation, BC001C8_A63ResidentBsnNumber, BC001C8_A64ResidentGivenName, BC001C8_A65ResidentLastName, BC001C8_A66ResidentInitials, BC001C8_A67ResidentEmail, BC001C8_A68ResidentGender, BC001C8_A312ResidentCountry, BC001C8_A313ResidentCity,
               BC001C8_A314ResidentZipCode, BC001C8_A315ResidentAddressLine1, BC001C8_A316ResidentAddressLine2, BC001C8_A70ResidentPhone, BC001C8_A73ResidentBirthDate, BC001C8_A71ResidentGUID, BC001C8_A97ResidentTypeName, BC001C8_A99MedicalIndicationName, BC001C8_A347ResidentPhoneCode, BC001C8_A348ResidentPhoneNumber,
               BC001C8_A268AgendaCalendarId, BC001C8_A29LocationId, BC001C8_A11OrganisationId, BC001C8_A62ResidentId, BC001C8_A96ResidentTypeId, BC001C8_n96ResidentTypeId, BC001C8_A98MedicalIndicationId, BC001C8_n98MedicalIndicationId
               }
               , new Object[] {
               BC001C9_A268AgendaCalendarId, BC001C9_A62ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001C13_A29LocationId, BC001C13_A11OrganisationId
               }
               , new Object[] {
               BC001C14_A72ResidentSalutation, BC001C14_A63ResidentBsnNumber, BC001C14_A64ResidentGivenName, BC001C14_A65ResidentLastName, BC001C14_A66ResidentInitials, BC001C14_A67ResidentEmail, BC001C14_A68ResidentGender, BC001C14_A312ResidentCountry, BC001C14_A313ResidentCity, BC001C14_A314ResidentZipCode,
               BC001C14_A315ResidentAddressLine1, BC001C14_A316ResidentAddressLine2, BC001C14_A70ResidentPhone, BC001C14_A73ResidentBirthDate, BC001C14_A71ResidentGUID, BC001C14_A347ResidentPhoneCode, BC001C14_A348ResidentPhoneNumber, BC001C14_A96ResidentTypeId, BC001C14_n96ResidentTypeId, BC001C14_A98MedicalIndicationId,
               BC001C14_n98MedicalIndicationId
               }
               , new Object[] {
               BC001C15_A97ResidentTypeName
               }
               , new Object[] {
               BC001C16_A99MedicalIndicationName
               }
               , new Object[] {
               BC001C17_A442AgendaEventGroupRSVP, BC001C17_A72ResidentSalutation, BC001C17_A63ResidentBsnNumber, BC001C17_A64ResidentGivenName, BC001C17_A65ResidentLastName, BC001C17_A66ResidentInitials, BC001C17_A67ResidentEmail, BC001C17_A68ResidentGender, BC001C17_A312ResidentCountry, BC001C17_A313ResidentCity,
               BC001C17_A314ResidentZipCode, BC001C17_A315ResidentAddressLine1, BC001C17_A316ResidentAddressLine2, BC001C17_A70ResidentPhone, BC001C17_A73ResidentBirthDate, BC001C17_A71ResidentGUID, BC001C17_A97ResidentTypeName, BC001C17_A99MedicalIndicationName, BC001C17_A347ResidentPhoneCode, BC001C17_A348ResidentPhoneNumber,
               BC001C17_A268AgendaCalendarId, BC001C17_A29LocationId, BC001C17_A11OrganisationId, BC001C17_A62ResidentId, BC001C17_A96ResidentTypeId, BC001C17_n96ResidentTypeId, BC001C17_A98MedicalIndicationId, BC001C17_n98MedicalIndicationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound83 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string Z66ResidentInitials ;
      private string A66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string A70ResidentPhone ;
      private string sMode83 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool Z442AgendaEventGroupRSVP ;
      private bool A442AgendaEventGroupRSVP ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
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
      private string Z314ResidentZipCode ;
      private string A314ResidentZipCode ;
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
      private string Z97ResidentTypeName ;
      private string A97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string A99MedicalIndicationName ;
      private Guid Z268AgendaCalendarId ;
      private Guid A268AgendaCalendarId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z96ResidentTypeId ;
      private Guid A96ResidentTypeId ;
      private Guid Z98MedicalIndicationId ;
      private Guid A98MedicalIndicationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] BC001C8_A442AgendaEventGroupRSVP ;
      private string[] BC001C8_A72ResidentSalutation ;
      private string[] BC001C8_A63ResidentBsnNumber ;
      private string[] BC001C8_A64ResidentGivenName ;
      private string[] BC001C8_A65ResidentLastName ;
      private string[] BC001C8_A66ResidentInitials ;
      private string[] BC001C8_A67ResidentEmail ;
      private string[] BC001C8_A68ResidentGender ;
      private string[] BC001C8_A312ResidentCountry ;
      private string[] BC001C8_A313ResidentCity ;
      private string[] BC001C8_A314ResidentZipCode ;
      private string[] BC001C8_A315ResidentAddressLine1 ;
      private string[] BC001C8_A316ResidentAddressLine2 ;
      private string[] BC001C8_A70ResidentPhone ;
      private DateTime[] BC001C8_A73ResidentBirthDate ;
      private string[] BC001C8_A71ResidentGUID ;
      private string[] BC001C8_A97ResidentTypeName ;
      private string[] BC001C8_A99MedicalIndicationName ;
      private string[] BC001C8_A347ResidentPhoneCode ;
      private string[] BC001C8_A348ResidentPhoneNumber ;
      private Guid[] BC001C8_A268AgendaCalendarId ;
      private Guid[] BC001C8_A29LocationId ;
      private Guid[] BC001C8_A11OrganisationId ;
      private Guid[] BC001C8_A62ResidentId ;
      private Guid[] BC001C8_A96ResidentTypeId ;
      private bool[] BC001C8_n96ResidentTypeId ;
      private Guid[] BC001C8_A98MedicalIndicationId ;
      private bool[] BC001C8_n98MedicalIndicationId ;
      private Guid[] BC001C4_A29LocationId ;
      private Guid[] BC001C4_A11OrganisationId ;
      private string[] BC001C5_A72ResidentSalutation ;
      private string[] BC001C5_A63ResidentBsnNumber ;
      private string[] BC001C5_A64ResidentGivenName ;
      private string[] BC001C5_A65ResidentLastName ;
      private string[] BC001C5_A66ResidentInitials ;
      private string[] BC001C5_A67ResidentEmail ;
      private string[] BC001C5_A68ResidentGender ;
      private string[] BC001C5_A312ResidentCountry ;
      private string[] BC001C5_A313ResidentCity ;
      private string[] BC001C5_A314ResidentZipCode ;
      private string[] BC001C5_A315ResidentAddressLine1 ;
      private string[] BC001C5_A316ResidentAddressLine2 ;
      private string[] BC001C5_A70ResidentPhone ;
      private DateTime[] BC001C5_A73ResidentBirthDate ;
      private string[] BC001C5_A71ResidentGUID ;
      private string[] BC001C5_A347ResidentPhoneCode ;
      private string[] BC001C5_A348ResidentPhoneNumber ;
      private Guid[] BC001C5_A96ResidentTypeId ;
      private bool[] BC001C5_n96ResidentTypeId ;
      private Guid[] BC001C5_A98MedicalIndicationId ;
      private bool[] BC001C5_n98MedicalIndicationId ;
      private string[] BC001C6_A97ResidentTypeName ;
      private string[] BC001C7_A99MedicalIndicationName ;
      private Guid[] BC001C9_A268AgendaCalendarId ;
      private Guid[] BC001C9_A62ResidentId ;
      private bool[] BC001C3_A442AgendaEventGroupRSVP ;
      private Guid[] BC001C3_A268AgendaCalendarId ;
      private Guid[] BC001C3_A62ResidentId ;
      private bool[] BC001C2_A442AgendaEventGroupRSVP ;
      private Guid[] BC001C2_A268AgendaCalendarId ;
      private Guid[] BC001C2_A62ResidentId ;
      private Guid[] BC001C13_A29LocationId ;
      private Guid[] BC001C13_A11OrganisationId ;
      private string[] BC001C14_A72ResidentSalutation ;
      private string[] BC001C14_A63ResidentBsnNumber ;
      private string[] BC001C14_A64ResidentGivenName ;
      private string[] BC001C14_A65ResidentLastName ;
      private string[] BC001C14_A66ResidentInitials ;
      private string[] BC001C14_A67ResidentEmail ;
      private string[] BC001C14_A68ResidentGender ;
      private string[] BC001C14_A312ResidentCountry ;
      private string[] BC001C14_A313ResidentCity ;
      private string[] BC001C14_A314ResidentZipCode ;
      private string[] BC001C14_A315ResidentAddressLine1 ;
      private string[] BC001C14_A316ResidentAddressLine2 ;
      private string[] BC001C14_A70ResidentPhone ;
      private DateTime[] BC001C14_A73ResidentBirthDate ;
      private string[] BC001C14_A71ResidentGUID ;
      private string[] BC001C14_A347ResidentPhoneCode ;
      private string[] BC001C14_A348ResidentPhoneNumber ;
      private Guid[] BC001C14_A96ResidentTypeId ;
      private bool[] BC001C14_n96ResidentTypeId ;
      private Guid[] BC001C14_A98MedicalIndicationId ;
      private bool[] BC001C14_n98MedicalIndicationId ;
      private string[] BC001C15_A97ResidentTypeName ;
      private string[] BC001C16_A99MedicalIndicationName ;
      private bool[] BC001C17_A442AgendaEventGroupRSVP ;
      private string[] BC001C17_A72ResidentSalutation ;
      private string[] BC001C17_A63ResidentBsnNumber ;
      private string[] BC001C17_A64ResidentGivenName ;
      private string[] BC001C17_A65ResidentLastName ;
      private string[] BC001C17_A66ResidentInitials ;
      private string[] BC001C17_A67ResidentEmail ;
      private string[] BC001C17_A68ResidentGender ;
      private string[] BC001C17_A312ResidentCountry ;
      private string[] BC001C17_A313ResidentCity ;
      private string[] BC001C17_A314ResidentZipCode ;
      private string[] BC001C17_A315ResidentAddressLine1 ;
      private string[] BC001C17_A316ResidentAddressLine2 ;
      private string[] BC001C17_A70ResidentPhone ;
      private DateTime[] BC001C17_A73ResidentBirthDate ;
      private string[] BC001C17_A71ResidentGUID ;
      private string[] BC001C17_A97ResidentTypeName ;
      private string[] BC001C17_A99MedicalIndicationName ;
      private string[] BC001C17_A347ResidentPhoneCode ;
      private string[] BC001C17_A348ResidentPhoneNumber ;
      private Guid[] BC001C17_A268AgendaCalendarId ;
      private Guid[] BC001C17_A29LocationId ;
      private Guid[] BC001C17_A11OrganisationId ;
      private Guid[] BC001C17_A62ResidentId ;
      private Guid[] BC001C17_A96ResidentTypeId ;
      private bool[] BC001C17_n96ResidentTypeId ;
      private Guid[] BC001C17_A98MedicalIndicationId ;
      private bool[] BC001C17_n98MedicalIndicationId ;
      private SdtTrn_AgendaEventGroup bcTrn_AgendaEventGroup ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendaeventgroup_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_agendaeventgroup_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_agendaeventgroup_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001C2;
       prmBC001C2 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C3;
       prmBC001C3 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C4;
       prmBC001C4 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C5;
       prmBC001C5 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C6;
       prmBC001C6 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001C7;
       prmBC001C7 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001C8;
       prmBC001C8 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C9;
       prmBC001C9 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C10;
       prmBC001C10 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C11;
       prmBC001C11 = new Object[] {
       new ParDef("AgendaEventGroupRSVP",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C12;
       prmBC001C12 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C13;
       prmBC001C13 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C14;
       prmBC001C14 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001C15;
       prmBC001C15 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001C16;
       prmBC001C16 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001C17;
       prmBC001C17 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001C2", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId  FOR UPDATE OF Trn_AgendaEventGroup",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C3", "SELECT AgendaEventGroupRSVP, AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C4", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C5", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C6", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C7", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C8", "SELECT TM1.AgendaEventGroupRSVP, T3.ResidentSalutation, T3.ResidentBsnNumber, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentInitials, T3.ResidentEmail, T3.ResidentGender, T3.ResidentCountry, T3.ResidentCity, T3.ResidentZipCode, T3.ResidentAddressLine1, T3.ResidentAddressLine2, T3.ResidentPhone, T3.ResidentBirthDate, T3.ResidentGUID, T4.ResidentTypeName, T5.MedicalIndicationName, T3.ResidentPhoneCode, T3.ResidentPhoneNumber, TM1.AgendaCalendarId, T2.LocationId, T2.OrganisationId, TM1.ResidentId, T3.ResidentTypeId, T3.MedicalIndicationId FROM ((((Trn_AgendaEventGroup TM1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = TM1.AgendaCalendarId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = T2.OrganisationId) LEFT JOIN Trn_ResidentType T4 ON T4.ResidentTypeId = T3.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T5 ON T5.MedicalIndicationId = T3.MedicalIndicationId) WHERE TM1.AgendaCalendarId = :AgendaCalendarId and TM1.ResidentId = :ResidentId ORDER BY TM1.AgendaCalendarId, TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C9", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C10", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaEventGroup(AgendaEventGroupRSVP, AgendaCalendarId, ResidentId) VALUES(:AgendaEventGroupRSVP, :AgendaCalendarId, :ResidentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001C10)
          ,new CursorDef("BC001C11", "SAVEPOINT gxupdate;UPDATE Trn_AgendaEventGroup SET AgendaEventGroupRSVP=:AgendaEventGroupRSVP  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C11)
          ,new CursorDef("BC001C12", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaEventGroup  WHERE AgendaCalendarId = :AgendaCalendarId AND ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C12)
          ,new CursorDef("BC001C13", "SELECT LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C14", "SELECT ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentInitials, ResidentEmail, ResidentGender, ResidentCountry, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentPhone, ResidentBirthDate, ResidentGUID, ResidentPhoneCode, ResidentPhoneNumber, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C15", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C16", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001C17", "SELECT TM1.AgendaEventGroupRSVP, T3.ResidentSalutation, T3.ResidentBsnNumber, T3.ResidentGivenName, T3.ResidentLastName, T3.ResidentInitials, T3.ResidentEmail, T3.ResidentGender, T3.ResidentCountry, T3.ResidentCity, T3.ResidentZipCode, T3.ResidentAddressLine1, T3.ResidentAddressLine2, T3.ResidentPhone, T3.ResidentBirthDate, T3.ResidentGUID, T4.ResidentTypeName, T5.MedicalIndicationName, T3.ResidentPhoneCode, T3.ResidentPhoneNumber, TM1.AgendaCalendarId, T2.LocationId, T2.OrganisationId, TM1.ResidentId, T3.ResidentTypeId, T3.MedicalIndicationId FROM ((((Trn_AgendaEventGroup TM1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = TM1.AgendaCalendarId) LEFT JOIN Trn_Resident T3 ON T3.ResidentId = TM1.ResidentId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = T2.OrganisationId) LEFT JOIN Trn_ResidentType T4 ON T4.ResidentTypeId = T3.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T5 ON T5.MedicalIndicationId = T3.MedicalIndicationId) WHERE TM1.AgendaCalendarId = :AgendaCalendarId and TM1.ResidentId = :ResidentId ORDER BY TM1.AgendaCalendarId, TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C17,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 6 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getString(14, 20);
             ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((bool[]) buf[27])[0] = rslt.wasNull(26);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getString(13, 20);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((Guid[]) buf[17])[0] = rslt.getGuid(18);
             ((bool[]) buf[18])[0] = rslt.wasNull(18);
             ((Guid[]) buf[19])[0] = rslt.getGuid(19);
             ((bool[]) buf[20])[0] = rslt.wasNull(19);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 15 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getString(14, 20);
             ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((string[]) buf[16])[0] = rslt.getVarchar(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((string[]) buf[18])[0] = rslt.getVarchar(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             ((Guid[]) buf[26])[0] = rslt.getGuid(26);
             ((bool[]) buf[27])[0] = rslt.wasNull(26);
             return;
    }
 }

}

}
