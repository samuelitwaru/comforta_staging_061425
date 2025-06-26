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
   public class loadaudittrn_receptionist : GXProcedure
   {
      public loadaudittrn_receptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittrn_receptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_ReceptionistId ,
                           Guid aP3_OrganisationId ,
                           Guid aP4_LocationId ,
                           string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ReceptionistId = aP2_ReceptionistId;
         this.AV18OrganisationId = aP3_OrganisationId;
         this.AV19LocationId = aP4_LocationId;
         this.AV15ActualMode = aP5_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_ReceptionistId ,
                                 Guid aP3_OrganisationId ,
                                 Guid aP4_LocationId ,
                                 string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ReceptionistId = aP2_ReceptionistId;
         this.AV18OrganisationId = aP3_OrganisationId;
         this.AV19LocationId = aP4_LocationId;
         this.AV15ActualMode = aP5_ActualMode;
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
         /* Using cursor P007T2 */
         pr_default.execute(0, new Object[] {AV17ReceptionistId, AV18OrganisationId, AV19LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P007T2_A29LocationId[0];
            A11OrganisationId = P007T2_A11OrganisationId[0];
            A89ReceptionistId = P007T2_A89ReceptionistId[0];
            A90ReceptionistGivenName = P007T2_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = P007T2_A91ReceptionistLastName[0];
            A92ReceptionistInitials = P007T2_A92ReceptionistInitials[0];
            A93ReceptionistEmail = P007T2_A93ReceptionistEmail[0];
            A345ReceptionistPhoneCode = P007T2_A345ReceptionistPhoneCode[0];
            A94ReceptionistPhone = P007T2_A94ReceptionistPhone[0];
            A346ReceptionistPhoneNumber = P007T2_A346ReceptionistPhoneNumber[0];
            A95ReceptionistGAMGUID = P007T2_A95ReceptionistGAMGUID[0];
            A369ReceptionistIsActive = P007T2_A369ReceptionistIsActive[0];
            AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Receptionist";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A89ReceptionistId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisation Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A11OrganisationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A29LocationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistGivenName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A90ReceptionistGivenName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistLastName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A91ReceptionistLastName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistInitials";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A92ReceptionistInitials;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistEmail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A93ReceptionistEmail;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhoneCode";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A345ReceptionistPhoneCode;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A94ReceptionistPhone;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhoneNumber";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A346ReceptionistPhoneNumber;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistGAMGUID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GAMGUID", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A95ReceptionistGAMGUID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistIsActive";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Active", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A369ReceptionistIsActive);
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
         /* Using cursor P007T3 */
         pr_default.execute(1, new Object[] {AV17ReceptionistId, AV18OrganisationId, AV19LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P007T3_A29LocationId[0];
            A11OrganisationId = P007T3_A11OrganisationId[0];
            A89ReceptionistId = P007T3_A89ReceptionistId[0];
            A90ReceptionistGivenName = P007T3_A90ReceptionistGivenName[0];
            A91ReceptionistLastName = P007T3_A91ReceptionistLastName[0];
            A92ReceptionistInitials = P007T3_A92ReceptionistInitials[0];
            A93ReceptionistEmail = P007T3_A93ReceptionistEmail[0];
            A345ReceptionistPhoneCode = P007T3_A345ReceptionistPhoneCode[0];
            A94ReceptionistPhone = P007T3_A94ReceptionistPhone[0];
            A346ReceptionistPhoneNumber = P007T3_A346ReceptionistPhoneNumber[0];
            A95ReceptionistGAMGUID = P007T3_A95ReceptionistGAMGUID[0];
            A369ReceptionistIsActive = P007T3_A369ReceptionistIsActive[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Receptionist";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A89ReceptionistId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisation Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistGivenName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "First Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A90ReceptionistGivenName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistLastName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Last Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A91ReceptionistLastName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistInitials";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Initials", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A92ReceptionistInitials;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Email", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A93ReceptionistEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhoneCode";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345ReceptionistPhoneCode;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A94ReceptionistPhone;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistPhoneNumber";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Phone Number", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A346ReceptionistPhoneNumber;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistGAMGUID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GAMGUID", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A95ReceptionistGAMGUID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ReceptionistIsActive";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Active", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A369ReceptionistIsActive);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22GXV1 = 1;
               while ( AV22GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV22GXV1));
                  AV23GXV2 = 1;
                  while ( AV23GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV23GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A89ReceptionistId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "OrganisationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LocationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistGivenName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A90ReceptionistGivenName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistLastName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A91ReceptionistLastName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistInitials") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A92ReceptionistInitials;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistEmail") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A93ReceptionistEmail;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistPhoneCode") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345ReceptionistPhoneCode;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistPhone") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A94ReceptionistPhone;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistPhoneNumber") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A346ReceptionistPhoneNumber;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistGAMGUID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A95ReceptionistGAMGUID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ReceptionistIsActive") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A369ReceptionistIsActive);
                     }
                     AV23GXV2 = (int)(AV23GXV2+1);
                  }
                  AV22GXV1 = (int)(AV22GXV1+1);
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
         P007T2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007T2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P007T2_A90ReceptionistGivenName = new string[] {""} ;
         P007T2_A91ReceptionistLastName = new string[] {""} ;
         P007T2_A92ReceptionistInitials = new string[] {""} ;
         P007T2_A93ReceptionistEmail = new string[] {""} ;
         P007T2_A345ReceptionistPhoneCode = new string[] {""} ;
         P007T2_A94ReceptionistPhone = new string[] {""} ;
         P007T2_A346ReceptionistPhoneNumber = new string[] {""} ;
         P007T2_A95ReceptionistGAMGUID = new string[] {""} ;
         P007T2_A369ReceptionistIsActive = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A92ReceptionistInitials = "";
         A93ReceptionistEmail = "";
         A345ReceptionistPhoneCode = "";
         A94ReceptionistPhone = "";
         A346ReceptionistPhoneNumber = "";
         A95ReceptionistGAMGUID = "";
         AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007T3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007T3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007T3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P007T3_A90ReceptionistGivenName = new string[] {""} ;
         P007T3_A91ReceptionistLastName = new string[] {""} ;
         P007T3_A92ReceptionistInitials = new string[] {""} ;
         P007T3_A93ReceptionistEmail = new string[] {""} ;
         P007T3_A345ReceptionistPhoneCode = new string[] {""} ;
         P007T3_A94ReceptionistPhone = new string[] {""} ;
         P007T3_A346ReceptionistPhoneNumber = new string[] {""} ;
         P007T3_A95ReceptionistGAMGUID = new string[] {""} ;
         P007T3_A369ReceptionistIsActive = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_receptionist__default(),
            new Object[][] {
                new Object[] {
               P007T2_A29LocationId, P007T2_A11OrganisationId, P007T2_A89ReceptionistId, P007T2_A90ReceptionistGivenName, P007T2_A91ReceptionistLastName, P007T2_A92ReceptionistInitials, P007T2_A93ReceptionistEmail, P007T2_A345ReceptionistPhoneCode, P007T2_A94ReceptionistPhone, P007T2_A346ReceptionistPhoneNumber,
               P007T2_A95ReceptionistGAMGUID, P007T2_A369ReceptionistIsActive
               }
               , new Object[] {
               P007T3_A29LocationId, P007T3_A11OrganisationId, P007T3_A89ReceptionistId, P007T3_A90ReceptionistGivenName, P007T3_A91ReceptionistLastName, P007T3_A92ReceptionistInitials, P007T3_A93ReceptionistEmail, P007T3_A345ReceptionistPhoneCode, P007T3_A94ReceptionistPhone, P007T3_A346ReceptionistPhoneNumber,
               P007T3_A95ReceptionistGAMGUID, P007T3_A369ReceptionistIsActive
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string A92ReceptionistInitials ;
      private string A94ReceptionistPhone ;
      private bool returnInSub ;
      private bool A369ReceptionistIsActive ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string A345ReceptionistPhoneCode ;
      private string A346ReceptionistPhoneNumber ;
      private string A95ReceptionistGAMGUID ;
      private Guid AV17ReceptionistId ;
      private Guid AV18OrganisationId ;
      private Guid AV19LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV11AuditingObject ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007T2_A29LocationId ;
      private Guid[] P007T2_A11OrganisationId ;
      private Guid[] P007T2_A89ReceptionistId ;
      private string[] P007T2_A90ReceptionistGivenName ;
      private string[] P007T2_A91ReceptionistLastName ;
      private string[] P007T2_A92ReceptionistInitials ;
      private string[] P007T2_A93ReceptionistEmail ;
      private string[] P007T2_A345ReceptionistPhoneCode ;
      private string[] P007T2_A94ReceptionistPhone ;
      private string[] P007T2_A346ReceptionistPhoneNumber ;
      private string[] P007T2_A95ReceptionistGAMGUID ;
      private bool[] P007T2_A369ReceptionistIsActive ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P007T3_A29LocationId ;
      private Guid[] P007T3_A11OrganisationId ;
      private Guid[] P007T3_A89ReceptionistId ;
      private string[] P007T3_A90ReceptionistGivenName ;
      private string[] P007T3_A91ReceptionistLastName ;
      private string[] P007T3_A92ReceptionistInitials ;
      private string[] P007T3_A93ReceptionistEmail ;
      private string[] P007T3_A345ReceptionistPhoneCode ;
      private string[] P007T3_A94ReceptionistPhone ;
      private string[] P007T3_A346ReceptionistPhoneNumber ;
      private string[] P007T3_A95ReceptionistGAMGUID ;
      private bool[] P007T3_A369ReceptionistIsActive ;
   }

   public class loadaudittrn_receptionist__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007T2;
          prmP007T2 = new Object[] {
          new ParDef("AV17ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007T3;
          prmP007T3 = new Object[] {
          new ParDef("AV17ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007T2", "SELECT LocationId, OrganisationId, ReceptionistId, ReceptionistGivenName, ReceptionistLastName, ReceptionistInitials, ReceptionistEmail, ReceptionistPhoneCode, ReceptionistPhone, ReceptionistPhoneNumber, ReceptionistGAMGUID, ReceptionistIsActive FROM Trn_Receptionist WHERE ReceptionistId = :AV17ReceptionistId and OrganisationId = :AV18OrganisationId and LocationId = :AV19LocationId ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007T3", "SELECT LocationId, OrganisationId, ReceptionistId, ReceptionistGivenName, ReceptionistLastName, ReceptionistInitials, ReceptionistEmail, ReceptionistPhoneCode, ReceptionistPhone, ReceptionistPhoneNumber, ReceptionistGAMGUID, ReceptionistIsActive FROM Trn_Receptionist WHERE ReceptionistId = :AV17ReceptionistId and OrganisationId = :AV18OrganisationId and LocationId = :AV19LocationId ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T3,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                return;
       }
    }

 }

}
