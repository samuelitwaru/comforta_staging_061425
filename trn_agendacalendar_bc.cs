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
   public class trn_agendacalendar_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_agendacalendar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendacalendar_bc( IGxContext context )
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
         ReadRow0Y50( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Y50( ) ;
         standaloneModal( ) ;
         AddRow0Y50( ) ;
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

      protected void CONFIRM_0Y0( )
      {
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Y50( ) ;
            }
            else
            {
               CheckExtendedTable0Y50( ) ;
               if ( AnyError == 0 )
               {
                  ZM0Y50( 9) ;
               }
               CloseExtendedTableCursors0Y50( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0Y50( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z269AgendaCalendarTitle = A269AgendaCalendarTitle;
            Z270AgendaCalendarStartDate = A270AgendaCalendarStartDate;
            Z271AgendaCalendarEndDate = A271AgendaCalendarEndDate;
            Z441AgendaCalendarType = A441AgendaCalendarType;
            Z272AgendaCalendarAllDay = A272AgendaCalendarAllDay;
            Z437AgendaCalendarRecurring = A437AgendaCalendarRecurring;
            Z438AgendaCalendarRecurringType = A438AgendaCalendarRecurringType;
            Z439AgendaCalendarAddRSVP = A439AgendaCalendarAddRSVP;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z268AgendaCalendarId = A268AgendaCalendarId;
            Z269AgendaCalendarTitle = A269AgendaCalendarTitle;
            Z270AgendaCalendarStartDate = A270AgendaCalendarStartDate;
            Z271AgendaCalendarEndDate = A271AgendaCalendarEndDate;
            Z441AgendaCalendarType = A441AgendaCalendarType;
            Z272AgendaCalendarAllDay = A272AgendaCalendarAllDay;
            Z437AgendaCalendarRecurring = A437AgendaCalendarRecurring;
            Z438AgendaCalendarRecurringType = A438AgendaCalendarRecurringType;
            Z439AgendaCalendarAddRSVP = A439AgendaCalendarAddRSVP;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A268AgendaCalendarId) )
         {
            A268AgendaCalendarId = Guid.NewGuid( );
         }
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         GXt_guid1 = A11OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A11OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Y50( )
      {
         /* Using cursor BC000Y5 */
         pr_default.execute(3, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound50 = 1;
            A269AgendaCalendarTitle = BC000Y5_A269AgendaCalendarTitle[0];
            A270AgendaCalendarStartDate = BC000Y5_A270AgendaCalendarStartDate[0];
            A271AgendaCalendarEndDate = BC000Y5_A271AgendaCalendarEndDate[0];
            A441AgendaCalendarType = BC000Y5_A441AgendaCalendarType[0];
            A272AgendaCalendarAllDay = BC000Y5_A272AgendaCalendarAllDay[0];
            A437AgendaCalendarRecurring = BC000Y5_A437AgendaCalendarRecurring[0];
            A438AgendaCalendarRecurringType = BC000Y5_A438AgendaCalendarRecurringType[0];
            A439AgendaCalendarAddRSVP = BC000Y5_A439AgendaCalendarAddRSVP[0];
            A29LocationId = BC000Y5_A29LocationId[0];
            A11OrganisationId = BC000Y5_A11OrganisationId[0];
            ZM0Y50( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0Y50( ) ;
      }

      protected void OnLoadActions0Y50( )
      {
      }

      protected void CheckExtendedTable0Y50( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000Y4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A441AgendaCalendarType, "Event") == 0 ) || ( StringUtil.StrCmp(A441AgendaCalendarType, "Activity") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Agenda Calendar Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0Y50( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Y50( )
      {
         /* Using cursor BC000Y6 */
         pr_default.execute(4, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Y3 */
         pr_default.execute(1, new Object[] {A268AgendaCalendarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y50( 8) ;
            RcdFound50 = 1;
            A268AgendaCalendarId = BC000Y3_A268AgendaCalendarId[0];
            A269AgendaCalendarTitle = BC000Y3_A269AgendaCalendarTitle[0];
            A270AgendaCalendarStartDate = BC000Y3_A270AgendaCalendarStartDate[0];
            A271AgendaCalendarEndDate = BC000Y3_A271AgendaCalendarEndDate[0];
            A441AgendaCalendarType = BC000Y3_A441AgendaCalendarType[0];
            A272AgendaCalendarAllDay = BC000Y3_A272AgendaCalendarAllDay[0];
            A437AgendaCalendarRecurring = BC000Y3_A437AgendaCalendarRecurring[0];
            A438AgendaCalendarRecurringType = BC000Y3_A438AgendaCalendarRecurringType[0];
            A439AgendaCalendarAddRSVP = BC000Y3_A439AgendaCalendarAddRSVP[0];
            A29LocationId = BC000Y3_A29LocationId[0];
            A11OrganisationId = BC000Y3_A11OrganisationId[0];
            Z268AgendaCalendarId = A268AgendaCalendarId;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Y50( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey0Y50( ) ;
            }
            Gx_mode = sMode50;
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey0Y50( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode50;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y50( ) ;
         if ( RcdFound50 == 0 )
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
         CONFIRM_0Y0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Y50( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Y2 */
            pr_default.execute(0, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z269AgendaCalendarTitle, BC000Y2_A269AgendaCalendarTitle[0]) != 0 ) || ( Z270AgendaCalendarStartDate != BC000Y2_A270AgendaCalendarStartDate[0] ) || ( Z271AgendaCalendarEndDate != BC000Y2_A271AgendaCalendarEndDate[0] ) || ( StringUtil.StrCmp(Z441AgendaCalendarType, BC000Y2_A441AgendaCalendarType[0]) != 0 ) || ( Z272AgendaCalendarAllDay != BC000Y2_A272AgendaCalendarAllDay[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z437AgendaCalendarRecurring != BC000Y2_A437AgendaCalendarRecurring[0] ) || ( StringUtil.StrCmp(Z438AgendaCalendarRecurringType, BC000Y2_A438AgendaCalendarRecurringType[0]) != 0 ) || ( Z439AgendaCalendarAddRSVP != BC000Y2_A439AgendaCalendarAddRSVP[0] ) || ( Z29LocationId != BC000Y2_A29LocationId[0] ) || ( Z11OrganisationId != BC000Y2_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaCalendar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y50( )
      {
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y50( 0) ;
            CheckOptimisticConcurrency0Y50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y7 */
                     pr_default.execute(5, new Object[] {A268AgendaCalendarId, A269AgendaCalendarTitle, A270AgendaCalendarStartDate, A271AgendaCalendarEndDate, A441AgendaCalendarType, A272AgendaCalendarAllDay, A437AgendaCalendarRecurring, A438AgendaCalendarRecurringType, A439AgendaCalendarAddRSVP, A29LocationId, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
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
               Load0Y50( ) ;
            }
            EndLevel0Y50( ) ;
         }
         CloseExtendedTableCursors0Y50( ) ;
      }

      protected void Update0Y50( )
      {
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y8 */
                     pr_default.execute(6, new Object[] {A269AgendaCalendarTitle, A270AgendaCalendarStartDate, A271AgendaCalendarEndDate, A441AgendaCalendarType, A272AgendaCalendarAllDay, A437AgendaCalendarRecurring, A438AgendaCalendarRecurringType, A439AgendaCalendarAddRSVP, A29LocationId, A11OrganisationId, A268AgendaCalendarId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y50( ) ;
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
            EndLevel0Y50( ) ;
         }
         CloseExtendedTableCursors0Y50( ) ;
      }

      protected void DeferredUpdate0Y50( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Y50( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y50( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y50( ) ;
            AfterConfirm0Y50( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y50( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Y9 */
                  pr_default.execute(7, new Object[] {A268AgendaCalendarId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Y50( ) ;
         Gx_mode = sMode50;
      }

      protected void OnDeleteControls0Y50( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Y10 */
            pr_default.execute(8, new Object[] {A268AgendaCalendarId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda Event Residents", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel0Y50( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y50( ) ;
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

      public void ScanKeyStart0Y50( )
      {
         /* Using cursor BC000Y11 */
         pr_default.execute(9, new Object[] {A268AgendaCalendarId});
         RcdFound50 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound50 = 1;
            A268AgendaCalendarId = BC000Y11_A268AgendaCalendarId[0];
            A269AgendaCalendarTitle = BC000Y11_A269AgendaCalendarTitle[0];
            A270AgendaCalendarStartDate = BC000Y11_A270AgendaCalendarStartDate[0];
            A271AgendaCalendarEndDate = BC000Y11_A271AgendaCalendarEndDate[0];
            A441AgendaCalendarType = BC000Y11_A441AgendaCalendarType[0];
            A272AgendaCalendarAllDay = BC000Y11_A272AgendaCalendarAllDay[0];
            A437AgendaCalendarRecurring = BC000Y11_A437AgendaCalendarRecurring[0];
            A438AgendaCalendarRecurringType = BC000Y11_A438AgendaCalendarRecurringType[0];
            A439AgendaCalendarAddRSVP = BC000Y11_A439AgendaCalendarAddRSVP[0];
            A29LocationId = BC000Y11_A29LocationId[0];
            A11OrganisationId = BC000Y11_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Y50( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound50 = 0;
         ScanKeyLoad0Y50( ) ;
      }

      protected void ScanKeyLoad0Y50( )
      {
         sMode50 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound50 = 1;
            A268AgendaCalendarId = BC000Y11_A268AgendaCalendarId[0];
            A269AgendaCalendarTitle = BC000Y11_A269AgendaCalendarTitle[0];
            A270AgendaCalendarStartDate = BC000Y11_A270AgendaCalendarStartDate[0];
            A271AgendaCalendarEndDate = BC000Y11_A271AgendaCalendarEndDate[0];
            A441AgendaCalendarType = BC000Y11_A441AgendaCalendarType[0];
            A272AgendaCalendarAllDay = BC000Y11_A272AgendaCalendarAllDay[0];
            A437AgendaCalendarRecurring = BC000Y11_A437AgendaCalendarRecurring[0];
            A438AgendaCalendarRecurringType = BC000Y11_A438AgendaCalendarRecurringType[0];
            A439AgendaCalendarAddRSVP = BC000Y11_A439AgendaCalendarAddRSVP[0];
            A29LocationId = BC000Y11_A29LocationId[0];
            A11OrganisationId = BC000Y11_A11OrganisationId[0];
         }
         Gx_mode = sMode50;
      }

      protected void ScanKeyEnd0Y50( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0Y50( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y50( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y50( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y50( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y50( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y50( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y50( )
      {
      }

      protected void send_integrity_lvl_hashes0Y50( )
      {
      }

      protected void AddRow0Y50( )
      {
         VarsToRow50( bcTrn_AgendaCalendar) ;
      }

      protected void ReadRow0Y50( )
      {
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
      }

      protected void InitializeNonKey0Y50( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A269AgendaCalendarTitle = "";
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A441AgendaCalendarType = "";
         A272AgendaCalendarAllDay = false;
         A437AgendaCalendarRecurring = false;
         A438AgendaCalendarRecurringType = "";
         A439AgendaCalendarAddRSVP = false;
         Z269AgendaCalendarTitle = "";
         Z270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z441AgendaCalendarType = "";
         Z272AgendaCalendarAllDay = false;
         Z437AgendaCalendarRecurring = false;
         Z438AgendaCalendarRecurringType = "";
         Z439AgendaCalendarAddRSVP = false;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0Y50( )
      {
         A268AgendaCalendarId = Guid.NewGuid( );
         InitializeNonKey0Y50( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         A11OrganisationId = i11OrganisationId;
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

      public void VarsToRow50( SdtTrn_AgendaCalendar obj50 )
      {
         obj50.gxTpr_Mode = Gx_mode;
         obj50.gxTpr_Locationid = A29LocationId;
         obj50.gxTpr_Organisationid = A11OrganisationId;
         obj50.gxTpr_Agendacalendartitle = A269AgendaCalendarTitle;
         obj50.gxTpr_Agendacalendarstartdate = A270AgendaCalendarStartDate;
         obj50.gxTpr_Agendacalendarenddate = A271AgendaCalendarEndDate;
         obj50.gxTpr_Agendacalendartype = A441AgendaCalendarType;
         obj50.gxTpr_Agendacalendarallday = A272AgendaCalendarAllDay;
         obj50.gxTpr_Agendacalendarrecurring = A437AgendaCalendarRecurring;
         obj50.gxTpr_Agendacalendarrecurringtype = A438AgendaCalendarRecurringType;
         obj50.gxTpr_Agendacalendaraddrsvp = A439AgendaCalendarAddRSVP;
         obj50.gxTpr_Agendacalendarid = A268AgendaCalendarId;
         obj50.gxTpr_Agendacalendarid_Z = Z268AgendaCalendarId;
         obj50.gxTpr_Locationid_Z = Z29LocationId;
         obj50.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj50.gxTpr_Agendacalendartitle_Z = Z269AgendaCalendarTitle;
         obj50.gxTpr_Agendacalendarstartdate_Z = Z270AgendaCalendarStartDate;
         obj50.gxTpr_Agendacalendarenddate_Z = Z271AgendaCalendarEndDate;
         obj50.gxTpr_Agendacalendartype_Z = Z441AgendaCalendarType;
         obj50.gxTpr_Agendacalendarallday_Z = Z272AgendaCalendarAllDay;
         obj50.gxTpr_Agendacalendarrecurring_Z = Z437AgendaCalendarRecurring;
         obj50.gxTpr_Agendacalendarrecurringtype_Z = Z438AgendaCalendarRecurringType;
         obj50.gxTpr_Agendacalendaraddrsvp_Z = Z439AgendaCalendarAddRSVP;
         obj50.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow50( SdtTrn_AgendaCalendar obj50 )
      {
         obj50.gxTpr_Agendacalendarid = A268AgendaCalendarId;
         return  ;
      }

      public void RowToVars50( SdtTrn_AgendaCalendar obj50 ,
                               int forceLoad )
      {
         Gx_mode = obj50.gxTpr_Mode;
         A29LocationId = obj50.gxTpr_Locationid;
         A11OrganisationId = obj50.gxTpr_Organisationid;
         A269AgendaCalendarTitle = obj50.gxTpr_Agendacalendartitle;
         A270AgendaCalendarStartDate = obj50.gxTpr_Agendacalendarstartdate;
         A271AgendaCalendarEndDate = obj50.gxTpr_Agendacalendarenddate;
         A441AgendaCalendarType = obj50.gxTpr_Agendacalendartype;
         A272AgendaCalendarAllDay = obj50.gxTpr_Agendacalendarallday;
         A437AgendaCalendarRecurring = obj50.gxTpr_Agendacalendarrecurring;
         A438AgendaCalendarRecurringType = obj50.gxTpr_Agendacalendarrecurringtype;
         A439AgendaCalendarAddRSVP = obj50.gxTpr_Agendacalendaraddrsvp;
         A268AgendaCalendarId = obj50.gxTpr_Agendacalendarid;
         Z268AgendaCalendarId = obj50.gxTpr_Agendacalendarid_Z;
         Z29LocationId = obj50.gxTpr_Locationid_Z;
         Z11OrganisationId = obj50.gxTpr_Organisationid_Z;
         Z269AgendaCalendarTitle = obj50.gxTpr_Agendacalendartitle_Z;
         Z270AgendaCalendarStartDate = obj50.gxTpr_Agendacalendarstartdate_Z;
         Z271AgendaCalendarEndDate = obj50.gxTpr_Agendacalendarenddate_Z;
         Z441AgendaCalendarType = obj50.gxTpr_Agendacalendartype_Z;
         Z272AgendaCalendarAllDay = obj50.gxTpr_Agendacalendarallday_Z;
         Z437AgendaCalendarRecurring = obj50.gxTpr_Agendacalendarrecurring_Z;
         Z438AgendaCalendarRecurringType = obj50.gxTpr_Agendacalendarrecurringtype_Z;
         Z439AgendaCalendarAddRSVP = obj50.gxTpr_Agendacalendaraddrsvp_Z;
         Gx_mode = obj50.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A268AgendaCalendarId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Y50( ) ;
         ScanKeyStart0Y50( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z268AgendaCalendarId = A268AgendaCalendarId;
         }
         ZM0Y50( -8) ;
         OnLoadActions0Y50( ) ;
         AddRow0Y50( ) ;
         ScanKeyEnd0Y50( ) ;
         if ( RcdFound50 == 0 )
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
         RowToVars50( bcTrn_AgendaCalendar, 0) ;
         ScanKeyStart0Y50( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z268AgendaCalendarId = A268AgendaCalendarId;
         }
         ZM0Y50( -8) ;
         OnLoadActions0Y50( ) ;
         AddRow0Y50( ) ;
         ScanKeyEnd0Y50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Y50( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Y50( ) ;
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( A268AgendaCalendarId != Z268AgendaCalendarId )
               {
                  A268AgendaCalendarId = Z268AgendaCalendarId;
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
                  Update0Y50( ) ;
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
                  if ( A268AgendaCalendarId != Z268AgendaCalendarId )
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
                        Insert0Y50( ) ;
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
                        Insert0Y50( ) ;
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
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
         SaveImpl( ) ;
         VarsToRow50( bcTrn_AgendaCalendar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Y50( ) ;
         AfterTrn( ) ;
         VarsToRow50( bcTrn_AgendaCalendar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow50( bcTrn_AgendaCalendar) ;
         }
         else
         {
            SdtTrn_AgendaCalendar auxBC = new SdtTrn_AgendaCalendar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A268AgendaCalendarId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AgendaCalendar);
               auxBC.Save();
               bcTrn_AgendaCalendar.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
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
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Y50( ) ;
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
               VarsToRow50( bcTrn_AgendaCalendar) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow50( bcTrn_AgendaCalendar) ;
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
         RowToVars50( bcTrn_AgendaCalendar, 0) ;
         GetKey0Y50( ) ;
         if ( RcdFound50 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A268AgendaCalendarId != Z268AgendaCalendarId )
            {
               A268AgendaCalendarId = Z268AgendaCalendarId;
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
            if ( A268AgendaCalendarId != Z268AgendaCalendarId )
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
         context.RollbackDataStores("trn_agendacalendar_bc",pr_default);
         VarsToRow50( bcTrn_AgendaCalendar) ;
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
         Gx_mode = bcTrn_AgendaCalendar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AgendaCalendar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AgendaCalendar )
         {
            bcTrn_AgendaCalendar = (SdtTrn_AgendaCalendar)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AgendaCalendar.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaCalendar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow50( bcTrn_AgendaCalendar) ;
            }
            else
            {
               RowToVars50( bcTrn_AgendaCalendar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AgendaCalendar.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AgendaCalendar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars50( bcTrn_AgendaCalendar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AgendaCalendar Trn_AgendaCalendar_BC
      {
         get {
            return bcTrn_AgendaCalendar ;
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
            return "trn_agendacalendar_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z268AgendaCalendarId = Guid.Empty;
         A268AgendaCalendarId = Guid.Empty;
         Z269AgendaCalendarTitle = "";
         A269AgendaCalendarTitle = "";
         Z270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z441AgendaCalendarType = "";
         A441AgendaCalendarType = "";
         Z438AgendaCalendarRecurringType = "";
         A438AgendaCalendarRecurringType = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC000Y5_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y5_A269AgendaCalendarTitle = new string[] {""} ;
         BC000Y5_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y5_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y5_A441AgendaCalendarType = new string[] {""} ;
         BC000Y5_A272AgendaCalendarAllDay = new bool[] {false} ;
         BC000Y5_A437AgendaCalendarRecurring = new bool[] {false} ;
         BC000Y5_A438AgendaCalendarRecurringType = new string[] {""} ;
         BC000Y5_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         BC000Y5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Y5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Y4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Y6_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y3_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y3_A269AgendaCalendarTitle = new string[] {""} ;
         BC000Y3_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_A441AgendaCalendarType = new string[] {""} ;
         BC000Y3_A272AgendaCalendarAllDay = new bool[] {false} ;
         BC000Y3_A437AgendaCalendarRecurring = new bool[] {false} ;
         BC000Y3_A438AgendaCalendarRecurringType = new string[] {""} ;
         BC000Y3_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         BC000Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Y3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode50 = "";
         BC000Y2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y2_A269AgendaCalendarTitle = new string[] {""} ;
         BC000Y2_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_A441AgendaCalendarType = new string[] {""} ;
         BC000Y2_A272AgendaCalendarAllDay = new bool[] {false} ;
         BC000Y2_A437AgendaCalendarRecurring = new bool[] {false} ;
         BC000Y2_A438AgendaCalendarRecurringType = new string[] {""} ;
         BC000Y2_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         BC000Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Y10_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y10_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000Y11_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000Y11_A269AgendaCalendarTitle = new string[] {""} ;
         BC000Y11_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y11_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000Y11_A441AgendaCalendarType = new string[] {""} ;
         BC000Y11_A272AgendaCalendarAllDay = new bool[] {false} ;
         BC000Y11_A437AgendaCalendarRecurring = new bool[] {false} ;
         BC000Y11_A438AgendaCalendarRecurringType = new string[] {""} ;
         BC000Y11_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         BC000Y11_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Y11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         i29LocationId = Guid.Empty;
         i11OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Y2_A268AgendaCalendarId, BC000Y2_A269AgendaCalendarTitle, BC000Y2_A270AgendaCalendarStartDate, BC000Y2_A271AgendaCalendarEndDate, BC000Y2_A441AgendaCalendarType, BC000Y2_A272AgendaCalendarAllDay, BC000Y2_A437AgendaCalendarRecurring, BC000Y2_A438AgendaCalendarRecurringType, BC000Y2_A439AgendaCalendarAddRSVP, BC000Y2_A29LocationId,
               BC000Y2_A11OrganisationId
               }
               , new Object[] {
               BC000Y3_A268AgendaCalendarId, BC000Y3_A269AgendaCalendarTitle, BC000Y3_A270AgendaCalendarStartDate, BC000Y3_A271AgendaCalendarEndDate, BC000Y3_A441AgendaCalendarType, BC000Y3_A272AgendaCalendarAllDay, BC000Y3_A437AgendaCalendarRecurring, BC000Y3_A438AgendaCalendarRecurringType, BC000Y3_A439AgendaCalendarAddRSVP, BC000Y3_A29LocationId,
               BC000Y3_A11OrganisationId
               }
               , new Object[] {
               BC000Y4_A29LocationId
               }
               , new Object[] {
               BC000Y5_A268AgendaCalendarId, BC000Y5_A269AgendaCalendarTitle, BC000Y5_A270AgendaCalendarStartDate, BC000Y5_A271AgendaCalendarEndDate, BC000Y5_A441AgendaCalendarType, BC000Y5_A272AgendaCalendarAllDay, BC000Y5_A437AgendaCalendarRecurring, BC000Y5_A438AgendaCalendarRecurringType, BC000Y5_A439AgendaCalendarAddRSVP, BC000Y5_A29LocationId,
               BC000Y5_A11OrganisationId
               }
               , new Object[] {
               BC000Y6_A268AgendaCalendarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y10_A268AgendaCalendarId, BC000Y10_A62ResidentId
               }
               , new Object[] {
               BC000Y11_A268AgendaCalendarId, BC000Y11_A269AgendaCalendarTitle, BC000Y11_A270AgendaCalendarStartDate, BC000Y11_A271AgendaCalendarEndDate, BC000Y11_A441AgendaCalendarType, BC000Y11_A272AgendaCalendarAllDay, BC000Y11_A437AgendaCalendarRecurring, BC000Y11_A438AgendaCalendarRecurringType, BC000Y11_A439AgendaCalendarAddRSVP, BC000Y11_A29LocationId,
               BC000Y11_A11OrganisationId
               }
            }
         );
         Z268AgendaCalendarId = Guid.NewGuid( );
         A268AgendaCalendarId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound50 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode50 ;
      private DateTime Z270AgendaCalendarStartDate ;
      private DateTime A270AgendaCalendarStartDate ;
      private DateTime Z271AgendaCalendarEndDate ;
      private DateTime A271AgendaCalendarEndDate ;
      private bool Z272AgendaCalendarAllDay ;
      private bool A272AgendaCalendarAllDay ;
      private bool Z437AgendaCalendarRecurring ;
      private bool A437AgendaCalendarRecurring ;
      private bool Z439AgendaCalendarAddRSVP ;
      private bool A439AgendaCalendarAddRSVP ;
      private bool Gx_longc ;
      private string Z269AgendaCalendarTitle ;
      private string A269AgendaCalendarTitle ;
      private string Z441AgendaCalendarType ;
      private string A441AgendaCalendarType ;
      private string Z438AgendaCalendarRecurringType ;
      private string A438AgendaCalendarRecurringType ;
      private Guid Z268AgendaCalendarId ;
      private Guid A268AgendaCalendarId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i29LocationId ;
      private Guid i11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000Y5_A268AgendaCalendarId ;
      private string[] BC000Y5_A269AgendaCalendarTitle ;
      private DateTime[] BC000Y5_A270AgendaCalendarStartDate ;
      private DateTime[] BC000Y5_A271AgendaCalendarEndDate ;
      private string[] BC000Y5_A441AgendaCalendarType ;
      private bool[] BC000Y5_A272AgendaCalendarAllDay ;
      private bool[] BC000Y5_A437AgendaCalendarRecurring ;
      private string[] BC000Y5_A438AgendaCalendarRecurringType ;
      private bool[] BC000Y5_A439AgendaCalendarAddRSVP ;
      private Guid[] BC000Y5_A29LocationId ;
      private Guid[] BC000Y5_A11OrganisationId ;
      private Guid[] BC000Y4_A29LocationId ;
      private Guid[] BC000Y6_A268AgendaCalendarId ;
      private Guid[] BC000Y3_A268AgendaCalendarId ;
      private string[] BC000Y3_A269AgendaCalendarTitle ;
      private DateTime[] BC000Y3_A270AgendaCalendarStartDate ;
      private DateTime[] BC000Y3_A271AgendaCalendarEndDate ;
      private string[] BC000Y3_A441AgendaCalendarType ;
      private bool[] BC000Y3_A272AgendaCalendarAllDay ;
      private bool[] BC000Y3_A437AgendaCalendarRecurring ;
      private string[] BC000Y3_A438AgendaCalendarRecurringType ;
      private bool[] BC000Y3_A439AgendaCalendarAddRSVP ;
      private Guid[] BC000Y3_A29LocationId ;
      private Guid[] BC000Y3_A11OrganisationId ;
      private Guid[] BC000Y2_A268AgendaCalendarId ;
      private string[] BC000Y2_A269AgendaCalendarTitle ;
      private DateTime[] BC000Y2_A270AgendaCalendarStartDate ;
      private DateTime[] BC000Y2_A271AgendaCalendarEndDate ;
      private string[] BC000Y2_A441AgendaCalendarType ;
      private bool[] BC000Y2_A272AgendaCalendarAllDay ;
      private bool[] BC000Y2_A437AgendaCalendarRecurring ;
      private string[] BC000Y2_A438AgendaCalendarRecurringType ;
      private bool[] BC000Y2_A439AgendaCalendarAddRSVP ;
      private Guid[] BC000Y2_A29LocationId ;
      private Guid[] BC000Y2_A11OrganisationId ;
      private Guid[] BC000Y10_A268AgendaCalendarId ;
      private Guid[] BC000Y10_A62ResidentId ;
      private Guid[] BC000Y11_A268AgendaCalendarId ;
      private string[] BC000Y11_A269AgendaCalendarTitle ;
      private DateTime[] BC000Y11_A270AgendaCalendarStartDate ;
      private DateTime[] BC000Y11_A271AgendaCalendarEndDate ;
      private string[] BC000Y11_A441AgendaCalendarType ;
      private bool[] BC000Y11_A272AgendaCalendarAllDay ;
      private bool[] BC000Y11_A437AgendaCalendarRecurring ;
      private string[] BC000Y11_A438AgendaCalendarRecurringType ;
      private bool[] BC000Y11_A439AgendaCalendarAddRSVP ;
      private Guid[] BC000Y11_A29LocationId ;
      private Guid[] BC000Y11_A11OrganisationId ;
      private SdtTrn_AgendaCalendar bcTrn_AgendaCalendar ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendacalendar_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_agendacalendar_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_agendacalendar_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000Y2;
       prmBC000Y2 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y3;
       prmBC000Y3 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y4;
       prmBC000Y4 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y5;
       prmBC000Y5 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y6;
       prmBC000Y6 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y7;
       prmBC000Y7 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y8;
       prmBC000Y8 = new Object[] {
       new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
       new ParDef("AgendaCalendarType",GXType.VarChar,40,0) ,
       new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurring",GXType.Boolean,4,0) ,
       new ParDef("AgendaCalendarRecurringType",GXType.VarChar,100,0) ,
       new ParDef("AgendaCalendarAddRSVP",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y9;
       prmBC000Y9 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y10;
       prmBC000Y10 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Y11;
       prmBC000Y11 = new Object[] {
       new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000Y2", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId  FOR UPDATE OF Trn_AgendaCalendar",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Y3", "SELECT AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Y4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Y5", "SELECT TM1.AgendaCalendarId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarType, TM1.AgendaCalendarAllDay, TM1.AgendaCalendarRecurring, TM1.AgendaCalendarRecurringType, TM1.AgendaCalendarAddRSVP, TM1.LocationId, TM1.OrganisationId FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Y6", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Y7", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaCalendar(AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, LocationId, OrganisationId) VALUES(:AgendaCalendarId, :AgendaCalendarTitle, :AgendaCalendarStartDate, :AgendaCalendarEndDate, :AgendaCalendarType, :AgendaCalendarAllDay, :AgendaCalendarRecurring, :AgendaCalendarRecurringType, :AgendaCalendarAddRSVP, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y7)
          ,new CursorDef("BC000Y8", "SAVEPOINT gxupdate;UPDATE Trn_AgendaCalendar SET AgendaCalendarTitle=:AgendaCalendarTitle, AgendaCalendarStartDate=:AgendaCalendarStartDate, AgendaCalendarEndDate=:AgendaCalendarEndDate, AgendaCalendarType=:AgendaCalendarType, AgendaCalendarAllDay=:AgendaCalendarAllDay, AgendaCalendarRecurring=:AgendaCalendarRecurring, AgendaCalendarRecurringType=:AgendaCalendarRecurringType, AgendaCalendarAddRSVP=:AgendaCalendarAddRSVP, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y8)
          ,new CursorDef("BC000Y9", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y9)
          ,new CursorDef("BC000Y10", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000Y11", "SELECT TM1.AgendaCalendarId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarType, TM1.AgendaCalendarAllDay, TM1.AgendaCalendarRecurring, TM1.AgendaCalendarRecurringType, TM1.AgendaCalendarAddRSVP, TM1.LocationId, TM1.OrganisationId FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             return;
    }
 }

}

}
