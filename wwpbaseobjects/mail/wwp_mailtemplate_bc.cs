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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mailtemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate_bc( IGxContext context )
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
         ReadRow0P35( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0P35( ) ;
         standaloneModal( ) ;
         AddRow0P35( ) ;
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
            E110P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z193WWPMailTemplateName = A193WWPMailTemplateName;
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P35( ) ;
            }
            else
            {
               CheckExtendedTable0P35( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0P35( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120P2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0P35( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z194WWPMailTemplateDescription = A194WWPMailTemplateDescription;
            Z195WWPMailTemplateSubject = A195WWPMailTemplateSubject;
         }
         if ( GX_JID == -1 )
         {
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
            Z194WWPMailTemplateDescription = A194WWPMailTemplateDescription;
            Z195WWPMailTemplateSubject = A195WWPMailTemplateSubject;
            Z178WWPMailTemplateBody = A178WWPMailTemplateBody;
            Z179WWPMailTemplateSenderAddress = A179WWPMailTemplateSenderAddress;
            Z180WWPMailTemplateSenderName = A180WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0P35( )
      {
         /* Using cursor BC000P4 */
         pr_default.execute(2, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound35 = 1;
            A194WWPMailTemplateDescription = BC000P4_A194WWPMailTemplateDescription[0];
            A195WWPMailTemplateSubject = BC000P4_A195WWPMailTemplateSubject[0];
            A178WWPMailTemplateBody = BC000P4_A178WWPMailTemplateBody[0];
            A179WWPMailTemplateSenderAddress = BC000P4_A179WWPMailTemplateSenderAddress[0];
            A180WWPMailTemplateSenderName = BC000P4_A180WWPMailTemplateSenderName[0];
            ZM0P35( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0P35( ) ;
      }

      protected void OnLoadActions0P35( )
      {
      }

      protected void CheckExtendedTable0P35( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0P35( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0P35( )
      {
         /* Using cursor BC000P5 */
         pr_default.execute(3, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000P3 */
         pr_default.execute(1, new Object[] {A193WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P35( 1) ;
            RcdFound35 = 1;
            A193WWPMailTemplateName = BC000P3_A193WWPMailTemplateName[0];
            A194WWPMailTemplateDescription = BC000P3_A194WWPMailTemplateDescription[0];
            A195WWPMailTemplateSubject = BC000P3_A195WWPMailTemplateSubject[0];
            A178WWPMailTemplateBody = BC000P3_A178WWPMailTemplateBody[0];
            A179WWPMailTemplateSenderAddress = BC000P3_A179WWPMailTemplateSenderAddress[0];
            A180WWPMailTemplateSenderName = BC000P3_A180WWPMailTemplateSenderName[0];
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0P35( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey0P35( ) ;
            }
            Gx_mode = sMode35;
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0P35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode35;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P35( ) ;
         if ( RcdFound35 == 0 )
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
         CONFIRM_0P0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0P35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000P2 */
            pr_default.execute(0, new Object[] {A193WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z194WWPMailTemplateDescription, BC000P2_A194WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z195WWPMailTemplateSubject, BC000P2_A195WWPMailTemplateSubject[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P35( )
      {
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P35( 0) ;
            CheckOptimisticConcurrency0P35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000P6 */
                     pr_default.execute(4, new Object[] {A193WWPMailTemplateName, A194WWPMailTemplateDescription, A195WWPMailTemplateSubject, A178WWPMailTemplateBody, A179WWPMailTemplateSenderAddress, A180WWPMailTemplateSenderName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load0P35( ) ;
            }
            EndLevel0P35( ) ;
         }
         CloseExtendedTableCursors0P35( ) ;
      }

      protected void Update0P35( )
      {
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000P7 */
                     pr_default.execute(5, new Object[] {A194WWPMailTemplateDescription, A195WWPMailTemplateSubject, A178WWPMailTemplateBody, A179WWPMailTemplateSenderAddress, A180WWPMailTemplateSenderName, A193WWPMailTemplateName});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P35( ) ;
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
            EndLevel0P35( ) ;
         }
         CloseExtendedTableCursors0P35( ) ;
      }

      protected void DeferredUpdate0P35( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0P35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P35( ) ;
            AfterConfirm0P35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000P8 */
                  pr_default.execute(6, new Object[] {A193WWPMailTemplateName});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0P35( ) ;
         Gx_mode = sMode35;
      }

      protected void OnDeleteControls0P35( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0P35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P35( ) ;
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

      public void ScanKeyStart0P35( )
      {
         /* Using cursor BC000P9 */
         pr_default.execute(7, new Object[] {A193WWPMailTemplateName});
         RcdFound35 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound35 = 1;
            A193WWPMailTemplateName = BC000P9_A193WWPMailTemplateName[0];
            A194WWPMailTemplateDescription = BC000P9_A194WWPMailTemplateDescription[0];
            A195WWPMailTemplateSubject = BC000P9_A195WWPMailTemplateSubject[0];
            A178WWPMailTemplateBody = BC000P9_A178WWPMailTemplateBody[0];
            A179WWPMailTemplateSenderAddress = BC000P9_A179WWPMailTemplateSenderAddress[0];
            A180WWPMailTemplateSenderName = BC000P9_A180WWPMailTemplateSenderName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0P35( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound35 = 0;
         ScanKeyLoad0P35( ) ;
      }

      protected void ScanKeyLoad0P35( )
      {
         sMode35 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound35 = 1;
            A193WWPMailTemplateName = BC000P9_A193WWPMailTemplateName[0];
            A194WWPMailTemplateDescription = BC000P9_A194WWPMailTemplateDescription[0];
            A195WWPMailTemplateSubject = BC000P9_A195WWPMailTemplateSubject[0];
            A178WWPMailTemplateBody = BC000P9_A178WWPMailTemplateBody[0];
            A179WWPMailTemplateSenderAddress = BC000P9_A179WWPMailTemplateSenderAddress[0];
            A180WWPMailTemplateSenderName = BC000P9_A180WWPMailTemplateSenderName[0];
         }
         Gx_mode = sMode35;
      }

      protected void ScanKeyEnd0P35( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0P35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P35( )
      {
      }

      protected void send_integrity_lvl_hashes0P35( )
      {
      }

      protected void AddRow0P35( )
      {
         VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
      }

      protected void ReadRow0P35( )
      {
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
      }

      protected void InitializeNonKey0P35( )
      {
         A194WWPMailTemplateDescription = "";
         A195WWPMailTemplateSubject = "";
         A178WWPMailTemplateBody = "";
         A179WWPMailTemplateSenderAddress = "";
         A180WWPMailTemplateSenderName = "";
         Z194WWPMailTemplateDescription = "";
         Z195WWPMailTemplateSubject = "";
      }

      protected void InitAll0P35( )
      {
         A193WWPMailTemplateName = "";
         InitializeNonKey0P35( ) ;
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

      public void VarsToRow35( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj35 )
      {
         obj35.gxTpr_Mode = Gx_mode;
         obj35.gxTpr_Wwpmailtemplatedescription = A194WWPMailTemplateDescription;
         obj35.gxTpr_Wwpmailtemplatesubject = A195WWPMailTemplateSubject;
         obj35.gxTpr_Wwpmailtemplatebody = A178WWPMailTemplateBody;
         obj35.gxTpr_Wwpmailtemplatesenderaddress = A179WWPMailTemplateSenderAddress;
         obj35.gxTpr_Wwpmailtemplatesendername = A180WWPMailTemplateSenderName;
         obj35.gxTpr_Wwpmailtemplatename = A193WWPMailTemplateName;
         obj35.gxTpr_Wwpmailtemplatename_Z = Z193WWPMailTemplateName;
         obj35.gxTpr_Wwpmailtemplatedescription_Z = Z194WWPMailTemplateDescription;
         obj35.gxTpr_Wwpmailtemplatesubject_Z = Z195WWPMailTemplateSubject;
         obj35.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow35( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj35 )
      {
         obj35.gxTpr_Wwpmailtemplatename = A193WWPMailTemplateName;
         return  ;
      }

      public void RowToVars35( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj35 ,
                               int forceLoad )
      {
         Gx_mode = obj35.gxTpr_Mode;
         A194WWPMailTemplateDescription = obj35.gxTpr_Wwpmailtemplatedescription;
         A195WWPMailTemplateSubject = obj35.gxTpr_Wwpmailtemplatesubject;
         A178WWPMailTemplateBody = obj35.gxTpr_Wwpmailtemplatebody;
         A179WWPMailTemplateSenderAddress = obj35.gxTpr_Wwpmailtemplatesenderaddress;
         A180WWPMailTemplateSenderName = obj35.gxTpr_Wwpmailtemplatesendername;
         A193WWPMailTemplateName = obj35.gxTpr_Wwpmailtemplatename;
         Z193WWPMailTemplateName = obj35.gxTpr_Wwpmailtemplatename_Z;
         Z194WWPMailTemplateDescription = obj35.gxTpr_Wwpmailtemplatedescription_Z;
         Z195WWPMailTemplateSubject = obj35.gxTpr_Wwpmailtemplatesubject_Z;
         Gx_mode = obj35.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A193WWPMailTemplateName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0P35( ) ;
         ScanKeyStart0P35( ) ;
         if ( RcdFound35 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
         }
         ZM0P35( -1) ;
         OnLoadActions0P35( ) ;
         AddRow0P35( ) ;
         ScanKeyEnd0P35( ) ;
         if ( RcdFound35 == 0 )
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
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         ScanKeyStart0P35( ) ;
         if ( RcdFound35 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z193WWPMailTemplateName = A193WWPMailTemplateName;
         }
         ZM0P35( -1) ;
         OnLoadActions0P35( ) ;
         AddRow0P35( ) ;
         ScanKeyEnd0P35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0P35( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0P35( ) ;
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
               {
                  A193WWPMailTemplateName = Z193WWPMailTemplateName;
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
                  Update0P35( ) ;
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
                  if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
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
                        Insert0P35( ) ;
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
                        Insert0P35( ) ;
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
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0P35( ) ;
         AfterTrn( ) ;
         VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A193WWPMailTemplateName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_MailTemplate);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_MailTemplate.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
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
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0P35( ) ;
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
               VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         GetKey0P35( ) ;
         if ( RcdFound35 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
            {
               A193WWPMailTemplateName = Z193WWPMailTemplateName;
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
            if ( StringUtil.StrCmp(A193WWPMailTemplateName, Z193WWPMailTemplateName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate_bc",pr_default);
         VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_MailTemplate )
         {
            bcwwpbaseobjects_mail_WWP_MailTemplate = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow35( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
            else
            {
               RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars35( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_MailTemplate WWP_MailTemplate_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_MailTemplate ;
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
            return "wwpmailtemplate_Execute" ;
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
         Z193WWPMailTemplateName = "";
         A193WWPMailTemplateName = "";
         Z194WWPMailTemplateDescription = "";
         A194WWPMailTemplateDescription = "";
         Z195WWPMailTemplateSubject = "";
         A195WWPMailTemplateSubject = "";
         Z178WWPMailTemplateBody = "";
         A178WWPMailTemplateBody = "";
         Z179WWPMailTemplateSenderAddress = "";
         A179WWPMailTemplateSenderAddress = "";
         Z180WWPMailTemplateSenderName = "";
         A180WWPMailTemplateSenderName = "";
         BC000P4_A193WWPMailTemplateName = new string[] {""} ;
         BC000P4_A194WWPMailTemplateDescription = new string[] {""} ;
         BC000P4_A195WWPMailTemplateSubject = new string[] {""} ;
         BC000P4_A178WWPMailTemplateBody = new string[] {""} ;
         BC000P4_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000P4_A180WWPMailTemplateSenderName = new string[] {""} ;
         BC000P5_A193WWPMailTemplateName = new string[] {""} ;
         BC000P3_A193WWPMailTemplateName = new string[] {""} ;
         BC000P3_A194WWPMailTemplateDescription = new string[] {""} ;
         BC000P3_A195WWPMailTemplateSubject = new string[] {""} ;
         BC000P3_A178WWPMailTemplateBody = new string[] {""} ;
         BC000P3_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000P3_A180WWPMailTemplateSenderName = new string[] {""} ;
         sMode35 = "";
         BC000P2_A193WWPMailTemplateName = new string[] {""} ;
         BC000P2_A194WWPMailTemplateDescription = new string[] {""} ;
         BC000P2_A195WWPMailTemplateSubject = new string[] {""} ;
         BC000P2_A178WWPMailTemplateBody = new string[] {""} ;
         BC000P2_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000P2_A180WWPMailTemplateSenderName = new string[] {""} ;
         BC000P9_A193WWPMailTemplateName = new string[] {""} ;
         BC000P9_A194WWPMailTemplateDescription = new string[] {""} ;
         BC000P9_A195WWPMailTemplateSubject = new string[] {""} ;
         BC000P9_A178WWPMailTemplateBody = new string[] {""} ;
         BC000P9_A179WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000P9_A180WWPMailTemplateSenderName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000P2_A193WWPMailTemplateName, BC000P2_A194WWPMailTemplateDescription, BC000P2_A195WWPMailTemplateSubject, BC000P2_A178WWPMailTemplateBody, BC000P2_A179WWPMailTemplateSenderAddress, BC000P2_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000P3_A193WWPMailTemplateName, BC000P3_A194WWPMailTemplateDescription, BC000P3_A195WWPMailTemplateSubject, BC000P3_A178WWPMailTemplateBody, BC000P3_A179WWPMailTemplateSenderAddress, BC000P3_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000P4_A193WWPMailTemplateName, BC000P4_A194WWPMailTemplateDescription, BC000P4_A195WWPMailTemplateSubject, BC000P4_A178WWPMailTemplateBody, BC000P4_A179WWPMailTemplateSenderAddress, BC000P4_A180WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000P5_A193WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000P9_A193WWPMailTemplateName, BC000P9_A194WWPMailTemplateDescription, BC000P9_A195WWPMailTemplateSubject, BC000P9_A178WWPMailTemplateBody, BC000P9_A179WWPMailTemplateSenderAddress, BC000P9_A180WWPMailTemplateSenderName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120P2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound35 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode35 ;
      private bool returnInSub ;
      private string Z178WWPMailTemplateBody ;
      private string A178WWPMailTemplateBody ;
      private string Z179WWPMailTemplateSenderAddress ;
      private string A179WWPMailTemplateSenderAddress ;
      private string Z180WWPMailTemplateSenderName ;
      private string A180WWPMailTemplateSenderName ;
      private string Z193WWPMailTemplateName ;
      private string A193WWPMailTemplateName ;
      private string Z194WWPMailTemplateDescription ;
      private string A194WWPMailTemplateDescription ;
      private string Z195WWPMailTemplateSubject ;
      private string A195WWPMailTemplateSubject ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000P4_A193WWPMailTemplateName ;
      private string[] BC000P4_A194WWPMailTemplateDescription ;
      private string[] BC000P4_A195WWPMailTemplateSubject ;
      private string[] BC000P4_A178WWPMailTemplateBody ;
      private string[] BC000P4_A179WWPMailTemplateSenderAddress ;
      private string[] BC000P4_A180WWPMailTemplateSenderName ;
      private string[] BC000P5_A193WWPMailTemplateName ;
      private string[] BC000P3_A193WWPMailTemplateName ;
      private string[] BC000P3_A194WWPMailTemplateDescription ;
      private string[] BC000P3_A195WWPMailTemplateSubject ;
      private string[] BC000P3_A178WWPMailTemplateBody ;
      private string[] BC000P3_A179WWPMailTemplateSenderAddress ;
      private string[] BC000P3_A180WWPMailTemplateSenderName ;
      private string[] BC000P2_A193WWPMailTemplateName ;
      private string[] BC000P2_A194WWPMailTemplateDescription ;
      private string[] BC000P2_A195WWPMailTemplateSubject ;
      private string[] BC000P2_A178WWPMailTemplateBody ;
      private string[] BC000P2_A179WWPMailTemplateSenderAddress ;
      private string[] BC000P2_A180WWPMailTemplateSenderName ;
      private string[] BC000P9_A193WWPMailTemplateName ;
      private string[] BC000P9_A194WWPMailTemplateDescription ;
      private string[] BC000P9_A195WWPMailTemplateSubject ;
      private string[] BC000P9_A178WWPMailTemplateBody ;
      private string[] BC000P9_A179WWPMailTemplateSenderAddress ;
      private string[] BC000P9_A180WWPMailTemplateSenderName ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate bcwwpbaseobjects_mail_WWP_MailTemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mailtemplate_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_mailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000P2;
       prmBC000P2 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P3;
       prmBC000P3 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P4;
       prmBC000P4 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P5;
       prmBC000P5 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P6;
       prmBC000P6 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0) ,
       new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
       new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC000P7;
       prmBC000P7 = new Object[] {
       new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
       new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P8;
       prmBC000P8 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       Object[] prmBC000P9;
       prmBC000P9 = new Object[] {
       new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000P2", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName  FOR UPDATE OF WWP_MailTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000P3", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000P4", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000P5", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000P6", "SAVEPOINT gxupdate;INSERT INTO WWP_MailTemplate(WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName) VALUES(:WWPMailTemplateName, :WWPMailTemplateDescription, :WWPMailTemplateSubject, :WWPMailTemplateBody, :WWPMailTemplateSenderAddress, :WWPMailTemplateSenderName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000P6)
          ,new CursorDef("BC000P7", "SAVEPOINT gxupdate;UPDATE WWP_MailTemplate SET WWPMailTemplateDescription=:WWPMailTemplateDescription, WWPMailTemplateSubject=:WWPMailTemplateSubject, WWPMailTemplateBody=:WWPMailTemplateBody, WWPMailTemplateSenderAddress=:WWPMailTemplateSenderAddress, WWPMailTemplateSenderName=:WWPMailTemplateSenderName  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000P7)
          ,new CursorDef("BC000P8", "SAVEPOINT gxupdate;DELETE FROM WWP_MailTemplate  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000P8)
          ,new CursorDef("BC000P9", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P9,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             return;
    }
 }

}

}
