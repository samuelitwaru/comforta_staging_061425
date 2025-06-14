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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class loadaudittrn_manager : GXProcedure
   {
      public loadaudittrn_manager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittrn_manager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_ManagerId ,
                           Guid aP3_OrganisationId ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ManagerId = aP2_ManagerId;
         this.AV18OrganisationId = aP3_OrganisationId;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_ManagerId ,
                                 Guid aP3_OrganisationId ,
                                 string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ManagerId = aP2_ManagerId;
         this.AV18OrganisationId = aP3_OrganisationId;
         this.AV15ActualMode = aP4_ActualMode;
         SubmitImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007O2 */
         pr_default.execute(0, new Object[] {AV17ManagerId, AV18OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P007O2_A11OrganisationId[0];
            A21ManagerId = P007O2_A21ManagerId[0];
            A22ManagerGivenName = P007O2_A22ManagerGivenName[0];
            A23ManagerLastName = P007O2_A23ManagerLastName[0];
            A24ManagerInitials = P007O2_A24ManagerInitials[0];
            A25ManagerEmail = P007O2_A25ManagerEmail[0];
            A26ManagerPhone = P007O2_A26ManagerPhone[0];
            A357ManagerPhoneCode = P007O2_A357ManagerPhoneCode[0];
            A358ManagerPhoneNumber = P007O2_A358ManagerPhoneNumber[0];
            A27ManagerGender = P007O2_A27ManagerGender[0];
            A28ManagerGAMGUID = P007O2_A28ManagerGAMGUID[0];
            A332ManagerIsMainManager = P007O2_A332ManagerIsMainManager[0];
            A365ManagerIsActive = P007O2_A365ManagerIsActive[0];
            AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Manager";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A21ManagerId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A11OrganisationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGivenName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A22ManagerGivenName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerLastName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A23ManagerLastName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerInitials";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A24ManagerInitials;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerEmail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A25ManagerEmail;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A26ManagerPhone;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhoneCode";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A357ManagerPhoneCode;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhoneNumber";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A358ManagerPhoneNumber;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGender";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Gender", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A27ManagerGender;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGAMGUID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GAMGUID", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A28ManagerGAMGUID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerIsMainManager";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Main Manager?", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A332ManagerIsMainManager);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerIsActive";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Active", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A365ManagerIsActive);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007O3 */
         pr_default.execute(1, new Object[] {AV17ManagerId, AV18OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P007O3_A11OrganisationId[0];
            A21ManagerId = P007O3_A21ManagerId[0];
            A22ManagerGivenName = P007O3_A22ManagerGivenName[0];
            A23ManagerLastName = P007O3_A23ManagerLastName[0];
            A24ManagerInitials = P007O3_A24ManagerInitials[0];
            A25ManagerEmail = P007O3_A25ManagerEmail[0];
            A26ManagerPhone = P007O3_A26ManagerPhone[0];
            A357ManagerPhoneCode = P007O3_A357ManagerPhoneCode[0];
            A358ManagerPhoneNumber = P007O3_A358ManagerPhoneNumber[0];
            A27ManagerGender = P007O3_A27ManagerGender[0];
            A28ManagerGAMGUID = P007O3_A28ManagerGAMGUID[0];
            A332ManagerIsMainManager = P007O3_A332ManagerIsMainManager[0];
            A365ManagerIsActive = P007O3_A365ManagerIsActive[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Manager";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A21ManagerId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisations", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGivenName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A22ManagerGivenName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerLastName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A23ManagerLastName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerInitials";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A24ManagerInitials;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A25ManagerEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A26ManagerPhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A357ManagerPhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerPhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358ManagerPhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGender";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Gender", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A27ManagerGender;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerGAMGUID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GAMGUID", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A28ManagerGAMGUID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerIsMainManager";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Main Manager?", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A332ManagerIsMainManager);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ManagerIsActive";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Active", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A365ManagerIsActive);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV21GXV1 = 1;
               while ( AV21GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV21GXV1));
                  AV22GXV2 = 1;
                  while ( AV22GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV22GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A21ManagerId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "OrganisationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerGivenName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A22ManagerGivenName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerLastName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A23ManagerLastName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerInitials") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A24ManagerInitials;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerEmail") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A25ManagerEmail;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerPhone") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A26ManagerPhone;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerPhoneCode") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A357ManagerPhoneCode;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerPhoneNumber") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358ManagerPhoneNumber;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerGender") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A27ManagerGender;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerGAMGUID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A28ManagerGAMGUID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerIsMainManager") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A332ManagerIsMainManager);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ManagerIsActive") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A365ManagerIsActive);
                     }
                     AV22GXV2 = (int)(AV22GXV2+1);
                  }
                  AV21GXV1 = (int)(AV21GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P007O2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007O2_A21ManagerId = new Guid[] {Guid.Empty} ;
         P007O2_A22ManagerGivenName = new string[] {""} ;
         P007O2_A23ManagerLastName = new string[] {""} ;
         P007O2_A24ManagerInitials = new string[] {""} ;
         P007O2_A25ManagerEmail = new string[] {""} ;
         P007O2_A26ManagerPhone = new string[] {""} ;
         P007O2_A357ManagerPhoneCode = new string[] {""} ;
         P007O2_A358ManagerPhoneNumber = new string[] {""} ;
         P007O2_A27ManagerGender = new string[] {""} ;
         P007O2_A28ManagerGAMGUID = new string[] {""} ;
         P007O2_A332ManagerIsMainManager = new bool[] {false} ;
         P007O2_A365ManagerIsActive = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A24ManagerInitials = "";
         A25ManagerEmail = "";
         A26ManagerPhone = "";
         A357ManagerPhoneCode = "";
         A358ManagerPhoneNumber = "";
         A27ManagerGender = "";
         A28ManagerGAMGUID = "";
         AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007O3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007O3_A21ManagerId = new Guid[] {Guid.Empty} ;
         P007O3_A22ManagerGivenName = new string[] {""} ;
         P007O3_A23ManagerLastName = new string[] {""} ;
         P007O3_A24ManagerInitials = new string[] {""} ;
         P007O3_A25ManagerEmail = new string[] {""} ;
         P007O3_A26ManagerPhone = new string[] {""} ;
         P007O3_A357ManagerPhoneCode = new string[] {""} ;
         P007O3_A358ManagerPhoneNumber = new string[] {""} ;
         P007O3_A27ManagerGender = new string[] {""} ;
         P007O3_A28ManagerGAMGUID = new string[] {""} ;
         P007O3_A332ManagerIsMainManager = new bool[] {false} ;
         P007O3_A365ManagerIsActive = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_manager__default(),
            new Object[][] {
                new Object[] {
               P007O2_A11OrganisationId, P007O2_A21ManagerId, P007O2_A22ManagerGivenName, P007O2_A23ManagerLastName, P007O2_A24ManagerInitials, P007O2_A25ManagerEmail, P007O2_A26ManagerPhone, P007O2_A357ManagerPhoneCode, P007O2_A358ManagerPhoneNumber, P007O2_A27ManagerGender,
               P007O2_A28ManagerGAMGUID, P007O2_A332ManagerIsMainManager, P007O2_A365ManagerIsActive
               }
               , new Object[] {
               P007O3_A11OrganisationId, P007O3_A21ManagerId, P007O3_A22ManagerGivenName, P007O3_A23ManagerLastName, P007O3_A24ManagerInitials, P007O3_A25ManagerEmail, P007O3_A26ManagerPhone, P007O3_A357ManagerPhoneCode, P007O3_A358ManagerPhoneNumber, P007O3_A27ManagerGender,
               P007O3_A28ManagerGAMGUID, P007O3_A332ManagerIsMainManager, P007O3_A365ManagerIsActive
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string A24ManagerInitials ;
      private string A26ManagerPhone ;
      private bool returnInSub ;
      private bool A332ManagerIsMainManager ;
      private bool A365ManagerIsActive ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A25ManagerEmail ;
      private string A357ManagerPhoneCode ;
      private string A358ManagerPhoneNumber ;
      private string A27ManagerGender ;
      private string A28ManagerGAMGUID ;
      private Guid AV17ManagerId ;
      private Guid AV18OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV11AuditingObject ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007O2_A11OrganisationId ;
      private Guid[] P007O2_A21ManagerId ;
      private string[] P007O2_A22ManagerGivenName ;
      private string[] P007O2_A23ManagerLastName ;
      private string[] P007O2_A24ManagerInitials ;
      private string[] P007O2_A25ManagerEmail ;
      private string[] P007O2_A26ManagerPhone ;
      private string[] P007O2_A357ManagerPhoneCode ;
      private string[] P007O2_A358ManagerPhoneNumber ;
      private string[] P007O2_A27ManagerGender ;
      private string[] P007O2_A28ManagerGAMGUID ;
      private bool[] P007O2_A332ManagerIsMainManager ;
      private bool[] P007O2_A365ManagerIsActive ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P007O3_A11OrganisationId ;
      private Guid[] P007O3_A21ManagerId ;
      private string[] P007O3_A22ManagerGivenName ;
      private string[] P007O3_A23ManagerLastName ;
      private string[] P007O3_A24ManagerInitials ;
      private string[] P007O3_A25ManagerEmail ;
      private string[] P007O3_A26ManagerPhone ;
      private string[] P007O3_A357ManagerPhoneCode ;
      private string[] P007O3_A358ManagerPhoneNumber ;
      private string[] P007O3_A27ManagerGender ;
      private string[] P007O3_A28ManagerGAMGUID ;
      private bool[] P007O3_A332ManagerIsMainManager ;
      private bool[] P007O3_A365ManagerIsActive ;
   }

   public class loadaudittrn_manager__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007O2;
          prmP007O2 = new Object[] {
          new ParDef("AV17ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007O3;
          prmP007O3 = new Object[] {
          new ParDef("AV17ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007O2", "SELECT OrganisationId, ManagerId, ManagerGivenName, ManagerLastName, ManagerInitials, ManagerEmail, ManagerPhone, ManagerPhoneCode, ManagerPhoneNumber, ManagerGender, ManagerGAMGUID, ManagerIsMainManager, ManagerIsActive FROM Trn_Manager WHERE ManagerId = :AV17ManagerId and OrganisationId = :AV18OrganisationId ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007O3", "SELECT OrganisationId, ManagerId, ManagerGivenName, ManagerLastName, ManagerInitials, ManagerEmail, ManagerPhone, ManagerPhoneCode, ManagerPhoneNumber, ManagerGender, ManagerGAMGUID, ManagerIsMainManager, ManagerIsActive FROM Trn_Manager WHERE ManagerId = :AV17ManagerId and OrganisationId = :AV18OrganisationId ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O3,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
       }
    }

 }

}
